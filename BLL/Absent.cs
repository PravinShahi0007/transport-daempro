using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Absent
    {
        public int EmpCode { get; set; }
        public string FDate { get; set; }
        public short? FType { get; set; }
        public string Remark { get; set; }
        public string Remark2 { get; set; }
        public string FNo2 { get; set; }
        public string FType2
        {
            get
            {
                switch (this.FType)
                {
                    case 0: return "بدون عذر";
                    case 1: return "أجازة مرضية";
                    case 2: return "أضطراري";
                    case 3: return "أجازة براتب";
                    case 4: return "أجازة بدون راتب";
                    default: return "أخرى";
                }
            }
        }
        public string FDate2
        {
            get
            {
                return moh.Days[(int)DateTime.Parse(this.FDate).DayOfWeek + 1] + " " + this.FDate;
            }
        } 

        public Absent()
        {
            this.EmpCode = 0;
            this.FDate = "";
            this.FType = 0;
            this.Remark = "";
            this.Remark2 = "";
            this.FNo2 = "";
        }

        /// <summary>
        /// Add Car in Cars Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.AbsentAdd(this.EmpCode, this.FDate, this.FType, this.Remark);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Car from Cars Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.AbsentDelete(this.EmpCode, this.FDate);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Car in Cars Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.Absentupdate(this.EmpCode, this.FDate, this.FType, this.Remark);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select all Cars from Cars Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<Absent> GetByDay(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.AbsentGetByDay(this.FDate);
                    return (from itm in result
                            select new Absent
                            {
                                 FType = itm.FType,
                                 EmpCode = itm.EmpCode,
                                 FDate = itm.FDate,
                                 Remark = itm.Remark
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cars from Cars Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<Absent> GetByMonth(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.AbsentGetByMonth(this.FDate);
                    return (from itm in result
                            select new Absent
                            {
                                FType = itm.FType,
                                EmpCode = itm.EmpCode,
                                FDate = itm.FDate,
                                Remark = itm.Remark
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cars from Cars Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<Absent> GetByMonthEmp(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.AbsentGetByMonthEmp(this.EmpCode, this.FDate);
                    return (from itm in result
                            select new Absent
                            {
                                FType = itm.FType,
                                EmpCode = itm.EmpCode,
                                FDate = itm.FDate,
                                Remark = itm.Remark
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cars from Cars Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public Absent Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.AbsentGet(this.EmpCode, this.FDate);
                    return (from itm in result
                            select new Absent
                            {
                                FType = itm.FType,
                                EmpCode = itm.EmpCode,
                                FDate = itm.FDate,
                                Remark = itm.Remark
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cars from Cars Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public EmpTypes GetEmpTypes(int FYear,int FMonth,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.AbsentGetEmpTypes(this.EmpCode, FYear , FMonth);
                    return (from itm in result
                            select new EmpTypes
                            {
                                Abs0 = itm.abs0,
                                Abs1 = itm.abs1,
                                Abs2 = itm.abs2,
                                Abs3 = itm.abs3,
                                Abs4 = itm.abs4,
                                Abs5 = itm.abs5
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }

    [Serializable]
    public class EmpTypes
    {
        public int? Abs0 { get; set; }
        public int? Abs1 { get; set; }
        public int? Abs2 { get; set; }
        public int? Abs3 { get; set; }
        public int? Abs4 { get; set; }
        public int? Abs5 { get; set; }
    }

}
