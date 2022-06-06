using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
	public class SEmp
    {
		public  int EmpCode { get; set; }
		public  string Name { get; set; }
		public  string Name2 { get; set; }
		public  string JobNo { get; set; }
		public  string MobileNo { get; set; }
		public  System.Nullable<int> Nat { get; set; }
		public  System.Nullable<int> Certificate { get; set; }
		public  System.Nullable<int> Reginal { get; set; }
		public  System.Nullable<int> Section { get; set; }
        public System.Nullable<int> Dep { get; set; }
		public  System.Nullable<int> Job { get; set; }
		public  string EnterVisaNo { get; set; }
		public  string EnterVisaPlace { get; set; }
		public  string EnterVisaNo2 { get; set; }
		public  string EnterVisaDate { get; set; }
		public  string EnterVisaDate2 { get; set; }
		public  string WorkerNo { get; set; }
		public  string IqamaEnd { get; set; }
		public  string Office { get; set; }
		public  string OfficeManager { get; set; }
		public  string PaperNo1 { get; set; }
		public  string PaperNo2 { get; set; }
		public  string PaperNo3 { get; set; }
		public  string PaperNo4 { get; set; }
		public  string PaperNo5 { get; set; }
		public  string PaperNo6 { get; set; }
		public  string PaperNo7 { get; set; }
		public  string PaperNo8 { get; set; }
		public  string PaperNo9 { get; set; }
		public  string PaperNo10 { get; set; }
        public  string PLoc1 { get; set; }
        public  string PLoc2 { get; set; }
        public  string PLoc3 { get; set; }
        public  string PLoc4 { get; set; }
        public  string PLoc5 { get; set; }
        public  string PLoc6 { get; set; }
        public  string PLoc7 { get; set; }
        public  string PLoc8 { get; set; }
        public  string PLoc9 { get; set; }
        public  string PLoc10 { get; set; }
		public  System.Nullable<int> PaperLoc1 { get; set; }
		public  System.Nullable<int> PaperLoc2 { get; set; }
		public  System.Nullable<int> PaperLoc3 { get; set; }
		public  System.Nullable<int> PaperLoc4 { get; set; }
		public  System.Nullable<int> PaperLoc5 { get; set; }
		public  System.Nullable<int> PaperLoc6 { get; set; }
		public  System.Nullable<int> PaperLoc7 { get; set; }
		public  System.Nullable<int> PaperLoc8 { get; set; }
		public  System.Nullable<int> PaperLoc9 { get; set; }
		public  System.Nullable<int> PaperLoc10 { get; set; }
		public  string IssueDate1 { get; set; }
		public  string IssueDate2 { get; set; }
		public  string IssueDate3 { get; set; }
		public  string IssueDate4 { get; set; }
		public  string IssueDate5 { get; set; }
		public  string IssueDate6 { get; set; }
		public  string IssueDate7 { get; set; }
		public  string IssueDate8 { get; set; }
		public  string IssueDate9 { get; set; }
		public  string IssueDate10 { get; set; }
		public  string ExpDate1 { get; set; }
		public  string ExpDate2 { get; set; }
		public  string ExpDate3 { get; set; }
		public  string ExpDate4 { get; set; }
		public  string ExpDate5 { get; set; }
		public  string ExpDate6 { get; set; }
		public  string ExpDate7 { get; set; }
		public  string ExpDate8 { get; set; }
		public  string ExpDate9 { get; set; }
		public  string ExpDate10 { get; set; }
		public  string FileName1 { get; set; }
		public  string FileName2 { get; set; }
		public  string FileName3 { get; set; }
		public  string FileName4 { get; set; }
		public  string FileName5 { get; set; }
		public  string FileName6 { get; set; }
		public  string FileName7 { get; set; }
		public  string FileName8 { get; set; }
		public  string FileName9 { get; set; }
		public  string FileName10 { get; set; }
		public  System.Nullable<double> Basic { get; set; }
		public  System.Nullable<double> Add01 { get; set; }
		public  System.Nullable<double> Add02 { get; set; }
		public  System.Nullable<double> Add03 { get; set; }
		public  System.Nullable<double> Add04 { get; set; }
		public  System.Nullable<double> Add05 { get; set; }
		public  System.Nullable<double> Add06 { get; set; }
		public  System.Nullable<double> Add07 { get; set; }
		public  System.Nullable<double> Add08 { get; set; }
		public  System.Nullable<double> Add09 { get; set; }
		public  System.Nullable<double> Add10 { get; set; }
        public  System.Nullable<double> Add11 { get; set; }
        public  System.Nullable<double> Add12 { get; set; }
        public  System.Nullable<double> Add13 { get; set; }
        public  System.Nullable<double> Add14 { get; set; }
        public  System.Nullable<double> Add15 { get; set; }
		public  System.Nullable<double> Ded01 { get; set; }
		public  System.Nullable<double> Ded02 { get; set; }
		public  System.Nullable<double> Ded03 { get; set; }
		public  System.Nullable<double> Ded04 { get; set; }
		public  System.Nullable<double> Ded05 { get; set; }
		public  System.Nullable<double> Ded06 { get; set; }
		public  System.Nullable<double> Ded07 { get; set; }
		public  System.Nullable<double> Ded08 { get; set; }
		public  System.Nullable<double> Ded09 { get; set; }
		public  System.Nullable<double> Ded10 { get; set; }
        public  System.Nullable<double> Ded11 { get; set; }
        public  System.Nullable<double> Ded12 { get; set; }
        public  System.Nullable<double> Ded13 { get; set; }
        public  System.Nullable<double> Ded14 { get; set; }
        public  System.Nullable<double> Ded15 { get; set; }
		public  string OfficeMobile { get; set; }
		public  string BirthDate { get; set; }
		public  System.Nullable<int> BirthPlace { get; set; }
		public  string MobileNo2 { get; set; }
		public  System.Nullable<int> Sponsor { get; set; }
		public  string JoinDate { get; set; }
		public  string VacDate { get; set; }
		public  string ReturnDate { get; set; }
		public  System.Nullable<int> Bank { get; set; }
		public  string IBan { get; set; }
		public  string ATM { get; set; }
		public  string Remark { get; set; }
        public System.Nullable<short> ContractType { get; set; }
        public System.Nullable<short> TicketNo { get; set; }
        public System.Nullable<short> VacDays { get; set; }
        public string Photo { get; set; }
        public bool? AttTime { get; set; }
        public short? Status { get; set; }
        public string EndDate { get; set; }
        public short? VacRemain { get; set; }
        public string Manag1 { get; set; }
        public string Manag2 { get; set; }
        public double? Insurance { get; set; }
        public string UserName { get; set; }
        public string UserName2 { get; set; }
        public double? TicketValue { get; set; }
        public int? OffDays { get; set; }
        public int? Shift { get; set; }
        public double? P10am { get; set; }
        public short? P10m { get; set; }
        public double? P11am { get; set; }
        public short? P11m { get; set; }
        public double? P12am { get; set; }
        public short? P13m { get; set; }
        public double? P13am { get; set; }
        public short? P12m { get; set; }
        public string P10LDate { get; set; }
        public string P11LDate { get; set; }
        public string P12LDate { get; set; }
        public string P13LDate { get; set; }

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
                return Math.Round((double)(this.AddAll - this.DedAll),0);
            }
        }

		public SEmp()
		{
            this.EmpCode = 0;
            this.Name = "";
            this.Name2 = "";
            this.JobNo = "";
            this.MobileNo = "";
            this.Nat = -1;
            this.Certificate = -1;
            this.Reginal = -1;
            this.Section = -1;
            this.Dep = -1;
            this.Job = -1;
            this.EnterVisaNo = "";
            this.EnterVisaPlace = "";
            this.EnterVisaNo2 = "";
            this.EnterVisaDate = "";
            this.EnterVisaDate2 = "";
            this.WorkerNo = "";
            this.IqamaEnd = "";
            this.Office = "";
            this.OfficeManager = "";
            this.PaperNo1 = "";
            this.PaperNo2 = "";
            this.PaperNo3 = "";
            this.PaperNo4 = "";
            this.PaperNo5 = "";
            this.PaperNo6 = "";
            this.PaperNo7 = "";
            this.PaperNo8 = "";
            this.PaperNo9 = "";
            this.PaperNo10 = "";
            this.PaperLoc1 = -1;
            this.PaperLoc2 = -1;
            this.PaperLoc3 = -1;
            this.PaperLoc4 = -1;
            this.PaperLoc5 = -1;
            this.PaperLoc6 = -1;
            this.PaperLoc7 = -1;
            this.PaperLoc8 = -1;
            this.PaperLoc9 = -1;
            this.PaperLoc10 = -1;
            this.PLoc1 = "";
            this.PLoc2 = "";
            this.PLoc3 = "";
            this.PLoc4 = "";
            this.PLoc5 = "";
            this.PLoc6 = "";
            this.PLoc7 = "";
            this.PLoc8 = "";
            this.PLoc9 = "";
            this.PLoc10 = "";
            this.IssueDate1 = "";
            this.IssueDate2 = "";
            this.IssueDate3 = "";
            this.IssueDate4 = "";
            this.IssueDate5 = "";
            this.IssueDate6 = "";
            this.IssueDate7 = "";
            this.IssueDate8 = "";
            this.IssueDate9 = "";
            this.IssueDate10 = "";
            this.ExpDate1 = "";
            this.ExpDate2 = "";
            this.ExpDate3 = "";
            this.ExpDate4 = "";
            this.ExpDate5 = "";
            this.ExpDate6 = "";
            this.ExpDate7 = "";
            this.ExpDate8 = "";
            this.ExpDate9 = "";
            this.ExpDate10 = "";
            this.FileName1 = "";
            this.FileName2 = "";
            this.FileName3 = "";
            this.FileName4 = "";
            this.FileName5 = "";
            this.FileName6 = "";
            this.FileName7 = "";
            this.FileName8 = "";
            this.FileName9 = "";
            this.FileName10 = "";
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
            this.OfficeMobile = "";
            this.BirthDate = "";
            this.BirthPlace = -1;
            this.MobileNo2 = "";
            this.Sponsor = -1;
            this.JoinDate = "";
            this.VacDate = "";
            this.ReturnDate = "";
            this.Bank = -1;
            this.IBan = "";
            this.ATM = "";
            this.Remark = "";
            this.ContractType = 0;
            this.TicketNo = 0;
            this.VacDays = 0;
            this.Photo = "";
            this.Status = 0;
            this.AttTime = false;
            this.EndDate = "";
            this.VacRemain = 0;
            this.Manag1 = "-1";
            this.Manag2 = "-1";
            this.Insurance = 0;
            this.UserName = "-1";
            this.UserName2 = "-1";
            this.TicketValue = 0;
            this.OffDays = 0;
            this.Shift = -1;
            this.P10am = 0;
            this.P10m = 0;
            this.P11am = 0;
            this.P11m = 0;
            this.P12am = 0;
            this.P12m = 0;
            this.P13am = 0;
            this.P13m = 0;
            this.P10LDate = "";
            this.P11LDate = "";
            this.P12LDate = "";
            this.P13LDate = "";
		}

		/// <summary>
		/// Add Account in Acc Table
		/// </summary>
		/// <returns>True if Insert Success or False if Fail</returns>
		public bool Add(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
                    myContext.SEmpInsert(
                            this.EmpCode,
                            this.Name,
                            this.Name2,
                            this.JobNo,
                            this.MobileNo,
                            this.Nat,
                            this.Certificate,
                            this.Reginal,
                            this.Section,
                            this.Job,
                            this.EnterVisaNo,
                            this.EnterVisaPlace,
                            this.EnterVisaNo2,
                            this.EnterVisaDate,
                            this.EnterVisaDate2,
                            this.WorkerNo,
                            this.IqamaEnd,
                            this.Office,
                            this.OfficeManager,
                            this.PaperNo1,
                            this.PaperNo2,
                            this.PaperNo3,
                            this.PaperNo4,
                            this.PaperNo5,
                            this.PaperNo6,
                            this.PaperNo7,
                            this.PaperNo8,
                            this.PaperNo9,
                            this.PaperNo10,
                            this.PaperLoc1,
                            this.PaperLoc2,
                            this.PaperLoc3,
                            this.PaperLoc4,
                            this.PaperLoc5,
                            this.PaperLoc6,
                            this.PaperLoc7,
                            this.PaperLoc8,
                            this.PaperLoc9,
                            this.PaperLoc10,
                            this.IssueDate1,
                            this.IssueDate2,
                            this.IssueDate3,
                            this.IssueDate4,
                            this.IssueDate5,
                            this.IssueDate6,
                            this.IssueDate7,
                            this.IssueDate8,
                            this.IssueDate9,
                            this.IssueDate10,
                            this.ExpDate1,
                            this.ExpDate2,
                            this.ExpDate3,
                            this.ExpDate4,
                            this.ExpDate5,
                            this.ExpDate6,
                            this.ExpDate7,
                            this.ExpDate8,
                            this.ExpDate9,
                            this.ExpDate10,
                            this.FileName1,
                            this.FileName2,
                            this.FileName3,
                            this.FileName4,
                            this.FileName5,
                            this.FileName6,
                            this.FileName7,
                            this.FileName8,
                            this.FileName9,
                            this.FileName10,
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
                            this.Ded15,
                            this.OfficeMobile,
                            this.BirthDate,
                            this.BirthPlace,
                            this.MobileNo2,
                            this.Sponsor,
                            this.JoinDate,
                            this.VacDate,
                            this.ReturnDate,
                            this.Bank,
                            this.IBan,
                            this.ATM,
                            this.Remark,
                            this.ContractType,
                            this.TicketNo,
                            this.VacDays,
                            this.Photo,
                            this.AttTime,
                            this.Status,
                            this.EndDate,
                            this.VacRemain,
                            this.Manag1,
                            this.Manag2,
                            this.Insurance,
                            this.UserName,
                            this.UserName2,
                            this.TicketValue,
                            this.OffDays,
                            this.Shift,
                            this.P10am,
                            this.P10m,
                            this.P11am,
                            this.P11m,
                            this.P12am,
                            this.P12m,
                            this.P10LDate,
                            this.P11LDate,
                            this.P12LDate,
                            this.P13am,
                            this.P13m,
                            this.P13LDate,
                            this.Dep
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
		/// Delete Account from Acc Table
		/// </summary>
		/// <returns>True if Update Success or False if Fail</returns>
		public bool Delete(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					myContext.SEmpDelete(this.EmpCode);
					return true;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Update Account in Acc Table
		/// </summary>
		/// <returns>True if Update Success or False if Fail</returns>
		public bool update(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					myContext.SEmpUpdate(
                            this.EmpCode,
                            this.Name,
                            this.Name2,
                            this.JobNo,
                            this.MobileNo,
                            this.Nat,
                            this.Certificate,
                            this.Reginal,
                            this.Section,
                            this.Job,
                            this.EnterVisaNo,
                            this.EnterVisaPlace,
                            this.EnterVisaNo2,
                            this.EnterVisaDate,
                            this.EnterVisaDate2,
                            this.WorkerNo,
                            this.IqamaEnd,
                            this.Office,
                            this.OfficeManager,
                            this.PaperNo1,
                            this.PaperNo2,
                            this.PaperNo3,
                            this.PaperNo4,
                            this.PaperNo5,
                            this.PaperNo6,
                            this.PaperNo7,
                            this.PaperNo8,
                            this.PaperNo9,
                            this.PaperNo10,
                            this.PaperLoc1,
                            this.PaperLoc2,
                            this.PaperLoc3,
                            this.PaperLoc4,
                            this.PaperLoc5,
                            this.PaperLoc6,
                            this.PaperLoc7,
                            this.PaperLoc8,
                            this.PaperLoc9,
                            this.PaperLoc10,
                            this.IssueDate1,
                            this.IssueDate2,
                            this.IssueDate3,
                            this.IssueDate4,
                            this.IssueDate5,
                            this.IssueDate6,
                            this.IssueDate7,
                            this.IssueDate8,
                            this.IssueDate9,
                            this.IssueDate10,
                            this.ExpDate1,
                            this.ExpDate2,
                            this.ExpDate3,
                            this.ExpDate4,
                            this.ExpDate5,
                            this.ExpDate6,
                            this.ExpDate7,
                            this.ExpDate8,
                            this.ExpDate9,
                            this.ExpDate10,
                            this.FileName1,
                            this.FileName2,
                            this.FileName3,
                            this.FileName4,
                            this.FileName5,
                            this.FileName6,
                            this.FileName7,
                            this.FileName8,
                            this.FileName9,
                            this.FileName10,
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
                            this.Ded15,
                            this.OfficeMobile,
                            this.BirthDate,
                            this.BirthPlace,
                            this.MobileNo2,
                            this.Sponsor,
                            this.JoinDate,
                            this.VacDate,
                            this.ReturnDate,
                            this.Bank,
                            this.IBan,
                            this.ATM,
                            this.Remark,
                            this.ContractType,
                            this.TicketNo,
                            this.VacDays,
                            this.Photo,
                            this.AttTime,
                            this.Status,
                            this.EndDate,
                            this.VacRemain,
                            this.Manag1,
                            this.Manag2,
                            this.Insurance,
                            this.UserName,
                            this.UserName2,
                            this.TicketValue,
                            this.OffDays,
                            this.Shift,
                            this.P10am,
                            this.P10m,
                            this.P11am,
                            this.P11m,
                            this.P12am,
                            this.P12m,
                            this.P10LDate,
                            this.P11LDate,
                            this.P12LDate,
                            this.P13am,
                            this.P13m,
                            this.P13LDate,
                            this.Dep
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
		/// select all Account from Acc Table
		/// </summary>
		/// <returns>List of Account or null if Fail</returns>
		public List<SEmp> GetAll(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.SEmpGetAll();
					return (from itm in result
							select new SEmp
							{
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
                                 ATM = itm.ATM,
                                 Bank = itm.Bank,
                                 Basic = itm.Basic,
                                 BirthDate = itm.BirthDate,
                                 BirthPlace = itm.BirthPlace,
                                 Certificate = itm.Certificate,
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
                                 Ded15 = itm.Ded15,
                                 EmpCode = itm.EmpCode,
                                 EnterVisaDate = itm.EnterVisaDate,
                                 EnterVisaDate2 = itm.EnterVisaDate2,
                                 EnterVisaNo = itm.EnterVisaNo,
                                 EnterVisaNo2 = itm.EnterVisaNo2,
                                 EnterVisaPlace = itm.EnterVisaPlace,
                                 ExpDate1 = itm.ExpDate1,
                                 ExpDate10 = itm.ExpDate2,
                                 ExpDate2 = itm.ExpDate2,
                                 ExpDate3 = itm.ExpDate3,
                                 ExpDate4 = itm.ExpDate4,
                                 ExpDate5 = itm.ExpDate5,
                                 ExpDate6 = itm.ExpDate6,
                                 ExpDate7 = itm.ExpDate7,
                                 ExpDate8 = itm.ExpDate8,
                                 ExpDate9 = itm.ExpDate9,
                                 FileName1 = itm.FileName1,
                                 FileName10 = itm.FileName10,
                                 FileName2 = itm.FileName2,
                                 FileName3 = itm.FileName3,
                                 FileName4 = itm.FileName4,
                                 FileName5 = itm.FileName5,
                                 FileName6 = itm.FileName6,
                                 FileName7 = itm.FileName7,
                                 FileName8 = itm.FileName8,
                                 FileName9 = itm.FileName9,
                                 IBan = itm.IBan,
                                 IqamaEnd = itm.IqamaEnd,
                                 IssueDate1 = itm.IssueDate1,
                                 IssueDate10 = itm.IssueDate10,
                                 IssueDate2 = itm.IssueDate2,
                                 IssueDate3 = itm.IssueDate3,
                                 IssueDate4 = itm.IssueDate4,
                                 IssueDate5 = itm.IssueDate5,
                                 IssueDate6 = itm.IssueDate6,
                                 IssueDate7 = itm.IssueDate7,
                                 IssueDate8 = itm.IssueDate8,
                                 IssueDate9 = itm.IssueDate9,
                                 Job = itm.Job,
                                 JobNo = itm.JobNo,
                                 JoinDate = itm.JoinDate,
                                 MobileNo = itm.MobileNo,
                                 MobileNo2 = itm.MobileNo2,
                                 Name = itm.Name,
                                 Name2 = itm.Name2,
                                 Nat = itm.Nat,
                                 Office = itm.Office,
                                 OfficeManager = itm.OfficeManager,
                                 OfficeMobile = itm.OfficeMobile,
                                 PaperLoc1 = itm.PaperLoc1,
                                 PaperLoc10 = itm.PaperLoc10,
                                 PaperLoc2 = itm.PaperLoc2,
                                 PaperLoc3 = itm.PaperLoc3,
                                 PaperLoc4 = itm.PaperLoc4,
                                 PaperLoc5 = itm.PaperLoc5,
                                 PaperLoc6 = itm.PaperLoc6,
                                 PaperLoc7 = itm.PaperLoc7,
                                 PaperLoc8 = itm.PaperLoc8,
                                 PaperLoc9 = itm.PaperLoc9,
                                 PaperNo1 = itm.PaperNo1,
                                 PaperNo10 = itm.PaperNo10,
                                 PaperNo2 = itm.PaperNo2,
                                 PaperNo3 = itm.PaperNo3,
                                 PaperNo4 = itm.PaperNo4,
                                 PaperNo5 = itm.PaperNo5,
                                 PaperNo6 = itm.PaperNo6,
                                 PaperNo7 = itm.PaperNo7,
                                 PaperNo8 = itm.PaperNo8,
                                 PaperNo9 = itm.PaperNo9,
                                 Reginal = itm.Reginal,
                                 Remark = itm.Remark,
                                 ReturnDate = itm.ReturnDate,
                                 Section = itm.Section,
                                 Sponsor = itm.Sponsor,
                                 VacDate = itm.VacDate,
                                 WorkerNo = itm.WorkerNo,
                                 ContractType = itm.ContractType,
                                 Photo = itm.Photo,
                                 TicketNo = itm.TicketNo,
                                 VacDays = itm.VacDays,
                                 AttTime = itm.AttTime,
                                 Status = itm.Status,
                                 EndDate = itm.EndDate,
                                 VacRemain = itm.VacRemain,
                                 Manag1 = itm.Manag1,
                                 Manag2 = itm.Manag2,
                                 Insurance = itm.Insurance,
                                 UserName = itm.UserName,
                                 UserName2 = itm.UserName2,
                                 TicketValue = itm.TicketValue,
                                 OffDays = itm.OffDays,
                                 Shift = itm.Shift,
                                 P10am = itm.P10am,
                                 P10m = itm.P10m,
                                 P11am = itm.P11am,
                                 P11m = itm.P11m,
                                 P12am = itm.P12am,
                                 P12m = itm.P12m,
                                 P10LDate = itm.P10LDate,
                                 P11LDate = itm.P11LDate,
                                 P12LDate = itm.P12LDate,
                                 P13am = itm.P13am,
                                 P13LDate = itm.P13LDate,
                                 P13m = itm.P13m,
                                 Dep = itm.Dep
							}).ToList();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

        /// <summary>
        /// select all Account from Acc Table
        /// </summary>
        /// <returns>List of Account or null if Fail</returns>
        public List<SEmp> GetAll2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.SEmpGetAll();
                    return (from itm in result
                            where itm.Status != 2
                            select new SEmp
                            {
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
                                ATM = itm.ATM,
                                Bank = itm.Bank,
                                Basic = itm.Basic,
                                BirthDate = itm.BirthDate,
                                BirthPlace = itm.BirthPlace,
                                Certificate = itm.Certificate,
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
                                Ded15 = itm.Ded15,
                                EmpCode = itm.EmpCode,
                                EnterVisaDate = itm.EnterVisaDate,
                                EnterVisaDate2 = itm.EnterVisaDate2,
                                EnterVisaNo = itm.EnterVisaNo,
                                EnterVisaNo2 = itm.EnterVisaNo2,
                                EnterVisaPlace = itm.EnterVisaPlace,
                                ExpDate1 = itm.ExpDate1,
                                ExpDate10 = itm.ExpDate2,
                                ExpDate2 = itm.ExpDate2,
                                ExpDate3 = itm.ExpDate3,
                                ExpDate4 = itm.ExpDate4,
                                ExpDate5 = itm.ExpDate5,
                                ExpDate6 = itm.ExpDate6,
                                ExpDate7 = itm.ExpDate7,
                                ExpDate8 = itm.ExpDate8,
                                ExpDate9 = itm.ExpDate9,
                                FileName1 = itm.FileName1,
                                FileName10 = itm.FileName10,
                                FileName2 = itm.FileName2,
                                FileName3 = itm.FileName3,
                                FileName4 = itm.FileName4,
                                FileName5 = itm.FileName5,
                                FileName6 = itm.FileName6,
                                FileName7 = itm.FileName7,
                                FileName8 = itm.FileName8,
                                FileName9 = itm.FileName9,
                                IBan = itm.IBan,
                                IqamaEnd = itm.IqamaEnd,
                                IssueDate1 = itm.IssueDate1,
                                IssueDate10 = itm.IssueDate10,
                                IssueDate2 = itm.IssueDate2,
                                IssueDate3 = itm.IssueDate3,
                                IssueDate4 = itm.IssueDate4,
                                IssueDate5 = itm.IssueDate5,
                                IssueDate6 = itm.IssueDate6,
                                IssueDate7 = itm.IssueDate7,
                                IssueDate8 = itm.IssueDate8,
                                IssueDate9 = itm.IssueDate9,
                                Job = itm.Job,
                                JobNo = itm.JobNo,
                                JoinDate = itm.JoinDate,
                                MobileNo = itm.MobileNo,
                                MobileNo2 = itm.MobileNo2,
                                Name = itm.Name,
                                Name2 = itm.Name2,
                                Nat = itm.Nat,
                                Office = itm.Office,
                                OfficeManager = itm.OfficeManager,
                                OfficeMobile = itm.OfficeMobile,
                                PaperLoc1 = itm.PaperLoc1,
                                PaperLoc10 = itm.PaperLoc10,
                                PaperLoc2 = itm.PaperLoc2,
                                PaperLoc3 = itm.PaperLoc3,
                                PaperLoc4 = itm.PaperLoc4,
                                PaperLoc5 = itm.PaperLoc5,
                                PaperLoc6 = itm.PaperLoc6,
                                PaperLoc7 = itm.PaperLoc7,
                                PaperLoc8 = itm.PaperLoc8,
                                PaperLoc9 = itm.PaperLoc9,
                                PaperNo1 = itm.PaperNo1,
                                PaperNo10 = itm.PaperNo10,
                                PaperNo2 = itm.PaperNo2,
                                PaperNo3 = itm.PaperNo3,
                                PaperNo4 = itm.PaperNo4,
                                PaperNo5 = itm.PaperNo5,
                                PaperNo6 = itm.PaperNo6,
                                PaperNo7 = itm.PaperNo7,
                                PaperNo8 = itm.PaperNo8,
                                PaperNo9 = itm.PaperNo9,
                                Reginal = itm.Reginal,
                                Remark = itm.Remark,
                                ReturnDate = itm.ReturnDate,
                                Section = itm.Section,
                                Sponsor = itm.Sponsor,
                                VacDate = itm.VacDate,
                                WorkerNo = itm.WorkerNo,
                                ContractType = itm.ContractType,
                                Photo = itm.Photo,
                                TicketNo = itm.TicketNo,
                                VacDays = itm.VacDays,
                                AttTime = itm.AttTime,
                                Status = itm.Status,
                                EndDate = itm.EndDate,
                                VacRemain = itm.VacRemain,
                                Manag1 = itm.Manag1,
                                Manag2 = itm.Manag2,
                                Insurance = itm.Insurance,
                                UserName = itm.UserName,
                                UserName2 = itm.UserName2,
                                TicketValue = itm.TicketValue,
                                OffDays = itm.OffDays,
                                Shift = itm.Shift,
                                P10am = itm.P10am,
                                P10m = itm.P10m,
                                P11am = itm.P11am,
                                P11m = itm.P11m,
                                P12am = itm.P12am,
                                P12m = itm.P12m,
                                P10LDate = itm.P10LDate,
                                P11LDate = itm.P11LDate,
                                P12LDate = itm.P12LDate,
                                P13am = itm.P13am,
                                P13LDate = itm.P13LDate,
                                P13m = itm.P13m,
                                Dep = itm.Dep
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


		/// <summary>
		/// select all Account from Acc Table
		/// </summary>
		/// <returns>List of Account or null if Fail</returns>
		public SEmp find(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.SEmpGet(this.EmpCode);
					return (from itm in result
							select new SEmp
							{
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
                                ATM = itm.ATM,
                                Bank = itm.Bank,
                                Basic = itm.Basic,
                                BirthDate = itm.BirthDate,
                                BirthPlace = itm.BirthPlace,
                                Certificate = itm.Certificate,
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
                                Ded15 = itm.Ded15,
                                EmpCode = itm.EmpCode,
                                EnterVisaDate = itm.EnterVisaDate,
                                EnterVisaDate2 = itm.EnterVisaDate2,
                                EnterVisaNo = itm.EnterVisaNo,
                                EnterVisaNo2 = itm.EnterVisaNo2,
                                EnterVisaPlace = itm.EnterVisaPlace,
                                ExpDate1 = itm.ExpDate1,
                                ExpDate10 = itm.ExpDate2,
                                ExpDate2 = itm.ExpDate2,
                                ExpDate3 = itm.ExpDate3,
                                ExpDate4 = itm.ExpDate4,
                                ExpDate5 = itm.ExpDate5,
                                ExpDate6 = itm.ExpDate6,
                                ExpDate7 = itm.ExpDate7,
                                ExpDate8 = itm.ExpDate8,
                                ExpDate9 = itm.ExpDate9,
                                FileName1 = itm.FileName1,
                                FileName10 = itm.FileName10,
                                FileName2 = itm.FileName2,
                                FileName3 = itm.FileName3,
                                FileName4 = itm.FileName4,
                                FileName5 = itm.FileName5,
                                FileName6 = itm.FileName6,
                                FileName7 = itm.FileName7,
                                FileName8 = itm.FileName8,
                                FileName9 = itm.FileName9,
                                IBan = itm.IBan,
                                IqamaEnd = itm.IqamaEnd,
                                IssueDate1 = itm.IssueDate1,
                                IssueDate10 = itm.IssueDate10,
                                IssueDate2 = itm.IssueDate2,
                                IssueDate3 = itm.IssueDate3,
                                IssueDate4 = itm.IssueDate4,
                                IssueDate5 = itm.IssueDate5,
                                IssueDate6 = itm.IssueDate6,
                                IssueDate7 = itm.IssueDate7,
                                IssueDate8 = itm.IssueDate8,
                                IssueDate9 = itm.IssueDate9,
                                Job = itm.Job,
                                JobNo = itm.JobNo,
                                JoinDate = itm.JoinDate,
                                MobileNo = itm.MobileNo,
                                MobileNo2 = itm.MobileNo2,
                                Name = itm.Name,
                                Name2 = itm.Name2,
                                Nat = itm.Nat,
                                Office = itm.Office,
                                OfficeManager = itm.OfficeManager,
                                OfficeMobile = itm.OfficeMobile,
                                PaperLoc1 = itm.PaperLoc1,
                                PaperLoc10 = itm.PaperLoc10,
                                PaperLoc2 = itm.PaperLoc2,
                                PaperLoc3 = itm.PaperLoc3,
                                PaperLoc4 = itm.PaperLoc4,
                                PaperLoc5 = itm.PaperLoc5,
                                PaperLoc6 = itm.PaperLoc6,
                                PaperLoc7 = itm.PaperLoc7,
                                PaperLoc8 = itm.PaperLoc8,
                                PaperLoc9 = itm.PaperLoc9,
                                PaperNo1 = itm.PaperNo1,
                                PaperNo10 = itm.PaperNo10,
                                PaperNo2 = itm.PaperNo2,
                                PaperNo3 = itm.PaperNo3,
                                PaperNo4 = itm.PaperNo4,
                                PaperNo5 = itm.PaperNo5,
                                PaperNo6 = itm.PaperNo6,
                                PaperNo7 = itm.PaperNo7,
                                PaperNo8 = itm.PaperNo8,
                                PaperNo9 = itm.PaperNo9,
                                Reginal = itm.Reginal,
                                Remark = itm.Remark,
                                ReturnDate = itm.ReturnDate,
                                Section = itm.Section,
                                Sponsor = itm.Sponsor,
                                VacDate = itm.VacDate,
                                WorkerNo = itm.WorkerNo,
                                ContractType = itm.ContractType,
                                Photo = itm.Photo,
                                TicketNo = itm.TicketNo,
                                VacDays = itm.VacDays,
                                AttTime = itm.AttTime,
                                Status = itm.Status,
                                EndDate = itm.EndDate,
                                VacRemain = itm.VacRemain,
                                Manag1 = itm.Manag1,
                                Manag2 = itm.Manag2,
                                Insurance = itm.Insurance,
                                UserName = itm.UserName,
                                UserName2 = itm.UserName2,
                                TicketValue = itm.TicketValue,
                                OffDays = itm.OffDays,
                                Shift = itm.Shift,
                                P10am = itm.P10am,
                                P10m = itm.P10m,
                                P11am = itm.P11am,
                                P11m = itm.P11m,
                                P12am = itm.P12am,
                                P12m = itm.P12m,
                                P10LDate = itm.P10LDate,
                                P11LDate = itm.P11LDate,
                                P12LDate = itm.P12LDate,
                                P13am = itm.P13am,
                                P13LDate = itm.P13LDate,
                                P13m = itm.P13m,
                                Dep = itm.Dep
                            }).FirstOrDefault();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

        /// <summary>
        /// select all Account from Acc Table
        /// </summary>
        /// <returns>List of Account or null if Fail</returns>
        public SEmp FindByATM(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.SEmpGetByATM(this.ATM);
                    return (from itm in result
                            select new SEmp
                            {
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
                                ATM = itm.ATM,
                                Bank = itm.Bank,
                                Basic = itm.Basic,
                                BirthDate = itm.BirthDate,
                                BirthPlace = itm.BirthPlace,
                                Certificate = itm.Certificate,
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
                                Ded15 = itm.Ded15,
                                EmpCode = itm.EmpCode,
                                EnterVisaDate = itm.EnterVisaDate,
                                EnterVisaDate2 = itm.EnterVisaDate2,
                                EnterVisaNo = itm.EnterVisaNo,
                                EnterVisaNo2 = itm.EnterVisaNo2,
                                EnterVisaPlace = itm.EnterVisaPlace,
                                ExpDate1 = itm.ExpDate1,
                                ExpDate10 = itm.ExpDate2,
                                ExpDate2 = itm.ExpDate2,
                                ExpDate3 = itm.ExpDate3,
                                ExpDate4 = itm.ExpDate4,
                                ExpDate5 = itm.ExpDate5,
                                ExpDate6 = itm.ExpDate6,
                                ExpDate7 = itm.ExpDate7,
                                ExpDate8 = itm.ExpDate8,
                                ExpDate9 = itm.ExpDate9,
                                FileName1 = itm.FileName1,
                                FileName10 = itm.FileName10,
                                FileName2 = itm.FileName2,
                                FileName3 = itm.FileName3,
                                FileName4 = itm.FileName4,
                                FileName5 = itm.FileName5,
                                FileName6 = itm.FileName6,
                                FileName7 = itm.FileName7,
                                FileName8 = itm.FileName8,
                                FileName9 = itm.FileName9,
                                IBan = itm.IBan,
                                IqamaEnd = itm.IqamaEnd,
                                IssueDate1 = itm.IssueDate1,
                                IssueDate10 = itm.IssueDate10,
                                IssueDate2 = itm.IssueDate2,
                                IssueDate3 = itm.IssueDate3,
                                IssueDate4 = itm.IssueDate4,
                                IssueDate5 = itm.IssueDate5,
                                IssueDate6 = itm.IssueDate6,
                                IssueDate7 = itm.IssueDate7,
                                IssueDate8 = itm.IssueDate8,
                                IssueDate9 = itm.IssueDate9,
                                Job = itm.Job,
                                JobNo = itm.JobNo,
                                JoinDate = itm.JoinDate,
                                MobileNo = itm.MobileNo,
                                MobileNo2 = itm.MobileNo2,
                                Name = itm.Name,
                                Name2 = itm.Name2,
                                Nat = itm.Nat,
                                Office = itm.Office,
                                OfficeManager = itm.OfficeManager,
                                OfficeMobile = itm.OfficeMobile,
                                PaperLoc1 = itm.PaperLoc1,
                                PaperLoc10 = itm.PaperLoc10,
                                PaperLoc2 = itm.PaperLoc2,
                                PaperLoc3 = itm.PaperLoc3,
                                PaperLoc4 = itm.PaperLoc4,
                                PaperLoc5 = itm.PaperLoc5,
                                PaperLoc6 = itm.PaperLoc6,
                                PaperLoc7 = itm.PaperLoc7,
                                PaperLoc8 = itm.PaperLoc8,
                                PaperLoc9 = itm.PaperLoc9,
                                PaperNo1 = itm.PaperNo1,
                                PaperNo10 = itm.PaperNo10,
                                PaperNo2 = itm.PaperNo2,
                                PaperNo3 = itm.PaperNo3,
                                PaperNo4 = itm.PaperNo4,
                                PaperNo5 = itm.PaperNo5,
                                PaperNo6 = itm.PaperNo6,
                                PaperNo7 = itm.PaperNo7,
                                PaperNo8 = itm.PaperNo8,
                                PaperNo9 = itm.PaperNo9,
                                Reginal = itm.Reginal,
                                Remark = itm.Remark,
                                ReturnDate = itm.ReturnDate,
                                Section = itm.Section,
                                Sponsor = itm.Sponsor,
                                VacDate = itm.VacDate,
                                WorkerNo = itm.WorkerNo,
                                ContractType = itm.ContractType,
                                Photo = itm.Photo,
                                TicketNo = itm.TicketNo,
                                VacDays = itm.VacDays,
                                AttTime = itm.AttTime,
                                Status = itm.Status,
                                EndDate = itm.EndDate,
                                VacRemain = itm.VacRemain,
                                Manag1 = itm.Manag1,
                                Manag2 = itm.Manag2,
                                Insurance = itm.Insurance,
                                UserName = itm.UserName,
                                UserName2 = itm.UserName2,
                                TicketValue = itm.TicketValue,
                                OffDays = itm.OffDays,
                                Shift = itm.Shift,
                                P10am = itm.P10am,
                                P10m = itm.P10m,
                                P11am = itm.P11am,
                                P11m = itm.P11m,
                                P12am = itm.P12am,
                                P12m = itm.P12m,
                                P10LDate = itm.P10LDate,
                                P11LDate = itm.P11LDate,
                                P12LDate = itm.P12LDate,
                                P13am = itm.P13am,
                                P13LDate = itm.P13LDate,
                                P13m = itm.P13m,
                                Dep = itm.Dep
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Account from Acc Table
        /// </summary>
        /// <returns>List of Account or null if Fail</returns>
        public vSEmp vfind(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vSEmpGet(this.EmpCode);
                    return (from itm in result
                            select new vSEmp
                            {
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
                                ATM = itm.ATM,
                                Bank = itm.Bank,
                                Basic = itm.Basic,
                                BirthDate = itm.BirthDate,
                                BirthPlace = itm.BirthPlace,
                                Certificate = itm.Certificate,
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
                                Ded15 = itm.Ded15,
                                EmpCode = itm.EmpCode,
                                EnterVisaDate = itm.EnterVisaDate,
                                EnterVisaDate2 = itm.EnterVisaDate2,
                                EnterVisaNo = itm.EnterVisaNo,
                                EnterVisaNo2 = itm.EnterVisaNo2,
                                EnterVisaPlace = itm.EnterVisaPlace,
                                ExpDate1 = itm.ExpDate1,
                                ExpDate10 = itm.ExpDate2,
                                ExpDate2 = itm.ExpDate2,
                                ExpDate3 = itm.ExpDate3,
                                ExpDate4 = itm.ExpDate4,
                                ExpDate5 = itm.ExpDate5,
                                ExpDate6 = itm.ExpDate6,
                                ExpDate7 = itm.ExpDate7,
                                ExpDate8 = itm.ExpDate8,
                                ExpDate9 = itm.ExpDate9,
                                FileName1 = itm.FileName1,
                                FileName10 = itm.FileName10,
                                FileName2 = itm.FileName2,
                                FileName3 = itm.FileName3,
                                FileName4 = itm.FileName4,
                                FileName5 = itm.FileName5,
                                FileName6 = itm.FileName6,
                                FileName7 = itm.FileName7,
                                FileName8 = itm.FileName8,
                                FileName9 = itm.FileName9,
                                IBan = itm.IBan,
                                IqamaEnd = itm.IqamaEnd,
                                IssueDate1 = itm.IssueDate1,
                                IssueDate10 = itm.IssueDate10,
                                IssueDate2 = itm.IssueDate2,
                                IssueDate3 = itm.IssueDate3,
                                IssueDate4 = itm.IssueDate4,
                                IssueDate5 = itm.IssueDate5,
                                IssueDate6 = itm.IssueDate6,
                                IssueDate7 = itm.IssueDate7,
                                IssueDate8 = itm.IssueDate8,
                                IssueDate9 = itm.IssueDate9,
                                Job = itm.Job,
                                JobNo = itm.JobNo,
                                JoinDate = itm.JoinDate,
                                MobileNo = itm.MobileNo,
                                MobileNo2 = itm.MobileNo2,
                                Name = itm.Name,
                                Name2 = itm.Name2,
                                Nat = itm.Nat,
                                Office = itm.Office,
                                OfficeManager = itm.OfficeManager,
                                OfficeMobile = itm.OfficeMobile,
                                PaperLoc1 = itm.PaperLoc1,
                                PaperLoc10 = itm.PaperLoc10,
                                PaperLoc2 = itm.PaperLoc2,
                                PaperLoc3 = itm.PaperLoc3,
                                PaperLoc4 = itm.PaperLoc4,
                                PaperLoc5 = itm.PaperLoc5,
                                PaperLoc6 = itm.PaperLoc6,
                                PaperLoc7 = itm.PaperLoc7,
                                PaperLoc8 = itm.PaperLoc8,
                                PaperLoc9 = itm.PaperLoc9,
                                PaperNo1 = itm.PaperNo1,
                                PaperNo10 = itm.PaperNo10,
                                PaperNo2 = itm.PaperNo2,
                                PaperNo3 = itm.PaperNo3,
                                PaperNo4 = itm.PaperNo4,
                                PaperNo5 = itm.PaperNo5,
                                PaperNo6 = itm.PaperNo6,
                                PaperNo7 = itm.PaperNo7,
                                PaperNo8 = itm.PaperNo8,
                                PaperNo9 = itm.PaperNo9,
                                Reginal = itm.Reginal,
                                Remark = itm.Remark,
                                ReturnDate = itm.ReturnDate,
                                Section = itm.Section,
                                Sponsor = itm.Sponsor,
                                VacDate = itm.VacDate,
                                WorkerNo = itm.WorkerNo,
                                ContractType = itm.ContractType,
                                Photo = itm.Photo,
                                TicketNo = itm.TicketNo,
                                VacDays = itm.VacDays,
                                AttTime = itm.AttTime,
                                Status = itm.Status,
                                EndDate = itm.EndDate,
                                VacRemain = itm.VacRemain,
                                Manag1 = itm.Manag1,
                                Manag2 = itm.Manag2,
                                Insurance = itm.Insurance,
                                UserName = itm.UserName,
                                UserName2 = itm.UserName2,
                                TicketValue = itm.TicketValue,
                                OffDays = itm.OffDays,
                                Shift = itm.Shift,
                                P10am = itm.P10am,
                                P10m = itm.P10m,
                                P11am = itm.P11am,
                                P11m = itm.P11m,
                                P12am = itm.P12am,
                                P12m = itm.P12m,
                                P10LDate = itm.P10LDate,
                                P11LDate = itm.P11LDate,
                                P12LDate = itm.P12LDate,
                                JobName1 = itm.JobName1,
                                JobName2 = itm.JobName2,
                                SectionName1 = itm.SectionName1,
                                SectionName2 = itm.SectionName2,
                                NatName1 = itm.NatName1,
                                NatName2 = itm.NatName2,
                                P13am = itm.P13am,
                                P13LDate = itm.P13LDate,
                                P13m = itm.P13m
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        /// <summary>
        /// select all Account from Acc Table
        /// </summary>
        /// <returns>List of Account or null if Fail</returns>
        public List<SEmp> find2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.SEmpGetByJobNo(this.JobNo);
                    return (from itm in result
                            select new SEmp
                            {
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
                                ATM = itm.ATM,
                                Bank = itm.Bank,
                                Basic = itm.Basic,
                                BirthDate = itm.BirthDate,
                                BirthPlace = itm.BirthPlace,
                                Certificate = itm.Certificate,
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
                                Ded15 = itm.Ded15,
                                EmpCode = itm.EmpCode,
                                EnterVisaDate = itm.EnterVisaDate,
                                EnterVisaDate2 = itm.EnterVisaDate2,
                                EnterVisaNo = itm.EnterVisaNo,
                                EnterVisaNo2 = itm.EnterVisaNo2,
                                EnterVisaPlace = itm.EnterVisaPlace,
                                ExpDate1 = itm.ExpDate1,
                                ExpDate10 = itm.ExpDate2,
                                ExpDate2 = itm.ExpDate2,
                                ExpDate3 = itm.ExpDate3,
                                ExpDate4 = itm.ExpDate4,
                                ExpDate5 = itm.ExpDate5,
                                ExpDate6 = itm.ExpDate6,
                                ExpDate7 = itm.ExpDate7,
                                ExpDate8 = itm.ExpDate8,
                                ExpDate9 = itm.ExpDate9,
                                FileName1 = itm.FileName1,
                                FileName10 = itm.FileName10,
                                FileName2 = itm.FileName2,
                                FileName3 = itm.FileName3,
                                FileName4 = itm.FileName4,
                                FileName5 = itm.FileName5,
                                FileName6 = itm.FileName6,
                                FileName7 = itm.FileName7,
                                FileName8 = itm.FileName8,
                                FileName9 = itm.FileName9,
                                IBan = itm.IBan,
                                IqamaEnd = itm.IqamaEnd,
                                IssueDate1 = itm.IssueDate1,
                                IssueDate10 = itm.IssueDate10,
                                IssueDate2 = itm.IssueDate2,
                                IssueDate3 = itm.IssueDate3,
                                IssueDate4 = itm.IssueDate4,
                                IssueDate5 = itm.IssueDate5,
                                IssueDate6 = itm.IssueDate6,
                                IssueDate7 = itm.IssueDate7,
                                IssueDate8 = itm.IssueDate8,
                                IssueDate9 = itm.IssueDate9,
                                Job = itm.Job,
                                JobNo = itm.JobNo,
                                JoinDate = itm.JoinDate,
                                MobileNo = itm.MobileNo,
                                MobileNo2 = itm.MobileNo2,
                                Name = itm.Name,
                                Name2 = itm.Name2,
                                Nat = itm.Nat,
                                Office = itm.Office,
                                OfficeManager = itm.OfficeManager,
                                OfficeMobile = itm.OfficeMobile,
                                PaperLoc1 = itm.PaperLoc1,
                                PaperLoc10 = itm.PaperLoc10,
                                PaperLoc2 = itm.PaperLoc2,
                                PaperLoc3 = itm.PaperLoc3,
                                PaperLoc4 = itm.PaperLoc4,
                                PaperLoc5 = itm.PaperLoc5,
                                PaperLoc6 = itm.PaperLoc6,
                                PaperLoc7 = itm.PaperLoc7,
                                PaperLoc8 = itm.PaperLoc8,
                                PaperLoc9 = itm.PaperLoc9,
                                PaperNo1 = itm.PaperNo1,
                                PaperNo10 = itm.PaperNo10,
                                PaperNo2 = itm.PaperNo2,
                                PaperNo3 = itm.PaperNo3,
                                PaperNo4 = itm.PaperNo4,
                                PaperNo5 = itm.PaperNo5,
                                PaperNo6 = itm.PaperNo6,
                                PaperNo7 = itm.PaperNo7,
                                PaperNo8 = itm.PaperNo8,
                                PaperNo9 = itm.PaperNo9,
                                Reginal = itm.Reginal,
                                Remark = itm.Remark,
                                ReturnDate = itm.ReturnDate,
                                Section = itm.Section,
                                Sponsor = itm.Sponsor,
                                VacDate = itm.VacDate,
                                WorkerNo = itm.WorkerNo,
                                ContractType = itm.ContractType,
                                Photo = itm.Photo,
                                TicketNo = itm.TicketNo,
                                VacDays = itm.VacDays,
                                AttTime = itm.AttTime,
                                Status = itm.Status,
                                EndDate = itm.EndDate,
                                VacRemain = itm.VacRemain,
                                Manag1 = itm.Manag1,
                                Manag2 = itm.Manag2,
                                Insurance = itm.Insurance,
                                UserName = itm.UserName,
                                UserName2 = itm.UserName2,
                                TicketValue = itm.TicketValue,
                                OffDays = itm.OffDays,
                                Shift = itm.Shift,
                                P10am = itm.P10am,
                                P10m = itm.P10m,
                                P11am = itm.P11am,
                                P11m = itm.P11m,
                                P12am = itm.P12am,
                                P12m = itm.P12m,
                                P10LDate = itm.P10LDate,
                                P11LDate = itm.P11LDate,
                                P12LDate = itm.P12LDate,
                                P13am = itm.P13am,
                                P13LDate = itm.P13LDate,
                                P13m = itm.P13m,
                                Dep = itm.Dep
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        /// <summary>
        /// select all Account from Acc Table
        /// </summary>
        /// <returns>List of Account or null if Fail</returns>
        public int? FindByUserName(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.SEmpGetByUserName(this.UserName);
                    return (from itm in result
                            select itm.EmpCode).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

		/// <summary>
		/// Get New Code for Cat Table
		/// </summary>
		/// <returns>New code or null if fail</returns>
		public int? GetNewCode(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					// Pending work check if there any item have same Cat. 
                    var result = myContext.SEmpMaxCode();
					return (from myAcc in result
							select myAcc.myCode).FirstOrDefault();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}    
    }

    [Serializable]
    public class vSEmp:SEmp
    {
        public string JobName1 { get; set; }
        public string JobName2 { get; set; }
        public string SectionName1 { get; set; }
        public string SectionName2 { get; set; }
        public string NatName1 { get; set; }
        public string NatName2 { get; set; }
    }

    [Serializable]
    public class DepManager
    {
        public int? Dep { get; set; }
        public string Manag1 { get; set; }
        public string Manag2 { get; set; }


        /// <summary>
        /// select all Account from Acc Table
        /// </summary>
        /// <returns>List of Account or null if Fail</returns>
        public List<DepManager> GetManager(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.SEmpGetDepManager();
                    return (from itm in result
                            select new DepManager
                            {
                                 Dep = itm.Dep,
                                 Manag1 = itm.Manag1,
                                 Manag2 = itm.Manag2
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public DepManager GetDepManager(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.SEmpGetDepManager();
                    return (from itm in result
                            where itm.Dep == this.Dep
                            select new DepManager
                            {
                                Dep = itm.Dep,
                                Manag1 = itm.Manag1,
                                Manag2 = itm.Manag2
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
