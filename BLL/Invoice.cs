using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Invoice
    {
        public short Branch { get; set; }
        public string VouLoc { get; set; }
        public int VouNo { get; set; }
        public System.Nullable<short> VouType { get; set; }
        public string RDate { get; set; }
        public string HDate { get; set; }
        public string GDate { get; set; }
        public string Name { get; set; }
        public string IDNo { get; set; }
        public System.Nullable<short> IDType { get; set; }
        public string IDFrom { get; set; }
        public string IDDate { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string PlaceofLoading { get; set; }
        public string Destination { get; set; }
        public System.Nullable<double> Amount { get; set; }
        public System.Nullable<double> Amount2 { get; set; }
        public string RecName { get; set; }
        public string RecAddress { get; set; }
        public string RecMobileNo { get; set; }
        public string CarType { get; set; }
        public string Brand { get; set; }
        public string PlateNo { get; set; }
        public string ChassisNo { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public System.Nullable<double> CashAmount { get; set; }
        public System.Nullable<double> ShAmount { get; set; }
        public System.Nullable<int> RecVouNo { get; set; }
        public string RecVouDate { get; set; }
        public string Site { get; set; }
        public System.Nullable<double> SiteAmount { get; set; }
        public string Customer { get; set; }
        public System.Nullable<double> CustomerAmount { get; set; }
        public System.Nullable<bool> S1 { get; set; }
        public System.Nullable<bool> S2 { get; set; }
        public System.Nullable<bool> S3 { get; set; }
        public System.Nullable<bool> S4 { get; set; }
        public System.Nullable<bool> S5 { get; set; }
        public System.Nullable<bool> S6 { get; set; }
        public System.Nullable<bool> S7 { get; set; }
        public System.Nullable<bool> S8 { get; set; }
        public System.Nullable<bool> S9 { get; set; }
        public System.Nullable<bool> S10 { get; set; }
        public System.Nullable<bool> S11 { get; set; }
        public System.Nullable<bool> S12 { get; set; }
        public System.Nullable<bool> S13 { get; set; }
        public System.Nullable<bool> S14 { get; set; }
        public System.Nullable<bool> S15 { get; set; }
        public System.Nullable<bool> S16 { get; set; }
        public System.Nullable<bool> S17 { get; set; }
        public System.Nullable<bool> S18 { get; set; }
        public System.Nullable<bool> S19 { get; set; }
        public System.Nullable<bool> S20 { get; set; }
        public System.Nullable<bool> S21 { get; set; }
        public System.Nullable<bool> S22 { get; set; }
        public System.Nullable<bool> S23 { get; set; }
        public System.Nullable<bool> S24 { get; set; }
        public System.Nullable<bool> S25 { get; set; }
        public System.Nullable<bool> S26 { get; set; }
        public System.Nullable<bool> S27 { get; set; }
        public System.Nullable<bool> S28 { get; set; }
        public System.Nullable<bool> S29 { get; set; }
        public System.Nullable<bool> S30 { get; set; }
        public System.Nullable<bool> S31 { get; set; }
        public System.Nullable<bool> S32 { get; set; }
        public System.Nullable<bool> S33 { get; set; }
        public System.Nullable<bool> S34 { get; set; }
        public System.Nullable<bool> S35 { get; set; }
        public System.Nullable<bool> S36 { get; set; }
        public System.Nullable<bool> S37 { get; set; }
        public System.Nullable<bool> S38 { get; set; }
        public System.Nullable<bool> Access1 { get; set; }
        public System.Nullable<bool> Access2 { get; set; }
        public System.Nullable<bool> Access3 { get; set; }
        public System.Nullable<bool> Access4 { get; set; }
        public System.Nullable<bool> Access5 { get; set; }
        public System.Nullable<bool> Access6 { get; set; }
        public System.Nullable<bool> Access7 { get; set; }
        public System.Nullable<bool> Access8 { get; set; }
        public System.Nullable<bool> Access9 { get; set; }
        public System.Nullable<bool> Access10 { get; set; }
        public System.Nullable<bool> Access11 { get; set; }
        public System.Nullable<bool> Access12 { get; set; }
        public System.Nullable<bool> Access13 { get; set; }
        public System.Nullable<bool> Access14 { get; set; }
        public System.Nullable<bool> Access15 { get; set; }
        public System.Nullable<bool> Access16 { get; set; }
        public System.Nullable<bool> Access17 { get; set; }
        public System.Nullable<bool> Access18 { get; set; }
        public string sAccess1 { get; set; }
        public string sAccess2 { get; set; }
        public string sAccess3 { get; set; }
        public string sAccess4 { get; set; }
        public string sAccess5 { get; set; }
        public string sAccess6 { get; set; }
        public string sAccess7 { get; set; }
        public string sAccess8 { get; set; }
        public string sAccess9 { get; set; }
        public string sAccess10 { get; set; }
        public string sAccess11 { get; set; }
        public string sAccess12 { get; set; }
        public string sAccess13 { get; set; }
        public string sAccess14 { get; set; }
        public string sAccess15 { get; set; }
        public string sAccess16 { get; set; }
        public string sAccess17 { get; set; }
        public string sAccess18 { get; set; }
        public string Remark1 { get; set; }
        public string Remark2 { get; set; }
        public string Attached { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public System.Nullable<short> Qty { get; set; }
        public System.Nullable<short> Qty2 { get; set; }
        public string RcvNo { get; set; }
        public string VouNo2 { get; set; }
        public string FTime { get; set; }
        public string OVouNo { get; set; }
        public System.Nullable<Boolean> ReturnInv { get; set; }
        public System.Nullable<short> Payment { get; set; }
        public System.Nullable<short> DPeriod { get; set; }
        public bool? PlaceFrom {get; set;}
        public bool? PlaceTo {get; set;}
        public string SLat { get; set; }
        public string SLng { get; set; }
        public string RLat { get; set; }
        public string RLng { get; set; }
        public System.Nullable<short> Status { get; set; }
        public System.Nullable<double> Tax { get; set; }
        public System.Nullable<double> Discount { get; set; }
        public string DiscountTerm { get; set; }
        public System.Nullable<short> ShipType2 { get; set; }
        public string VouLoc2 { get; set; }
        public string Mail { get; set; }
        public string IDdriver { get; set; }
        public string RecMail { get; set; }
        public short? CardType { get; set; }
        public short? PayType { get; set; }
        public string CardNo { get; set; }
        public string CardHolder { get; set; }
        public string Expiry { get; set; }
        public string ServiceCode { get; set; }
        public short? Rate { get; set; }
        public short? CustRate { get; set; }
        public int? CancelReason { get; set; }
        public string DeliveredDate { get; set; }
        public string ArrivingTime { get; set; }
        public string RateNote { get; set; }
        public System.Nullable<int> RateReason { get; set; }
        public string OrDateTime { get; set; }
        public string IDDriver2 { get; set; }
        public short? Rate2 { get; set; }
        public int? OrderIssue { get; set; }
        public int? OrderIssue2 { get; set; }
        public string DriverNote { get; set; }
        public string DriverNote2 { get; set; }
        public double? Reward1 { get; set; }
        public double? Reward2 { get; set; }
        public double? Penal1 { get; set; }
        public double? Penal2 { get; set; }
        public double? Earn1 { get; set; }
        public double? Earn2 { get; set; }
        public string CNN { get; set; }
        public string FromName
        {
            get
            {
                return "";
                string Name = "out side of saudi arabia";
                if (!string.IsNullOrEmpty(this.SLat) && !string.IsNullOrEmpty(this.SLng))
                {
                    Name = moh.GetCity(this.SLat, this.SLng);
                }
                Cities myCity = new Cities();
                myCity.Name1 = Name;
                myCity = myCity.Find2(this.CNN);
                return (myCity == null ? "00165" : myCity.Code);
            }
        }
        public string ToName
        {
            get
            {
                return "";
                string Name = "out side of saudi arabia";
                if (!string.IsNullOrEmpty(this.RLat) && !string.IsNullOrEmpty(this.RLng))
                {
                    Name = moh.GetCity(this.RLat, this.RLng);
                }

                Cities myCity = new Cities();
                myCity.Name1 = Name;
                myCity = myCity.Find2(this.CNN);
                return (myCity == null ? "00165" : myCity.Code);
            }
        }
        public string OrderID
        {
            get
            {
                return "10" + this.VouLoc.Substring(3, 2) + this.VouNo.ToString();
            }
        }
        public string UIID
        {
            get
            {
                return "10" + this.VouNo.ToString();
            }
        }


        public Invoice()
        {
            this.Branch = 1;
            this.VouLoc = "";
            this.VouLoc2 = "";
            this.VouNo = 0;
            this.VouType = 0;
            this.HDate = "";
            this.GDate = "";
            this.RDate = "";
            this.Name = "";
            this.IDNo = "";
            this.IDType = 0;
            this.IDFrom = "";
            this.IDDate = "";
            this.Address = "";
            this.MobileNo = "";
            this.PlaceofLoading = "";
            this.Destination = "";
            this.Amount = 0;
            this.ShAmount = 0;
            this.Amount2 = 0;
            this.RecName = "";
            this.RecAddress = "";
            this.RecMobileNo = "";
            this.CarType = "";
            this.Brand = "";
            this.PlateNo = "";
            this.ChassisNo = "";
            this.Color = "";
            this.Model = "";
            this.CashAmount = 0;
            this.RecVouNo = 0;
            this.RecVouDate = "";
            this.Site = "";
            this.SiteAmount = 0;
            this.Customer = "";
            this.CustomerAmount = 0;
            this.S1 = false;
            this.S2 = false;
            this.S3 = false;
            this.S4 = false;
            this.S5 = false;
            this.S6 = false;
            this.S7 = false;
            this.S8 = false;
            this.S9 = false;
            this.S10 = false;
            this.S11 = false;
            this.S12 = false;
            this.S13 = false;
            this.S14 = false;
            this.S15 = false;
            this.S16 = false;
            this.S17 = false;
            this.S18 = false;
            this.S19 = false;
            this.S20 = false;
            this.S21 = false;
            this.S22 = false;
            this.S23 = false;
            this.S24 = false;
            this.S25 = false;
            this.S26 = false;
            this.S27 = false;
            this.S28 = false;
            this.S29 = false;
            this.S30 = false;
            this.S31 = false;
            this.S32 = false;
            this.S33 = false;
            this.S34 = false;
            this.S35 = false;
            this.S36 = false;
            this.S37 = false;
            this.S38 = false;
            this.Access1 = false;
            this.Access2 = false;
            this.Access3 = false;
            this.Access4 = false;
            this.Access5 = false;
            this.Access6 = false;
            this.Access7 = false;
            this.Access8 = false;
            this.Access9 = false;
            this.Access10 = false;
            this.Access11 = false;
            this.Access12 = false;
            this.Access13 = false;
            this.Access14 = false;
            this.Access15 = false;
            this.Access16 = false;
            this.Access17 = false;
            this.Access18 = false;
            this.sAccess1 = "";
            this.sAccess2 = "";
            this.sAccess3 = "";
            this.sAccess4 = "";
            this.sAccess5 = "";
            this.sAccess6 = "";
            this.sAccess7 = "";
            this.sAccess8 = "";
            this.sAccess9 = "";
            this.sAccess10 = "";
            this.sAccess11 = "";
            this.sAccess12 = "";
            this.sAccess13 = "";
            this.sAccess14 = "";
            this.sAccess15 = "";
            this.sAccess16 = "";
            this.sAccess17 = "";
            this.sAccess18 = "";
            this.Remark1 = "";
            this.Remark2 = "";
            this.Attached = "";
            this.UserName = "";
            this.UserDate = "";
            this.Qty = 1;
            this.Qty2 = 0;
            this.RcvNo = "";
            this.VouNo2 = "";
            this.FTime = String.Format("{0:HH:mm:ss}", moh.Nows());  //moh.Nows().ToShortTimeString();
            this.OVouNo = "";
            this.ReturnInv = false;
            this.Payment = 0;
            this.DPeriod = 10;
            this.PlaceFrom = false;
            this.PlaceTo = false;
            this.SLat = "";
            this.SLng = "";
            this.RLat = "";
            this.RLng = "";
            this.Status = 0;
            this.Tax = 0;
            this.Discount = 0;
            this.DiscountTerm = "";
            this.ShipType2 = 0;
            this.Mail = "";
            this.IDdriver = "";
            this.RecMail = "";
            this.CardType = -1;
            this.PayType = -1;
            this.CardNo = "";
            this.CardHolder = "";
            this.Expiry = "";
            this.ServiceCode = "";
            this.Rate = -1;
            this.CustRate = -1;
            this.CancelReason = -1;
            this.DeliveredDate = "";
            this.ArrivingTime = "";
            this.RateNote = "";
            this.RateReason = -1;
            this.OrDateTime = "";
            this.IDDriver2 = "";
            this.Rate2 = -1;
            this.OrderIssue = -1;
            this.OrderIssue2 = -1;
            this.DriverNote = "";
            this.DriverNote2 = "";
            this.Reward1 = 0;
            this.Reward2 = 0;
            this.Penal1 = 0;
            this.Penal2 = 0;
            this.Earn1 = 0;
            this.Earn2 = 0;
        }

        /// <summary>
        /// Add Invoice center in Invoice Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr, string IncomeAcc, string CashAcc,string ShAcc, string SiteAcc, string Area, string Project, string SiteCode, string Shabaka)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.InvoiceInsert(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.VouType,
                                            this.HDate,
                                            this.GDate,
                                            this.Name,
                                            this.IDNo,
                                            this.IDType,
                                            this.IDFrom,
                                            this.IDDate,
                                            this.Address,
                                            this.MobileNo,
                                            this.PlaceofLoading,
                                            this.Destination,
                                            this.Amount,
                                            this.Amount2,
                                            this.RecName,
                                            this.RecAddress,
                                            this.RecMobileNo,
                                            this.CarType,
                                            this.Brand,
                                            this.PlateNo,
                                            this.ChassisNo,
                                            this.Color,
                                            this.Model,
                                            this.CashAmount,
                                            this.ShAmount,
                                            this.RecVouNo,
                                            this.RecVouDate,
                                            this.Site,
                                            this.SiteAmount,
                                            this.Customer,
                                            this.CustomerAmount,
                                            this.S1,
                                            this.S2,
                                            this.S3,
                                            this.S4,
                                            this.S5,
                                            this.S6,
                                            this.S7,
                                            this.S8,
                                            this.S9,
                                            this.S10,
                                            this.S11,
                                            this.S12,
                                            this.S13,
                                            this.S14,
                                            this.S15,
                                            this.S16,
                                            this.S17,
                                            this.S18,
                                            this.S19,
                                            this.S20,
                                            this.S21,
                                            this.S22,
                                            this.S23,
                                            this.S24,
                                            this.S25,
                                            this.S26,
                                            this.S27,
                                            this.S28,
                                            this.S29,
                                            this.S30,
                                            this.S31,
                                            this.S32,
                                            this.S33,
                                            this.S34,
                                            this.S35,
                                            this.S36,
                                            this.S37,
                                            this.S38,
                                            this.Access1,
                                            this.Access2,
                                            this.Access3,
                                            this.Access4,
                                            this.Access5,
                                            this.Access6,
                                            this.Access7,
                                            this.Access8,
                                            this.Access9,
                                            this.Access10,
                                            this.Access11,
                                            this.Access12,
                                            this.Access13,
                                            this.Access14,
                                            this.Access15,
                                            this.Access16,
                                            this.Access17,
                                            this.Access18,
                                            this.sAccess1,
                                            this.sAccess2,
                                            this.sAccess3,
                                            this.sAccess4,
                                            this.sAccess5,
                                            this.sAccess6,
                                            this.sAccess7,
                                            this.sAccess8,
                                            this.sAccess9,
                                            this.sAccess10,
                                            this.sAccess11,
                                            this.sAccess12,
                                            this.sAccess13,
                                            this.sAccess14,
                                            this.sAccess15,
                                            this.sAccess16,
                                            this.sAccess17,
                                            this.sAccess18,
                                            this.Remark1,
                                            this.Remark2,
                                            this.Attached,
                                            this.UserName,
                                            this.UserDate,
                                            IncomeAcc,
                                            CashAcc,
                                            ShAcc,
                                            SiteAcc,
                                            Project,
                                            Area,
                                            SiteCode,
                                            this.Qty,
                                            this.Qty2,
                                            this.RcvNo,
                                            this.VouNo2,
                                            this.FTime,
                                            this.OVouNo,
                                            this.ReturnInv,
                                            this.Payment,
                                            Shabaka,
                                            this.DPeriod,
                                            this.PlaceFrom,
                                            this.PlaceTo,
                                            this.SLat,
                                            this.SLng,
                                            this.RLat,
                                            this.RLng,
                                            this.Tax,
                                            this.Discount,
                                            this.DiscountTerm,
                                            this.ShipType2,
                                            this.VouLoc2,
                                            this.RDate,
                                            this.Mail,
                                            this.IDdriver,
                                            this.RecMail,
                                            this.CardType,
                                            this.PayType,
                                            this.CardNo,
                                            this.CardHolder,
                                            this.Expiry,
                                            this.ServiceCode, this.Rate, this.CustRate, this.CancelReason,
                                            this.DeliveredDate,
                                            this.ArrivingTime,
                                            this.RateNote,
                                            this.RateReason,
                                            this.OrDateTime,
                                            this.IDDriver2,
                                            this.Rate2,
                                            this.OrderIssue,
                                            this.OrderIssue2,
                                            this.DriverNote,
                                            this.DriverNote2,
                                            this.Reward1,
                                            this.Reward2,
                                            this.Penal1,
                                            this.Penal2,
                                            this.Earn1,
                                            this.Earn2                                            
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
        /// Update Gas in Gas Table
        /// </summary>
        /// <returns>True if Gas Success or False if Fail</returns>
        public bool StatusUpdate(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.InvoiceStatusUpdate(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
                                                this.Status);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Gas in Gas Table
        /// </summary>
        /// <returns>True if Gas Success or False if Fail</returns>
        public bool StatusDriverUpdate(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.InvoiceStatusDriverUpdate(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
                                                this.Status,this.IDdriver);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Update Gas in Gas Table
        /// </summary>
        /// <returns>True if Gas Success or False if Fail</returns>
        public bool doCancel(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.InvoiceCancel(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
                                                this.Status,this.CancelReason);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Update Gas in Gas Table
        /// </summary>
        /// <returns>True if Gas Success or False if Fail</returns>
        public bool doRate(string DriverID,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.InvoiceRate(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
                                                this.Rate, MyEncryption.base64Encode(DriverID),this.RateNote,this.RateReason);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Gas in Gas Table
        /// </summary>
        /// <returns>True if Gas Success or False if Fail</returns>
        public bool doCustRate(string CustID,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.InvoiceCustRate(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
                                                this.CustRate, MyEncryption.base64Encode(CustID));
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Add Shipment in Shipment Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        /// 
        public bool UpdateDriverNote(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.InvoiceDriverNoteUpdate(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.DriverNote);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Add Shipment in Shipment Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        /// 
        public bool UpdateOrderIssue(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.InvoiceOrderIssueUpdate(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.OrderIssue);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Invoice center from Invoice Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.InvoiceDelete(this.Branch,this.VouLoc,this.VouNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Invoice center in Invoice Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr, string IncomeAcc, string CashAcc, string ShAcc, string SiteAcc, string Area, string Project, string SiteCode, string Shabaka)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.InvoiceUpdate(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.VouType,
                                            this.HDate,
                                            this.GDate,
                                            this.Name,
                                            this.IDNo,
                                            this.IDType,
                                            this.IDFrom,
                                            this.IDDate,
                                            this.Address,
                                            this.MobileNo,
                                            this.PlaceofLoading,
                                            this.Destination,
                                            this.Amount,
                                            this.Amount2,
                                            this.RecName,
                                            this.RecAddress,
                                            this.RecMobileNo,
                                            this.CarType,
                                            this.Brand,
                                            this.PlateNo,
                                            this.ChassisNo,
                                            this.Color,
                                            this.Model,
                                            this.CashAmount,
                                            this.ShAmount,
                                            this.RecVouNo,
                                            this.RecVouDate,
                                            this.Site,
                                            this.SiteAmount,
                                            this.Customer,
                                            this.CustomerAmount,
                                            this.S1,
                                            this.S2,
                                            this.S3,
                                            this.S4,
                                            this.S5,
                                            this.S6,
                                            this.S7,
                                            this.S8,
                                            this.S9,
                                            this.S10,
                                            this.S11,
                                            this.S12,
                                            this.S13,
                                            this.S14,
                                            this.S15,
                                            this.S16,
                                            this.S17,
                                            this.S18,
                                            this.S19,
                                            this.S20,
                                            this.S21,
                                            this.S22,
                                            this.S23,
                                            this.S24,
                                            this.S25,
                                            this.S26,
                                            this.S27,
                                            this.S28,
                                            this.S29,
                                            this.S30,
                                            this.S31,
                                            this.S32,
                                            this.S33,
                                            this.S34,
                                            this.S35,
                                            this.S36,
                                            this.S37,
                                            this.S38,
                                            this.Access1,
                                            this.Access2,
                                            this.Access3,
                                            this.Access4,
                                            this.Access5,
                                            this.Access6,
                                            this.Access7,
                                            this.Access8,
                                            this.Access9,
                                            this.Access10,
                                            this.Access11,
                                            this.Access12,
                                            this.Access13,
                                            this.Access14,
                                            this.Access15,
                                            this.Access16,
                                            this.Access17,
                                            this.Access18,
                                            this.sAccess1,
                                            this.sAccess2,
                                            this.sAccess3,
                                            this.sAccess4,
                                            this.sAccess5,
                                            this.sAccess6,
                                            this.sAccess7,
                                            this.sAccess8,
                                            this.sAccess9,
                                            this.sAccess10,
                                            this.sAccess11,
                                            this.sAccess12,
                                            this.sAccess13,
                                            this.sAccess14,
                                            this.sAccess15,
                                            this.sAccess16,
                                            this.sAccess17,
                                            this.sAccess18,
                                            this.Remark1,
                                            this.Remark2,
                                            this.Attached,
                                            this.UserName,
                                            this.UserDate,
                                            IncomeAcc,
                                            CashAcc,
                                            ShAcc,
                                            SiteAcc,
                                            Project,
                                            Area,
                                            SiteCode,
                                            this.Qty,
                                            this.Qty2,
                                            this.RcvNo,
                                            this.VouNo2,
                                            this.FTime,
                                            this.OVouNo,
                                            this.ReturnInv,
                                            this.Payment,
                                            Shabaka,
                                            this.DPeriod,
                                            this.PlaceFrom,
                                            this.PlaceTo,
                                            this.SLat,
                                            this.SLng,
                                            this.RLat,
                                            this.RLng,
                                            this.Tax,
                                            this.Discount,
                                            this.DiscountTerm,
                                            this.ShipType2,
                                            this.VouLoc2,
                                            this.RDate,
                                            this.Mail,
                                            this.IDdriver,
                                            this.RecMail,
                                            this.CardType,
                                            this.PayType,
                                            this.CardNo,
                                            this.CardHolder,
                                            this.Expiry,
                                            this.ServiceCode, this.Rate, this.CustRate, this.CancelReason,
                                            this.DeliveredDate,
                                            this.ArrivingTime,
                                            this.RateNote,
                                            this.RateReason,
                                            this.OrDateTime,
                                            this.IDDriver2,
                                            this.Rate2,
                                            this.OrderIssue,
                                            this.OrderIssue2,
                                            this.DriverNote,
                                            this.DriverNote2,
                                            this.Reward1,
                                            this.Reward2,
                                            this.Penal1,
                                            this.Penal2,
                                            this.Earn1,
                                            this.Earn2                                                                                       
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
        /// Update Invoice RecVou in Invoice Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.InvoiceUpdateRec(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.RecVouNo,
                                            this.RecVouDate
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
        /// Update Invoice RecVou in Invoice Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool updateLoc(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.InvoiceUpdateLOC(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.PlaceofLoading,
                                            this.Destination                                            
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
        /// Get New Invoice No from Invoice Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public int? GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceMaxCode(this.Branch,this.VouLoc);
                    return (from Cat in result
                            select Cat.myCode).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get New Invoice No from Invoice Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public int? GetNewRecCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceRecMaxCode(this.Branch,this.VouLoc);
                    return (from Cat in result
                            select Cat.myCode).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public Invoice Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGet(this.Branch,this.VouLoc,this.VouNo);
                    return (from itm in result
                            select new Invoice
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                CNN = ConnectionStr,
                                VouType = itm.VouType,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                Amount = itm.Amount,
                                Amount2 = itm.Amount2,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                CashAmount = itm.CashAmount,
                                RecVouNo = itm.RecVouNo,
                                RecVouDate = itm.RecVouDate,
                                Site = itm.Site,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                S1 = itm.S1,
                                S2 = itm.S2,
                                S3 = itm.S3,
                                S4 = itm.S4,
                                S5 = itm.S5,
                                S6 = itm.S6,
                                S7 = itm.S7,
                                S8 = itm.S8,
                                S9 = itm.S9,
                                S10 = itm.S10,
                                S11 = itm.S11,
                                S12 = itm.S11,
                                S13 = itm.S13,
                                S14 = itm.S14,
                                S15 = itm.S15,
                                S16 = itm.S16,
                                S17 = itm.S17,
                                S18 = itm.S18,
                                S19 = itm.S19,
                                S20 = itm.S20,
                                S21 = itm.S21,
                                S22 = itm.S22,
                                S23 = itm.S23,
                                S24 = itm.S24,
                                S25 = itm.S25,
                                S26 = itm.S26,
                                S27 = itm.S27,
                                S28 = itm.S28,
                                S29 = itm.S29,
                                S30 = itm.S30,
                                S31 = itm.S31,
                                S32 = itm.S32,
                                S33 = itm.S33,
                                S34 = itm.S34,
                                S35 = itm.S35,
                                S36 = itm.S36,
                                S37 = itm.S37,
                                S38 = itm.S38,
                                Access1 = itm.Access1,
                                Access2 = itm.Access2,
                                Access3 = itm.Access3,
                                Access4 = itm.Access4,
                                Access5 = itm.Access5,
                                Access6 = itm.Access6,
                                Access7 = itm.Access7,
                                Access8 = itm.Access8,
                                Access9 = itm.Access9,
                                Access10 = itm.Access10,
                                Access11 = itm.Access11,
                                Access12 = itm.Access12,
                                Access13 = itm.Access13,
                                Access14 = itm.Access14,
                                Access15 = itm.Access15,
                                Access16 = itm.Access16,
                                Access17 = itm.Access17,
                                Access18 = itm.Access18,
                                sAccess1 = itm.sAccess1,
                                sAccess2 = itm.sAccess2,
                                sAccess3 = itm.sAccess3,
                                sAccess4 = itm.sAccess4,
                                sAccess5 = itm.sAccess5,
                                sAccess6 = itm.sAccess6,
                                sAccess7 = itm.sAccess7,
                                sAccess8 = itm.sAccess8,
                                sAccess9 = itm.sAccess9,
                                sAccess10 = itm.sAccess10,
                                sAccess11 = itm.sAccess11,
                                sAccess12 = itm.sAccess12,
                                sAccess13 = itm.sAccess13,
                                sAccess14 = itm.sAccess14,
                                sAccess15 = itm.sAccess15,
                                sAccess16 = itm.sAccess16,
                                sAccess17 = itm.sAccess17,
                                sAccess18 = itm.sAccess18,
                                Remark1 = itm.Remark1,
                                Remark2 = itm.Remark2,
                                Attached = itm.Attached,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                Qty2 = itm.Qty2,
                                RcvNo = itm.RcvNo,
                                VouNo2 = itm.VouNo2,
                                FTime = itm.FTime,
                                OVouNo = itm.OVouNo,
                                ReturnInv = itm.ReturnInv,
                                Payment = itm.Payment,
                                DPeriod = itm.DPeriod,
                                PlaceFrom = itm.PlaceFrom,
                                PlaceTo = itm.PlaceTo,
                                RLat = itm.RLat,
                                RLng = itm.RLng,
                                SLat = itm.SLat,
                                SLng = itm.SLng,
                                Tax = itm.Tax,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                Status = itm.Status,
                                ShipType2 = itm.ShipType2,
                                VouLoc2 = itm.VouLoc2,
                                RDate = itm.RDate,
                                CardNo = itm.CardNo,
                                CardHolder = itm.CardHolder,
                                CardType = itm.CardType,
                                Expiry = itm.Expiry,
                                IDdriver = itm.IDdriver,
                                Mail = itm.Mail,
                                PayType = itm.PayType,
                                RecMail = itm.RecMail,
                                ServiceCode = itm.ServiceCode,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                OrDateTime = itm.OrDateTime,
                                DriverNote = itm.DriverNote,
                                DriverNote2 = itm.DriverNote2,
                                IDDriver2 = itm.IDDriver2,
                                OrderIssue = itm.OrderIssue,
                                OrderIssue2 = itm.OrderIssue2,
                                Rate2 = itm.Rate2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                Penal2 = itm.Penal2,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                ShAmount = itm.ShAmount                               
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public Invoice Find2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGet2(this.Branch, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new Invoice
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                CNN = ConnectionStr,
                                VouType = itm.VouType,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                Amount = itm.Amount,
                                Amount2 = itm.Amount2,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                CashAmount = itm.CashAmount,
                                RecVouNo = itm.RecVouNo,
                                RecVouDate = itm.RecVouDate,
                                Site = itm.Site,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                S1 = itm.S1,
                                S2 = itm.S2,
                                S3 = itm.S3,
                                S4 = itm.S4,
                                S5 = itm.S5,
                                S6 = itm.S6,
                                S7 = itm.S7,
                                S8 = itm.S8,
                                S9 = itm.S9,
                                S10 = itm.S10,
                                S11 = itm.S11,
                                S12 = itm.S11,
                                S13 = itm.S13,
                                S14 = itm.S14,
                                S15 = itm.S15,
                                S16 = itm.S16,
                                S17 = itm.S17,
                                S18 = itm.S18,
                                S19 = itm.S19,
                                S20 = itm.S20,
                                S21 = itm.S21,
                                S22 = itm.S22,
                                S23 = itm.S23,
                                S24 = itm.S24,
                                S25 = itm.S25,
                                S26 = itm.S26,
                                S27 = itm.S27,
                                S28 = itm.S28,
                                S29 = itm.S29,
                                S30 = itm.S30,
                                S31 = itm.S31,
                                S32 = itm.S32,
                                S33 = itm.S33,
                                S34 = itm.S34,
                                S35 = itm.S35,
                                S36 = itm.S36,
                                S37 = itm.S37,
                                S38 = itm.S38,
                                Access1 = itm.Access1,
                                Access2 = itm.Access2,
                                Access3 = itm.Access3,
                                Access4 = itm.Access4,
                                Access5 = itm.Access5,
                                Access6 = itm.Access6,
                                Access7 = itm.Access7,
                                Access8 = itm.Access8,
                                Access9 = itm.Access9,
                                Access10 = itm.Access10,
                                Access11 = itm.Access11,
                                Access12 = itm.Access12,
                                Access13 = itm.Access13,
                                Access14 = itm.Access14,
                                Access15 = itm.Access15,
                                Access16 = itm.Access16,
                                Access17 = itm.Access17,
                                Access18 = itm.Access18,
                                sAccess1 = itm.sAccess1,
                                sAccess2 = itm.sAccess2,
                                sAccess3 = itm.sAccess3,
                                sAccess4 = itm.sAccess4,
                                sAccess5 = itm.sAccess5,
                                sAccess6 = itm.sAccess6,
                                sAccess7 = itm.sAccess7,
                                sAccess8 = itm.sAccess8,
                                sAccess9 = itm.sAccess9,
                                sAccess10 = itm.sAccess10,
                                sAccess11 = itm.sAccess11,
                                sAccess12 = itm.sAccess12,
                                sAccess13 = itm.sAccess13,
                                sAccess14 = itm.sAccess14,
                                sAccess15 = itm.sAccess15,
                                sAccess16 = itm.sAccess16,
                                sAccess17 = itm.sAccess17,
                                sAccess18 = itm.sAccess18,
                                Remark1 = itm.Remark1,
                                Remark2 = itm.Remark2,
                                Attached = itm.Attached,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                Qty2 = itm.Qty2,
                                RcvNo = itm.RcvNo,
                                VouNo2 = itm.VouNo2,
                                FTime = itm.FTime,
                                OVouNo = itm.OVouNo,
                                ReturnInv = itm.ReturnInv,
                                PlaceFrom = itm.PlaceFrom,
                                PlaceTo = itm.PlaceTo,
                                RLat = itm.RLat,
                                RLng = itm.RLng,
                                SLat = itm.SLat,
                                SLng = itm.SLng,
                                Tax = itm.Tax,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                Status = itm.Status,
                                ShipType2 = itm.ShipType2,
                                DPeriod = itm.DPeriod,
                                Payment = itm.Payment,
                                VouLoc2 = itm.VouLoc2,
                                RDate = itm.RDate,
                                CardNo = itm.CardNo,
                                CardHolder = itm.CardHolder,
                                CardType = itm.CardType,
                                Expiry = itm.Expiry,
                                IDdriver = itm.IDDate,
                                Mail = itm.Mail,
                                PayType = itm.PayType,
                                RecMail = itm.RecMail,
                                ServiceCode = itm.ServiceCode,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                OrDateTime = itm.OrDateTime,
                                DriverNote = itm.DriverNote,
                                DriverNote2 = itm.DriverNote2,
                                IDDriver2 = itm.IDDriver2,
                                OrderIssue = itm.OrderIssue,
                                OrderIssue2 = itm.OrderIssue2,
                                Rate2 = itm.Rate2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                Penal2 = itm.Penal2,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                ShAmount = itm.ShAmount
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<Invoice> GetStatement(string ConnectionStr , string FDate , string EDate)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceStatement(this.Branch, this.VouLoc, FDate,EDate);
                    return (from itm in result
                            select new Invoice
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                CNN = ConnectionStr,
                                VouType = itm.VouType,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                Amount = itm.Amount,
                                Amount2 = itm.Amount2,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                CashAmount = itm.CashAmount,
                                RecVouNo = itm.RecVouNo,
                                RecVouDate = itm.RecVouDate,
                                Site = itm.Site,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                S1 = itm.S1,
                                S2 = itm.S2,
                                S3 = itm.S3,
                                S4 = itm.S4,
                                S5 = itm.S5,
                                S6 = itm.S6,
                                S7 = itm.S7,
                                S8 = itm.S8,
                                S9 = itm.S9,
                                S10 = itm.S10,
                                S11 = itm.S11,
                                S12 = itm.S11,
                                S13 = itm.S13,
                                S14 = itm.S14,
                                S15 = itm.S15,
                                S16 = itm.S16,
                                S17 = itm.S17,
                                S18 = itm.S18,
                                S19 = itm.S19,
                                S20 = itm.S20,
                                S21 = itm.S21,
                                S22 = itm.S22,
                                S23 = itm.S23,
                                S24 = itm.S24,
                                S25 = itm.S25,
                                S26 = itm.S26,
                                S27 = itm.S27,
                                S28 = itm.S28,
                                S29 = itm.S29,
                                S30 = itm.S30,
                                S31 = itm.S31,
                                S32 = itm.S32,
                                S33 = itm.S33,
                                S34 = itm.S34,
                                S35 = itm.S35,
                                S36 = itm.S36,
                                S37 = itm.S37,
                                S38 = itm.S38,
                                Access1 = itm.Access1,
                                Access2 = itm.Access2,
                                Access3 = itm.Access3,
                                Access4 = itm.Access4,
                                Access5 = itm.Access5,
                                Access6 = itm.Access6,
                                Access7 = itm.Access7,
                                Access8 = itm.Access8,
                                Access9 = itm.Access9,
                                Access10 = itm.Access10,
                                Access11 = itm.Access11,
                                Access12 = itm.Access12,
                                Access13 = itm.Access13,
                                Access14 = itm.Access14,
                                Access15 = itm.Access15,
                                Access16 = itm.Access16,
                                Access17 = itm.Access17,
                                Access18 = itm.Access18,
                                sAccess1 = itm.sAccess1,
                                sAccess2 = itm.sAccess2,
                                sAccess3 = itm.sAccess3,
                                sAccess4 = itm.sAccess4,
                                sAccess5 = itm.sAccess5,
                                sAccess6 = itm.sAccess6,
                                sAccess7 = itm.sAccess7,
                                sAccess8 = itm.sAccess8,
                                sAccess9 = itm.sAccess9,
                                sAccess10 = itm.sAccess10,
                                sAccess11 = itm.sAccess11,
                                sAccess12 = itm.sAccess12,
                                sAccess13 = itm.sAccess13,
                                sAccess14 = itm.sAccess14,
                                sAccess15 = itm.sAccess15,
                                sAccess16 = itm.sAccess16,
                                sAccess17 = itm.sAccess17,
                                sAccess18 = itm.sAccess18,
                                Remark1 = itm.Remark1,
                                Remark2 = itm.Remark2,
                                Attached = itm.Attached,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                Qty2 = itm.Qty2,
                                RcvNo = itm.RcvNo,
                                VouNo2 = itm.VouNo2,
                                FTime = itm.FTime,
                                OVouNo = itm.OVouNo,
                                ReturnInv = itm.ReturnInv,
                                Payment = itm.Payment,
                                DPeriod = itm.DPeriod,
                                PlaceFrom = itm.PlaceFrom,
                                PlaceTo = itm.PlaceTo,
                                RLat = itm.RLat,
                                RLng = itm.RLng,
                                SLat = itm.SLat,
                                SLng = itm.SLng,
                                Tax = itm.Tax,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                Status = itm.Status,
                                ShipType2 = itm.ShipType2,
                                VouLoc2 = itm.VouLoc2,
                                RDate = itm.RDate,
                                CardNo = itm.CardNo,
                                CardHolder = itm.CardHolder,
                                CardType = itm.CardType,
                                Expiry = itm.Expiry,
                                IDdriver = itm.IDDate,
                                Mail = itm.Mail,
                                PayType = itm.PayType,
                                RecMail = itm.RecMail,
                                ServiceCode = itm.ServiceCode,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                OrDateTime = itm.OrDateTime,
                                DriverNote = itm.DriverNote,
                                DriverNote2 = itm.DriverNote2,
                                IDDriver2 = itm.IDDriver2,
                                OrderIssue = itm.OrderIssue,
                                OrderIssue2 = itm.OrderIssue2,
                                Rate2 = itm.Rate2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                Penal2 = itm.Penal2,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                ShAmount = itm.ShAmount
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<Invoice> FindByUserName(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGetByUserName(this.UserName);
                    return (from itm in result
                            select new Invoice
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                Name = itm.Name,
                                CNN = ConnectionStr,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                Amount = itm.Amount,
                                Amount2 = itm.Amount2,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                CashAmount = itm.CashAmount,
                                RecVouNo = itm.RecVouNo,
                                RecVouDate = itm.RecVouDate,
                                Site = itm.Site,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                ShAmount = itm.ShAmount,
                                /*
                                S1 = itm.S1,
                                S2 = itm.S2,
                                S3 = itm.S3,
                                S4 = itm.S4,
                                S5 = itm.S5,
                                S6 = itm.S6,
                                S7 = itm.S7,
                                S8 = itm.S8,
                                S9 = itm.S9,
                                S10 = itm.S10,
                                S11 = itm.S11,
                                S12 = itm.S11,
                                S13 = itm.S13,
                                S14 = itm.S14,
                                S15 = itm.S15,
                                S16 = itm.S16,
                                S17 = itm.S17,
                                S18 = itm.S18,
                                S19 = itm.S19,
                                S20 = itm.S20,
                                S21 = itm.S21,
                                S22 = itm.S22,
                                S23 = itm.S23,
                                S24 = itm.S24,
                                S25 = itm.S25,
                                S26 = itm.S26,
                                S27 = itm.S27,
                                S28 = itm.S28,
                                S29 = itm.S29,
                                S30 = itm.S30,
                                S31 = itm.S31,
                                S32 = itm.S32,
                                S33 = itm.S33,
                                S34 = itm.S34,
                                S35 = itm.S35,
                                S36 = itm.S36,
                                S37 = itm.S37,
                                S38 = itm.S38,
                                Access1 = itm.Access1,
                                Access2 = itm.Access2,
                                Access3 = itm.Access3,
                                Access4 = itm.Access4,
                                Access5 = itm.Access5,
                                Access6 = itm.Access6,
                                Access7 = itm.Access7,
                                Access8 = itm.Access8,
                                Access9 = itm.Access9,
                                Access10 = itm.Access10,
                                Access11 = itm.Access11,
                                Access12 = itm.Access12,
                                Access13 = itm.Access13,
                                Access14 = itm.Access14,
                                Access15 = itm.Access15,
                                Access16 = itm.Access16,
                                Access17 = itm.Access17,
                                Access18 = itm.Access18,
                                sAccess1 = itm.sAccess1,
                                sAccess2 = itm.sAccess2,
                                sAccess3 = itm.sAccess3,
                                sAccess4 = itm.sAccess4,
                                sAccess5 = itm.sAccess5,
                                sAccess6 = itm.sAccess6,
                                sAccess7 = itm.sAccess7,
                                sAccess8 = itm.sAccess8,
                                sAccess9 = itm.sAccess9,
                                sAccess10 = itm.sAccess10,
                                sAccess11 = itm.sAccess11,
                                sAccess12 = itm.sAccess12,
                                sAccess13 = itm.sAccess13,
                                sAccess14 = itm.sAccess14,
                                sAccess15 = itm.sAccess15,
                                sAccess16 = itm.sAccess16,
                                sAccess17 = itm.sAccess17,
                                sAccess18 = itm.sAccess18,
                                 */
                                Remark1 = itm.Remark1,
                                Remark2 = itm.Remark2,
                                Attached = itm.Attached,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                Qty2 = itm.Qty2,
                                RcvNo = itm.RcvNo,
                                VouNo2 = itm.VouNo2,
                                FTime = itm.FTime,
                                OVouNo = itm.OVouNo,
                                ReturnInv = itm.ReturnInv,
                                Payment = itm.Payment,
                                DPeriod = itm.DPeriod,
                                PlaceFrom = itm.PlaceFrom,
                                PlaceTo = itm.PlaceTo,
                                RLat = itm.RLat,
                                RLng = itm.RLng,
                                SLat = itm.SLat,
                                SLng = itm.SLng,
                                Tax = itm.Tax,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                Status = itm.Status,
                                ShipType2 = itm.ShipType2,
                                VouLoc2 = itm.VouLoc2,
                                RDate = itm.RDate,
                                CardNo = itm.CardNo,
                                CardHolder = itm.CardHolder,
                                CardType = itm.CardType,
                                Expiry = itm.Expiry,
                                IDdriver = itm.IDDate,
                                Mail = itm.Mail,
                                PayType = itm.PayType,
                                RecMail = itm.RecMail,
                                ServiceCode = itm.ServiceCode,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                OrDateTime = itm.OrDateTime,
                                DriverNote = itm.DriverNote,
                                DriverNote2 = itm.DriverNote2,
                                IDDriver2 = itm.IDDriver2,
                                OrderIssue = itm.OrderIssue,
                                OrderIssue2 = itm.OrderIssue2,
                                Rate2 = itm.Rate2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                Penal2 = itm.Penal2,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<Invoice> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGetAll(this.Branch);
                    return (from itm in result
                            select new Invoice
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
                                CNN = ConnectionStr,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                Amount = itm.Amount,
                                Amount2 = itm.Amount2,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                CashAmount = itm.CashAmount,
                                RecVouNo = itm.RecVouNo,
                                RecVouDate = itm.RecVouDate,
                                Site = itm.Site,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                S1 = itm.S1,
                                S2 = itm.S2,
                                S3 = itm.S3,
                                S4 = itm.S4,
                                S5 = itm.S5,
                                S6 = itm.S6,
                                S7 = itm.S7,
                                S8 = itm.S8,
                                S9 = itm.S9,
                                S10 = itm.S10,
                                S11 = itm.S11,
                                S12 = itm.S11,
                                S13 = itm.S13,
                                S14 = itm.S14,
                                S15 = itm.S15,
                                S16 = itm.S16,
                                S17 = itm.S17,
                                S18 = itm.S18,
                                S19 = itm.S19,
                                S20 = itm.S20,
                                S21 = itm.S21,
                                S22 = itm.S22,
                                S23 = itm.S23,
                                S24 = itm.S24,
                                S25 = itm.S25,
                                S26 = itm.S26,
                                S27 = itm.S27,
                                S28 = itm.S28,
                                S29 = itm.S29,
                                S30 = itm.S30,
                                S31 = itm.S31,
                                S32 = itm.S32,
                                S33 = itm.S33,
                                S34 = itm.S34,
                                S35 = itm.S35,
                                S36 = itm.S36,
                                S37 = itm.S37,
                                S38 = itm.S38,
                                Access1 = itm.Access1,
                                Access2 = itm.Access2,
                                Access3 = itm.Access3,
                                Access4 = itm.Access4,
                                Access5 = itm.Access5,
                                Access6 = itm.Access6,
                                Access7 = itm.Access7,
                                Access8 = itm.Access8,
                                Access9 = itm.Access9,
                                Access10 = itm.Access10,
                                Access11 = itm.Access11,
                                Access12 = itm.Access12,
                                Access13 = itm.Access13,
                                Access14 = itm.Access14,
                                Access15 = itm.Access15,
                                Access16 = itm.Access16,
                                Access17 = itm.Access17,
                                Access18 = itm.Access18,
                                sAccess1 = itm.sAccess1,
                                sAccess2 = itm.sAccess2,
                                sAccess3 = itm.sAccess3,
                                sAccess4 = itm.sAccess4,
                                sAccess5 = itm.sAccess5,
                                sAccess6 = itm.sAccess6,
                                sAccess7 = itm.sAccess7,
                                sAccess8 = itm.sAccess8,
                                sAccess9 = itm.sAccess9,
                                sAccess10 = itm.sAccess10,
                                sAccess11 = itm.sAccess11,
                                sAccess12 = itm.sAccess12,
                                sAccess13 = itm.sAccess13,
                                sAccess14 = itm.sAccess14,
                                sAccess15 = itm.sAccess15,
                                sAccess16 = itm.sAccess16,
                                sAccess17 = itm.sAccess17,
                                sAccess18 = itm.sAccess18,
                                Remark1 = itm.Remark1,
                                Remark2 = itm.Remark2,
                                Attached = itm.Attached,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                Qty2 = itm.Qty2,
                                RcvNo = itm.RcvNo,
                                VouNo2 = itm.VouNo2,
                                FTime = itm.FTime,
                                OVouNo = itm.OVouNo,
                                ReturnInv = itm.ReturnInv,
                                Payment = itm.Payment,
                                DPeriod = itm.DPeriod,
                                PlaceFrom = itm.PlaceFrom,
                                PlaceTo = itm.PlaceTo,
                                RLat = itm.RLat,
                                RLng = itm.RLng,
                                SLat = itm.SLat,
                                SLng = itm.SLng,
                                Tax = itm.Tax,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                Status = itm.Status,
                                ShipType2 = itm.ShipType2,
                                VouLoc2 = itm.VouLoc2,
                                RDate = itm.RDate,
                                CardNo = itm.CardNo,
                                CardHolder = itm.CardHolder,
                                CardType = itm.CardType,
                                Expiry = itm.Expiry,
                                IDdriver = itm.IDDate,
                                Mail = itm.Mail,
                                PayType = itm.PayType,
                                RecMail = itm.RecMail,
                                ServiceCode = itm.ServiceCode,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                OrDateTime = itm.OrDateTime,
                                DriverNote = itm.DriverNote,
                                DriverNote2 = itm.DriverNote2,
                                IDDriver2 = itm.IDDriver2,
                                OrderIssue = itm.OrderIssue,
                                OrderIssue2 = itm.OrderIssue2,
                                Rate2 = itm.Rate2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                Penal2 = itm.Penal2,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                ShAmount = itm.ShAmount
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        


        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<Invoice> FindByOVouNo2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGetByOVouNo(this.OVouNo).GroupBy(test => test.VouLoc.ToString() + test.VouNo.ToString()).Select(grp => grp.First()).ToList(); ;
                    return (from itm in result
                            select new Invoice
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                CNN = ConnectionStr,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                Amount = itm.Amount,
                                Amount2 = itm.Amount2,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                CashAmount = itm.CashAmount,
                                RecVouNo = itm.RecVouNo,
                                RecVouDate = itm.RecVouDate,
                                Site = itm.Site,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                S1 = itm.S1,
                                S2 = itm.S2,
                                S3 = itm.S3,
                                S4 = itm.S4,
                                S5 = itm.S5,
                                S6 = itm.S6,
                                S7 = itm.S7,
                                S8 = itm.S8,
                                S9 = itm.S9,
                                S10 = itm.S10,
                                S11 = itm.S11,
                                S12 = itm.S11,
                                S13 = itm.S13,
                                S14 = itm.S14,
                                S15 = itm.S15,
                                S16 = itm.S16,
                                S17 = itm.S17,
                                S18 = itm.S18,
                                S19 = itm.S19,
                                S20 = itm.S20,
                                S21 = itm.S21,
                                S22 = itm.S22,
                                S23 = itm.S23,
                                S24 = itm.S24,
                                S25 = itm.S25,
                                S26 = itm.S26,
                                S27 = itm.S27,
                                S28 = itm.S28,
                                S29 = itm.S29,
                                S30 = itm.S30,
                                S31 = itm.S31,
                                S32 = itm.S32,
                                S33 = itm.S33,
                                S34 = itm.S34,
                                S35 = itm.S35,
                                S36 = itm.S36,
                                S37 = itm.S37,
                                S38 = itm.S38,
                                Access1 = itm.Access1,
                                Access2 = itm.Access2,
                                Access3 = itm.Access3,
                                Access4 = itm.Access4,
                                Access5 = itm.Access5,
                                Access6 = itm.Access6,
                                Access7 = itm.Access7,
                                Access8 = itm.Access8,
                                Access9 = itm.Access9,
                                Access10 = itm.Access10,
                                Access11 = itm.Access11,
                                Access12 = itm.Access12,
                                Access13 = itm.Access13,
                                Access14 = itm.Access14,
                                Access15 = itm.Access15,
                                Access16 = itm.Access16,
                                Access17 = itm.Access17,
                                Access18 = itm.Access18,
                                sAccess1 = itm.sAccess1,
                                sAccess2 = itm.sAccess2,
                                sAccess3 = itm.sAccess3,
                                sAccess4 = itm.sAccess4,
                                sAccess5 = itm.sAccess5,
                                sAccess6 = itm.sAccess6,
                                sAccess7 = itm.sAccess7,
                                sAccess8 = itm.sAccess8,
                                sAccess9 = itm.sAccess9,
                                sAccess10 = itm.sAccess10,
                                sAccess11 = itm.sAccess11,
                                sAccess12 = itm.sAccess12,
                                sAccess13 = itm.sAccess13,
                                sAccess14 = itm.sAccess14,
                                sAccess15 = itm.sAccess15,
                                sAccess16 = itm.sAccess16,
                                sAccess17 = itm.sAccess17,
                                sAccess18 = itm.sAccess18,
                                Remark1 = itm.Remark1,
                                Remark2 = itm.Remark2,
                                Attached = itm.Attached,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                Qty2 = itm.Qty2,
                                RcvNo = itm.RcvNo,
                                VouNo2 = itm.VouNo2,
                                FTime = itm.FTime,
                                OVouNo = itm.OVouNo,
                                ReturnInv = itm.ReturnInv,
                                Payment = itm.Payment,
                                DPeriod = itm.DPeriod,
                                PlaceFrom = itm.PlaceFrom,
                                PlaceTo = itm.PlaceTo,
                                RLat = itm.RLat,
                                RLng = itm.RLng,
                                SLat = itm.SLat,
                                SLng = itm.SLng,
                                Tax = itm.Tax,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                Status = itm.Status,
                                ShipType2 = itm.ShipType2,
                                VouLoc2 = itm.VouLoc2,
                                RDate = itm.RDate,
                                CardNo = itm.CardNo,
                                CardHolder = itm.CardHolder,
                                CardType = itm.CardType,
                                Expiry = itm.Expiry,
                                IDdriver = itm.IDDate,
                                Mail = itm.Mail,
                                PayType = itm.PayType,
                                RecMail = itm.RecMail,
                                ServiceCode = itm.ServiceCode,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                OrDateTime = itm.OrDateTime,
                                DriverNote = itm.DriverNote,
                                DriverNote2 = itm.DriverNote2,
                                IDDriver2 = itm.IDDriver2,
                                OrderIssue = itm.OrderIssue,
                                OrderIssue2 = itm.OrderIssue2,
                                Rate2 = itm.Rate2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                Penal2 = itm.Penal2,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                ShAmount = itm.ShAmount
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public Invoice FindByOVouNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGetByOVouNo(this.OVouNo);
                    return (from itm in result
                            select new Invoice
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                Amount = itm.Amount,
                                CNN = ConnectionStr,
                                Amount2 = itm.Amount2,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                CashAmount = itm.CashAmount,
                                RecVouNo = itm.RecVouNo,
                                RecVouDate = itm.RecVouDate,
                                Site = itm.Site,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                S1 = itm.S1,
                                S2 = itm.S2,
                                S3 = itm.S3,
                                S4 = itm.S4,
                                S5 = itm.S5,
                                S6 = itm.S6,
                                S7 = itm.S7,
                                S8 = itm.S8,
                                S9 = itm.S9,
                                S10 = itm.S10,
                                S11 = itm.S11,
                                S12 = itm.S11,
                                S13 = itm.S13,
                                S14 = itm.S14,
                                S15 = itm.S15,
                                S16 = itm.S16,
                                S17 = itm.S17,
                                S18 = itm.S18,
                                S19 = itm.S19,
                                S20 = itm.S20,
                                S21 = itm.S21,
                                S22 = itm.S22,
                                S23 = itm.S23,
                                S24 = itm.S24,
                                S25 = itm.S25,
                                S26 = itm.S26,
                                S27 = itm.S27,
                                S28 = itm.S28,
                                S29 = itm.S29,
                                S30 = itm.S30,
                                S31 = itm.S31,
                                S32 = itm.S32,
                                S33 = itm.S33,
                                S34 = itm.S34,
                                S35 = itm.S35,
                                S36 = itm.S36,
                                S37 = itm.S37,
                                S38 = itm.S38,
                                Access1 = itm.Access1,
                                Access2 = itm.Access2,
                                Access3 = itm.Access3,
                                Access4 = itm.Access4,
                                Access5 = itm.Access5,
                                Access6 = itm.Access6,
                                Access7 = itm.Access7,
                                Access8 = itm.Access8,
                                Access9 = itm.Access9,
                                Access10 = itm.Access10,
                                Access11 = itm.Access11,
                                Access12 = itm.Access12,
                                Access13 = itm.Access13,
                                Access14 = itm.Access14,
                                Access15 = itm.Access15,
                                Access16 = itm.Access16,
                                Access17 = itm.Access17,
                                Access18 = itm.Access18,
                                sAccess1 = itm.sAccess1,
                                sAccess2 = itm.sAccess2,
                                sAccess3 = itm.sAccess3,
                                sAccess4 = itm.sAccess4,
                                sAccess5 = itm.sAccess5,
                                sAccess6 = itm.sAccess6,
                                sAccess7 = itm.sAccess7,
                                sAccess8 = itm.sAccess8,
                                sAccess9 = itm.sAccess9,
                                sAccess10 = itm.sAccess10,
                                sAccess11 = itm.sAccess11,
                                sAccess12 = itm.sAccess12,
                                sAccess13 = itm.sAccess13,
                                sAccess14 = itm.sAccess14,
                                sAccess15 = itm.sAccess15,
                                sAccess16 = itm.sAccess16,
                                sAccess17 = itm.sAccess17,
                                sAccess18 = itm.sAccess18,
                                Remark1 = itm.Remark1,
                                Remark2 = itm.Remark2,
                                Attached = itm.Attached,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                Qty2 = itm.Qty2,
                                RcvNo = itm.RcvNo,
                                VouNo2 = itm.VouNo2,
                                FTime = itm.FTime,
                                OVouNo = itm.OVouNo,
                                ReturnInv = itm.ReturnInv,
                                Payment = itm.Payment,
                                DPeriod = itm.DPeriod,
                                PlaceFrom = itm.PlaceFrom,
                                PlaceTo = itm.PlaceTo,
                                RLat = itm.RLat,
                                RLng = itm.RLng,
                                SLat = itm.SLat,
                                SLng = itm.SLng,
                                Tax = itm.Tax,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                Status = itm.Status,
                                ShipType2 = itm.ShipType2,
                                VouLoc2 = itm.VouLoc2,
                                RDate = itm.RDate,
                                CardNo = itm.CardNo,
                                CardHolder = itm.CardHolder,
                                CardType = itm.CardType,
                                Expiry = itm.Expiry,
                                IDdriver = itm.IDDate,
                                Mail = itm.Mail,
                                PayType = itm.PayType,
                                RecMail = itm.RecMail,
                                ServiceCode = itm.ServiceCode,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                OrDateTime = itm.OrDateTime,
                                DriverNote = itm.DriverNote,
                                DriverNote2 = itm.DriverNote2,
                                IDDriver2 = itm.IDDriver2,
                                OrderIssue = itm.OrderIssue,
                                OrderIssue2 = itm.OrderIssue2,
                                Rate2 = itm.Rate2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                Penal2 = itm.Penal2,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                ShAmount = itm.ShAmount
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<Invoice> GetByMobileNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGetByMobileNo(this.MobileNo);
                    return (from itm in result
                            select new Invoice
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                CNN = ConnectionStr,
                                VouType = itm.VouType,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                Amount = itm.Amount,
                                Amount2 = itm.Amount2,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                CashAmount = itm.CashAmount,
                                RecVouNo = itm.RecVouNo,
                                RecVouDate = itm.RecVouDate,
                                Site = itm.Site,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                S1 = itm.S1,
                                S2 = itm.S2,
                                S3 = itm.S3,
                                S4 = itm.S4,
                                S5 = itm.S5,
                                S6 = itm.S6,
                                S7 = itm.S7,
                                S8 = itm.S8,
                                S9 = itm.S9,
                                S10 = itm.S10,
                                S11 = itm.S11,
                                S12 = itm.S11,
                                S13 = itm.S13,
                                S14 = itm.S14,
                                S15 = itm.S15,
                                S16 = itm.S16,
                                S17 = itm.S17,
                                S18 = itm.S18,
                                S19 = itm.S19,
                                S20 = itm.S20,
                                S21 = itm.S21,
                                S22 = itm.S22,
                                S23 = itm.S23,
                                S24 = itm.S24,
                                S25 = itm.S25,
                                S26 = itm.S26,
                                S27 = itm.S27,
                                S28 = itm.S28,
                                S29 = itm.S29,
                                S30 = itm.S30,
                                S31 = itm.S31,
                                S32 = itm.S32,
                                S33 = itm.S33,
                                S34 = itm.S34,
                                S35 = itm.S35,
                                S36 = itm.S36,
                                S37 = itm.S37,
                                S38 = itm.S38,
                                Access1 = itm.Access1,
                                Access2 = itm.Access2,
                                Access3 = itm.Access3,
                                Access4 = itm.Access4,
                                Access5 = itm.Access5,
                                Access6 = itm.Access6,
                                Access7 = itm.Access7,
                                Access8 = itm.Access8,
                                Access9 = itm.Access9,
                                Access10 = itm.Access10,
                                Access11 = itm.Access11,
                                Access12 = itm.Access12,
                                Access13 = itm.Access13,
                                Access14 = itm.Access14,
                                Access15 = itm.Access15,
                                Access16 = itm.Access16,
                                Access17 = itm.Access17,
                                Access18 = itm.Access18,
                                sAccess1 = itm.sAccess1,
                                sAccess2 = itm.sAccess2,
                                sAccess3 = itm.sAccess3,
                                sAccess4 = itm.sAccess4,
                                sAccess5 = itm.sAccess5,
                                sAccess6 = itm.sAccess6,
                                sAccess7 = itm.sAccess7,
                                sAccess8 = itm.sAccess8,
                                sAccess9 = itm.sAccess9,
                                sAccess10 = itm.sAccess10,
                                sAccess11 = itm.sAccess11,
                                sAccess12 = itm.sAccess12,
                                sAccess13 = itm.sAccess13,
                                sAccess14 = itm.sAccess14,
                                sAccess15 = itm.sAccess15,
                                sAccess16 = itm.sAccess16,
                                sAccess17 = itm.sAccess17,
                                sAccess18 = itm.sAccess18,
                                Remark1 = itm.Remark1,
                                Remark2 = itm.Remark2,
                                Attached = itm.Attached,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                Qty2 = itm.Qty2,
                                RcvNo = itm.RcvNo,
                                VouNo2 = itm.VouNo2,
                                FTime = itm.FTime,
                                OVouNo = itm.OVouNo,
                                ReturnInv = itm.ReturnInv,
                                Payment = itm.Payment,
                                DPeriod = itm.DPeriod,
                                PlaceFrom = itm.PlaceFrom,
                                PlaceTo = itm.PlaceTo,
                                RLat = itm.RLat,
                                RLng = itm.RLng,
                                SLat = itm.SLat,
                                SLng = itm.SLng,
                                Tax = itm.Tax,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                Status = itm.Status,
                                ShipType2 = itm.ShipType2,
                                VouLoc2 = itm.VouLoc2,
                                RDate = itm.RDate,
                                CardNo = itm.CardNo,
                                CardHolder = itm.CardHolder,
                                CardType = itm.CardType,
                                Expiry = itm.Expiry,
                                IDdriver = itm.IDDate,
                                Mail = itm.Mail,
                                PayType = itm.PayType,
                                RecMail = itm.RecMail,
                                ServiceCode = itm.ServiceCode,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                OrDateTime = itm.OrDateTime,
                                DriverNote = itm.DriverNote,
                                DriverNote2 = itm.DriverNote2,
                                IDDriver2 = itm.IDDriver2,
                                OrderIssue = itm.OrderIssue,
                                OrderIssue2 = itm.OrderIssue2,
                                Rate2 = itm.Rate2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                Penal2 = itm.Penal2,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                ShAmount = itm.ShAmount
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<Invoice> GetByRecMobileNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGetByRecMobileNo(this.RecMobileNo);
                    return (from itm in result
                            select new Invoice
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
                                CNN = ConnectionStr,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                Amount = itm.Amount,
                                Amount2 = itm.Amount2,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                CashAmount = itm.CashAmount,
                                RecVouNo = itm.RecVouNo,
                                RecVouDate = itm.RecVouDate,
                                Site = itm.Site,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                S1 = itm.S1,
                                S2 = itm.S2,
                                S3 = itm.S3,
                                S4 = itm.S4,
                                S5 = itm.S5,
                                S6 = itm.S6,
                                S7 = itm.S7,
                                S8 = itm.S8,
                                S9 = itm.S9,
                                S10 = itm.S10,
                                S11 = itm.S11,
                                S12 = itm.S11,
                                S13 = itm.S13,
                                S14 = itm.S14,
                                S15 = itm.S15,
                                S16 = itm.S16,
                                S17 = itm.S17,
                                S18 = itm.S18,
                                S19 = itm.S19,
                                S20 = itm.S20,
                                S21 = itm.S21,
                                S22 = itm.S22,
                                S23 = itm.S23,
                                S24 = itm.S24,
                                S25 = itm.S25,
                                S26 = itm.S26,
                                S27 = itm.S27,
                                S28 = itm.S28,
                                S29 = itm.S29,
                                S30 = itm.S30,
                                S31 = itm.S31,
                                S32 = itm.S32,
                                S33 = itm.S33,
                                S34 = itm.S34,
                                S35 = itm.S35,
                                S36 = itm.S36,
                                S37 = itm.S37,
                                S38 = itm.S38,
                                Access1 = itm.Access1,
                                Access2 = itm.Access2,
                                Access3 = itm.Access3,
                                Access4 = itm.Access4,
                                Access5 = itm.Access5,
                                Access6 = itm.Access6,
                                Access7 = itm.Access7,
                                Access8 = itm.Access8,
                                Access9 = itm.Access9,
                                Access10 = itm.Access10,
                                Access11 = itm.Access11,
                                Access12 = itm.Access12,
                                Access13 = itm.Access13,
                                Access14 = itm.Access14,
                                Access15 = itm.Access15,
                                Access16 = itm.Access16,
                                Access17 = itm.Access17,
                                Access18 = itm.Access18,
                                sAccess1 = itm.sAccess1,
                                sAccess2 = itm.sAccess2,
                                sAccess3 = itm.sAccess3,
                                sAccess4 = itm.sAccess4,
                                sAccess5 = itm.sAccess5,
                                sAccess6 = itm.sAccess6,
                                sAccess7 = itm.sAccess7,
                                sAccess8 = itm.sAccess8,
                                sAccess9 = itm.sAccess9,
                                sAccess10 = itm.sAccess10,
                                sAccess11 = itm.sAccess11,
                                sAccess12 = itm.sAccess12,
                                sAccess13 = itm.sAccess13,
                                sAccess14 = itm.sAccess14,
                                sAccess15 = itm.sAccess15,
                                sAccess16 = itm.sAccess16,
                                sAccess17 = itm.sAccess17,
                                sAccess18 = itm.sAccess18,
                                Remark1 = itm.Remark1,
                                Remark2 = itm.Remark2,
                                Attached = itm.Attached,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                Qty2 = itm.Qty2,
                                RcvNo = itm.RcvNo,
                                VouNo2 = itm.VouNo2,
                                FTime = itm.FTime,
                                OVouNo = itm.OVouNo,
                                ReturnInv = itm.ReturnInv,
                                Payment = itm.Payment,
                                PlaceFrom = itm.PlaceFrom,
                                PlaceTo = itm.PlaceTo,
                                RLat = itm.RLat,
                                RLng = itm.RLng,
                                SLat = itm.SLat,
                                SLng = itm.SLng,
                                Tax = itm.Tax,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                Status = itm.Status,
                                ShipType2 = itm.ShipType2,
                                DPeriod = itm.DPeriod,
                                VouLoc2 = itm.VouLoc2,
                                RDate = itm.RDate,
                                CardNo = itm.CardNo,
                                CardHolder = itm.CardHolder,
                                CardType = itm.CardType,
                                Expiry = itm.Expiry,
                                IDdriver = itm.IDDate,
                                Mail = itm.Mail,
                                PayType = itm.PayType,
                                RecMail = itm.RecMail,
                                ServiceCode = itm.ServiceCode,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                OrDateTime = itm.OrDateTime,
                                DriverNote = itm.DriverNote,
                                DriverNote2 = itm.DriverNote2,
                                IDDriver2 = itm.IDDriver2,
                                OrderIssue = itm.OrderIssue,
                                OrderIssue2 = itm.OrderIssue2,
                                Rate2 = itm.Rate2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                Penal2 = itm.Penal2,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                ShAmount = itm.ShAmount
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<Invoice> GetByIDNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGetByIDNo(this.IDNo);
                    return (from itm in result
                            select new Invoice
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
                                CNN = ConnectionStr,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                Amount = itm.Amount,
                                Amount2 = itm.Amount2,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                CashAmount = itm.CashAmount,
                                RecVouNo = itm.RecVouNo,
                                RecVouDate = itm.RecVouDate,
                                Site = itm.Site,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                S1 = itm.S1,
                                S2 = itm.S2,
                                S3 = itm.S3,
                                S4 = itm.S4,
                                S5 = itm.S5,
                                S6 = itm.S6,
                                S7 = itm.S7,
                                S8 = itm.S8,
                                S9 = itm.S9,
                                S10 = itm.S10,
                                S11 = itm.S11,
                                S12 = itm.S11,
                                S13 = itm.S13,
                                S14 = itm.S14,
                                S15 = itm.S15,
                                S16 = itm.S16,
                                S17 = itm.S17,
                                S18 = itm.S18,
                                S19 = itm.S19,
                                S20 = itm.S20,
                                S21 = itm.S21,
                                S22 = itm.S22,
                                S23 = itm.S23,
                                S24 = itm.S24,
                                S25 = itm.S25,
                                S26 = itm.S26,
                                S27 = itm.S27,
                                S28 = itm.S28,
                                S29 = itm.S29,
                                S30 = itm.S30,
                                S31 = itm.S31,
                                S32 = itm.S32,
                                S33 = itm.S33,
                                S34 = itm.S34,
                                S35 = itm.S35,
                                S36 = itm.S36,
                                S37 = itm.S37,
                                S38 = itm.S38,
                                Access1 = itm.Access1,
                                Access2 = itm.Access2,
                                Access3 = itm.Access3,
                                Access4 = itm.Access4,
                                Access5 = itm.Access5,
                                Access6 = itm.Access6,
                                Access7 = itm.Access7,
                                Access8 = itm.Access8,
                                Access9 = itm.Access9,
                                Access10 = itm.Access10,
                                Access11 = itm.Access11,
                                Access12 = itm.Access12,
                                Access13 = itm.Access13,
                                Access14 = itm.Access14,
                                Access15 = itm.Access15,
                                Access16 = itm.Access16,
                                Access17 = itm.Access17,
                                Access18 = itm.Access18,
                                sAccess1 = itm.sAccess1,
                                sAccess2 = itm.sAccess2,
                                sAccess3 = itm.sAccess3,
                                sAccess4 = itm.sAccess4,
                                sAccess5 = itm.sAccess5,
                                sAccess6 = itm.sAccess6,
                                sAccess7 = itm.sAccess7,
                                sAccess8 = itm.sAccess8,
                                sAccess9 = itm.sAccess9,
                                sAccess10 = itm.sAccess10,
                                sAccess11 = itm.sAccess11,
                                sAccess12 = itm.sAccess12,
                                sAccess13 = itm.sAccess13,
                                sAccess14 = itm.sAccess14,
                                sAccess15 = itm.sAccess15,
                                sAccess16 = itm.sAccess16,
                                sAccess17 = itm.sAccess17,
                                sAccess18 = itm.sAccess18,
                                Remark1 = itm.Remark1,
                                Remark2 = itm.Remark2,
                                Attached = itm.Attached,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                Qty2 = itm.Qty2,
                                RcvNo = itm.RcvNo,
                                VouNo2 = itm.VouNo2,
                                FTime = itm.FTime,
                                OVouNo = itm.OVouNo,
                                ReturnInv = itm.ReturnInv,
                                Payment = itm.Payment,
                                DPeriod = itm.DPeriod,
                                PlaceFrom = itm.PlaceFrom,
                                PlaceTo = itm.PlaceTo,
                                RLat = itm.RLat,
                                RLng = itm.RLng,
                                SLat = itm.SLat,
                                SLng = itm.SLng,
                                Tax = itm.Tax,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                Status = itm.Status,
                                ShipType2 = itm.ShipType2,
                                VouLoc2 = itm.VouLoc2,
                                RDate = itm.RDate,
                                CardNo = itm.CardNo,
                                CardHolder = itm.CardHolder,
                                CardType = itm.CardType,
                                Expiry = itm.Expiry,
                                IDdriver = itm.IDDate,
                                Mail = itm.Mail,
                                PayType = itm.PayType,
                                RecMail = itm.RecMail,
                                ServiceCode = itm.ServiceCode,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate ,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                OrDateTime = itm.OrDateTime,
                                DriverNote = itm.DriverNote,
                                DriverNote2 = itm.DriverNote2,
                                IDDriver2 = itm.IDDriver2,
                                OrderIssue = itm.OrderIssue,
                                OrderIssue2 = itm.OrderIssue2,
                                Rate2 = itm.Rate2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                Penal2 = itm.Penal2,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                ShAmount = itm.ShAmount
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<Invoice> GetByName(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGetByName(this.Name);
                    return (from itm in result
                            select new Invoice
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                CNN = ConnectionStr,
                                VouType = itm.VouType,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                Amount = itm.Amount,
                                Amount2 = itm.Amount2,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                CashAmount = itm.CashAmount,
                                RecVouNo = itm.RecVouNo,
                                RecVouDate = itm.RecVouDate,
                                Site = itm.Site,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                S1 = itm.S1,
                                S2 = itm.S2,
                                S3 = itm.S3,
                                S4 = itm.S4,
                                S5 = itm.S5,
                                S6 = itm.S6,
                                S7 = itm.S7,
                                S8 = itm.S8,
                                S9 = itm.S9,
                                S10 = itm.S10,
                                S11 = itm.S11,
                                S12 = itm.S11,
                                S13 = itm.S13,
                                S14 = itm.S14,
                                S15 = itm.S15,
                                S16 = itm.S16,
                                S17 = itm.S17,
                                S18 = itm.S18,
                                S19 = itm.S19,
                                S20 = itm.S20,
                                S21 = itm.S21,
                                S22 = itm.S22,
                                S23 = itm.S23,
                                S24 = itm.S24,
                                S25 = itm.S25,
                                S26 = itm.S26,
                                S27 = itm.S27,
                                S28 = itm.S28,
                                S29 = itm.S29,
                                S30 = itm.S30,
                                S31 = itm.S31,
                                S32 = itm.S32,
                                S33 = itm.S33,
                                S34 = itm.S34,
                                S35 = itm.S35,
                                S36 = itm.S36,
                                S37 = itm.S37,
                                S38 = itm.S38,
                                Access1 = itm.Access1,
                                Access2 = itm.Access2,
                                Access3 = itm.Access3,
                                Access4 = itm.Access4,
                                Access5 = itm.Access5,
                                Access6 = itm.Access6,
                                Access7 = itm.Access7,
                                Access8 = itm.Access8,
                                Access9 = itm.Access9,
                                Access10 = itm.Access10,
                                Access11 = itm.Access11,
                                Access12 = itm.Access12,
                                Access13 = itm.Access13,
                                Access14 = itm.Access14,
                                Access15 = itm.Access15,
                                Access16 = itm.Access16,
                                Access17 = itm.Access17,
                                Access18 = itm.Access18,
                                sAccess1 = itm.sAccess1,
                                sAccess2 = itm.sAccess2,
                                sAccess3 = itm.sAccess3,
                                sAccess4 = itm.sAccess4,
                                sAccess5 = itm.sAccess5,
                                sAccess6 = itm.sAccess6,
                                sAccess7 = itm.sAccess7,
                                sAccess8 = itm.sAccess8,
                                sAccess9 = itm.sAccess9,
                                sAccess10 = itm.sAccess10,
                                sAccess11 = itm.sAccess11,
                                sAccess12 = itm.sAccess12,
                                sAccess13 = itm.sAccess13,
                                sAccess14 = itm.sAccess14,
                                sAccess15 = itm.sAccess15,
                                sAccess16 = itm.sAccess16,
                                sAccess17 = itm.sAccess17,
                                sAccess18 = itm.sAccess18,
                                Remark1 = itm.Remark1,
                                Remark2 = itm.Remark2,
                                Attached = itm.Attached,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                Qty2 = itm.Qty2,
                                RcvNo = itm.RcvNo,
                                VouNo2 = itm.VouNo2,
                                FTime = itm.FTime,
                                OVouNo = itm.OVouNo,
                                ReturnInv = itm.ReturnInv,
                                Payment = itm.Payment,
                                DPeriod = itm.DPeriod,
                                PlaceFrom = itm.PlaceFrom,
                                PlaceTo = itm.PlaceTo,
                                RLat = itm.RLat,
                                RLng = itm.RLng,
                                SLat = itm.SLat,
                                SLng = itm.SLng,
                                Tax = itm.Tax,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                Status = itm.Status,
                                ShipType2 = itm.ShipType2,
                                VouLoc2 = itm.VouLoc2,
                                RDate = itm.RDate,
                                CardNo = itm.CardNo,
                                CardHolder = itm.CardHolder,
                                CardType = itm.CardType,
                                Expiry = itm.Expiry,
                                IDdriver = itm.IDDate,
                                Mail = itm.Mail,
                                PayType = itm.PayType,
                                RecMail = itm.RecMail,
                                ServiceCode = itm.ServiceCode,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                OrDateTime = itm.OrDateTime,
                                DriverNote = itm.DriverNote,
                                DriverNote2 = itm.DriverNote2,
                                IDDriver2 = itm.IDDriver2,
                                OrderIssue = itm.OrderIssue,
                                OrderIssue2 = itm.OrderIssue2,
                                Rate2 = itm.Rate2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                Penal2 = itm.Penal2,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                ShAmount = itm.ShAmount
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<Invoice> GetByRecName(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGetByRecName(this.RecName);
                    return (from itm in result
                            select new Invoice
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
                                CNN = ConnectionStr,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                Amount = itm.Amount,
                                Amount2 = itm.Amount2,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                CashAmount = itm.CashAmount,
                                RecVouNo = itm.RecVouNo,
                                RecVouDate = itm.RecVouDate,
                                Site = itm.Site,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                S1 = itm.S1,
                                S2 = itm.S2,
                                S3 = itm.S3,
                                S4 = itm.S4,
                                S5 = itm.S5,
                                S6 = itm.S6,
                                S7 = itm.S7,
                                S8 = itm.S8,
                                S9 = itm.S9,
                                S10 = itm.S10,
                                S11 = itm.S11,
                                S12 = itm.S11,
                                S13 = itm.S13,
                                S14 = itm.S14,
                                S15 = itm.S15,
                                S16 = itm.S16,
                                S17 = itm.S17,
                                S18 = itm.S18,
                                S19 = itm.S19,
                                S20 = itm.S20,
                                S21 = itm.S21,
                                S22 = itm.S22,
                                S23 = itm.S23,
                                S24 = itm.S24,
                                S25 = itm.S25,
                                S26 = itm.S26,
                                S27 = itm.S27,
                                S28 = itm.S28,
                                S29 = itm.S29,
                                S30 = itm.S30,
                                S31 = itm.S31,
                                S32 = itm.S32,
                                S33 = itm.S33,
                                S34 = itm.S34,
                                S35 = itm.S35,
                                S36 = itm.S36,
                                S37 = itm.S37,
                                S38 = itm.S38,
                                Access1 = itm.Access1,
                                Access2 = itm.Access2,
                                Access3 = itm.Access3,
                                Access4 = itm.Access4,
                                Access5 = itm.Access5,
                                Access6 = itm.Access6,
                                Access7 = itm.Access7,
                                Access8 = itm.Access8,
                                Access9 = itm.Access9,
                                Access10 = itm.Access10,
                                Access11 = itm.Access11,
                                Access12 = itm.Access12,
                                Access13 = itm.Access13,
                                Access14 = itm.Access14,
                                Access15 = itm.Access15,
                                Access16 = itm.Access16,
                                Access17 = itm.Access17,
                                Access18 = itm.Access18,
                                sAccess1 = itm.sAccess1,
                                sAccess2 = itm.sAccess2,
                                sAccess3 = itm.sAccess3,
                                sAccess4 = itm.sAccess4,
                                sAccess5 = itm.sAccess5,
                                sAccess6 = itm.sAccess6,
                                sAccess7 = itm.sAccess7,
                                sAccess8 = itm.sAccess8,
                                sAccess9 = itm.sAccess9,
                                sAccess10 = itm.sAccess10,
                                sAccess11 = itm.sAccess11,
                                sAccess12 = itm.sAccess12,
                                sAccess13 = itm.sAccess13,
                                sAccess14 = itm.sAccess14,
                                sAccess15 = itm.sAccess15,
                                sAccess16 = itm.sAccess16,
                                sAccess17 = itm.sAccess17,
                                sAccess18 = itm.sAccess18,
                                Remark1 = itm.Remark1,
                                Remark2 = itm.Remark2,
                                Attached = itm.Attached,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                Qty2 = itm.Qty2,
                                RcvNo = itm.RcvNo,
                                VouNo2 = itm.VouNo2,
                                FTime = itm.FTime,
                                OVouNo = itm.OVouNo,
                                ReturnInv = itm.ReturnInv,
                                Payment = itm.Payment,
                                DPeriod = itm.DPeriod,
                                PlaceFrom = itm.PlaceFrom,
                                PlaceTo = itm.PlaceTo,
                                RLat = itm.RLat,
                                RLng = itm.RLng,
                                SLat = itm.SLat,
                                SLng = itm.SLng,
                                Tax = itm.Tax,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                Status = itm.Status,
                                ShipType2 = itm.ShipType2,
                                VouLoc2 = itm.VouLoc2,
                                RDate = itm.RDate,
                                CardNo = itm.CardNo,
                                CardHolder = itm.CardHolder,
                                CardType = itm.CardType,
                                Expiry = itm.Expiry,
                                IDdriver = itm.IDDate,
                                Mail = itm.Mail,
                                PayType = itm.PayType,
                                RecMail = itm.RecMail,
                                ServiceCode = itm.ServiceCode,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                OrDateTime = itm.OrDateTime,
                                DriverNote = itm.DriverNote,
                                DriverNote2 = itm.DriverNote2,
                                IDDriver2 = itm.IDDriver2,
                                OrderIssue = itm.OrderIssue,
                                OrderIssue2 = itm.OrderIssue2,
                                Rate2 = itm.Rate2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                Penal2 = itm.Penal2,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                ShAmount = itm.ShAmount
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Invoices from vInvoice1 View
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<vInvoice1> GetInvs(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vInvoice1GetAll(this.Branch, this.VouLoc);
                    return (from itm in result
                            select new vInvoice1
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                Amount = itm.Amount,
                                Amount2 = itm.Amount2,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                CashAmount = itm.CashAmount,
                                RecVouNo = itm.RecVouNo,
                                RecVouDate = itm.RecVouDate,
                                Site = itm.Site,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                S1 = itm.S1,
                                S2 = itm.S2,
                                S3 = itm.S3,
                                S4 = itm.S4,
                                S5 = itm.S5,
                                S6 = itm.S6,
                                S7 = itm.S7,
                                S8 = itm.S8,
                                S9 = itm.S9,
                                S10 = itm.S10,
                                S11 = itm.S11,
                                S12 = itm.S11,
                                S13 = itm.S13,
                                S14 = itm.S14,
                                S15 = itm.S15,
                                S16 = itm.S16,
                                S17 = itm.S17,
                                S18 = itm.S18,
                                S19 = itm.S19,
                                S20 = itm.S20,
                                S21 = itm.S21,
                                S22 = itm.S22,
                                S23 = itm.S23,
                                S24 = itm.S24,
                                S25 = itm.S25,
                                S26 = itm.S26,
                                S27 = itm.S27,
                                S28 = itm.S28,
                                S29 = itm.S29,
                                S30 = itm.S30,
                                S31 = itm.S31,
                                S32 = itm.S32,
                                S33 = itm.S33,
                                S34 = itm.S34,
                                S35 = itm.S35,
                                S36 = itm.S36,
                                S37 = itm.S37,
                                S38 = itm.S38,
                                Access1 = itm.Access1,
                                Access2 = itm.Access2,
                                Access3 = itm.Access3,
                                Access4 = itm.Access4,
                                Access5 = itm.Access5,
                                Access6 = itm.Access6,
                                Access7 = itm.Access7,
                                Access8 = itm.Access8,
                                Access9 = itm.Access9,
                                Access10 = itm.Access10,
                                Access11 = itm.Access11,
                                Access12 = itm.Access12,
                                Access13 = itm.Access13,
                                Access14 = itm.Access14,
                                Access15 = itm.Access15,
                                Access16 = itm.Access16,
                                Access17 = itm.Access17,
                                Access18 = itm.Access18,
                                sAccess1 = itm.sAccess1,
                                sAccess2 = itm.sAccess2,
                                sAccess3 = itm.sAccess3,
                                sAccess4 = itm.sAccess4,
                                sAccess5 = itm.sAccess5,
                                sAccess6 = itm.sAccess6,
                                sAccess7 = itm.sAccess7,
                                sAccess8 = itm.sAccess8,
                                sAccess9 = itm.sAccess9,
                                sAccess10 = itm.sAccess10,
                                sAccess11 = itm.sAccess11,
                                sAccess12 = itm.sAccess12,
                                sAccess13 = itm.sAccess13,
                                sAccess14 = itm.sAccess14,
                                sAccess15 = itm.sAccess15,
                                sAccess16 = itm.sAccess16,
                                sAccess17 = itm.sAccess17,
                                sAccess18 = itm.sAccess18,
                                Remark1 = itm.Remark1,
                                Remark2 = itm.Remark2,
                                Attached = itm.Attached,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                Qty2 = itm.Qty2,
                                CustomerName1 = itm.CustomerName1,
                                CustomerName2 = itm.CustomerName2,
                                DestinationName1 = itm.DestinationName1,
                                DestinationName2 = itm.DestinationName2,
                                PlaceofLoadingName1 = itm.PlaceofLoadingName1,
                                PlaceofLoadingName2 = itm.PlaceofLoadingName2,
                                SiteName1 = itm.SiteName1,
                                SiteName2 = itm.SiteName2,
                                VouNo2 = itm.VouNo2,
                                FTime = itm.FTime,
                                Payment = itm.Payment
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<myInv2> GetInvMove(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vInvoice2GetMove(this.Branch, this.VouLoc);
                    return (from itm in result
                            where !(bool)itm.FClosed
                            select new myInv2
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                Amount = itm.Amount,
                                Amount2 = itm.Amount2,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                CashAmount = itm.CashAmount,
                                RecVouNo = itm.RecVouNo,
                                RecVouDate = itm.RecVouDate,
                                Site = itm.Site,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                Qty2 = itm.Qty2,
                                Status = false,
                                CustomerName1 = itm.CustomerName1,
                                CustomerName2 = itm.CustomerName2,
                                DestinationName1 = itm.DestinationName1,
                                DestinationName2 = itm.DestinationName2,
                                PlaceofLoadingName1 = itm.PlaceofLoadingName1,
                                PlaceofLoadingName2 = itm.PlaceofLoadingName2,
                                SiteName1 = itm.SiteName1,
                                SiteName2 = itm.SiteName2,
                                InvoiceVouLoc = itm.VouLoc,
                                VouNo20 = itm.VouNo2,
                                InvoiceFNo = itm.FNo,
                                FNo2 = itm.FNo,                                 
                                FTime = itm.FTime,    
                                FClosed = itm.FClosed,
                                //Transit = itm.Transit,
                                Flag = ""
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<myInv2> GetInvMove2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vInvoice2GetMove2(this.Branch, this.VouLoc , this.Destination);
                    return (from itm in result
                            select new myInv2
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = (short)itm.VouType,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                Amount = itm.Amount,
                                Amount2 = itm.Amount2,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                CashAmount = itm.CashAmount,
                                RecVouNo = itm.RecVouNo,
                                RecVouDate = itm.RecVouDate,
                                Site = itm.Site,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = (short)itm.Qty,
                                Qty2 = (short)itm.Qty2,
                                Status = false,
                                CustomerName1 = itm.CustomerName1,
                                CustomerName2 = itm.CustomerName2,
                                DestinationName1 = itm.DestinationName1,
                                DestinationName2 = itm.DestinationName2,
                                PlaceofLoadingName1 = itm.PlaceofLoadingName1,
                                PlaceofLoadingName2 = itm.PlaceofLoadingName2,
                                SiteName1 = itm.SiteName1,
                                SiteName2 = itm.SiteName2,
                                InvoiceVouLoc = itm.VouLoc,
                                VouNo20 = itm.VouNo2,
                                InvoiceFNo = (short)itm.FNo,
                                FNo2 = (short)itm.FNo,
                                FTime = itm.FTime,
                                //Transit = itm.Transit,
                                Flag = itm.Flag
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<myInv2> GetInvMove3(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vInvoice2GetMove3(this.Branch, this.VouLoc, this.PlaceofLoading);
                    return (from itm in result
                            select new myInv2
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = (short)itm.VouType,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                Amount = itm.Amount,
                                Amount2 = itm.Amount2,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                CashAmount = itm.CashAmount,
                                RecVouNo = itm.RecVouNo,
                                RecVouDate = itm.RecVouDate,
                                Site = itm.Site,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = (short)itm.Qty,
                                Qty2 = (short)itm.Qty2,
                                Status = false,
                                CustomerName1 = itm.CustomerName1,
                                CustomerName2 = itm.CustomerName2,
                                DestinationName1 = itm.DestinationName1,
                                DestinationName2 = itm.DestinationName2,
                                PlaceofLoadingName1 = itm.PlaceofLoadingName1,
                                PlaceofLoadingName2 = itm.PlaceofLoadingName2,
                                SiteName1 = itm.SiteName1,
                                SiteName2 = itm.SiteName2,
                                InvoiceVouLoc = itm.VouLoc,
                                VouNo20 = itm.VouNo2,
                                InvoiceFNo = (short)itm.FNo,
                                FNo2 = (short)itm.FNo,
                                FTime = itm.FTime,
                                Flag = itm.Flag,
                                SLat = itm.LocFrom.Split('#')[0],
                                SLong = itm.LocFrom.Split('#')[1]
                                //Transit = itm.Transit
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<myInv2> GetInv4Rcv(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vInvoice2Get4Rcv(this.Branch, this.VouLoc,this.VouNo);
                    return (from itm in result
                            select new myInv2
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = (short)itm.VouType,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                Amount = itm.Amount,
                                Amount2 = itm.Amount2,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                CashAmount = itm.CashAmount,
                                RecVouNo = itm.RecVouNo,
                                RecVouDate = itm.RecVouDate,
                                Site = itm.Site,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = (short)itm.Qty,
                                Qty2 = (short)itm.Qty2,
                                Status = false,
                                CustomerName1 = itm.CustomerName1,
                                CustomerName2 = itm.CustomerName2,
                                DestinationName1 = itm.DestinationName1,
                                DestinationName2 = itm.DestinationName2,
                                PlaceofLoadingName1 = itm.PlaceofLoadingName1,
                                PlaceofLoadingName2 = itm.PlaceofLoadingName2,
                                SiteName1 = itm.SiteName1,
                                SiteName2 = itm.SiteName2,
                                InvoiceVouLoc = itm.VouLoc,
                                VouNo20 = itm.VouNo2,
                                InvoiceFNo = (short)itm.FNo,
                                FNo2 = (short)itm.FNo,
                                FTime = itm.FTime,
                                Flag = itm.Flag
                                //Transit = itm.Transit                                
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
    public class vInvoice1:Invoice
    {
        public string SiteName1 { get; set; }
        public string SiteName2 { get; set; }
        public string CustomerName1 { get; set; }
        public string CustomerName2 { get; set; }
        public string PlaceofLoadingName1 { get; set; }
        public string PlaceofLoadingName2 { get; set; }
        public string DestinationName1 { get; set; }
        public string DestinationName2 { get; set; }
    }

    [Serializable]
    public class myInv2
    {
        public short Branch { get; set; }
        public short LocType { get; set; }
        public string VouLoc { get; set; }
        public int VouNo { get; set; }
        public System.Nullable<short> VouType { get; set; }
        public short DocType { get; set; }
        public string HDate { get; set; }
        public string GDate { get; set; }
        public string RDate { get; set; }
        public string Name { get; set; }
        public string IDNo { get; set; }
        public System.Nullable<short> IDType { get; set; }
        public string IDFrom { get; set; }
        public string IDDate { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string PlaceofLoading { get; set; }
        public string Destination { get; set; }
        public string FromLoc { get; set; }
        public string ToLoc { get; set; }
        public System.Nullable<double> Amount { get; set; }
        public System.Nullable<double> Amount2 { get; set; }
        public string RecName { get; set; }
        public string RecAddress { get; set; }
        public string RecMobileNo { get; set; }
        public string CarType { get; set; }
        public string Brand { get; set; }
        public string PlateNo { get; set; }
        public string ChassisNo { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public System.Nullable<double> CashAmount { get; set; }
        public System.Nullable<double> ShAmount { get; set; }
        public System.Nullable<int> RecVouNo { get; set; }
        public string RecVouDate { get; set; }
        public string Site { get; set; }
        public System.Nullable<double> SiteAmount { get; set; }
        public string Customer { get; set; }
        public System.Nullable<double> CustomerAmount { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public string SiteName1 { get; set; }
        public string SiteName2 { get; set; }
        public string CustomerName1 { get; set; }
        public string CustomerName2 { get; set; }
        public string PlaceofLoadingName1 { get; set; }
        public string PlaceofLoadingName2 { get; set; }
        public string DestinationName1 { get; set; }
        public string DestinationName2 { get; set; }
        public System.Nullable<short> Qty { get; set; }
        public System.Nullable<short> Qty2 { get; set; }
        public string InvoiceVouLoc { get; set; }
        public bool Status { get; set; }
        public System.Nullable<short> InvoiceFNo { get; set; }
        public System.Nullable<int> CarMoveNo { get; set; }
        public string CarMoveLoc { get; set; }
        public int FNo { get; set; }
        public string VouNo20 { get; set; }
        public string FTime { get; set; }
        public string InvFTime { get; set; }
        public System.Nullable<short> FNo2 { get; set; }
        public System.Nullable<short> Payment { get; set; }
        public bool? Transit { get; set;}
        public string MobileNo2 { get; set; }
        public string SendStatus { get; set; }
        public string RcvNo2 { get; set; }
        public string Flag { get; set; }
        public string Status2 {
            get
            {
                return sms.ShowResult(this.SendStatus);
            }
        }
        public string VouNo2
        {
            get
            {
                return this.Flag + (this.LocType == 3 ? "00" : "") +  int.Parse(this.InvoiceVouLoc).ToString() + "/" + this.VouNo.ToString();
            }
        }

        public System.Nullable<double> Price { get; set; }
        public string Mail { get; set; }
        public string RecMail { get; set; }
        public System.Nullable<bool> PlaceFrom { get; set; }
        public System.Nullable<double> Weight { get; set; }
        public System.Nullable<short> Unit { get; set; }
        public System.Nullable<short> ShUse { get; set; }
        public System.Nullable<short> ShType { get; set; }
        public string ShRemark { get; set; }
        public string ShNote { get; set; }
        public System.Nullable<double> ShabakaAmount { get; set; }
        public string LocFrom { get; set; }
        public string LocTo { get; set; }
        public System.Nullable<short> DPeriod { get; set; }
        public string VouLoc2 { get; set; }
        public System.Nullable<short> CoverType { get; set; }
        public System.Nullable<short> CoverSize { get; set; }
        public System.Nullable<bool> bto { get; set; }
        public System.Nullable<short> sitm { get; set; }
        public System.Nullable<short> shipType { get; set; }
        public string ItemName { get; set; }
        public System.Nullable<int> ItemQty { get; set; }
        public System.Nullable<int> Claim { get; set; }
        public System.Nullable<int> myStatus { get; set; }
        public string DTPickUp { get; set; }
        public string DTDropOff { get; set; }
        public System.Nullable<bool> FClosed { get; set; }
        public string SLat { get; set; }
        public string SLong { get; set; }

        public myInv2()
        {
            this.FNo = 1;
            this.DocType = 0;
            this.Branch = 1;
            this.LocType = 2;
            this.VouLoc = "";
            this.VouNo = 0;
            this.VouType = 0;
            this.HDate = "";
            this.GDate = "";
            this.RDate = "";
            this.Name = "";
            this.IDNo = "";
            this.IDType = 0;
            this.RcvNo2 = "";
            this.IDFrom = "";
            this.IDDate = "";
            this.Address = "";
            this.MobileNo = "";
            this.PlaceofLoading = "";
            this.Destination = "";
            this.FromLoc = "";
            this.ToLoc = "";
            this.Amount = 0;
            this.Amount2 = 0;
            this.RecName = "";
            this.RecAddress = "";
            this.RecMobileNo = "";
            this.CarType = "";
            this.Brand = "";
            this.PlateNo = "";
            this.ChassisNo = "";
            this.Color = "";
            this.Model = "";
            this.CashAmount = 0;
            this.RecVouNo = 0;
            this.RecVouDate = "";
            this.Site = "";
            this.SiteAmount = 0;
            this.Customer = "";
            this.CustomerAmount = 0;
            this.UserName = "";
            this.UserDate = "";
            this.SiteName1 = "";
            this.SiteName2 = "";
            this.CustomerName1 = "";
            this.CustomerName2 = "";
            this.PlaceofLoadingName1 = "";
            this.PlaceofLoadingName2 = "";
            this.DestinationName1 = "";
            this.DestinationName2 = "";
            this.Qty = 0;
            this.Qty2 = 0;
            this.Status = false;
            this.InvoiceVouLoc = "0";
            this.InvoiceFNo = 1;
            this.CarMoveNo = 0;
            this.CarMoveLoc = "-1";
            this.VouNo20 = "";
            this.FNo2 = 0;
            this.FTime = "";
            this.MobileNo2 = "";
            this.SendStatus = "0";
            this.Payment = 0;
            this.Flag = "";
            this.Price = 0;
            this.Mail = "";
            this.RecMail = "";
            this.PlaceFrom = false;
            this.Weight = 0;
            this.Unit = 0;
            this.ShUse = 0;
            this.ShType = 0;
            this.ShRemark = "";
            this.ShNote = "";
            this.ShabakaAmount = 0;
            this.LocFrom = "";
            this.LocTo = "";
            this.DPeriod = 0;
            this.VouLoc2 = "";
            this.CoverType = 0;
            this.CoverSize = 0;
            this.bto = false;
            this.sitm = 0;
            this.shipType = 0;
            this.ItemName = "";
            this.ItemQty = 0;
            this.Claim = 0;
            this.myStatus = 0;
            this.DTPickUp = "";
            this.DTDropOff = "";
            this.FClosed = false;
            this.SLat = "";
            this.SLong = "";
        }
    }

    [Serializable]
    public class InvDetails
    {

        public short Branch { get; set; }
        public string VouLoc { get; set; }
        public int VouNo { get; set; }
        public short FNo { get; set; }
        public string CarType { get; set; }
        public string Brand { get; set; }
        public string PlateNo { get; set; }
        public string ChassisNo { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public double? Price { get; set; }
        public double? Price2 { get; set; }
        public string RcvNo { get; set; }
        public string VouNo2 { get; set; }
        public string CarMove { get; set; }
        public string RGetDate { get; set; }
        public bool? Transit { get; set; }
        public string Status { get; set; }
        public string VouLoc2 { get; set; }
        public bool? FClosed { get; set; }
        public string ClosedDateTime { get; set; }
        public string ClosedUser { get; set; }
        public string InvNo
        {
            get
            {
                return int.Parse(VouLoc).ToString() + "/" + VouNo.ToString();
            }
        }

        public InvDetails()
        {
            this.Branch = 0;
            this.VouLoc = "";
            this.VouLoc2 = "";
            this.VouNo = 0;
            this.FNo = 0;
            this.CarType = "-1";
            this.Brand = "";
            this.PlateNo = "";
            this.ChassisNo = "";
            this.Color = "";
            this.Model = "-1";
            this.Price = 0;
            this.Price2 = 0;
            this.RcvNo = "";
            this.VouNo2 = "";
            this.CarMove = "";
            this.RGetDate = "";
            this.Transit = false;
            this.Status = "0";
            this.FClosed = false;
            this.ClosedDateTime = "";
            this.ClosedUser = "";
        }

        /// <summary>
        /// Add Invoice center in Invoice Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.InvDetailsInsert(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.FNo,
                                            this.CarType,
                                            this.Brand,
                                            this.PlateNo,
                                            this.ChassisNo,
                                            this.Color,
                                            this.Model,
                                            this.Price,
                                            this.Price2,
                                            this.RcvNo,
                                            this.VouNo2,
                                            this.CarMove,
                                            this.RGetDate,
                                            this.Transit,
                                            this.Status,
                                            this.VouLoc2,
                                            this.FClosed,
                                            this.ClosedUser,
                                            this.ClosedDateTime
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
        /// Add Invoice center in Invoice Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool SetTransit(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.InvDetailsUpdateTransit(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.FNo,
                                            this.Transit
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
        /// Add Invoice center in Invoice Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool SetStatus(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.InvDetailsUpdateStatus(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.FNo,
                                            this.Status
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
        /// Delete Invoice center from Invoice Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.InvDetailsDelete(this.Branch, this.VouLoc, this.VouNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<InvDetails> Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvDetailsGet(this.Branch, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new InvDetails
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                FNo = itm.FNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                Price = itm.Price,
                                Price2 = itm.Price2,
                                RcvNo = itm.RcvNo,
                                VouNo2 = itm.VouNo2,
                                CarMove = itm.CarMove,
                                RGetDate = itm.RGetDate,
                                Transit = itm.Transit,
                                Status = itm.Status,
                                VouLoc2 = itm.VouLoc2,
                                ClosedDateTime = itm.ClosedDateTime,
                                ClosedUser = itm.ClosedUser,
                                FClosed = itm.FClosed
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<InvDetails> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvDetailsGetAll(this.Branch);
                    return (from itm in result
                            select new InvDetails
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                FNo = itm.FNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                Price = itm.Price,
                                Price2 = itm.Price2,
                                RcvNo = itm.RcvNo,
                                VouNo2 = itm.VouNo2,
                                CarMove = itm.CarMove,
                                RGetDate = itm.RGetDate,
                                Transit = itm.Transit,
                                Status = itm.Status,
                                VouLoc2 = itm.VouLoc2,
                                ClosedDateTime = itm.ClosedDateTime,
                                ClosedUser = itm.ClosedUser,
                                FClosed = itm.FClosed
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<InvDetails> GetClosed(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvDetailsGetClosed();
                    return (from itm in result
                            select new InvDetails
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                FNo = itm.FNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                Price = itm.Price,
                                Price2 = itm.Price2,
                                RcvNo = itm.RcvNo,
                                VouNo2 = itm.VouNo2,
                                CarMove = itm.CarMove,
                                RGetDate = itm.RGetDate,
                                Transit = itm.Transit,
                                Status = itm.Status,
                                VouLoc2 = itm.VouLoc2,
                                ClosedDateTime = itm.ClosedDateTime,
                                ClosedUser = itm.ClosedUser,
                                FClosed = itm.FClosed
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public InvDetails GetFNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvDetailsGetFNo(this.Branch, this.VouLoc, this.VouNo,this.FNo);
                    return (from itm in result
                            select new InvDetails
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                FNo = itm.FNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                Price = itm.Price,
                                Price2 = itm.Price2,
                                RcvNo = itm.RcvNo,
                                VouNo2 = itm.VouNo2,
                                CarMove = itm.CarMove,
                                RGetDate = itm.RGetDate,
                                Transit = itm.Transit,
                                Status = itm.Status,
                                VouLoc2 = itm.VouLoc2,
                                ClosedDateTime = itm.ClosedDateTime,
                                ClosedUser = itm.ClosedUser,
                                FClosed = itm.FClosed
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<InvDetails> GetByPlateNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvDetailsGetByPlateNo(this.Branch, this.PlateNo);
                    return (from itm in result
                            select new InvDetails
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                FNo = itm.FNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                Price = itm.Price,
                                Price2 = itm.Price2,
                                RcvNo = itm.RcvNo,
                                VouNo2 = itm.VouNo2,
                                CarMove = itm.CarMove,
                                RGetDate = itm.RGetDate,
                                Transit = itm.Transit,
                                Status = itm.Status,
                                VouLoc2 = itm.VouLoc2,
                                ClosedDateTime = itm.ClosedDateTime,
                                ClosedUser = itm.ClosedUser,
                                FClosed = itm.FClosed
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<InvDetails> GetByChassisNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvDetailsGetByChassisNo(this.Branch, this.ChassisNo);
                    return (from itm in result
                            select new InvDetails
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                FNo = itm.FNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                Price = itm.Price,
                                Price2 = itm.Price2,
                                RcvNo = itm.RcvNo,
                                VouNo2 = itm.VouNo2,
                                CarMove = itm.CarMove,
                                RGetDate = itm.RGetDate,
                                Transit = itm.Transit,
                                Status = itm.Status,
                                VouLoc2 = itm.VouLoc2,
                                ClosedDateTime = itm.ClosedDateTime,
                                ClosedUser = itm.ClosedUser,
                                FClosed = itm.FClosed
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
    public class CarStatus
    {
        public int? FNo { get; set; }
        public string TranDate { get; set; }
        public string DocNumber { get; set;}
        public string PlateNo { get; set; }
        public string ChassisNo { get; set; }
        public string Area { get; set; }
        public string Remark { get; set; }
    }

    [Serializable]
    public class InvoiceStatement
    {
        public int? FNo { get; set; }
        public string Customer { get; set; }
        public string CarType { get; set; }
        public string Location { get; set; }
        public string InvoiceNo { get; set; }
        public string VouNo { get; set; }
        public double SiteAmount { get; set; }
        public double CashAmount { get; set; }
        public double CreditAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double CustomerAmount { get; set; }
        public string DepositNo { get; set; }
        public double DepositAmount { get; set; }
        public string Site { get; set; }
        public double OpenBal { get; set; }
        public double DepositAmount2 { get; set;} 
        public double ShabakaAmount { get; set; }
        public double ShabakaDiscount { get; set; }        
        public double LoanAmount { get; set; }
        public string PayNo { get; set; }
        public string CarMoveNo { get; set; }
        public double PayAdd { get; set; }
        public double PayAmount { get; set; }
        public double LoanAmount2 {get;set;}
        public double VAT { get; set; }
        public int? Qty { get; set; }
    }

    [Serializable]
    public class vInvError
   {
        public int FNo { get; set; }
        public short Branch { get; set; }
        public string VouLoc { get; set; }
        public int VouNo { get; set; }
        public System.Nullable<short> VouType { get; set; }
        public string GDate { get; set; }
        public System.Nullable<double> CashAmount { get; set; }
        public System.Nullable<double> Amount { get; set; }
        public System.Nullable<double> Tax { get; set; }
        public System.Nullable<double> SiteAmount { get; set; }
        public System.Nullable<double> CustomerAmount { get; set; }
        public System.Nullable<double> JvAmount { get; set; }
        public System.Nullable<short> FType { get; set; }
        public System.Nullable<short> LocType { get; set; }
        public System.Nullable<short> LocNumber { get; set; }
        public System.Nullable<int> Qty { get; set; }
        public System.Nullable<int> Number { get; set; }
        public System.Nullable<double> LowAmount { get; set; }
        public System.Nullable<double> Net
        {
            get
            {
                return Amount - LowAmount;
            }
        }
        public string VouDate { get; set; }
        public string Site { get; set; }
        public string SiteName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Customer { get; set; }
        public int? CarMove { get; set; }
        public string CustomerName { get; set; }
        public string RecName { get; set; }
        public string InvNo { get; set; }
        public string InvNo2
        {
            get
            {
                return int.Parse(VouLoc).ToString() + "/" + VouNo.ToString();
            }
        }
        public string VouNo2 { 
            get {
                return LocNumber.ToString() + "/" + Number.ToString();
            }            
        }
        public double Diff
        {
            get
            {
                if (this.SiteAmount > 0)
                {
                    return (double)(this.SiteAmount - this.JvAmount);
                }
                else return (double)(this.CustomerAmount - this.JvAmount);
            }
        }

        public vInvError()
        {
            FNo = 0;
            Branch = 1;
            VouNo = 0;
            Tax = 0;
        }

        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<vInvError> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vInvErrorGetAll();
                    int i = 1;
                    return (from itm in result
                            select new vInvError
                            {
                                  FNo = i++,
                                  Amount = itm.Amount,
                                  Branch = itm.Branch,
                                  CustomerAmount = itm.CustomerAmount,
                                  FType = itm.FType,
                                  GDate = itm.GDate,
                                  InvNo = itm.InvNo,
                                  JvAmount = itm.JvAmount,
                                  LocNumber = itm.LocNumber,
                                  LocType = itm.LocType,
                                  Number = itm.Number,
                                  SiteAmount = itm.SiteAmount,
                                  VouLoc = itm.VouLoc,
                                  VouNo = itm.VouNo,
                                  VouType = itm.VouType
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<vInvError> GetAll2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vInvError2GetAll();
                    int i = 1;
                    return (from itm in result
                            select new vInvError
                            {
                                FNo = i++,
                                Amount = itm.Amount,
                                Branch = itm.Branch,
                                CustomerAmount = itm.CustomerAmount,
                                GDate = itm.GDate,
                                JvAmount = itm.xAmount,
                                SiteAmount = itm.SiteAmount,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
                                CustomerName = GetDoc(itm.Branch,itm.VouLoc,itm.VouNo,ConnectionStr)
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetDoc(short branch,string Site,int? Doc,string ConnectionStr)
        {
                string vStr = "";
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    List<Jv> lJv = new List<Jv>();
                    var result = myContext.JvGetByInvNo(branch,100 , int.Parse(Site).ToString()+"/"+Doc.ToString());
                    lJv = (from itm in result
                           select new Jv {
                               Person = "ق " + itm.Number.ToString()
                           }).ToList();

                    var result2 = myContext.JvGetByInvNo(branch,101 , int.Parse(Site).ToString()+"/"+Doc.ToString());
                    lJv.AddRange((from itm in result2
                                  select new Jv
                                  {
                                      Person = "س " + itm.LocNumber.ToString() + "/" + itm.Number.ToString()
                                  }).ToList());

                    foreach (Jv itm in lJv)
                    {
                        vStr = vStr + itm.Person + "   "; 
                    }
                }           
                return vStr;
        }

        public bool CheckMySite(List<vInvError> linvError,string mySite)
        {
            bool vResult = true;
            foreach (vInvError itm in linvError)
            {
                if (itm.Site == mySite)
                {
                    vResult = false;
                    break;
                }
            }
            return vResult;
        }

        public List<vInvError> NotPaidGetSite(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    List<vInvError> linvError = new List<vInvError>();
                    var result = myContext.vInvNotVouGetSite(this.VouLoc);
                    int i = 1;
                    linvError =  (from itm in result
                            select new vInvError
                            {
                                FNo = i++,
                                Site = itm.Site,
                                SiteName = itm.SiteName                                 
                            }).ToList();

                    var result1 = myContext.vShipNotVouGetSite(this.VouLoc);
                    linvError.AddRange((from itm in result1
                                 where CheckMySite(linvError,itm.Site)
                                 select new vInvError
                                 {
                                     FNo = i++,
                                     Site = itm.Site,
                                     SiteName = itm.SiteName
                                 }).ToList());
                    var result2 = myContext.vLShipNotVouGetSite(this.VouLoc);
                    linvError.AddRange((from itm in result2
                                        where CheckMySite(linvError, itm.Site)
                                        select new vInvError
                                        {
                                            FNo = i++,
                                            Site = itm.Site,
                                            SiteName = itm.SiteName
                                        }).ToList());
                    return linvError;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool CheckMyCustomer(List<vInvError> linvError, string myCustomer)
        {
            bool vResult = true;
            foreach (vInvError itm in linvError)
            {
                if (itm.Customer == myCustomer)
                {
                    vResult = false;
                    break;
                }
            }
            return vResult;
        }

        public List<vInvError> NotPaidGetCustomer(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    List<vInvError> linvError = new List<vInvError>();
                    var result = myContext.vInvNotVouGetCustomer(this.VouLoc);
                    int i = 1;
                    linvError = (from itm in result
                            select new vInvError
                            {
                                FNo = i++,
                                Customer = itm.Customer,
                                CustomerName = itm.CustomerName
                            }).ToList();

                    var result1 = myContext.vShipNotVouGetCustomer(this.VouLoc);
                    linvError = (from itm in result1
                                 where CheckMySite(linvError, itm.Customer)
                                 select new vInvError
                                 {
                                     FNo = i++,
                                     Customer = itm.Customer,
                                     CustomerName = itm.CustomerName
                                 }).ToList();

                    var result2 = myContext.vLShipNotVouGetCustomer(this.VouLoc);
                    linvError = (from itm in result2
                                 where CheckMySite(linvError, itm.Customer)
                                 select new vInvError
                                 {
                                     FNo = i++,
                                     Customer = itm.Customer,
                                     CustomerName = itm.CustomerName
                                 }).ToList();

                    return linvError;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<vInvError> NotPaidGetAll(string FDate,string EDate, bool ChkCarMove, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vInvNotVouGetAll(this.VouLoc,FDate, EDate, this.Site, this.Customer);
                    int i = 1;
                    return (from itm in result
                            where ChkCarMove || (itm.CarMove != null)
                            select new vInvError
                            {
                                FNo = i++,
                                CustomerAmount = itm.CustomerAmount,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                GDate = itm.GDate,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerName = itm.SiteAmount!=0 ? itm.Name : itm.CustomerName ,                                
                                Site = itm.Site,
                                SiteName = itm.SiteName,                                 
                                CashAmount = itm.CashAmount,
                                Amount = itm.SiteAmount + itm.CashAmount + itm.CustomerAmount,
                                RecName = itm.RecName,
                                CarMove = itm.CarMove,
                                LowAmount = itm.CustomerAmount,
                                Qty = itm.Qty,
                                Destination = itm.Destination,
                                Source = itm.Source
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<vInvError> NotPaidGetAll2(string FDate,string EDate, bool ChkCarMove, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    List<vInvError> linvError = new List<vInvError>();
                    int i = 1;
                    var result1 = myContext.vShipNotVouGetAll(this.VouLoc, FDate, EDate, this.Site, this.Customer);
                    linvError.AddRange((from itm in result1                                        
                                 select new vInvError
                                 {
                                     FNo = i++,
                                     CustomerAmount = itm.CustomerAmount,
                                     VouLoc = itm.VouLoc,
                                     VouNo = itm.VouNo,
                                     InvNo = "E"+short.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo.ToString(),
                                     GDate = itm.GDate,
                                     SiteAmount = itm.SiteAmount,
                                     Customer = itm.Customer,
                                     CustomerName = itm.SiteAmount != 0 ? itm.Name : itm.CustomerName,
                                     Site = itm.Site,
                                     SiteName = itm.SiteName,
                                     CashAmount = itm.CashAmount,
                                     Amount = itm.SiteAmount + itm.CashAmount + itm.CustomerAmount,
                                     RecName = itm.RecName,
                                     CarMove = 0,
                                     LowAmount = itm.CustomerAmount,
                                     Qty = itm.Qty,
                                     Tax = 0,
                                     Destination = itm.Destination,
                                     Source = itm.Source
                                 }).ToList());
                    var result2 = myContext.vLShipNotVouGetAll(this.VouLoc, FDate, EDate, this.Site, this.Customer);
                    linvError.AddRange((from itm in result2
                                        select new vInvError
                                        {
                                            FNo = i++,
                                            CustomerAmount = itm.CustomerAmount,
                                            VouLoc = itm.VouLoc,
                                            VouNo = itm.VouNo,
                                            InvNo = "L" + short.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo.ToString(),
                                            GDate = itm.GDate,
                                            SiteAmount = itm.SiteAmount,
                                            Customer = itm.Customer,
                                            CustomerName = itm.SiteAmount != 0 ? itm.Name : itm.CustomerName,
                                            Site = itm.Site,
                                            Tax = 0,
                                            SiteName = itm.SiteName,
                                            CashAmount = itm.CashAmount,
                                            Amount = itm.SiteAmount + itm.CashAmount + itm.CustomerAmount,
                                            RecName = itm.RecName,
                                            CarMove = 0,
                                            LowAmount = itm.CustomerAmount,
                                            Qty = itm.Qty,
                                            Destination = itm.Destination,
                                            Source = itm.Source
                                        }).ToList());

                    var result = myContext.vInvNotVouGetAll(this.VouLoc,FDate, EDate, this.Site, this.Customer);
                    linvError.AddRange((from itm in result
                            where ChkCarMove || (itm.CarMove != null)
                            select new vInvError
                            {
                                FNo = i++,
                                CustomerAmount = itm.CustomerAmount,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                InvNo = short.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo.ToString(),
                                GDate = itm.GDate,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerName = itm.SiteAmount!=0 ? itm.Name : itm.CustomerName ,                                
                                Site = itm.Site,
                                SiteName = itm.SiteName,                                 
                                CashAmount = itm.CashAmount,
                                Amount = itm.SiteAmount + itm.CashAmount + itm.CustomerAmount,
                                RecName = itm.RecName,
                                CarMove = itm.CarMove,
                                Tax = itm.Tax,
                                LowAmount = itm.CustomerAmount,
                                Qty = itm.Qty,
                                Destination = itm.Destination,
                                Source = itm.Source
                            }).ToList());
                    return linvError;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<vInvError> NotPaidGetAll20(string FDate, string EDate, bool ChkCarMove, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    List<vInvError> linvError = new List<vInvError>();
                    int i = 1;
                    var result1 = myContext.vShipNotVouGetAll(this.VouLoc, FDate, EDate, this.Site, this.Customer);
                    linvError.AddRange((from itm in result1
                                        select new vInvError
                                        {
                                            FNo = i++,
                                            CustomerAmount = itm.CustomerAmount,
                                            VouLoc = itm.VouLoc,
                                            VouNo = itm.VouNo,
                                            InvNo = "E" + short.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo.ToString(),
                                            GDate = itm.GDate,
                                            SiteAmount = itm.SiteAmount,
                                            Customer = itm.Customer,
                                            CustomerName = itm.SiteAmount != 0 ? itm.Name : itm.CustomerName,
                                            Site = itm.Site,
                                            SiteName = itm.SiteName,
                                            CashAmount = itm.CashAmount,
                                            Amount = itm.SiteAmount + itm.CashAmount + itm.CustomerAmount,
                                            RecName = itm.RecName,
                                            CarMove = 0,
                                            LowAmount = itm.CustomerAmount,
                                            Qty = itm.Qty,
                                            Tax = 0,
                                            Destination = itm.Destination,
                                            Source = itm.Source
                                        }).ToList());
                    var result2 = myContext.vLShipNotVouGetAll(this.VouLoc, FDate, EDate, this.Site, this.Customer);
                    linvError.AddRange((from itm in result2
                                        select new vInvError
                                        {
                                            FNo = i++,
                                            CustomerAmount = itm.CustomerAmount,
                                            VouLoc = itm.VouLoc,
                                            VouNo = itm.VouNo,
                                            InvNo = "L" + short.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo.ToString(),
                                            GDate = itm.GDate,
                                            SiteAmount = itm.SiteAmount,
                                            Customer = itm.Customer,
                                            CustomerName = itm.SiteAmount != 0 ? itm.Name : itm.CustomerName,
                                            Site = itm.Site,
                                            Tax = 0,
                                            SiteName = itm.SiteName,
                                            CashAmount = itm.CashAmount,
                                            Amount = itm.SiteAmount + itm.CashAmount + itm.CustomerAmount,
                                            RecName = itm.RecName,
                                            CarMove = 0,
                                            LowAmount = itm.CustomerAmount,
                                            Qty = itm.Qty,
                                            Destination = itm.Destination,
                                            Source = itm.Source
                                        }).ToList());

                    var result = myContext.vInvNotVou2GetAll(this.VouLoc, FDate, EDate, this.Site, this.Customer);
                    linvError.AddRange((from itm in result
                                        where ChkCarMove || (itm.CarMove != null)
                                        select new vInvError
                                        {
                                            FNo = i++,
                                            CustomerAmount = itm.CustomerAmount,
                                            VouLoc = itm.VouLoc,
                                            VouNo = itm.VouNo,
                                            InvNo = short.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo.ToString(),
                                            GDate = itm.GDate,
                                            SiteAmount = itm.SiteAmount,
                                            Customer = itm.Customer,
                                            CustomerName = itm.SiteAmount != 0 ? itm.Name : itm.CustomerName,
                                            Site = itm.Site,
                                            SiteName = itm.SiteName,
                                            CashAmount = itm.CashAmount,
                                            Amount = itm.SiteAmount + itm.CashAmount + itm.CustomerAmount,
                                            RecName = itm.RecName,
                                            CarMove = itm.CarMove,
                                            Tax = itm.Tax,
                                            LowAmount = itm.CustomerAmount,
                                            Qty = itm.Qty,
                                            Destination = itm.Destination,
                                            Source = itm.Source
                                        }).ToList());
                    return linvError;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<vInvError> PaidGetSite(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vInvVouGetSite(this.VouLoc);
                    int i = 1;
                    return (from itm in result
                            select new vInvError
                            {
                                FNo = i++,
                                Site = itm.Site,
                                SiteName = itm.SiteName
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<vInvError> PaidGetCustomer(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vInvVouGetCustomer(this.VouLoc);
                    int i = 1;
                    return (from itm in result
                            select new vInvError
                            {
                                FNo = i++,
                                Customer = itm.Customer,
                                CustomerName = itm.CustomerName
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<vInvError> PaidGetAll(string FDate, string EDate, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vInvVouGetAll(this.VouLoc, FDate, EDate, this.Site, this.Customer);
                    int i = 1;
                    return (from itm in result
                            select new vInvError
                            {
                                FNo = i++,
                                CustomerAmount = itm.CustomerAmount,
                                VouLoc = itm.VouLoc,
                                VouNo = (int)itm.VouNo,
                                GDate = itm.GDate,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerName = itm.SiteAmount != 0 ? itm.Name : itm.CustomerName,
                                Site = itm.Site,
                                SiteName = itm.SiteName,
                                CashAmount = itm.CashAmount,
                                Amount = itm.SiteAmount + itm.CashAmount + itm.CustomerAmount,
                                FType = itm.FType,
                                JvAmount = itm.JvAmount,
                                LocNumber = itm.LocNumber,
                                LocType = itm.LocType,
                                Branch = (short)itm.Branch,
                                InvNo = itm.InvNo,
                                Number = itm.Number,
                                VouDate = itm.FDate,
                                VouType = itm.VouType,
                                RecName = itm.RecName
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<vInvError> CashGetCustomer(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGetAllCashCustomer(this.VouLoc);
                    int i = 1;
                    return (from itm in result
                            select new vInvError
                            {
                                FNo = i++,
                                Customer = itm.Name,
                                CustomerName = itm.Name
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<vInvError> CashGetAll(string FDate, string EDate, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGetAllCash(this.VouLoc, FDate, EDate, this.Customer);
                    int i = 1;
                    return (from itm in result
                            select new vInvError
                            {
                                FNo = i++,
                                CustomerAmount = itm.CustomerAmount,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                GDate = itm.GDate,
                                SiteAmount = itm.SiteAmount,
                                CustomerName = itm.Name,
                                CashAmount = itm.CashAmount,
                                Amount = itm.SiteAmount + itm.CashAmount + itm.CustomerAmount,
                                RecName = itm.RecName
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<vInvError> CreditGetSite(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGetAllCreditSite(this.VouLoc);
                    int i = 1;
                    return (from itm in result
                            select new vInvError
                            {
                                FNo = i++,
                                Site = itm.Site,
                                SiteName = itm.SiteName
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<vInvError> CreditGetCustomer(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGetAllCreditCustomer(this.VouLoc);
                    int i = 1;
                    return (from itm in result
                            select new vInvError
                            {
                                FNo = i++,
                                Customer = itm.Customer,
                                CustomerName = itm.CustomerName
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<vInvError> CreditGetAll(string FDate, string EDate, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGetAllCredit(this.VouLoc, FDate, EDate, this.Customer, this.Site);
                    int i = 1;
                    return (from itm in result
                            select new vInvError
                            {
                                FNo = i++,
                                CustomerAmount = itm.CustomerAmount,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                GDate = itm.GDate,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerName = itm.SiteAmount != 0 ? itm.Name : itm.CustomerName,
                                Site = itm.Site,
                                SiteName = itm.SiteName,
                                CashAmount = itm.CashAmount,
                                Amount = itm.SiteAmount + itm.CashAmount + itm.CustomerAmount,
                                RecName = itm.RecName
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<vInvError> DeletedGetAll(string FDate, string EDate, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceDelGetAll(this.VouLoc, FDate, EDate);
                    int i = 1;
                    return (from itm in result
                            select new vInvError
                            {
                                FNo = i++,
                                CustomerAmount = itm.CustomerAmount,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                GDate = itm.GDate,
                                SiteAmount = itm.SiteAmount,
                                CustomerName = itm.Name,
                                CashAmount = itm.CashAmount,
                                Amount = itm.SiteAmount + itm.CashAmount + itm.CustomerAmount,
                                RecName = itm.RecName
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<vInvError> InvEmpPerDetails(string FDate, string EDate, string UserName,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvEmpPerDetails(FDate, EDate, UserName);
                    int i = 1;
                    return (from itm in result
                            select new vInvError
                            {
                                FNo = i++,
                                Amount = itm.CashAmount + itm.CustomerAmount + itm.SiteAmount,
                                CashAmount = itm.CashAmount,
                                CustomerAmount = itm.CustomerAmount,
                                LowAmount = itm.LowAmount,
                                GDate = itm.GDate,
                                SiteAmount = itm.SiteAmount,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                Site = itm.Site,
                                SiteName = itm.SiteName,
                                Customer = itm.Customer,
                                CustomerName = itm.SiteAmount != 0 ? itm.Name : itm.CustomerName,
                                RecName = itm.RecName                               
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
    public class DocSerial
    {
        public int FNo { get; set; }
        public string DocNo { get; set; }

        public List<DocSerial> GetLostSerial(string Site, string Doc, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    List<DocSerial> myR = new List<DocSerial>();
                    int FNo = 1;
                    int i = 0;
                    string VouLoc = "-1";
                    int loc = -1;
                    if (Doc == "1")
                    {
                        var result1 = myContext.InvoiceGetSerial(1,Site);
                        FNo = 1;
                        i = 0;
                        VouLoc = "-1";
                        foreach (InvoiceGetSerialResult itm in result1)
                        {
                            if(VouLoc != itm.VouLoc)
                            {
                                VouLoc = itm.VouLoc;
                                i = 0;
                            }
                            if (i == 0) 
                            {
                                i = itm.VouNo;
                                i++;
                            }
                            else
                            {
                                if (itm.VouNo != i)
                                {
                                    while (itm.VouNo != i)
                                    {
                                        myR.Add(new DocSerial
                                        {
                                            DocNo = int.Parse(VouLoc).ToString() + "/" + i.ToString(),
                                            FNo = FNo++
                                        });
                                        i++;
                                    }                                   
                                }
                                i++;
                            }
                        }
                    }
                    else if (Doc == "2")
                    {
                        var result2 = myContext.CarMoveGetSerial(1,Site);
                        FNo = 1;
                        i = 0;
                        VouLoc = "-1";
                        foreach (CarMoveGetSerialResult itm in result2)
                        {
                            if(VouLoc != itm.VouLoc)
                            {
                                VouLoc = itm.VouLoc;
                                i = 0;
                            }
                            if (i == 0) 
                            {
                                i = itm.Number;
                                i++;
                            }
                            else
                            {
                                if (itm.Number != i)
                                {
                                    while (itm.Number != i)
                                    {
                                        myR.Add(new DocSerial
                                        {
                                            DocNo = int.Parse(VouLoc).ToString() + "/" + i.ToString(),
                                            FNo = FNo++
                                        });
                                        i++;
                                    }
                                }
                                i++;
                            }
                        }
                    }
                    else if (Doc == "3")
                    {
                        var result3 = myContext.CarMoveRCVGetSerial(1, short.Parse(Site));
                        FNo = 1;
                        i = 0;
                        loc = -1;
                        foreach (CarMoveRCVGetSerialResult itm in result3)
                        {
                            if (loc != itm.LocNumber)
                            {
                                loc = itm.LocNumber;
                                i = 0;
                            }
                            if (i == 0)
                            {
                                i = itm.Number;
                                i++;
                            }
                            else
                            {
                                if (itm.Number != i)
                                {
                                    while (itm.Number != i)
                                    {
                                        myR.Add(new DocSerial
                                        {
                                            DocNo = loc.ToString() + "/" + i.ToString(),
                                            FNo = FNo++
                                        });
                                        i++;
                                    }
                                }
                                i++;
                            }
                        }
                    }
                    else if (Doc == "4")
                    {
                        var result3 = myContext.CarRcvGetSerial(1, short.Parse(Site));
                        FNo = 1;
                        i = 0;
                        loc = -1;
                        foreach (CarRcvGetSerialResult itm in result3)
                        {
                            if (loc != itm.LocNumber)
                            {
                                loc = itm.LocNumber;
                                i = 0;
                            }
                            if (i == 0)
                            {
                                i = itm.Number;
                                i++;
                            }
                            else
                            {
                                if (itm.Number != i)
                                {
                                    while (itm.Number != i)
                                    {
                                        myR.Add(new DocSerial
                                        {
                                            DocNo = loc.ToString() + "/" + i.ToString(),
                                            FNo = FNo++
                                        });
                                        i++;
                                    }
                                }
                                i++;
                            }
                        }
                    }
                    else if (Doc == "5")
                    {
                        var result3 = myContext.JvGetSerial(1,101,2, short.Parse(Site));
                        FNo = 1;
                        i = 0;
                        loc = -1;
                        foreach (JvGetSerialResult itm in result3)
                        {
                            if (loc != itm.LocNumber)
                            {
                                loc = itm.LocNumber;
                                i = 0;
                            }
                            if (i == 0)
                            {
                                i = itm.Number;
                                i++;
                            }
                            else
                            {
                                if (itm.Number != i)
                                {
                                    while (itm.Number != i)
                                    {
                                        myR.Add(new DocSerial
                                        {
                                            DocNo = loc.ToString() + "/" + i.ToString(),
                                            FNo = FNo++
                                        });
                                        i++;
                                    }
                                }
                                i++;
                            }
                        }
                    }
                    else if (Doc == "6")
                    {
                        var result3 = myContext.JvGetSerial(1, 102, 2, short.Parse(Site));
                        FNo = 1;
                        i = 0;
                        loc = -1;
                        foreach (JvGetSerialResult itm in result3)
                        {
                            if (loc != itm.LocNumber)
                            {
                                loc = itm.LocNumber;
                                i = 0;
                            }
                            if (i == 0)
                            {
                                i = itm.Number;
                                i++;
                            }
                            else
                            {
                                if (itm.Number != i)
                                {
                                    while (itm.Number != i)
                                    {
                                        myR.Add(new DocSerial
                                        {
                                            DocNo = loc.ToString() + "/" + i.ToString(),
                                            FNo = FNo++
                                        });
                                        i++;
                                    }
                                }
                                i++;
                            }
                        }
                    }
                    else if (Doc == "7")
                    {
                        var result3 = myContext.JvGetSerial(1, 105, 2, short.Parse(Site));
                        FNo = 1;
                        i = 0;
                        loc = -1;
                        foreach (JvGetSerialResult itm in result3)
                        {
                            if (loc != itm.LocNumber)
                            {
                                loc = itm.LocNumber;
                                i = 0;
                            }
                            if (i == 0)
                            {
                                i = itm.Number;
                                i++;
                            }
                            else
                            {
                                if (itm.Number != i)
                                {
                                    while (itm.Number != i)
                                    {
                                        myR.Add(new DocSerial
                                        {
                                            DocNo = loc.ToString() + "/" + i.ToString(),
                                            FNo = FNo++
                                        });
                                        i++;
                                    }
                                }
                                i++;
                            }
                        }
                    }
                    else if (Doc == "9")
                    {
                        var result3 = myContext.MyPOGetSerial(1, 2, short.Parse(Site));
                        FNo = 1;
                        i = 0;
                        loc = -1;
                        foreach (MyPOGetSerialResult itm in result3)
                        {
                            if (loc != itm.LocNumber)
                            {
                                loc = itm.LocNumber;
                                i = 0;
                            }
                            if (i == 0)
                            {
                                i = itm.Number;
                                i++;
                            }
                            else
                            {
                                if (itm.Number != i)
                                {
                                    while (itm.Number != i)
                                    {
                                        myR.Add(new DocSerial
                                        {
                                            DocNo = loc.ToString() + "/" + i.ToString(),
                                            FNo = FNo++
                                        });
                                        i++;
                                    }
                                }
                                i++;
                            }
                        }
                    }
                    else if (Doc == "8")
                    {
                        var result3 = myContext.POGetSerial(1, short.Parse(Site));
                        FNo = 1;
                        i = 0;
                        loc = -1;
                        foreach (POGetSerialResult itm in result3)
                        {
                            if (loc != itm.VouLoc)
                            {
                                loc = itm.VouLoc;
                                i = 0;
                            }
                            if (i == 0)
                            {
                                i = itm.VouNo;
                                i++;
                            }
                            else
                            {
                                if (itm.VouNo != i)
                                {
                                    while (itm.VouNo != i)
                                    {
                                        myR.Add(new DocSerial
                                        {
                                            DocNo = loc.ToString() + "/" + i.ToString(),
                                            FNo = FNo++
                                        });
                                        i++;
                                    }
                                }
                                i++;
                            }
                        }
                    }

                    return myR;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetMobileNoList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGetMobileNo();
                    return (from itm in result
                            select itm.MobileNo).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetLMobileNoList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.LShipmentGetMobileNo();
                    return (from itm in result
                            select itm.MobileNo).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetEMobileNoList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShipmentGetMobileNo();
                    return (from itm in result
                            select itm.MobileNo).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetRecMobileNoList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGetRecMobileNo();
                    return (from itm in result
                            select itm.RecMobileNo).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetLRecMobileNoList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.LShipmentGetRecMobileNo();
                    return (from itm in result
                            select itm.RecMobileNo).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetERecMobileNoList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShipmentGetRecMobileNo();
                    return (from itm in result
                            select itm.RecMobileNo).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetIDNoList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGetIDNo();
                    return (from itm in result
                            select itm.IDNo).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetLIDNoList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.LShipmentGetIDNo();
                    return (from itm in result
                            select itm.IDNo).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetEIDNoList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShipmentGetIDNo();
                    return (from itm in result
                            select itm.IDNo).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<string> GetNameList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGetName();
                    return (from itm in result
                            select itm.Name).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetLNameList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.LShipmentGetName();
                    return (from itm in result
                            select itm.Name).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<string> GetENameList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShipmentGetName();
                    return (from itm in result
                            select itm.Name).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetRecNameList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGetRecName();
                    return (from itm in result
                            select itm.RecName).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetLRecNameList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.LShipmentGetRecName();
                    return (from itm in result
                            select itm.RecName).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetERecNameList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShipmentGetRecName();
                    return (from itm in result
                            select itm.RecName).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetPlateNoList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvDetailsGetPlateNo();
                    return (from itm in result
                            select itm.PlateNo).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetChassisNoList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvDetailsGetChassisNo();
                    return (from itm in result
                            select itm.ChassisNo).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetVouNoList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvoiceGetVouNo();
                    return (from itm in result
                            select itm.VouNo2).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetLVouNoList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.LShipmentGetVouNo();
                    return (from itm in result
                            select itm.VouNo2).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetEVouNoList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShipmentGetVouNo();
                    return (from itm in result
                            select itm.VouNo2).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DocSerial> GetLostSerialWHS(string Site, string Doc, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    List<DocSerial> myR = new List<DocSerial>();
                    int FNo = 1;
                    int i = 0;
                    int loc = -1;
                    if (Doc == "1")
                    {
                        var result = myContext.JvGetSerial(1, 701, 2, short.Parse(Site));
                        FNo = 1;
                        i = 0;
                        //VouLoc = "-1";
                        foreach (JvGetSerialResult itm in result)
                        {
                            if (loc != itm.LocNumber)
                            {
                                loc = itm.LocNumber;
                                i = 0;
                            }
                            if (i == 0)
                            {
                                i = itm.Number;
                                i++;
                            }
                            else
                            {
                                if (itm.Number != i)
                                {
                                    while (itm.Number != i)
                                    {
                                        myR.Add(new DocSerial
                                        {
                                            DocNo = loc.ToString() + "/" + i.ToString(),
                                            FNo = FNo++
                                        });
                                        i++;
                                    }
                                }
                                i++;
                            }
                        }
                    }
                    return myR;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<DocSerial> GetLostSerialACC(string Doc, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    List<DocSerial> myR = new List<DocSerial>();
                    int FNo = 1;
                    int i = 0;
                    //string VouLoc = "-1";
                    int loc = -1;
                    if (Doc == "1")
                    {
                        var result3 = myContext.JvGetSerial(1, 101, 1, 1);
                        FNo = 1;
                        i = 0;
                        loc = -1;
                        foreach (JvGetSerialResult itm in result3)
                        {
                            if (loc != itm.LocNumber)
                            {
                                loc = itm.LocNumber;
                                i = 0;
                            }
                            if (i == 0)
                            {
                                i = itm.Number;
                                i++;
                            }
                            else
                            {
                                if (itm.Number != i)
                                {
                                    while (itm.Number != i)
                                    {
                                        myR.Add(new DocSerial
                                        {
                                            DocNo = loc.ToString() + "/" + i.ToString(),
                                            FNo = FNo++
                                        });
                                        i++;
                                    }
                                }
                                i++;
                            }
                        }
                    }
                    else if (Doc == "2")
                    {
                        var result3 = myContext.JvGetSerial(1, 102, 1, 1);
                        FNo = 1;
                        i = 0;
                        loc = -1;
                        foreach (JvGetSerialResult itm in result3)
                        {
                            if (loc != itm.LocNumber)
                            {
                                loc = itm.LocNumber;
                                i = 0;
                            }
                            if (i == 0)
                            {
                                i = itm.Number;
                                i++;
                            }
                            else
                            {
                                if (itm.Number != i)
                                {
                                    while (itm.Number != i)
                                    {
                                        myR.Add(new DocSerial
                                        {
                                            DocNo = loc.ToString() + "/" + i.ToString(),
                                            FNo = FNo++
                                        });
                                        i++;
                                    }
                                }
                                i++;
                            }
                        }
                    }
                    if (Doc == "3")
                    {
                        var result3 = myContext.JvGetSerial(1, 100, 1, 1);
                        FNo = 1;
                        i = 0;
                        loc = -1;
                        foreach (JvGetSerialResult itm in result3)
                        {
                            if (loc != itm.LocNumber)
                            {
                                loc = itm.LocNumber;
                                i = 0;
                            }
                            if (i == 0)
                            {
                                i = itm.Number;
                                i++;
                            }
                            else
                            {
                                if (itm.Number != i)
                                {
                                    while (itm.Number != i)
                                    {
                                        myR.Add(new DocSerial
                                        {
                                            DocNo = loc.ToString() + "/" + i.ToString(),
                                            FNo = FNo++
                                        });
                                        i++;
                                    }
                                }
                                i++;
                            }
                        }
                    }
                    else if (Doc == "4")
                    {
                        var result3 = myContext.JvGetSerial(1, 105, 1, 1);
                        FNo = 1;
                        i = 0;
                        loc = -1;
                        foreach (JvGetSerialResult itm in result3)
                        {
                            if (loc != itm.LocNumber)
                            {
                                loc = itm.LocNumber;
                                i = 0;
                            }
                            if (i == 0)
                            {
                                i = itm.Number;
                                i++;
                            }
                            else
                            {
                                if (itm.Number != i)
                                {
                                    while (itm.Number != i)
                                    {
                                        myR.Add(new DocSerial
                                        {
                                            DocNo = loc.ToString() + "/" + i.ToString(),
                                            FNo = FNo++
                                        });
                                        i++;
                                    }
                                }
                                i++;
                            }
                        }
                    }
                    else if (Doc == "5")
                    {
                        var result3 = myContext.JvGetSerial(1, 106, 1, 1);
                        FNo = 1;
                        i = 0;
                        loc = -1;
                        foreach (JvGetSerialResult itm in result3)
                        {
                            if (loc != itm.LocNumber)
                            {
                                loc = itm.LocNumber;
                                i = 0;
                            }
                            if (i == 0)
                            {
                                i = itm.Number;
                                i++;
                            }
                            else
                            {
                                if (itm.Number != i)
                                {
                                    while (itm.Number != i)
                                    {
                                        myR.Add(new DocSerial
                                        {
                                            DocNo = loc.ToString() + "/" + i.ToString(),
                                            FNo = FNo++
                                        });
                                        i++;
                                    }
                                }
                                i++;
                            }
                        }
                    }
                    else if (Doc == "7")
                    {
                        var result3 = myContext.MyPOGetSerial(1, 1, 0);
                        FNo = 1;
                        i = 0;
                        loc = -1;
                        foreach (MyPOGetSerialResult itm in result3)
                        {
                            if (loc != itm.LocNumber)
                            {
                                loc = itm.LocNumber;
                                i = 0;
                            }
                            if (i == 0)
                            {
                                i = itm.Number;
                                i++;
                            }
                            else
                            {
                                if (itm.Number != i)
                                {
                                    while (itm.Number != i)
                                    {
                                        myR.Add(new DocSerial
                                        {
                                            DocNo = loc.ToString() + "/" + i.ToString(),
                                            FNo = FNo++
                                        });
                                        i++;
                                    }
                                }
                                i++;
                            }
                        }
                    }
                    else if (Doc == "6")
                    {
                        var result3 = myContext.POGetSerial(1, 0);
                        FNo = 1;
                        i = 0;
                        loc = -1;
                        foreach (POGetSerialResult itm in result3)
                        {
                            if (loc != itm.VouLoc)
                            {
                                loc = itm.VouLoc;
                                i = 0;
                            }
                            if (i == 0)
                            {
                                i = itm.VouNo;
                                i++;
                            }
                            else
                            {
                                if (itm.VouNo != i)
                                {
                                    while (itm.VouNo != i)
                                    {
                                        myR.Add(new DocSerial
                                        {
                                            DocNo = loc.ToString() + "/" + i.ToString(),
                                            FNo = FNo++
                                        });
                                        i++;
                                    }
                                }
                                i++;
                            }
                        }
                    }

                    return myR;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }


    [Serializable]
    public class vInvEmpPer
    {
        public int FNo { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string CustomerName { get; set; }
        public int? InvCount { get; set; }
        public System.Nullable<double> CashAmount { get; set; }
        public System.Nullable<double> SiteAmount { get; set; }
        public System.Nullable<double> CustomerAmount { get; set; }
        public System.Nullable<double> Total { get; set; }
        public System.Nullable<double> LowAmount { get; set; }
        public System.Nullable<int> Qty { get; set; }
        public System.Nullable<double> Net
        {
            get
            {
                return Total - LowAmount;
            }
        }

        public List<vInvEmpPer> vInvEmpPerGetAll(string FDate, string EDate, string ConnectionStr,List<TblUsers> Users)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    //TblUsers myUser = new TblUsers();
                    //List<TblUsers> Users = new List<TblUsers>();
                    //Users = myUser.GetAll(ConnectionStr);

                    vInvEmpPer emp = new vInvEmpPer();
                    List<vInvEmpPer> lemp = new List<vInvEmpPer>();
                    lemp = emp.vInvEmpPer2GetAll(FDate, EDate, ConnectionStr);
                    var result = myContext.InvEmpsPer(FDate, EDate);
                    int i = 1;
                    return (from itm in result
                            select new vInvEmpPer
                            {
                                FNo = i++,
                                UserName = itm.UserName,
                                FullName = (from st in Users 
                                            where st.UserName == itm.UserName
                                            select st.FName).FirstOrDefault() == null ? itm.UserName : (from st in Users
                                                                                                        where st.UserName == itm.UserName
                                                                                                        select st.FName).FirstOrDefault(),
                                CashAmount = itm.CashAmount,
                                CustomerAmount = itm.CustomerAmount,
                                SiteAmount = itm.SiteAmount,
                                Total = itm.Total,
                                LowAmount = (from st2 in lemp
                                             where st2.UserName == itm.UserName
                                             select st2.LowAmount).FirstOrDefault()                               
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<vInvEmpPer> vInvEmpPer2GetAll(string FDate, string EDate, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result2 = myContext.InvEmpsPer2(FDate, EDate);
                    int i = 1;
                    return (from itm in result2
                            select new vInvEmpPer
                            {
                                FNo = i++,
                                UserName = itm.UserName,
                                LowAmount = itm.LowAmount
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<vInvEmpPer> vInvCustomerGetAll(string FDate, string EDate, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.InvCustomerGetAll(FDate, EDate);
                    int i = 1;
                    return (from itm in result
                            select new vInvEmpPer
                            {
                                FNo = i++,
                                CustomerName = itm.Name1,
                                CashAmount = itm.CashAmount,
                                CustomerAmount = itm.CustomerAmount,
                                SiteAmount = itm.SiteAmount,
                                Total = itm.CashAmount + itm.CustomerAmount + itm.SiteAmount,
                                InvCount = itm.InvCount,
                                Qty = itm.Qty
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




