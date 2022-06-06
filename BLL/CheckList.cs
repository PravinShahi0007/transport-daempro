using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class CheckList
    {
        public short Branch { get; set; }
        public short VouLoc { get; set; }
        public short VouType { get; set; }
        public int VouNo { get; set; }
        public System.Nullable<int> RepairReqNo { get; set; }
        public System.Nullable<short> RepaiReqLoc { get; set; }
        public string InTime { get; set; }
        public string Item01 { get; set; }
        public string Item02 { get; set; }
        public string Item03 { get; set; }
        public string Item04 { get; set; }
        public string Item05 { get; set; }
        public string Item06 { get; set; }
        public string Item07 { get; set; }
        public string Item08 { get; set; }
        public string Item09 { get; set; }
        public string Item10 { get; set; }
        public string Item11 { get; set; }
        public string Item12 { get; set; }
        public string Item13 { get; set; }
        public string Item14 { get; set; }
        public string Item15 { get; set; }
        public string Item16 { get; set; }
        public string Item17 { get; set; }
        public string Item18 { get; set; }
        public string Item19 { get; set; }
        public string Item20 { get; set; }
        public string Item21 { get; set; }
        public string Item22 { get; set; }
        public string Item23 { get; set; }
        public string Item24 { get; set; }
        public string Item25 { get; set; }
        public string Item26 { get; set; }
        public string Item27 { get; set; }
        public string Item28 { get; set; }
        public string Item29 { get; set; }
        public string Item30 { get; set; }
        public string SItem01 { get; set; }
        public string SItem02 { get; set; }
        public string SItem03 { get; set; }
        public string SItem04 { get; set; }
        public string SItem05 { get; set; }
        public string SItem06 { get; set; }
        public string SItem07 { get; set; }
        public string SItem08 { get; set; }
        public string SItem09 { get; set; }
        public string SItem10 { get; set; }
        public string SItem11 { get; set; }
        public string SItem12 { get; set; }
        public string SItem13 { get; set; }
        public string SItem14 { get; set; }
        public string SItem15 { get; set; }
        public string SItem16 { get; set; }
        public string SItem17 { get; set; }
        public string SItem18 { get; set; }
        public string SItem19 { get; set; }
        public string SItem20 { get; set; }
        public string SItem21 { get; set; }
        public string SItem22 { get; set; }
        public string SItem23 { get; set; }
        public string SItem24 { get; set; }
        public string SItem25 { get; set; }
        public string SItem26 { get; set; }
        public string SItem27 { get; set; }
        public string SItem28 { get; set; }
        public string SItem29 { get; set; }
        public string SItem30 { get; set; }
        public string Remark1 { get; set; }
        public string Remark2 { get; set; }
        public string Remark3 { get; set; }
        public string Remark4 { get; set; }
        public string Remark5 { get; set; }
        public string VouDate { get; set; }
        public string Branch2 { get; set; }
        public string Employee { get; set; }
        public string Job { get; set; }
        public string EngineType { get; set; }
        public string EngineSNo { get; set; }
        public string GearType { get; set; }
        public string GearSNo { get; set; }
        public string ACType { get; set; }
        public string ACSNo { get; set; }
        public string IPType { get; set; }
        public string IPSNo { get; set; }
        public System.Nullable<int> VehType { get; set; }
        public string Vechicle { get; set; }
        public string DriverCode { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        /// <summary>
        /// Add City in Cities Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CheckListInsert(        
                    this.Branch,
                    this.VouLoc,
                    this.VouType,
                    this.VouNo,
                    this.RepairReqNo,
                    this.RepaiReqLoc,
                    this.InTime,
                    this.Item01,
                    this.Item02,
                    this.Item03,
                    this.Item04,
                    this.Item05,
                    this.Item06,
                    this.Item07,
                    this.Item08,
                    this.Item09,
                    this.Item10,
                    this.Item11,
                    this.Item12,
                    this.Item13,
                    this.Item14,
                    this.Item15,
                    this.Item16,
                    this.Item17,
                    this.Item18,
                    this.Item19,
                    this.Item20,
                    this.Item21,
                    this.Item22,
                    this.Item23,
                    this.Item24,
                    this.Item25,
                    this.Item26,
                    this.Item27,
                    this.Item28,
                    this.Item29,
                    this.Item30,
                    this.SItem01,
                    this.SItem02,
                    this.SItem03,
                    this.SItem04,
                    this.SItem05,
                    this.SItem06,
                    this.SItem07,
                    this.SItem08,
                    this.SItem09,
                    this.SItem10,
                    this.SItem11,
                    this.SItem12,
                    this.SItem13,
                    this.SItem14,
                    this.SItem15,
                    this.SItem16,
                    this.SItem17,
                    this.SItem18,
                    this.SItem19,
                    this.SItem20,
                    this.SItem21,
                    this.SItem22,
                    this.SItem23,
                    this.SItem24,
                    this.SItem25,
                    this.SItem26,
                    this.SItem27,
                    this.SItem28,
                    this.SItem29,
                    this.SItem30,
                    this.Remark1,
                    this.Remark2,
                    this.Remark3,
                    this.Remark4,
                    this.Remark5,
                    this.VouDate,
                    this.Branch2,
                    this.Employee,
                    this.Job,
                    this.EngineType,
                    this.EngineSNo,
                    this.GearType,
                    this.GearSNo,
                    this.ACType,
                    this.ACSNo,
                    this.IPType,
                    this.IPSNo,
                    this.VehType,
                    this.Vechicle,
                    this.DriverCode,
                    this.UserName,
                    this.UserDate
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
        /// Delete City from Cities Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CheckListDelete(this.Branch, this.VouLoc, this.VouType, this.VouNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update city in Cities Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CheckListUpdate(
                    this.Branch,
                    this.VouLoc,
                    this.VouType,
                    this.VouNo,
                    this.RepairReqNo,
                    this.RepaiReqLoc,
                    this.InTime,
                    this.Item01,
                    this.Item02,
                    this.Item03,
                    this.Item04,
                    this.Item05,
                    this.Item06,
                    this.Item07,
                    this.Item08,
                    this.Item09,
                    this.Item10,
                    this.Item11,
                    this.Item12,
                    this.Item13,
                    this.Item14,
                    this.Item15,
                    this.Item16,
                    this.Item17,
                    this.Item18,
                    this.Item19,
                    this.Item20,
                    this.Item21,
                    this.Item22,
                    this.Item23,
                    this.Item24,
                    this.Item25,
                    this.Item26,
                    this.Item27,
                    this.Item28,
                    this.Item29,
                    this.Item30,
                    this.SItem01,
                    this.SItem02,
                    this.SItem03,
                    this.SItem04,
                    this.SItem05,
                    this.SItem06,
                    this.SItem07,
                    this.SItem08,
                    this.SItem09,
                    this.SItem10,
                    this.SItem11,
                    this.SItem12,
                    this.SItem13,
                    this.SItem14,
                    this.SItem15,
                    this.SItem16,
                    this.SItem17,
                    this.SItem18,
                    this.SItem19,
                    this.SItem20,
                    this.SItem21,
                    this.SItem22,
                    this.SItem23,
                    this.SItem24,
                    this.SItem25,
                    this.SItem26,
                    this.SItem27,
                    this.SItem28,
                    this.SItem29,
                    this.SItem30,
                    this.Remark1,
                    this.Remark2,
                    this.Remark3,
                    this.Remark4,
                    this.Remark5,
                    this.VouDate,
                    this.Branch2,
                    this.Employee,
                    this.Job,
                    this.EngineType,
                    this.EngineSNo,
                    this.GearType,
                    this.GearSNo,
                    this.ACType,
                    this.ACSNo,
                    this.IPType,
                    this.IPSNo,
                    this.VehType,
                    this.Vechicle,
                    this.DriverCode,
                    this.UserName,
                    this.UserDate);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select all cities from Cities Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public CheckList Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CheckListGet(this.Branch, this.VouLoc, this.VouType, this.VouNo);
                    return (from itm in result
                            select new CheckList
                            {
                                 ACSNo = itm.ACSNo,
                                 ACType = itm.ACType,
                                 Branch = itm.Branch,
                                 Branch2 = itm.Branch2,
                                 InTime = itm.InTime,
                                 DriverCode = itm.DriverCode,
                                 Employee = itm.Employee,
                                 EngineSNo = itm.EngineSNo,
                                 EngineType = itm.EngineType,
                                 GearSNo = itm.GearSNo,
                                 GearType = itm.GearType,
                                 IPSNo = itm.IPSNo,
                                 IPType = itm.IPType,
                                 Item01 = itm.Item01,
                                 Item02 = itm.Item02,
                                 Item03 = itm.Item03,
                                 Item04 = itm.Item04,
                                 Item05 = itm.Item05,
                                 Item06 = itm.Item06,
                                 Item07 = itm.Item07,
                                 Item08 = itm.Item08,
                                 Item09 = itm.Item09,
                                 Item10 = itm.Item10,
                                 Item11 = itm.Item11,
                                 Item12 = itm.Item12,
                                 Item13 = itm.Item13,
                                 Item14 = itm.Item14,
                                 Item15 = itm.Item15,
                                 Item16 = itm.Item16,
                                 Item17 = itm.Item17,
                                 Item18 = itm.Item18,
                                 Item19 = itm.Item19,
                                 Item20 = itm.Item20,
                                 Item21 = itm.Item21,
                                 Item22 = itm.Item22,
                                 Item23 = itm.Item23,
                                 Item24 = itm.Item24,
                                 Item25 = itm.Item25,
                                 Item26 = itm.Item26,
                                 Item27 = itm.Item27,
                                 Item28 = itm.Item28,
                                 Item29 = itm.Item29,
                                 Item30 = itm.Item30,
                                 SItem01 = itm.SItem01,
                                 SItem02 = itm.SItem02,
                                 SItem03 = itm.SItem03,
                                 SItem04 = itm.SItem04,
                                 SItem05 = itm.SItem05,
                                 SItem06 = itm.SItem06,
                                 SItem07 = itm.SItem07,
                                 SItem08 = itm.SItem08,
                                 SItem09 = itm.SItem09,
                                 SItem10 = itm.SItem10,
                                 SItem11 = itm.SItem11,
                                 SItem12 = itm.SItem12,
                                 SItem13 = itm.SItem13,
                                 SItem14 = itm.SItem14,
                                 SItem15 = itm.SItem15,
                                 SItem16 = itm.SItem16,                                 
                                 SItem17 = itm.SItem17,
                                 SItem18 = itm.SItem18,
                                 SItem19 = itm.SItem19,
                                 SItem20 = itm.SItem20,
                                 SItem21 = itm.SItem21,
                                 SItem22 = itm.SItem22,
                                 SItem23 = itm.SItem23,
                                 SItem24 = itm.SItem24,
                                 SItem25 = itm.SItem25,
                                 SItem26 = itm.SItem26,
                                 SItem27 = itm.SItem27,
                                 SItem28 = itm.SItem28,
                                 SItem29 = itm.SItem29,
                                 SItem30 = itm.SItem30,
                                 Job = itm.Job,
                                 Remark1 = itm.Remark1,
                                 Remark2 = itm.Remark2,
                                 Remark3 = itm.Remark3,
                                 Remark4 = itm.Remark4,
                                 Remark5 = itm.Remark5,
                                 RepaiReqLoc = itm.RepaiReqLoc,
                                 RepairReqNo = itm.RepairReq,
                                 Vechicle = itm.Vechicle,
                                 VehType = itm.VehType,
                                 VouDate = itm.VouDate,
                                 VouLoc = itm.VouLoc,
                                 VouNo = itm.VouNo,
                                 VouType = itm.VouType,
                                 UserDate = itm.UserDate,
                                 UserName = itm.UserName
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Get New Code for Center Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public int? GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CheckListMaxCode(this.Branch, this.VouLoc, this.VouType);
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