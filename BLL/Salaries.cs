using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    [Serializable]
    public class Salaries
    {
        public short Year1 { get; set; }
        public short Month1 { get; set; }
        public int EmpCode { get; set; }
        public double? Basic { get; set; }
        public double? Add01 { get; set; }
        public double? Add02 { get; set; }
        public double? Add03 { get; set; }
        public double? Add04 { get; set; }
        public double? Add05 { get; set; }
        public double? Add06 { get; set; }
        public double? Add07 { get; set; }
        public double? Add08 { get; set; }
        public double? Add09 { get; set; }
        public double? Add10 { get; set; }
        public double? Add11 { get; set; }
        public double? Add12 { get; set; }
        public double? Add13 { get; set; }
        public double? Add14 { get; set; }
        public double? Add15 { get; set; }
        public double? Ded01 { get; set; }
        public double? Ded02 { get; set; }
        public double? Ded03 { get; set; }
        public double? Ded04 { get; set; }
        public double? Ded05 { get; set; }
        public double? Ded06 { get; set; }
        public double? Ded07 { get; set; }
        public double? Ded08 { get; set; }
        public double? Ded09 { get; set; }
        public double? Ded10 { get; set; }
        public double? Ded11 { get; set; }
        public double? Ded12 { get; set; }
        public double? Ded13 { get; set; }
        public double? Ded14 { get; set; }
        public double? Ded014 { get; set; }
        public double? Ded15 { get; set; }
        public double? Net2 { get; set; }
        public string sBasic { get; set; }
        public string sAdd01 { get; set; }
        public string sAdd02 { get; set; }
        public string sAdd03 { get; set; }
        public string sAdd04 { get; set; }
        public string sAdd05 { get; set; }
        public string sAdd06 { get; set; }
        public string sAdd07 { get; set; }
        public string sAdd08 { get; set; }
        public string sAdd09 { get; set; }
        public string sAdd10 { get; set; }
        public string sAdd11 { get; set; }
        public string sAdd12 { get; set; }
        public string sAdd13 { get; set; }
        public string sAdd14 { get; set; }
        public string sAdd15 { get; set; }
        public string sDed01 { get; set; }
        public string sDed02 { get; set; }
        public string sDed03 { get; set; }
        public string sDed04 { get; set; }
        public string sDed05 { get; set; }
        public string sDed06 { get; set; }
        public string sDed07 { get; set; }
        public string sDed08 { get; set; }
        public string sDed09 { get; set; }
        public string sDed10 { get; set; }
        public string sDed11 { get; set; }
        public string sDed12 { get; set; }
        public string sDed13 { get; set; }
        public string sDed14 { get; set; }
        public string sDed15 { get; set; }        
        public string Name { get; set; }
        public short? FNo { get; set; }
        public int Code { get; set; }
        public int? Section { get; set; }
        public int? Dep { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public bool? isSelected { get; set; }
        public string EndDate { get; set; }
        public string ReturnDate { get; set; }
        public string vacDate { get; set; }
        public string Username { get; set; }
        public string UserDate { get; set; }
        public short? NoDays { get; set; }
        public short? NoDays2 { get; set; }
        public string Remark { get; set; }
        public double? Add041 { get; set; }
        public double? Add042 { get; set; }
        public double? Ded021 { get; set; }
        public double? Ded022 { get; set; }
        public double? Add00 { get; set; }
        public double? Ded00 { get; set; }
        public int? VouNo { get; set; }
        public bool? Status { get; set; }
        public string ATM { get; set; }
        public string PaperNo1 { get; set; }
        public string OP {
            get {

                return "Load Funds";
            }

        }
        public double AddAll
        {
            get
            {
                return (double)(this.Basic + this.Add01 + this.Add02 + this.Add03 + this.Add04 + this.Add05 + this.Add06 + this.Add07 + this.Add08 + this.Add09 + this.Add10 + this.Add11 + this.Add12 + this.Add13 + this.Add14 + this.Add15);
            }
        }

        public double DedAll
        {
            get
            {
                return (double)(this.Ded01 + this.Ded02 + this.Ded03 + this.Ded04 + this.Ded05 + this.Ded06 + this.Ded07 + this.Ded08 + this.Ded09 + this.Ded10 + this.Ded11 + this.Ded12 + this.Ded13 + this.Ded14 + this.Ded15);
            }
        }

        public double Net
        {
            get
            {
                return Math.Round((double)(this.AddAll - this.DedAll),2);
            }
        }



        public Salaries()
        {
            this.FNo = 0;
            this.Year1 = 0;
            this.Month1 = 0;
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
            this.Ded014 = 0;
            this.Ded15 = 0;
            this.EmpCode = 0;
            this.Name = "";
            this.Code = 0;
            this.Section = -1;
            this.Name1 = "";
            this.isSelected = false;
            this.EndDate = "";
            this.ReturnDate = "";
            this.vacDate = "";
            this.Username = "";
            this.UserDate = "";
            this.NoDays = 0;
            this.NoDays2 = 0;
            this.Remark = "";
            this.sBasic = "";
            this.sAdd01 = "";
            this.sAdd02 = "";
            this.sAdd03 = "";
            this.sAdd04 = "";
            this.sAdd05 = "";
            this.sAdd06 = "";
            this.sAdd07 = "";
            this.sAdd08 = "";
            this.sAdd09 = "";
            this.sAdd10 = "";
            this.sAdd11 = "";
            this.sAdd12 = "";
            this.sAdd13 = "";
            this.sAdd14 = "";
            this.sAdd15 = "";
            this.sDed01 = "";
            this.sDed02 = "";
            this.sDed03 = "";
            this.sDed04 = "";
            this.sDed05 = "";
            this.sDed06 = "";
            this.sDed07 = "";
            this.sDed08 = ""; 
            this.sDed09 = "";
            this.sDed10 = "";
            this.sDed11 = "";
            this.sDed12 = "";
            this.sDed13 = "";
            this.sDed14 = "";
            this.sDed15 = "";
            this.Add041 = 0;
            this.Add042 = 0;
            this.Ded021 = 0;
            this.Ded022 = 0;
            this.VouNo = 0;
            this.Net2 = 0;
            this.ATM = "";
            this.PaperNo1 = "";
            this.Add00 = 0;
            this.Ded00 = 0;
            this.Name2 = "";
            this.Status = false;
            this.Dep = -1;
        }


        public bool insertSalary(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.SalaryAdd(this.EmpCode, this.Year1, this.Month1, this.Basic, this.Add01, this.Add02, this.Add03, this.Add04, this.Add05, this.Add06, this.Add07, this.Add08, this.Add09, this.Add10, this.Add11, this.Add12, this.Add13, this.Add14, this.Add15, this.Ded01, this.Ded02, this.Ded03, this.Ded04, this.Ded05, this.Ded06, this.Ded07, this.Ded08, this.Ded09, this.Ded10, this.Ded11, this.Ded12, this.Ded13, this.Ded14,this.Ded014, this.Ded15, this.Section, this.Username, this.UserDate, this.NoDays, this.Remark, this.sBasic, this.sAdd01, this.sAdd02, this.sAdd03, this.sAdd04, this.sAdd05, this.sAdd06, this.sAdd07, this.sAdd08, this.sAdd09, this.sAdd10, this.sAdd11, this.sAdd12, this.sAdd13, this.sAdd14, this.sAdd15, this.sDed01, this.sDed02, this.sDed03, this.sDed04, this.sDed05, this.sDed06, this.sDed07, this.sDed08, this.sDed09, this.sDed10, this.sDed11, this.sDed12, this.sDed13, this.sDed14, this.sDed15,this.Add041,this.Add042,this.Ded021,this.Ded022,this.VouNo,this.Status);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.SalaryEmpUpdate(this.EmpCode, this.Year1, this.Month1, this.Basic, this.Add01, this.Add02, this.Add03, this.Add04, this.Add05, this.Add06, this.Add07, this.Add08, this.Add09, this.Add10, this.Add11, this.Add12, this.Add13, this.Add14, this.Add15, this.Ded01, this.Ded02, this.Ded03, this.Ded04, this.Ded05, this.Ded06, this.Ded07, this.Ded08, this.Ded09, this.Ded10, this.Ded11, this.Ded12, this.Ded13, this.Ded14,this.Ded014, this.Ded15, this.Section, this.Username, this.UserDate, this.NoDays, this.Remark, this.sBasic, this.sAdd01, this.sAdd02, this.sAdd03, this.sAdd04, this.sAdd05, this.sAdd06, this.sAdd07, this.sAdd08, this.sAdd09, this.sAdd10, this.sAdd11, this.sAdd12, this.sAdd13, this.sAdd14, this.sAdd15, this.sDed01, this.sDed02, this.sDed03, this.sDed04, this.sDed05, this.sDed06, this.sDed07, this.sDed08, this.sDed09, this.sDed10, this.sDed11, this.sDed12, this.sDed13, this.sDed14, this.sDed15, this.Add041, this.Add042, this.Ded021, this.Ded022, this.VouNo,this.Status);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SetStatus(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.SalarySetStatus(this.Year1, this.Month1,this.EmpCode, this.Status);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteMonthSalary(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.SalaryDeleteMonth(Year1, Month1);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool DeleteSalary(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.SalaryDelete(EmpCode, Year1, Month1);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckMonth(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.SalaryCheckMonth(this.Year1, this.Month1);
                    return (result.Count() > 0);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Salaries CheckVouNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.SalaryCheckVouNo(this.VouNo);
                    return (from sitm in result
                            select new Salaries
                            {
                                FNo = 1,
                                EmpCode = sitm.EmpCode,
                                Section = sitm.Section,
                                Basic = sitm.Basic,
                                Add01 = sitm.Add01,
                                Add02 = sitm.Add02,
                                Add03 = sitm.Add03,
                                Add04 = sitm.Add04,
                                Add05 = sitm.Add05,
                                Add06 = sitm.Add06,
                                Add07 = sitm.Add07,
                                Add08 = sitm.Add08,
                                Add09 = sitm.Add09,
                                Add10 = sitm.Add10,
                                Add11 = sitm.Add11,
                                Add12 = sitm.Add12,
                                Add13 = sitm.Add13,
                                Add14 = sitm.Add14,
                                Add15 = sitm.Add15,
                                Ded01 = sitm.Ded01,
                                Ded02 = sitm.Ded02,
                                Ded03 = sitm.Ded03,
                                Ded04 = sitm.Ded04,
                                Ded05 = sitm.Ded05,
                                Ded06 = sitm.Ded06,
                                Ded07 = sitm.Ded07,
                                Ded08 = sitm.Ded08,
                                Ded09 = sitm.Ded09,
                                Ded10 = sitm.Ded10,
                                Ded11 = sitm.Ded11,
                                Ded12 = sitm.Ded12,
                                Ded13 = sitm.Ded13,
                                Ded14 = sitm.Ded14,
                                Ded014 = sitm.Ded014,
                                Ded15 = sitm.Ded15,
                                Month1 = sitm.Month1,
                                Year1 = sitm.Year1,
                                Username = sitm.UserName,
                                UserDate = sitm.UserDate,
                                NoDays = sitm.NoDays,
                                Remark = sitm.Remark,
                                sBasic = sitm.sBasic,
                                sAdd01 = sitm.sAdd01,
                                sAdd02 = sitm.sAdd02,
                                sAdd03 = sitm.sAdd03,
                                sAdd04 = sitm.sAdd04,
                                sAdd05 = sitm.sAdd05,
                                sAdd06 = sitm.sAdd06,
                                sAdd07 = sitm.sAdd07,
                                sAdd08 = sitm.sAdd08,
                                sAdd09 = sitm.sAdd09,
                                sAdd10 = sitm.sAdd10,
                                sAdd11 = sitm.sAdd11,
                                sAdd12 = sitm.sAdd12,
                                sAdd13 = sitm.sAdd13,
                                sAdd14 = sitm.sAdd14,
                                sAdd15 = sitm.sAdd15,
                                sDed01 = sitm.sDed01,
                                sDed02 = sitm.sDed02,
                                sDed03 = sitm.sDed03,
                                sDed04 = sitm.sDed04,
                                sDed05 = sitm.sDed05,
                                sDed06 = sitm.sDed06,
                                sDed07 = sitm.sDed07,
                                sDed08 = sitm.sDed08,
                                sDed09 = sitm.sDed09,
                                sDed10 = sitm.sDed10,
                                sDed11 = sitm.sDed11,
                                sDed12 = sitm.sDed12,
                                sDed13 = sitm.sDed13,
                                sDed14 = sitm.sDed14,
                                sDed15 = sitm.sDed15,
                                Add041 = sitm.Add041,
                                Add042 = sitm.Add042,
                                Ded021 = sitm.Ded021,
                                Ded022 = sitm.Ded022,
                                VouNo = sitm.VouNo,                                
                                Status = sitm.Status
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<Salaries> GetAllSalary(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    int fno = 1;
                    var result = myContext.VSalaryVSectionGetAll(Year1, Month1);
                    return (from sitm in result
                            select new Salaries
                            {
                                FNo = (short)fno++,
                                EmpCode = sitm.EmpCode,
                                Name = sitm.Name,
                                Name1 = sitm.Name1,
                                Section = sitm.Section,
                                Basic = sitm.Basic,
                                Add01 = sitm.Add01,
                                Add02 = sitm.Add02,
                                Add03 = sitm.Add03,
                                Add04 = sitm.Add04,
                                Add05 = sitm.Add05,
                                Add06 = sitm.Add06,
                                Add07 = sitm.Add07,
                                Add08 = sitm.Add08,
                                Add09 = sitm.Add09,
                                Add10 = sitm.Add10,
                                Add11 = sitm.Add11,
                                Add12 = sitm.Add12,
                                Add13 = sitm.Add13,
                                Add14 = sitm.Add14,
                                Add15 = sitm.Add15,
                                Ded01 = sitm.Ded01,
                                Ded02 = sitm.Ded02,
                                Ded03 = sitm.Ded03,
                                Ded04 = sitm.Ded04,
                                Ded05 = sitm.Ded05,
                                Ded06 = sitm.Ded06,
                                Ded07 = sitm.Ded07,
                                Ded08 = sitm.Ded08,
                                Ded09 = sitm.Ded09,
                                Ded10 = sitm.Ded10,
                                Ded11 = sitm.Ded11,
                                Ded12 = sitm.Ded12,
                                Ded13 = sitm.Ded13,
                                Ded14 = sitm.Ded14,
                                Ded014 = sitm.Ded014,
                                Ded15 = sitm.Ded15,
                                Month1 = sitm.Month1,
                                Year1 = sitm.Year1,
                                Username = sitm.UserName,
                                UserDate = sitm.UserDate,
                                NoDays2 = (short)(((double)sitm.NoDays - (double)sitm.Ded021) < 0 ? 0 : (short)((double)sitm.NoDays - (double)sitm.Ded021)),
                                NoDays = sitm.NoDays,
                                Remark = sitm.Remark,
                                sBasic = sitm.sBasic,
                                sAdd01 = sitm.sAdd01,
                                sAdd02 = sitm.sAdd02,
                                sAdd03 = sitm.sAdd03,
                                sAdd04 = sitm.sAdd04,
                                sAdd05 = sitm.sAdd05,
                                sAdd06 = sitm.sAdd06,
                                sAdd07 = sitm.sAdd07,
                                sAdd08 = sitm.sAdd08,
                                sAdd09 = sitm.sAdd09,
                                sAdd10 = sitm.sAdd10,
                                sAdd11 = sitm.sAdd11,
                                sAdd12 = sitm.sAdd12,
                                sAdd13 = sitm.sAdd13,
                                sAdd14 = sitm.sAdd14,
                                sAdd15 = sitm.sAdd15,
                                sDed01 = sitm.sDed01,
                                sDed02 = sitm.sDed02,
                                sDed03 = sitm.sDed03,
                                sDed04 = sitm.sDed04,
                                sDed05 = sitm.sDed05,
                                sDed06 = sitm.sDed06,
                                sDed07 = sitm.sDed07,
                                sDed08 = sitm.sDed08,
                                sDed09 = sitm.sDed09,
                                sDed10 = sitm.sDed10,
                                sDed11 = sitm.sDed11,
                                sDed12 = sitm.sDed12,
                                sDed13 = sitm.sDed13,
                                sDed14 = sitm.sDed14,
                                sDed15 = sitm.sDed15,
                                Add041 = sitm.Add041,
                                Add042 = sitm.Add042,
                                Ded021 = sitm.Ded021,
                                Ded022 = sitm.Ded022,
                                VouNo = sitm.VouNo,
                                ATM = sitm.ATM,
                                PaperNo1 = sitm.PaperNo1,
                                Name2 = sitm.EmpName2,
                                Status = sitm.Status,
                                Dep = sitm.Dep
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Salaries> GetAllSection(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    int fno = 1;
                    var result = myContext.VSalaryVSectionGetSelected(Year1, Month1,this.Section);
                    return (from sitm in result
                            select new Salaries
                            {
                                FNo = (short)fno++,
                                EmpCode = sitm.EmpCode,
                                Name = sitm.Name,
                                Name1 = sitm.Name1,
                                Section = sitm.Section,
                                Basic = sitm.Basic,
                                Add01 = sitm.Add01,
                                Add02 = sitm.Add02,
                                Add03 = sitm.Add03,
                                Add04 = sitm.Add04,
                                Add05 = sitm.Add05,
                                Add06 = sitm.Add06,
                                Add07 = sitm.Add07,
                                Add08 = sitm.Add08,
                                Add09 = sitm.Add09,
                                Add10 = sitm.Add10,
                                Add11 = sitm.Add11,
                                Add12 = sitm.Add12,
                                Add13 = sitm.Add13,
                                Add14 = sitm.Add14,
                                Add15 = sitm.Add15,
                                Ded01 = sitm.Ded01,
                                Ded02 = sitm.Ded02,
                                Ded03 = sitm.Ded03,
                                Ded04 = sitm.Ded04,
                                Ded05 = sitm.Ded05,
                                Ded06 = sitm.Ded06,
                                Ded07 = sitm.Ded07,
                                Ded08 = sitm.Ded08,
                                Ded09 = sitm.Ded09,
                                Ded10 = sitm.Ded10,
                                Ded11 = sitm.Ded11,
                                Ded12 = sitm.Ded12,
                                Ded13 = sitm.Ded13,
                                Ded14 = sitm.Ded14,
                                Ded014 = sitm.Ded014,
                                Ded15 = sitm.Ded15,
                                Month1 = sitm.Month1,
                                Year1 = sitm.Year1,
                                Username = sitm.UserName,
                                UserDate = sitm.UserDate,
                                NoDays2 = (short)(((double)sitm.NoDays - (double)sitm.Ded021) < 0 ? 0 : (short)((double)sitm.NoDays - (double)sitm.Ded021)),
                                NoDays = sitm.NoDays,
                                Remark = sitm.Remark,
                                sBasic = sitm.sBasic,
                                sAdd01 = sitm.sAdd01,
                                sAdd02 = sitm.sAdd02,
                                sAdd03 = sitm.sAdd03,
                                sAdd04 = sitm.sAdd04,
                                sAdd05 = sitm.sAdd05,
                                sAdd06 = sitm.sAdd06,
                                sAdd07 = sitm.sAdd07,
                                sAdd08 = sitm.sAdd08,
                                sAdd09 = sitm.sAdd09,
                                sAdd10 = sitm.sAdd10,
                                sAdd11 = sitm.sAdd11,
                                sAdd12 = sitm.sAdd12,
                                sAdd13 = sitm.sAdd13,
                                sAdd14 = sitm.sAdd14,
                                sAdd15 = sitm.sAdd15,
                                sDed01 = sitm.sDed01,
                                sDed02 = sitm.sDed02,
                                sDed03 = sitm.sDed03,
                                sDed04 = sitm.sDed04,
                                sDed05 = sitm.sDed05,
                                sDed06 = sitm.sDed06,
                                sDed07 = sitm.sDed07,
                                sDed08 = sitm.sDed08,
                                sDed09 = sitm.sDed09,
                                sDed10 = sitm.sDed10,
                                sDed11 = sitm.sDed11,
                                sDed12 = sitm.sDed12,
                                sDed13 = sitm.sDed13,
                                sDed14 = sitm.sDed14,
                                sDed15 = sitm.sDed15,
                                Add041 = sitm.Add041,
                                Add042 = sitm.Add042,
                                Ded021 = sitm.Ded021,
                                Ded022 = sitm.Ded022,
                                VouNo = sitm.VouNo,
                                ATM = sitm.ATM,
                                PaperNo1 = sitm.PaperNo1,
                                Name2 = sitm.EmpName2,
                                Status = sitm.Status,
                                Dep = sitm.Dep
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public Salaries GetEmp(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    int fno = 1;
                    var result = myContext.VSalaryVSectionGetEmp(this.Year1, this.Month1, this.EmpCode);
                    return (from sitm in result
                            select new Salaries
                            {
                                FNo = (short)fno++,
                                EmpCode = sitm.EmpCode,
                                Name = sitm.Name,
                                Name1 = sitm.Name1,
                                Section = sitm.Section,
                                Basic = sitm.Basic,
                                Add01 = sitm.Add01,
                                Add02 = sitm.Add02,
                                Add03 = sitm.Add03,
                                Add04 = sitm.Add04,
                                Add05 = sitm.Add05,
                                Add06 = sitm.Add06,
                                Add07 = sitm.Add07,
                                Add08 = sitm.Add08,
                                Add09 = sitm.Add09,
                                Add10 = sitm.Add10,
                                Add11 = sitm.Add11,
                                Add12 = sitm.Add12,
                                Add13 = sitm.Add13,
                                Add14 = sitm.Add14,
                                Add15 = sitm.Add15,
                                Ded01 = sitm.Ded01,
                                Ded02 = sitm.Ded02,
                                Ded03 = sitm.Ded03,
                                Ded04 = sitm.Ded04,
                                Ded05 = sitm.Ded05,
                                Ded06 = sitm.Ded06,
                                Ded07 = sitm.Ded07,
                                Ded08 = sitm.Ded08,
                                Ded09 = sitm.Ded09,
                                Ded10 = sitm.Ded10,
                                Ded11 = sitm.Ded11,
                                Ded12 = sitm.Ded12,
                                Ded13 = sitm.Ded13,
                                Ded14 = sitm.Ded14,
                                Ded014 = sitm.Ded014,
                                Ded15 = sitm.Ded15,
                                Month1 = sitm.Month1,
                                Year1 = sitm.Year1,
                                Username = sitm.UserName,
                                UserDate = sitm.UserDate,
                                NoDays = sitm.NoDays,
                                Remark = sitm.Remark,
                                sBasic = sitm.sBasic,
                                sAdd01 = sitm.sAdd01,
                                sAdd02 = sitm.sAdd02,
                                sAdd03 = sitm.sAdd03,
                                sAdd04 = sitm.sAdd04,
                                sAdd05 = sitm.sAdd05,
                                sAdd06 = sitm.sAdd06,
                                sAdd07 = sitm.sAdd07,
                                sAdd08 = sitm.sAdd08,
                                sAdd09 = sitm.sAdd09,
                                sAdd10 = sitm.sAdd10,
                                sAdd11 = sitm.sAdd11,
                                sAdd12 = sitm.sAdd12,
                                sAdd13 = sitm.sAdd13,
                                sAdd14 = sitm.sAdd14,
                                sAdd15 = sitm.sAdd15,
                                sDed01 = sitm.sDed01,
                                sDed02 = sitm.sDed02,
                                sDed03 = sitm.sDed03,
                                sDed04 = sitm.sDed04,
                                sDed05 = sitm.sDed05,
                                sDed06 = sitm.sDed06,
                                sDed07 = sitm.sDed07,
                                sDed08 = sitm.sDed08,
                                sDed09 = sitm.sDed09,
                                sDed10 = sitm.sDed10,
                                sDed11 = sitm.sDed11,
                                sDed12 = sitm.sDed12,
                                sDed13 = sitm.sDed13,
                                sDed14 = sitm.sDed14,
                                sDed15 = sitm.sDed15,
                                Add041 = sitm.Add041,
                                Add042 = sitm.Add042,
                                Ded021 = sitm.Ded021,
                                Ded022 = sitm.Ded022,
                                VouNo = sitm.VouNo,
                                ATM = sitm.ATM,
                                PaperNo1 = sitm.PaperNo1,
                                Name2 = sitm.EmpName2,
                                Status = sitm.Status,
                                Dep = sitm.Dep
                            }).FirstOrDefault();
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
        public List<string> GetMonth(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.SalaryGetMonth();
                    return (from itm in result
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
        public List<string> GetMonth2019(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.SalaryGetMonth();
                    return (from itm in result
                            where int.Parse(itm.Month2.Split('/')[0]) >= 2019
                            select itm.Month2).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


    }

    [Serializable]
    public class TransSal
    {
        public double? Net { get; set; }
        public string ATM { get; set; }
        public string Name { get; set; }
        public double? Basic { get; set; }
        public double? House { get; set; }
        public double? Other { get; set; }
        public double? Ded { get; set; }
        public string ID { get; set; }
        public string Status { get; set; }
    }

}

