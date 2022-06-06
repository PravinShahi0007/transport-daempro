using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class DealOut
    {
        public short FType { get; set; }
        public int FNum { get; set; }
        public short FNo { get; set; }
        public string FStep { get; set; }
        public string FDate { get; set; }
        public System.Nullable<short> FAgree { get; set; }
        public string FNote { get; set; }
        public string CurrentState { get; set; }
        public System.Nullable<int> EmpCode { get; set; }
        public string WDate { get; set; }
        public System.Nullable<int> Days { get; set; }
        public string SDays { get; set; }
        public string EDays { get; set; }
        public System.Nullable<double> TicketPrice { get; set; }
        public System.Nullable<short> TicketNo { get; set; }
        public System.Nullable<bool> vTaking { get; set; }
        public System.Nullable<bool> Replacement { get; set; }
        public System.Nullable<int> REmpCode { get; set; }
        public System.Nullable<short> vType { get; set; }
        public System.Nullable<double> Basic { get; set; }
        public System.Nullable<double> Add01 { get; set; }
        public System.Nullable<double> Add02 { get; set; }
        public System.Nullable<double> Add03 { get; set; }
        public System.Nullable<double> Add04 { get; set; }
        public System.Nullable<double> Add05 { get; set; }
        public System.Nullable<double> Add06 { get; set; }
        public System.Nullable<double> Add07 { get; set; }
        public System.Nullable<double> Add08 { get; set; }
        public System.Nullable<double> Add09 { get; set; }
        public System.Nullable<double> Add10 { get; set; }
        public System.Nullable<double> Add11 { get; set; }
        public System.Nullable<double> Add12 { get; set; }
        public System.Nullable<double> Add13 { get; set; }
        public System.Nullable<double> Add14 { get; set; }
        public System.Nullable<double> Add15 { get; set; }
        public System.Nullable<double> Ded01 { get; set; }
        public System.Nullable<double> Ded02 { get; set; }
        public System.Nullable<double> Ded03 { get; set; }
        public System.Nullable<double> Ded04 { get; set; }
        public System.Nullable<double> Ded05 { get; set; }
        public System.Nullable<double> Ded06 { get; set; }
        public System.Nullable<double> Ded07 { get; set; }
        public System.Nullable<double> Ded08 { get; set; }
        public System.Nullable<double> Ded09 { get; set; }
        public System.Nullable<double> Ded10 { get; set; }
        public System.Nullable<double> Ded11 { get; set; }
        public System.Nullable<double> Ded12 { get; set; }
        public System.Nullable<double> Ded13 { get; set; }
        public System.Nullable<double> Ded14 { get; set; }
        public System.Nullable<double> Ded15 { get; set; }
                       
        public DealOut()
        {
            this.FType = 0;
            this.FNum = 0;
            this.FNo = 0;
            this.FStep = "";
            this.FDate = "";
            this.FAgree = 0;
            this.FNote = "";
            this.CurrentState = "";
            this.EmpCode = 0;
            this.WDate = "";
            this.Days = 0;
            this.SDays = "";
            this.EDays = "";
            this.TicketPrice = 0;
            this.TicketNo = 0;
            this.vTaking = false;
            this.Replacement = false;
            this.REmpCode = 0;
            this.vType = 0;
            this.Basic = 0;
            this.Add01 = 0;
            this.Add02 = 0;
            this.Add03 = 0;
            this.Add04 = 0;
            this.Add05 = 0;
            this.Add06 = 0;
            this.Add07 = 0;
            this.Add08 = 0;
            this.Add09 = 0;
            this.Add10 = 0;
            this.Add11 = 0;
            this.Add12 = 0;
            this.Add13 = 0;
            this.Add14 = 0;
            this.Add15 = 0;
            this.Ded01 = 0;
            this.Ded02 = 0;
            this.Ded03 = 0;
            this.Ded04 = 0;
            this.Ded05 = 0;
            this.Ded06 = 0;
            this.Ded07 = 0;
            this.Ded08 = 0;
            this.Ded09 = 0;
            this.Ded10 = 0;
            this.Ded11 = 0;
            this.Ded12 = 0;
            this.Ded13 = 0;
            this.Ded14 = 0;
            this.Ded15 = 0;
        }

        /// <summary>
        /// Add Area in Area Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.DealOutAdd(this.FType,
                                         this.FNum,
                                         this.FNo,
                                         this.FStep,
                                         this.FDate,
                                         this.FAgree,
                                         this.FNote,
                                         this.CurrentState,
                                         this.EmpCode,
                                         this.WDate,
                                         this.Days,
                                         this.SDays,
                                         this.EDays,
                                         this.TicketPrice,
                                         this.TicketNo,
                                         this.vTaking,
                                         this.Replacement,
                                         this.REmpCode,
                                         this.vType,
                                         this.Basic,
                                         this.Add01,
                                         this.Add02,
                                         this.Add03,
                                         this.Add04,
                                         this.Add05,
                                         this.Add06,
                                         this.Add07,
                                         this.Add08,
                                         this.Add09,
                                         this.Add10,
                                         this.Add11,
                                         this.Add12,
                                         this.Add13,
                                         this.Add14,
                                         this.Add15,
                                         this.Ded01,
                                         this.Ded02,
                                         this.Ded03,
                                         this.Ded04,
                                         this.Ded05,
                                         this.Ded06,
                                         this.Ded07,
                                         this.Ded08,
                                         this.Ded09,
                                         this.Ded10,
                                         this.Ded11,
                                         this.Ded12,
                                         this.Ded13,
                                         this.Ded14,
                                         this.Ded15);

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
        public bool DeleteFNum(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.DealOutDeleteFNum(this.FType,this.FNum);
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
        public bool DeleteStep(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.DealOutDeleteFNumStep(this.FType, this.FNum,this.FNo);
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
        public List<DealOut> GetFNum(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.DealOutGetFNum(this.FType, this.FNum);
                    return (from itm in result
                            select new DealOut
                            {
                                FType = itm.FType,
                                FNum = itm.FNum,
                                FNo = itm.FNo,
                                FStep = itm.FStep,
                                FDate = itm.FDate,
                                FAgree = itm.FAgree,
                                FNote = itm.FNote,
                                CurrentState = itm.CurrentState,
                                EmpCode = itm.EmpCode,
                                WDate = itm.WDate,
                                Days = itm.Days,
                                SDays = itm.SDays,
                                EDays = itm.EDays,
                                TicketPrice = itm.TicketPrice,
                                TicketNo = itm.TicketNo,
                                vTaking = itm.vTaking,
                                Replacement = itm.Replacement,
                                REmpCode = itm.REmpCode,
                                vType = itm.vType,
                                Basic = itm.Basic,
                                Add01 = itm.Add01,
                                Add02 = itm.Add02,
                                Add03 = itm.Add03,
                                Add04 = itm.Add04,
                                Add05 = itm.Add05,
                                Add06 = itm.Add06,
                                Add07 = itm.Add07,
                                Add08 = itm.Add08,
                                Add09 = itm.Add09,
                                Add10 = itm.Add10,
                                Add11 = itm.Add11,
                                Add12 = itm.Add12,
                                Add13 = itm.Add13,
                                Add14 = itm.Add14,
                                Add15 = itm.Add15,
                                Ded01 = itm.Ded01,
                                Ded02 = itm.Ded02,
                                Ded03 = itm.Ded03,
                                Ded04 = itm.Ded04,
                                Ded05 = itm.Ded05,
                                Ded06 = itm.Ded06,
                                Ded07 = itm.Ded07,
                                Ded08 = itm.Ded08,
                                Ded09 = itm.Ded09,
                                Ded10 = itm.Ded10,
                                Ded11 = itm.Ded11,
                                Ded12 = itm.Ded12,
                                Ded13 = itm.Ded13,
                                Ded14 = itm.Ded14,
                                Ded15 = itm.Ded15
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
        public List<DealOut> GetState(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.DealOutGetState(this.CurrentState);
                    return (from itm in result
                            select new DealOut
                            {
                                FType = itm.FType,
                                FNum = itm.FNum,
                                FNo = itm.FNo,
                                FStep = itm.FStep,
                                FDate = itm.FDate,
                                FAgree = itm.FAgree,
                                FNote = itm.FNote,
                                CurrentState = itm.CurrentState,
                                EmpCode = itm.EmpCode,
                                WDate = itm.WDate,
                                Days = itm.Days,
                                SDays = itm.SDays,
                                EDays = itm.EDays,
                                TicketPrice = itm.TicketPrice,
                                TicketNo = itm.TicketNo,
                                vTaking = itm.vTaking,
                                Replacement = itm.Replacement,
                                REmpCode = itm.REmpCode,
                                vType = itm.vType,
                                Basic = itm.Basic,
                                Add01 = itm.Add01,
                                Add02 = itm.Add02,
                                Add03 = itm.Add03,
                                Add04 = itm.Add04,
                                Add05 = itm.Add05,
                                Add06 = itm.Add06,
                                Add07 = itm.Add07,
                                Add08 = itm.Add08,
                                Add09 = itm.Add09,
                                Add10 = itm.Add10,
                                Add11 = itm.Add11,
                                Add12 = itm.Add12,
                                Add13 = itm.Add13,
                                Add14 = itm.Add14,
                                Add15 = itm.Add15,
                                Ded01 = itm.Ded01,
                                Ded02 = itm.Ded02,
                                Ded03 = itm.Ded03,
                                Ded04 = itm.Ded04,
                                Ded05 = itm.Ded05,
                                Ded06 = itm.Ded06,
                                Ded07 = itm.Ded07,
                                Ded08 = itm.Ded08,
                                Ded09 = itm.Ded09,
                                Ded10 = itm.Ded10,
                                Ded11 = itm.Ded11,
                                Ded12 = itm.Ded12,
                                Ded13 = itm.Ded13,
                                Ded14 = itm.Ded14,
                                Ded15 = itm.Ded15
                            }).ToList();
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
        public DealOut GetStep(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.DealOutGetFNumStep(this.FType, this.FNum,this.FNo);
                    return (from itm in result
                            select new DealOut
                            {
                                FType = itm.FType,
                                FNum = itm.FNum,
                                FNo = itm.FNo,
                                FStep = itm.FStep,
                                FDate = itm.FDate,
                                FAgree = itm.FAgree,
                                FNote = itm.FNote,
                                CurrentState = itm.CurrentState,
                                EmpCode = itm.EmpCode,
                                WDate = itm.WDate,
                                Days = itm.Days,
                                SDays = itm.SDays,
                                EDays = itm.EDays,
                                TicketPrice = itm.TicketPrice,
                                TicketNo = itm.TicketNo,
                                vTaking = itm.vTaking,
                                Replacement = itm.Replacement,
                                REmpCode = itm.REmpCode,
                                vType = itm.vType,
                                Basic = itm.Basic,
                                Add01 = itm.Add01,
                                Add02 = itm.Add02,
                                Add03 = itm.Add03,
                                Add04 = itm.Add04,
                                Add05 = itm.Add05,
                                Add06 = itm.Add06,
                                Add07 = itm.Add07,
                                Add08 = itm.Add08,
                                Add09 = itm.Add09,
                                Add10 = itm.Add10,
                                Add11 = itm.Add11,
                                Add12 = itm.Add12,
                                Add13 = itm.Add13,
                                Add14 = itm.Add14,
                                Add15 = itm.Add15,
                                Ded01 = itm.Ded01,
                                Ded02 = itm.Ded02,
                                Ded03 = itm.Ded03,
                                Ded04 = itm.Ded04,
                                Ded05 = itm.Ded05,
                                Ded06 = itm.Ded06,
                                Ded07 = itm.Ded07,
                                Ded08 = itm.Ded08,
                                Ded09 = itm.Ded09,
                                Ded10 = itm.Ded10,
                                Ded11 = itm.Ded11,
                                Ded12 = itm.Ded12,
                                Ded13 = itm.Ded13,
                                Ded14 = itm.Ded14,
                                Ded15 = itm.Ded15
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
        public int? GetNewFNum(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.DealOutGetMaxFNum(this.FType);
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
        /// Get New Code for Area Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public short? GetNewStep(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.DealOutGetMaxStep(this.FType,this.FNum);
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
