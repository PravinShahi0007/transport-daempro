using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class AttLog
    {
        public int EmpCode { get; set; }
        public string FDate { get; set; }
        public string STime { get; set; }
        public string ETime { get; set; }
        public string Name { get; set; }
        public string BDate { get; set; }
        public int Code { get; set; }
        public int? Section { get; set; }
        public string Name1 { get; set; }
        public bool? isSelected { get; set; }
        public System.Nullable<int> Shift { get; set; }
        public string S_FTime { get; set; }
        public string S_ETime { get; set; }
        public string SFTime { get; set; }
        public string SETime { get; set; }
        public string RFTime { get; set; }
        public string RETime { get; set; }
        public System.Nullable<int> DLate { get; set; }
        public System.Nullable<int> MDLate { get; set; }
        public System.Nullable<int> MDLateNo { get; set; }
        public System.Nullable<int> YDLate { get; set; }
        public System.Nullable<int> YDLateNo { get; set; }
        public System.Nullable<int> DEarly { get; set; }
        public System.Nullable<int> MDEarly { get; set; }
        public System.Nullable<int> MDEarlyNo { get; set; }
        public System.Nullable<int> YDEarly { get; set; }
        public System.Nullable<int> YDEarlyNo { get; set; }
        public System.Nullable<int> MForget { get; set; }
        public System.Nullable<int> YForget { get; set; }
        public System.Nullable<int> Forget { get; set; }
        public System.Nullable<int> Delay { get; set; }
        public System.Nullable<int> Early { get; set; }

        public System.Nullable<int> YAllowCount { get; set; }
        public System.Nullable<int> YAllowMin { get; set; }
        public System.Nullable<int> MAllowCount { get; set; }
        public System.Nullable<int> MAllowMin { get; set; }

        public System.Nullable<int> eYAllowCount { get; set; }
        public System.Nullable<int> eYAllowMin { get; set; }
        public System.Nullable<int> eMAllowCount { get; set; }
        public System.Nullable<int> eMAllowMin { get; set; }


        public System.Nullable<int> Delay2 { get; set; }
        public System.Nullable<int> Early2 { get; set; }
        public string Remark { get; set; }
        public string SRemark { get; set; }
        public string ERemark { get; set; }
        public System.Nullable<double> NoTime { get; set; }
        public bool? SPer { get; set; }
        public bool? EPer { get; set; }
        public System.Nullable<bool> ThSat { get; set; }
        public string MyAttend {
            get
            {
                string attend = "00:00";
                try
                {
                    if (!string.IsNullOrEmpty(this.ETime) & !string.IsNullOrEmpty(this.STime))
                    {
                        string[] sTemp = this.STime.Split(':');
                        string[] eTemp = this.ETime.Split(':');

                        // (year, month, day, hour, minute, second)
                        DateTime sTime = new DateTime(1, 1, 1, int.Parse(sTemp[0]), int.Parse(sTemp[1]), int.Parse(sTemp[2]));
                        DateTime eTime = new DateTime(1, 1, 1, int.Parse(eTemp[0]), int.Parse(eTemp[1]), int.Parse(eTemp[2]));
                        TimeSpan workedTime = eTime.Subtract(sTime);

                        if (eTime < sTime && eTime < DateTime.Parse("03:30"))
                        {
                            workedTime = DateTime.Parse("23:59:59").Subtract(sTime);
                            workedTime += eTime.Subtract(DateTime.Parse("00:00:01"));

                        }

                        string h = "00";
                        string m = "00";

                        if (workedTime.Hours > 0)
                            h = (workedTime.Hours > 9) ? ("" + workedTime.Hours) : ("0" + workedTime.Hours);
                        if (workedTime.Minutes > 0)
                            m = (workedTime.Minutes > 9) ? ("" + workedTime.Minutes) : ("0" + workedTime.Minutes);

                        attend = h + ":" + m;
                    }
                }
                catch
                {
                
                }

                return attend;
            }
        }

        public short? StartLate
        {           
            get {
                short vres = 0;

                if (this.Shift > -1 && this.STime.Trim() != "" && !(bool)this.SPer)
                {
                    if (DateTime.Parse(HDate.DatetoHjiri(this.FDate)).Month == 9)
                    {
                        if (DateTime.Parse(this.STime) > DateTime.Parse(this.RFTime))
                        {
                            vres = 1;
                            if (DateTime.Parse(this.STime).AddMinutes((double)this.DLate * -1) > DateTime.Parse(this.RFTime))
                            {
                                vres = 2;
                            }
                        }
                    }
                    else
                    {
                        if ((int)DateTime.Parse(this.FDate).DayOfWeek != 6)
                        {
                            if (DateTime.Parse(this.STime) > DateTime.Parse(this.S_FTime))
                            {
                                vres = 1;
                                if (DateTime.Parse(this.STime).AddMinutes((double)this.DLate * -1) > DateTime.Parse(this.S_FTime))
                                {
                                    vres = 2;
                                }
                            }
                        }
                        else
                        {
                            if (this.SFTime != "")
                            {
                                if (DateTime.Parse(this.STime) > DateTime.Parse(this.SFTime))
                                {
                                    vres = 1;
                                    if (DateTime.Parse(this.STime).AddMinutes((double)this.DLate * -1) > DateTime.Parse(this.SFTime))
                                    {
                                        vres = 2;
                                    }
                                }
                            }
                        }
                    }
                }
                return vres;
            }            
        }
        public short? EndLate
        {
            get
            {
                short vres = 0;
                if (this.Shift > -1 && this.ETime.Trim() != "" && !(bool)this.EPer)
                {
                    if (DateTime.Parse(HDate.DatetoHjiri(this.FDate)).Month == 9)
                    {
                        if (DateTime.Parse(this.ETime) < DateTime.Parse(this.RETime))
                        {
                            vres = 1;
                            if (DateTime.Parse(this.ETime).AddMinutes((double)this.DEarly) < DateTime.Parse(this.RETime))
                            {
                                vres = 2;
                            }

                            if (vres == 2 && DateTime.Parse(this.ETime) < DateTime.Parse("03:30"))
                            {
                                vres = 0;
                            }
                        }
                    }
                    else
                    {
                        if ((int)DateTime.Parse(this.FDate).DayOfWeek != 6)
                        {
                            if (DateTime.Parse(this.ETime) < DateTime.Parse(this.S_ETime))
                            {
                                vres = 1;
                                if (DateTime.Parse(this.ETime).AddMinutes((double)this.DEarly) < DateTime.Parse(this.S_ETime))
                                {
                                    vres = 2;
                                }
                            }
                        }
                        else
                        {
                            if (this.SETime != "")
                            {
                                if (DateTime.Parse(this.ETime) < DateTime.Parse(this.SETime))
                                {
                                    vres = 1;
                                    if (DateTime.Parse(this.ETime).AddMinutes((double)this.DEarly) < DateTime.Parse(this.SETime))
                                    {
                                        vres = 2;
                                    }
                                }
                            }
                        }
                    }
                }
                return vres;
            }
        }
        public string STime2
        {
            get
            {
                return (this.StartLate == 0 ? "" : this.StartLate == 1 ? @"<font color=""orange"">" : @"<font color=""red"">") + this.STime +
                               (this.StartLate == 0 ? "" : this.StartLate == 1 ? @"</font>" : @"</font>");
            }
        }

        public string ETime2
        {
            get
            {
                return (this.EndLate == 0 ? "" : this.EndLate == 1 ? @"<font color=""orange"">" : @"<font color=""red"">") + this.ETime +
                (this.StartLate == 0 ? "" : this.StartLate == 1 ? @"</font>" : @"</font>");
            }
        }

        public string FDate2 {
            get
            {
                return moh.Days[(int)DateTime.Parse(this.FDate).DayOfWeek + 1] + " " + this.FDate;
            }         
        } 

        public AttLog()
        {
            this.EmpCode = 0;
            this.FDate = "";
            this.STime = "";
            this.ETime = "";
            this.Name = "";
            this.BDate = "";
            this.Code = 0;
            this.Section = 0;
            this.Name1 = "";
            this.isSelected = false;
            this.Shift = -1;
            this.S_FTime = "";
            this.S_ETime = "";
            this.SFTime = "";
            this.SETime = "";
            this.RFTime = "";
            this.RETime = "";
            this.DLate = 0;
            this.MDLate = 0;
            this.MDLateNo = 0;
            this.YDLate = 0;
            this.YDLateNo = 0;
            this.DEarly = 0;
            this.MDEarly = 0;
            this.MDEarlyNo = 0;
            this.YDEarly = 0;
            this.YDEarlyNo = 0;
            this.MForget = 0;
            this.YForget = 0;
            this.Forget = 0;
            this.NoTime = 0;
            this.Delay = 0;
            this.Delay2 = 0;
            this.Remark = "";
            this.SRemark = "";
            this.ERemark = "";
            this.YAllowCount = 0;
            this.YAllowMin = 0;
            this.MAllowCount = 0;
            this.MAllowMin = 0;
            this.Early = 0;
            this.Early2 = 0;
            this.eYAllowCount = 0;
            this.eYAllowMin = 0;
            this.eMAllowCount = 0;
            this.eMAllowMin = 0;
            this.SPer = false;
            this.EPer = false;
            this.ThSat = false;
        }


        public bool insert(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.AttLogAdd(this.EmpCode, this.FDate, this.STime, this.ETime , this.Shift,this.SPer,this.EPer,this.SRemark,this.ERemark);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select Emp from Absent Table
        /// </summary>
        /// <returns>Absent or null if Fail</returns>
        public List<string> GetMonth(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.AttLogGetMonth();
                    return (from itm in result
                            orderby itm.Month2.Split('/')[1] + "-" + itm.Month2.Split('/')[0]
                            select itm.Month2).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select Emp from Absent Table
        /// </summary>
        /// <returns>Absent or null if Fail</returns>
        public List<string> GetEmp(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.AttLogGetEMP();
                    return (from itm in result
                            orderby itm.SName.Split('.')[0]
                            select itm.SName).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<AttLog> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vAttLogSEMP1GetAll();
                    return (from sitm in result
                            select new AttLog
                            {
                                EmpCode = sitm.EmpCode,
                                Name = sitm.Name,
                                FDate = sitm.FDate,
                                STime = sitm.STime,
                                ETime = sitm.ETime,
                                Shift = sitm.Shift,
                                Name1 = sitm.Name2,
                                Section = sitm.Section,
                                EPer = sitm.EPer,
                                SPer = sitm.SPer,
                                ERemark = sitm.ERemark,
                                SRemark = sitm.SRemark
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<AttLog> GetByEmpMonth(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vAttLogFindEmpMonth(this.EmpCode,DateTime.Parse(this.FDate).Year,DateTime.Parse(this.FDate).Month);
                    return (from sitm in result
                            select new AttLog
                            {
                                EmpCode = sitm.EmpCode,
                                Name = sitm.Name,
                                FDate = sitm.FDate,
                                STime = sitm.STime,
                                ETime = sitm.ETime,
                                Name1 = sitm.Name2,
                                Section = sitm.Section,
                                SETime = sitm.SETime,
                                Shift = sitm.Shift,
                                DEarly = sitm.DEarly,
                                DLate = sitm.DLate,
                                Forget = sitm.Forget,
                                MDEarly = sitm.MDEarly,
                                MDEarlyNo = sitm.MDEarlyNo,
                                MDLate = sitm.MDLate,
                                MDLateNo = sitm.MDLateNo,
                                MForget = sitm.MForget,
                                NoTime = sitm.NoTime,
                                RETime = sitm.RETime,
                                RFTime = sitm.RFTime,
                                S_ETime = sitm.S_ETime,
                                S_FTime = sitm.S_FTime,
                                SFTime = sitm.SFTime,
                                YDEarly = sitm.YDEarly,
                                YDEarlyNo = sitm.YDEarlyNo,
                                YDLate = sitm.YDLate,
                                YDLateNo = sitm.YDLateNo,
                                YForget = sitm.YForget,
                                EPer = sitm.EPer,
                                SPer = sitm.SPer,
                                ERemark = sitm.ERemark,
                                SRemark = sitm.SRemark,
                                ThSat = sitm.ThSat                            
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public AttLog Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.AttLogFind(this.EmpCode, this.FDate);
                    return (from sitm in result
                            select new AttLog
                            {

                                EmpCode = sitm.EmpCode,
                                FDate = sitm.FDate,
                                STime = sitm.STime,
                                ETime = sitm.ETime,
                                Shift = sitm.Shift,
                                EPer = sitm.EPer,
                                SPer = sitm.SPer,
                                SRemark = sitm.SRemark,
                                ERemark = sitm.ERemark
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool Update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.AttlogUpdate(this.EmpCode, this.FDate, this.STime, this.ETime, this.Shift, this.SPer, this.EPer, this.SRemark , this.ERemark);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }






        /*
        public List<Timing> GetAllByDay(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.TimeFindByDay(FDate);
                    return (from sitm in result
                            select new Timing
                            {

                                EmpCode = sitm.EmpCode,
                                Name = sitm.Name,
                                FDate = sitm.FDate,
                                STime = sitm.STime,
                                ETime = sitm.ETime

                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<Timing> GetAllByDayC2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.TimeFindByDayC2(FDate);
                    return (from sitm in result
                            select new Timing
                            {

                                EmpCode = sitm.EmpCode,
                                Name = sitm.Expr6,
                                FDate = sitm.FDate,
                                STime = sitm.STime,
                                ETime = sitm.ETime

                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Timing> GetAllByEmp(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.TimeFindByEmp(EmpCode, FDate);
                    return (from sitm in result
                            select new Timing
                            {

                                EmpCode = sitm.EmpCode,
                                Name = sitm.Expr6,
                                FDate = sitm.FDate,
                                STime = sitm.STime,
                                ETime = sitm.ETime

                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }




        public List<Timing> GetAllByMonth(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.TimeFindMonth(FDate);
                    return (from sitm in result
                            select new Timing
                            {

                                EmpCode = sitm.EmpCode,
                                Name = sitm.Expr6,
                                FDate = sitm.FDate,
                                STime = sitm.STime,
                                ETime = sitm.ETime

                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<Timing> GetAllByMonthC2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.TimeFindMonthC2(FDate);
                    return (from sitm in result
                            select new Timing
                            {

                                EmpCode = sitm.EmpCode,
                                Name = sitm.Name,
                                FDate = sitm.FDate,
                                STime = sitm.STime,
                                ETime = sitm.ETime

                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Timing> GetAtt(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.SEMPGetAtt();
                    return (from sitm in result
                            select new Timing
                            {

                                EmpCode = sitm.EmpCode,
                                Name = sitm.Name,
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        public Timing FindAbsentByDay(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.TimeFindAbsentByDay(this.EmpCode, this.FDate);
                    return (from sitm in result
                            select new Timing
                            {

                                EmpCode = sitm.EmpCode,
                                FDate = sitm.FDate,
                                STime = sitm.STime,
                                ETime = sitm.ETime
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool insertAbsent(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.AbsentAdd(this.EmpCode, this.BDate);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }



        public bool DeleteAbsent(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.AbsentDelete(EmpCode, BDate);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public List<Timing> GetAAbsentByDay(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.AbsentGetByDay(this.BDate);
                    return (from sitm in result
                            select new Timing
                            {

                                EmpCode = sitm.EmpCode,
                                Name = sitm.Name,
                                BDate = sitm.BDate

                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Timing> GetAAbsentByDayC2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.AbsentGetByDayC2(this.BDate);
                    return (from sitm in result
                            select new Timing
                            {

                                EmpCode = sitm.EmpCode,
                                Name = sitm.Name,
                                BDate = sitm.BDate

                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<Timing> GetAbsentByMonth(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.AbsentGetByMonth(this.BDate);
                    return (from sitm in result
                            select new Timing
                            {

                                EmpCode = sitm.EmpCode,
                                Name = sitm.Name,
                                BDate = sitm.BDate

                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<Timing> GetAbsentByMonthC2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.AbsentGetByMonthC2(this.BDate);
                    return (from sitm in result
                            select new Timing
                            {

                                EmpCode = sitm.EmpCode,
                                Name = sitm.Name,
                                BDate = sitm.BDate

                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        public List<Timing> GetAbsentByMonthEmp(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.AbsentGetByMonthEmp(EmpCode, BDate);
                    return (from sitm in result
                            select new Timing
                            {

                                EmpCode = sitm.EmpCode,
                                Name = sitm.Name,
                                BDate = sitm.BDate

                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Timing> GetAllSection(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.VSectionGetAll();
                    return (from sitm in result
                            select new Timing
                            {


                                Name1 = sitm.Name1,
                                Code = sitm.Code


                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<Timing> GetEmpSection(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.VSectionGetEmp(Code);
                    return (from sitm in result
                            select new Timing
                            {

                                EmpCode = sitm.EmpCode,
                                Name1 = sitm.Name1,
                                Code = sitm.Code
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<Timing> GetEmpSection1(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.VSectionGetEmp1(Section);
                    return (from sitm in result
                            select new Timing
                            {

                                EmpCode = sitm.EmpCode,

                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateVSection(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.vSectionUpdateBySelected(Code, isSelected);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public List<Timing> FindSectionSelected(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.VSectionFindSelected();
                    return (from sitm in result
                            select new Timing
                            {

                                Code = sitm.Code,

                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        */
    }

    [Serializable]
    public class vCountClass
    {
        public int EmpCode { get; set; }
        public int MCount { get; set; }
        public int Count { get; set; }
        public int Count0 { get; set; }
    }
 

    [Serializable]
    public class vAttLogShift
    {
        public int EmpCode { get; set; }
        public string FDate { get; set; }
        public string STime { get; set; }
        public string ETime { get; set; }
        public System.Nullable<int> Shift { get; set; }
        public string FTime { get; set; }
        public string ETime2 { get; set; }
        public string SFTime { get; set; }
        public string SETime { get; set; }
        public string RFTime { get; set; }
        public string RETime { get; set; }
        public System.Nullable<int> DLate { get; set; }
        public System.Nullable<int> DEarly { get; set; }        
        public System.Nullable<int> MDLate { get; set; }
        public System.Nullable<int> MDLateNo { get; set; }
        public System.Nullable<int> YDLate { get; set; }
        public System.Nullable<int> YDLateNo { get; set; }
        public System.Nullable<int> MDEarly { get; set; }
        public System.Nullable<int> YDEarly { get; set; }
        public System.Nullable<int> MDEarlyNo { get; set; }
        public System.Nullable<int> YDEarlyNo { get; set; }
        public System.Nullable<int> MForget { get; set; }
        public System.Nullable<int> YForget { get; set; }
        public System.Nullable<int> Forget { get; set; }
        public string HDate2 { get; set; }
        public System.Nullable<int> HMonth { get; set; }
        public System.Nullable<bool> ThSat { get; set; }
        public int FYear { get; set; }
        public int FMonth { get; set; }
        public int FMonth0 { get; set; }
        public int FMonth2 { get; set; }
        public int delay { get; set; }
        public bool? SPer { get; set; }
        public bool? EPer { get; set; }
        public string Rate
        {
            get
            {
                return this.FMonth2 == 0 ? this.FYear.ToString() : this.FYear.ToString() + "/" + this.FMonth2.ToString();
            }
        }

        public List<vAttLogShift> AllowLate(int Year, int Month, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    int MyYear = 1; 
                    int MyMonth = 1;
                    var result = myContext.vAttlogShiftLate(Year, this.EmpCode);
                    List<vAttLogShift> lsh = new List<vAttLogShift>();
                    lsh = (from sitm in result
                            orderby DateTime.Parse(sitm.FDate)
                            select new vAttLogShift
                            {
                                EmpCode = sitm.EmpCode,
                                FDate = sitm.FDate,
                                STime = sitm.STime,
                                ETime = sitm.ETime,
                                DEarly = sitm.DEarly,
                                DLate = sitm.DLate,
                                ETime2 = sitm.ETime2,
                                Forget = sitm.Forget,
                                FTime = sitm.FTime,
                                MDEarly = sitm.MDEarly,
                                MDEarlyNo = sitm.MDEarlyNo,
                                MDLate = sitm.MDLate,
                                MDLateNo = sitm.MDLateNo,
                                MForget = sitm.MForget,
                                RETime = sitm.RETime,
                                RFTime = sitm.RFTime,
                                SETime = sitm.SETime,
                                SFTime = sitm.SFTime,
                                Shift = sitm.Shift,
                                YDEarly = sitm.YDEarly,
                                YDEarlyNo = sitm.YDEarlyNo,
                                YDLate = sitm.YDLate,
                                YDLateNo = sitm.YDLateNo,
                                YForget = sitm.YForget,
                                HMonth = sitm.HMonth,
                                HDate2 = sitm.HDate,
                                FYear = MyYear++,
                                SPer = sitm.SPer,
                                EPer = sitm.EPer,
                                ThSat = sitm.ThSat,
                                FMonth = sitm.HMonth == 9 ?  moh.SubTime(DateTime.Parse(sitm.STime) , DateTime.Parse(sitm.RFTime)).Hours * 60 + moh.SubTime(DateTime.Parse(sitm.STime) , DateTime.Parse(sitm.RFTime)).Minutes 
                                                    :                                                                                                
                                                    (((int)HDate.Ch_Date(sitm.FDate).DayOfWeek == 6 ? moh.SubTime(DateTime.Parse(sitm.STime) , DateTime.Parse(sitm.SFTime)).Hours * 60 + moh.SubTime(DateTime.Parse(sitm.STime) , DateTime.Parse(sitm.SFTime)).Minutes :
                                                                                                       moh.SubTime(DateTime.Parse(sitm.STime) , DateTime.Parse(sitm.FTime)).Hours * 60 + moh.SubTime(DateTime.Parse(sitm.STime) , DateTime.Parse(sitm.FTime)).Minutes) + 5),
                                FMonth2 = HDate.Ch_Date(sitm.FDate).Month == Month ? MyMonth++ : 0,
                                delay = (bool)sitm.SPer ? 0 :
                                        sitm.HMonth == 9 ? 
                                                    //HDate.Ch_Date(sitm.FDate).Month == Month ? ((DateTime.Parse(sitm.STime) - DateTime.Parse(sitm.RFTime)).Hours * 60 + (DateTime.Parse(sitm.STime) - DateTime.Parse(sitm.RFTime)).Minutes) + 5 : 0
                                                    HDate.Ch_Date(sitm.FDate).Month == Month ? (moh.SubTime(DateTime.Parse(sitm.STime) , DateTime.Parse(sitm.RFTime)).Hours * 60 + moh.SubTime(DateTime.Parse(sitm.STime) , DateTime.Parse(sitm.RFTime)).Minutes) : 0
                                                    :
                                                    HDate.Ch_Date(sitm.FDate).Month == Month ? (((int)HDate.Ch_Date(sitm.FDate).DayOfWeek == 6 ? moh.SubTime(DateTime.Parse(sitm.STime) , DateTime.Parse(sitm.SFTime)).Hours * 60 + moh.SubTime(DateTime.Parse(sitm.STime) , DateTime.Parse(sitm.SFTime)).Minutes :
                                                                                               moh.SubTime(DateTime.Parse(sitm.STime) , DateTime.Parse(sitm.FTime)).Hours * 60 + moh.SubTime(DateTime.Parse(sitm.STime) , DateTime.Parse(sitm.FTime)).Minutes)) : 0                                                                                  
                                                                                               //(DateTime.Parse(sitm.STime) - DateTime.Parse(sitm.FTime)).Hours * 60 + (DateTime.Parse(sitm.STime) - DateTime.Parse(sitm.FTime)).Minutes) + 5) : 0                                                                                  
                            }).ToList();


                    List<vCountClass> vs = new List<vCountClass>();
                    foreach (vAttLogShift itm in lsh)
                    {
                        bool vFound = false;
                        foreach (vCountClass sitm in vs)
                        {
                            if (itm.EmpCode == sitm.EmpCode)
                            {
                                sitm.Count += itm.FMonth;
                                sitm.MCount += itm.FMonth2;
                                sitm.Count0 += itm.FMonth0;

                                itm.FMonth = sitm.Count;
                                itm.FMonth2 = sitm.MCount;
                                itm.FMonth0 = sitm.Count0;
                                vFound = true;
                                break;
                            }
                        }

                        if (!vFound)
                        {
                            vs.Add(new vCountClass
                            {
                                EmpCode = itm.EmpCode,
                                Count = itm.FMonth,
                                MCount = itm.FMonth2,
                                Count0 = itm.FMonth0
                            });
                        }
                    }

                    return (from sitm in lsh
                            where HDate.Ch_Date(sitm.FDate).Month <= Month
                            select sitm).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<vAttLogShift> Late(int Year,int Month, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vAttlogShiftLate2(Year, this.EmpCode);
                    List<vAttLogShift> lsh = new List<vAttLogShift>();
                    lsh = (from sitm in result
                            select new vAttLogShift
                            {
                                EmpCode = sitm.EmpCode,
                                FDate = sitm.FDate,
                                STime = sitm.STime,
                                ETime = sitm.ETime,
                                DEarly = sitm.DEarly,
                                DLate = sitm.DLate,
                                ETime2 = sitm.ETime2,
                                Forget = sitm.Forget,
                                FTime = sitm.FTime,
                                MDEarly = sitm.MDEarly,
                                MDEarlyNo = sitm.MDEarlyNo,
                                MDLate = sitm.MDLate,
                                MDLateNo = sitm.MDLateNo,
                                MForget = sitm.MForget,
                                RETime = sitm.RETime,
                                RFTime = sitm.RFTime,
                                SETime = sitm.SETime,
                                SFTime = sitm.SFTime,
                                Shift = sitm.Shift,
                                YDEarly = sitm.YDEarly,
                                YDEarlyNo = sitm.YDEarlyNo,
                                YDLate = sitm.YDLate,
                                YDLateNo = sitm.YDLateNo,
                                YForget = sitm.YForget,
                                HMonth = sitm.HMonth,
                                HDate2 = sitm.HDate,
                                SPer = sitm.SPer,
                                EPer = sitm.EPer,
                                ThSat = sitm.ThSat,
                                FYear  = 0,
                                FMonth = (bool)sitm.SPer ? 0 :
                                         sitm.HMonth == 9 ? (moh.SubTime(DateTime.Parse(sitm.STime) , DateTime.Parse(sitm.RFTime)).Hours * 60 + moh.SubTime(DateTime.Parse(sitm.STime) , DateTime.Parse(sitm.RFTime)).Minutes) //+ 5
                                                        :
                                                        ((int)HDate.Ch_Date(sitm.FDate).DayOfWeek == 6 ?

                                                        sitm.SFTime == "" || sitm.SETime == "" ?  0 :
                                                        moh.SubTime(DateTime.Parse(sitm.STime) , DateTime.Parse(sitm.SFTime)).Hours * 60 + moh.SubTime(DateTime.Parse(sitm.STime) , DateTime.Parse(sitm.SFTime)).Minutes :
                                                                                                           moh.SubTime(DateTime.Parse(sitm.STime) , DateTime.Parse(sitm.FTime)).Hours * 60 + moh.SubTime(DateTime.Parse(sitm.STime) , DateTime.Parse(sitm.FTime)).Minutes) //+ 5
                            }).ToList();

                    List<vCountClass> vs = new List<vCountClass>();
                    foreach (vAttLogShift itm in lsh)
                    {
                        bool vFound = false;
                        foreach (vCountClass sitm in vs)
                        {
                            if (itm.EmpCode == sitm.EmpCode)
                            {
                                sitm.Count += itm.FMonth;
                                sitm.MCount += HDate.Ch_Date(itm.FDate).Month == Month ? itm.FMonth : 0;
                                itm.FYear = sitm.Count;
                                itm.FMonth2 = sitm.MCount;
                                vFound = true;
                                break;
                            }
                        }

                        if (!vFound)
                        {
                            vs.Add(new vCountClass
                            {
                                EmpCode = itm.EmpCode,
                                Count = itm.FMonth,
                                MCount = HDate.Ch_Date(itm.FDate).Month == Month ? itm.FMonth : 0
                            });
                            itm.FYear = itm.FMonth;
                        }                                                
                    }

                    return (from sitm in lsh
                            where HDate.Ch_Date(sitm.FDate).Month <= Month
                            select sitm).ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<vAttLogShift> ForgetInOut(int Year, int Month, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    int MyYear = 0;
                    int MyMonth = 0;
                    var result = myContext.vAttlogShiftLateLost(Year, this.EmpCode);
                    return (from sitm in result
                            where HDate.Ch_Date(sitm.FDate).Month <= Month
                            select new vAttLogShift
                            {
                                EmpCode = sitm.EmpCode,
                                FDate = sitm.FDate,
                                STime = sitm.STime,
                                ETime = sitm.ETime,
                                DEarly = sitm.DEarly,
                                DLate = sitm.DLate,
                                ETime2 = sitm.ETime2,
                                Forget = sitm.Forget,
                                FTime = sitm.FTime,
                                MDEarly = sitm.MDEarly,
                                MDEarlyNo = sitm.MDEarlyNo,
                                MDLate = sitm.MDLate,
                                MDLateNo = sitm.MDLateNo,
                                MForget = sitm.MForget,
                                RETime = sitm.RETime,
                                RFTime = sitm.RFTime,
                                SETime = sitm.SETime,
                                SFTime = sitm.SFTime,
                                Shift = sitm.Shift,
                                YDEarly = sitm.YDEarly,
                                YDEarlyNo = sitm.YDEarlyNo,
                                YDLate = sitm.YDLate,
                                YDLateNo = sitm.YDLateNo,
                                YForget = sitm.YForget,
                                ThSat = sitm.ThSat,
                                HMonth = sitm.HMonth,
                                HDate2 = sitm.HDate,
                                SPer = sitm.SPer,
                                EPer = sitm.EPer,
                                FYear = MyYear++,
                                FMonth = HDate.Ch_Date(sitm.FDate).Month == Month ? MyMonth++ : 0
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<vAttLogShift> AllowEarly(int Year,int Month, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    int MyYear = 0;
                    int MyMonth = 0;
                    var result = myContext.vAttlogShiftEarly(Year, this.EmpCode);
                    List<vAttLogShift> lsh = new List<vAttLogShift>();
                    lsh = (from sitm in result
                            select new vAttLogShift
                            {
                                EmpCode = sitm.EmpCode,
                                FDate = sitm.FDate,
                                STime = sitm.STime,
                                ETime = sitm.ETime,
                                DEarly = sitm.DEarly,
                                DLate = sitm.DLate,
                                ETime2 = sitm.ETime2,
                                Forget = sitm.Forget,
                                FTime = sitm.FTime,
                                MDEarly = sitm.MDEarly,
                                MDEarlyNo = sitm.MDEarlyNo,
                                MDLate = sitm.MDLate,
                                MDLateNo = sitm.MDLateNo,
                                MForget = sitm.MForget,
                                RETime = sitm.RETime,
                                RFTime = sitm.RFTime,
                                SETime = sitm.SETime,
                                SFTime = sitm.SFTime,
                                Shift = sitm.Shift,
                                YDEarly = sitm.YDEarly,
                                YDEarlyNo = sitm.YDEarlyNo,
                                YDLate = sitm.YDLate,
                                YDLateNo = sitm.YDLateNo,
                                YForget = sitm.YForget,
                                ThSat = sitm.ThSat,
                                HMonth = sitm.HMonth,
                                HDate2 = sitm.HDate,
                                SPer = sitm.SPer,
                                EPer = sitm.EPer,
                                FYear = MyYear++,
                                FMonth = (bool)sitm.EPer ? 0 :
                                          sitm.HMonth == 9 ?     (moh.SubTime(DateTime.Parse(sitm.RETime) , DateTime.Parse(sitm.ETime)).Hours * 60 + moh.SubTime(DateTime.Parse(sitm.RETime) , DateTime.Parse(sitm.ETime)).Minutes)
                                                                :
                                                                (((int)HDate.Ch_Date(sitm.FDate).DayOfWeek == 6 ? moh.SubTime(DateTime.Parse(sitm.SETime) , DateTime.Parse(sitm.ETime)).Hours * 60 + moh.SubTime(DateTime.Parse(sitm.SETime) , DateTime.Parse(sitm.ETime)).Minutes :
                                                                                   moh.SubTime(DateTime.Parse(sitm.ETime2) , DateTime.Parse(sitm.ETime)).Hours * 60 + moh.SubTime(DateTime.Parse(sitm.ETime2) , DateTime.Parse(sitm.ETime)).Minutes)),
                                FMonth2 = HDate.Ch_Date(sitm.FDate).Month == Month ? MyMonth++ : 0,
                                delay =  (bool)sitm.EPer ? 0 :
                                          sitm.HMonth == 9 ?     HDate.Ch_Date(sitm.FDate).Month == Month ? (moh.SubTime(DateTime.Parse(sitm.RETime) , DateTime.Parse(sitm.ETime)).Hours * 60 + moh.SubTime(DateTime.Parse(sitm.RETime) , DateTime.Parse(sitm.ETime)).Minutes) : 0
                                                        :
                                                        HDate.Ch_Date(sitm.FDate).Month == Month ? (((int)HDate.Ch_Date(sitm.FDate).DayOfWeek == 6 ? moh.SubTime(DateTime.Parse(sitm.SETime) , DateTime.Parse(sitm.ETime)).Hours * 60 + moh.SubTime(DateTime.Parse(sitm.SETime) , DateTime.Parse(sitm.ETime)).Minutes :
                                                                                   moh.SubTime(DateTime.Parse(sitm.ETime2) , DateTime.Parse(sitm.ETime)).Hours * 60 + moh.SubTime(DateTime.Parse(sitm.ETime2) , DateTime.Parse(sitm.ETime)).Minutes)) : 0
                            }).ToList();

                    List<vCountClass> vs = new List<vCountClass>();
                    foreach (vAttLogShift itm in lsh)
                    {
                        bool vFound = false;
                        foreach (vCountClass sitm in vs)
                        {
                            if (itm.EmpCode == sitm.EmpCode)
                            {
                                sitm.Count += itm.FMonth;
                                sitm.MCount += itm.FMonth2;
                                sitm.Count0 += itm.FMonth0;

                                itm.FMonth = sitm.Count;
                                itm.FMonth2 = sitm.MCount;
                                itm.FMonth0 = sitm.Count0;
                                vFound = true;
                                break;
                            }
                        }

                        if (!vFound)
                        {
                            vs.Add(new vCountClass
                            {
                                EmpCode = itm.EmpCode,
                                Count = itm.FMonth,
                                MCount = itm.FMonth2,
                                Count0 = itm.FMonth0
                            });
                        }
                    }

                    return (from sitm in lsh
                            where HDate.Ch_Date(sitm.FDate).Month <= Month
                            select sitm).ToList();


                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<vAttLogShift> Early(int Year,int Month, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    int MyYear = 0;
                    int MyMonth = 0;
                    var result = myContext.vAttlogShiftEarly2(Year, this.EmpCode);
                    List<vAttLogShift> lsh = new List<vAttLogShift>();
                    lsh = (from sitm in result
                           where HDate.Ch_Date(sitm.FDate).Month <= Month
                            select new vAttLogShift
                            {
                                EmpCode = sitm.EmpCode,
                                FDate = sitm.FDate,
                                STime = sitm.STime,
                                ETime = sitm.ETime,
                                DEarly = sitm.DEarly,
                                DLate = sitm.DLate,
                                ETime2 = sitm.ETime2,
                                Forget = sitm.Forget,
                                FTime = sitm.FTime,
                                MDEarly = sitm.MDEarly,
                                MDEarlyNo = sitm.MDEarlyNo,
                                MDLate = sitm.MDLate,
                                MDLateNo = sitm.MDLateNo,
                                MForget = sitm.MForget,
                                RETime = sitm.RETime,
                                RFTime = sitm.RFTime,
                                SETime = sitm.SETime,
                                SFTime = sitm.SFTime,
                                Shift = sitm.Shift,
                                HMonth = sitm.HMonth,
                                HDate2 = sitm.HDate,
                                YDEarly = sitm.YDEarly,
                                YDEarlyNo = sitm.YDEarlyNo,
                                YDLate = sitm.YDLate,
                                YDLateNo = sitm.YDLateNo,
                                YForget = sitm.YForget,
                                ThSat = sitm.ThSat,
                                SPer = sitm.SPer,
                                EPer = sitm.EPer,
                                FYear  = 0,
                                FMonth = (bool)sitm.EPer ? 0 :                                
                                            sitm.HMonth == 9 ?                                 
                                            (DateTime.Parse(sitm.ETime) < DateTime.Parse(sitm.RETime) && DateTime.Parse(sitm.ETime) < DateTime.Parse("03:30") &&  DateTime.Parse(sitm.RETime) > DateTime.Parse("03:30")) ?  0 :
                                
                                            (moh.SubTime(DateTime.Parse(sitm.RETime) , DateTime.Parse(sitm.ETime)).Hours * 60 + moh.SubTime(DateTime.Parse(sitm.RETime) , DateTime.Parse(sitm.ETime)).Minutes)

                                                                        :                                
                                                                        ((int)HDate.Ch_Date(sitm.FDate).DayOfWeek == 6 ? moh.SubTime(DateTime.Parse(sitm.SETime) , DateTime.Parse(sitm.ETime)).Hours * 60 + moh.SubTime(DateTime.Parse(sitm.SETime) , DateTime.Parse(sitm.ETime)).Minutes :
                                                                                                                           moh.SubTime(DateTime.Parse(sitm.ETime2) , DateTime.Parse(sitm.ETime)).Hours * 60 + moh.SubTime(DateTime.Parse(sitm.ETime2) , DateTime.Parse(sitm.ETime)).Minutes)
                            }).ToList();
                    List<vCountClass> vs = new List<vCountClass>();
                    foreach (vAttLogShift itm in lsh)
                    {
                        bool vFound = false;
                        foreach (vCountClass sitm in vs)
                        {
                            if (itm.EmpCode == sitm.EmpCode)
                            {
                                sitm.Count += itm.FMonth;
                                sitm.MCount += HDate.Ch_Date(itm.FDate).Month == Month ? itm.FMonth : 0;
                                itm.FYear = sitm.Count;
                                itm.FMonth2 = sitm.MCount;
                                vFound = true;
                                break;
                            }
                        }

                        if (!vFound)
                        {
                            vs.Add(new vCountClass
                            {
                                EmpCode = itm.EmpCode,
                                Count = itm.FMonth,
                                MCount = HDate.Ch_Date(itm.FDate).Month == Month ? itm.FMonth : 0
                            });
                            itm.FYear = itm.FMonth;
                        }
                    }

                    return (from sitm in lsh
                            where HDate.Ch_Date(sitm.FDate).Month <= Month
                            select sitm).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}