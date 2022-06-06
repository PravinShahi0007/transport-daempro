using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
	[Serializable]
	public class Acc1
	{
		public short Branch { get; set; }
		public string Code { get; set; }
		public string FCode { get; set; }
		public string Name1 { get; set; }
		public string Name2 { get; set; }
		public string FType { get; set; }        
	}

	[Serializable]
	public class Acc
	{
		public short Branch { get; set; }
		public string Code { get; set; }
		public string FCode { get; set; }
		public string MCode { get; set; }
		public System.Nullable<short> FLevel { get; set; }
		public string Name1 { get; set; }
		public string Name2 { get; set; }
		public System.Nullable<double> DAcc { get; set; }
		public System.Nullable<double> CAcc { get; set; }
		public System.Nullable<double> MDAcc { get; set; }
		public System.Nullable<double> MCAcc { get; set; }
		public System.Nullable<double> TDAcc { get; set; }
		public System.Nullable<double> TCAcc { get; set; }
		public System.Nullable<double> ODAcc { get; set; }
		public System.Nullable<double> OCAcc { get; set; }
		public System.Nullable<double> FDAcc { get; set; }
		public System.Nullable<double> FCAcc { get; set; }
		public string Coin { get; set; }
		public System.Nullable<bool> LastLevel { get; set; }
		public System.Nullable<double> DepPer { get; set; }
		public string DepCode { get; set; }
		public System.Nullable<double> FixPurch { get; set; }
		public System.Nullable<double> FixCurrent { get; set; }
		public string FixPurDate { get; set; }
		public System.Nullable<double> DepAmount { get; set; }
		public string TelNo { get; set; }
		public string FaxNo { get; set; }
		public string MobileNo { get; set; }
		public string FixCurDate { get; set; }
		public string Address { get; set; }
		public System.Nullable<double> CRLimit { get; set; }
		public System.Nullable<double> HCRLimit { get; set; }
		public System.Nullable<double> LCRLimit { get; set; }
		public System.Nullable<short> CustPer { get; set; }
		public string Salesman { get; set; }
		public string BatchCode { get; set; }
		public string DepDo { get; set; }
		public string DepMethod { get; set; }
		public System.Nullable<double> DDAcc { get; set; }
		public System.Nullable<double> DCAcc { get; set; }
		public string Remark { get; set; }
		public string FType { get; set; }
		public string SType { get; set; }
		public string Stype1 { get; set; }
		public System.Nullable<double> HCRPeriod { get; set; }
		public string TranType { get; set; }
		public System.Nullable<double> TranBal { get; set; }
		public string TranNo { get; set; }
		public string ACDep { get; set; }
		public System.Nullable<bool> FUpdate { get; set; }
		public System.Nullable<bool> CheckCostCenter { get; set; }
		public System.Nullable<bool> CheckEmp { get; set; }
		public System.Nullable<bool> CheckProject { get; set; }
		public System.Nullable<bool> CheckArea { get; set; }
		public System.Nullable<bool> CheckCostAcc { get; set; }
        public System.Nullable<bool> CheckCarNo { get; set; }
        public string Area { get; set; }
        public string CostCenter { get; set; }
        public string Project { get; set; }
        public string CostAcc { get; set; }
        public string EmpCode { get; set; }
        public string CarNo { get; set; }
		public bool AccountType = false; // Should Change and Switch According to Clients
        public double MBal
        {
            get
            {
                return (double)(this.DAcc - this.CAcc);
            }
        }

		public double Bal
		{
			get
			{
				return (double)(this.ODAcc - this.OCAcc + this.DAcc - this.CAcc);
			}
		}
		public double DBal
		{
			get
			{
				if (this.Bal > 0) return this.Bal;
				else return 0;
			}
		}
		public double CBal
		{
			get
			{
				if (this.Bal > 0) return 0;
				else return this.Bal * -1;
			}
		}

		public string ftype2
		{
			get
			{               

				if (this.FType == "1")
				{
					if (this.FLevel == 1) return "حساب ميزانية - أصول";
					else return "حساب ميزانية - أصول ثابتة";
				}
				else if (this.FType == "2") 
				{
					if (this.FLevel == 1) return "حساب ميزانية - مطلوبات وحقوق ملكية";
					else return "حساب ميزانية - أصول متداولة";
				}
				else if (this.FType == "3") 
				{
					if (AccountType)
					{
						if (this.FLevel == 1) return "الارباح والخسائر - الايرادات";
						return "حساب ميزانية - مطلوبات متداولة";
					}
					else
					{
						if (this.FLevel == 1) return "قائمة الدخل - الايرادات";
						return "حساب ميزانية - مطلوبات متداولة";
					}
				}
				else if (this.FType == "4")
				{
					if (AccountType)
					{
						if (this.FLevel == 1) return "الارباح والخسائر - المصروفات";
						else return "حساب ميزانية - حقوق الملكية";
					}
					else
					{
						if (this.FLevel == 1) return "قائمة الدخل - المصروفات";
						else return "حساب ميزانية - حقوق الملكية";
					}
				}
				else if (this.FType == "5")
				{
					if (AccountType)
					{
						if (this.FLevel == 1) return "التشغيل والمتاجرة - الايرادات";
						else return "قائمة الدخل - الايرادات";
					}
					else
					{
						return "قائمة الدخل - الايرادات";
					}                    
				}
				else if (this.FType == "6")
				{
					if (AccountType)
					{
						if (this.FLevel == 1) return "الارباح والخسائر - المصروفات";
						else return "قائمة الدخل - المصروفات";
					}
					else
					{
						return "قائمة الدخل - المصروفات";
					}
				}
				else if (this.FType == "7")
				{
					return "التشغيل والمتاجرة - الايرادات";
				}
				else if (this.FType == "8")
				{
					return "التشغيل و المتاجرة - المصروفات";
				}
				else return "";
			}
		}


		public Acc()
		{
			this.Branch = 1;
            this.Code = "";
            this.FCode = "";
            this.MCode = "";
            this.FLevel = 1;
            this.Name1 = "";
            this.Name2 = "";
            this.DAcc = 0;
            this.CAcc = 0;
            this.MDAcc = 0;
            this.MCAcc = 0;
            this.TDAcc = 0;
            this.TCAcc = 0;
            this.ODAcc = 0;
            this.OCAcc = 0;
            this.FDAcc = 0;
            this.FCAcc = 0;
            this.Coin = "00001";
            this.LastLevel = false;
            this.DepPer = 0;
            this.DepCode = "-1";
            this.FixPurch = 0;
            this.FixCurrent = 0;
            this.FixPurDate = "";
            this.DepAmount = 0;
            this.TelNo = "";
            this.FaxNo = "";
            this.MobileNo = "";
            this.FixCurDate = "";
            this.Address = "";
            this.CRLimit = 0;
            this.HCRLimit = 0;
            this.LCRLimit = 0;
            this.CustPer = 0;
            this.Salesman = "";
            this.BatchCode = "-1";
            this.DepDo = "";
            this.DepMethod = "";
            this.DDAcc = 0;
            this.DCAcc = 0;
            this.Remark = "";
            this.FType = "";
            this.SType = "";
            this.Stype1 = "";
            this.HCRPeriod = 0;
            this.TranType = "";
            this.TranBal = 0;
            this.TranNo = "";
            this.ACDep = "-1";
            this.FUpdate = false;
            this.CheckCostCenter = false;
            this.CheckEmp = false;
            this.CheckProject = false;
            this.CheckArea = false;
            this.CheckCostAcc = false;
            this.CheckCarNo = false;
            this.Area = "-1";
            this.CostCenter = "-1";
            this.Project = "-1";
            this.CostAcc = "-1";
            this.EmpCode = "-1";
            this.CarNo = "-1";
		}


		/// <summary>
		/// Get Ftype of Account in Acc Table
		/// </summary>
		/// <returns>fType No</returns>
		public string GetFtype(string mytype)
		{
			if (this.AccountType)
			{
				if (this.FLevel == 1)
				{
					if (mytype == "حساب ميزانية - أصول") return "1";
					else if (mytype == "حساب ميزانية - مطلوبات وحقوق ملكية") return "2";
					else if (mytype == "الارباح والخسائر - الايرادات") return "3";
					else if (mytype == "الارباح والخسائر - المصروفات") return "4";
					else if (mytype == "التشغيل والمتاجرة - الايرادات") return "5";
					else if (mytype == "التشغيل والمتاجرة - المصروفات") return "6";
					else return "0";
				}
				else
				{
					if (mytype == "حساب ميزانية - أصول ثابتة") return "1";
					else if (mytype == "حساب ميزانية - أصول متداولة") return "2";
					else if (mytype == "حساب ميزانية - مطلوبات متداولة") return "3";
					else if (mytype == "حساب ميزانية - حقوق الملكية") return "4";
					else if (mytype == "الارباح والخسائر - الايرادات") return "5";
					else if (mytype == "الارباح والخسائر - المصروفات") return "6";
					else if (mytype == "التشغيل والمتاجرة - الايرادات") return "7";
					else if (mytype == "التشغيل والمتاجرة - المصروفات") return "8";
					else return "0";
				}
			}
			else
			{
				if (this.FLevel == 1)
				{
					if (mytype == "حساب ميزانية - أصول") return "1";
					else if (mytype == "حساب ميزانية - مطلوبات وحقوق ملكية") return "2";
					else if (mytype == "قائمة الدخل - الايرادات") return "3";
					else if (mytype == "قائمة الدخل - المصروفات") return "4";
					else return "0";
				}
				else
				{
					if (mytype == "حساب ميزانية - أصول ثابتة") return "1";
					else if (mytype == "حساب ميزانية - أصول متداولة") return "2";
					else if (mytype == "حساب ميزانية - مطلوبات متداولة") return "3";
					else if (mytype == "حساب ميزانية - حقوق الملكية") return "4";
					else if (mytype == "قائمة الدخل - الايرادات") return "5";
					else if (mytype == "قائمة الدخل - المصروفات") return "6";
					else return "0";
				}
			}
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
					myContext.AccInsert(this.Branch, this.Code, this.FCode, this.MCode, this.FLevel, this.Name1, this.Name2, this.DAcc, this.CAcc, this.MDAcc, this.MCAcc, this.TDAcc
						, this.TCAcc, this.ODAcc, this.OCAcc, this.FDAcc, this.FCAcc, this.Coin, this.LastLevel, this.DepPer, this.DepCode, this.FixPurch, this.FixCurrent, this.FixPurDate
						, this.DepAmount, this.TelNo, this.FaxNo, this.MobileNo, this.FixCurDate, this.Address, this.CRLimit, this.HCRLimit, this.LCRLimit, this.CustPer, this.Salesman
						, this.BatchCode, this.DepDo, this.DepMethod, this.DDAcc, this.DCAcc, this.Remark, this.FType, this.SType, this.Stype1, this.HCRPeriod, this.TranType, this.TranBal
						, this.TranNo, this.ACDep, this.FUpdate,this.CheckCostCenter,this.CheckEmp,this.CheckProject,this.CheckArea,this.CheckCostAcc,this.CheckCarNo , this.Area , this.CostCenter , this.Project
                        , this.CostAcc , this.EmpCode , this.CarNo);
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
					myContext.AccDelete(this.Branch, this.Code);
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
					myContext.AccUpdate(this.Branch, this.Code, this.FCode, this.MCode, this.FLevel, this.Name1, this.Name2, this.DAcc, this.CAcc, this.MDAcc, this.MCAcc, this.TDAcc
						, this.TCAcc, this.ODAcc, this.OCAcc, this.FDAcc, this.FCAcc, this.Coin, this.LastLevel, this.DepPer, this.DepCode, this.FixPurch, this.FixCurrent, this.FixPurDate
						, this.DepAmount, this.TelNo, this.FaxNo, this.MobileNo, this.FixCurDate, this.Address, this.CRLimit, this.HCRLimit, this.LCRLimit, this.CustPer, this.Salesman
						, this.BatchCode, this.DepDo, this.DepMethod, this.DDAcc, this.DCAcc, this.Remark, this.FType, this.SType, this.Stype1, this.HCRPeriod, this.TranType, this.TranBal
						, this.TranNo, this.ACDep, this.FUpdate,this.CheckCostCenter,this.CheckEmp,this.CheckProject,this.CheckArea,this.CheckCostAcc,this.CheckCarNo , this.Area , this.CostCenter , this.Project
                        , this.CostAcc , this.EmpCode , this.CarNo);
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
        public bool Post(string ConnectionStr,short FType,double amount)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.AccPost(FType,this.Branch, this.Code,amount);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

		public double GetOpenBatch(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					return (double)myContext.AccGetBatch(this.Branch, this.BatchCode).FirstOrDefault().openbal;
				}
			}
			catch (Exception)
			{
				return 0;
			}
		}

		/// <summary>
		/// select all Account from Acc Table
		/// </summary>
		/// <returns>List of Account or null if Fail</returns>
		public List<Acc> GetAllAcc(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.AccGetAll(this.Branch, this.FCode);
					return (from itm in result
							select new Acc
							{
								Branch = itm.Branch,
								Code = itm.Code,
								FCode = itm.FCode,
								MCode = itm.MCode,
								FLevel = itm.FLevel,
								Name1 = itm.Name1,
								Name2 = itm.Name2,
								DAcc = itm.DAcc,
								CAcc = itm.CAcc,
								MDAcc = itm.MDAcc,
								MCAcc = itm.MCAcc,
								TDAcc = itm.TDAcc,
								TCAcc = itm.TCAcc,
								ODAcc = itm.ODAcc,
								OCAcc = itm.OCAcc,
								FDAcc = itm.FDAcc,
								FCAcc = itm.FCAcc,
								Coin = itm.Coin,
								LastLevel = itm.LastLevel,
								DepPer = itm.DepPer,
								DepCode = itm.DepCode,
								FixPurch = itm.FixPurch,
								FixCurrent = itm.FixCurrent,
								FixPurDate = itm.FixPurDate,
								DepAmount = itm.DepAmount,
								TelNo = itm.TelNo,
								FaxNo = itm.FaxNo,
								MobileNo = itm.MobileNo,
								FixCurDate = itm.FixCurDate,
								Address = itm.Address,
								CRLimit = itm.CRLimit,
								HCRLimit = itm.HCRLimit,
								LCRLimit = itm.LCRLimit,
								CustPer = itm.CustPer,
								Salesman = itm.Salesman,
								BatchCode = itm.BatchCode,
								DepDo = itm.DepDo,
								DepMethod = itm.DepMethod,
								DDAcc = itm.DDAcc,
								DCAcc = itm.DCAcc,
								Remark = itm.Remark,
								FType = itm.FType,
								SType = itm.SType,
								Stype1 = itm.Stype1,
								HCRPeriod = itm.HCRPeriod,
								TranType = itm.TranType,
								TranBal = itm.TranBal,
								TranNo = itm.TranNo,
								ACDep = itm.ACDep,
								FUpdate = itm.FUpdate,
								CheckCostCenter = itm.CheckCostCenter,
								CheckEmp = itm.CheckEmp,
								CheckArea = itm.CheckArea,
								CheckCostAcc = itm.CheckCostAcc,
								CheckProject = itm.CheckProject,
                                CheckCarNo = itm.CheckCarNo,
                                Area = itm.Area,
                                CarNo = itm.CarNo,
                                CostAcc = itm.CostAcc,
                                CostCenter = itm.CostCenter,
                                EmpCode = itm.EmpCode,
                                Project = itm.Project
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
        public List<Acc1> AccFixReleate(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.AccReleate(this.Code);
                    return (from itm in result
                            select new Acc1
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                FCode = itm.FCode,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                FType = itm.FType                                 
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
		public List<Acc1> GetAllAcc2(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.AccGetAll(this.Branch, this.FCode);
					return (from itm in result
							select new Acc1
							{
								Branch = itm.Branch,
								Code = itm.Code,
								FCode = itm.FCode,
								Name1 = itm.Name1,
								Name2 = itm.Name2,
								FType = itm.FType,
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
		public List<Acc1> GetLast(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.AccGetAllLast(this.Branch);
					return (from itm in result
							select new Acc1
							{
								Branch = itm.Branch,
								Code = itm.Code,
								FCode = itm.FCode,
								Name1 = itm.Name1,
								Name2 = itm.Name2,
								FType = itm.FType,
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
		public List<Acc> Getall(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.AccGetAll2(this.Branch);
					return (from itm in result
							select new Acc
							{
								Branch = itm.Branch,
								Code = itm.Code,
								FCode = itm.FCode,
								MCode = itm.MCode,
								FLevel = itm.FLevel,
								Name1 = itm.Name1,
								Name2 = itm.Name2,
								DAcc = itm.DAcc,
								CAcc = itm.CAcc,
								MDAcc = itm.MDAcc,
								MCAcc = itm.MCAcc,
								TDAcc = itm.TDAcc,
								TCAcc = itm.TCAcc,
								ODAcc = itm.ODAcc,
								OCAcc = itm.OCAcc,
								FDAcc = itm.FDAcc,
								FCAcc = itm.FCAcc,
								Coin = itm.Coin,
								LastLevel = itm.LastLevel,
								DepPer = itm.DepPer,
								DepCode = itm.DepCode,
								FixPurch = itm.FixPurch,
								FixCurrent = itm.FixCurrent,
								FixPurDate = itm.FixPurDate,
								DepAmount = itm.DepAmount,
								TelNo = itm.TelNo,
								FaxNo = itm.FaxNo,
								MobileNo = itm.MobileNo,
								FixCurDate = itm.FixCurDate,
								Address = itm.Address,
								CRLimit = itm.CRLimit,
								HCRLimit = itm.HCRLimit,
								LCRLimit = itm.LCRLimit,
								CustPer = itm.CustPer,
								Salesman = itm.Salesman,
								BatchCode = itm.BatchCode,
								DepDo = itm.DepDo,
								DepMethod = itm.DepMethod,
								DDAcc = itm.DDAcc,
								DCAcc = itm.DCAcc,
								Remark = itm.Remark,
								FType = itm.FType,
								SType = itm.SType,
								Stype1 = itm.Stype1,
								HCRPeriod = itm.HCRPeriod,
								TranType = itm.TranType,
								TranBal = itm.TranBal,
								TranNo = itm.TranNo,
								ACDep = itm.ACDep,
								FUpdate = itm.FUpdate,
								CheckCostCenter = itm.CheckCostCenter,
								CheckEmp = itm.CheckEmp,
								CheckArea = itm.CheckArea,
								CheckCostAcc = itm.CheckCostAcc,
								CheckProject = itm.CheckProject,
                                CheckCarNo = itm.CheckCarNo,
                                Area = itm.Area,
                                CarNo = itm.CarNo,
                                CostAcc = itm.CostAcc,
                                CostCenter = itm.CostCenter,
                                EmpCode = itm.EmpCode,
                                Project = itm.Project
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
		public List<Acc1> GetAllAccByType(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.AccGetType(this.Branch, this.FType, this.SType, this.Stype1);
					return (from itm in result
							select new Acc1
							{
								Branch = itm.Branch,
								Code = itm.Code,
								FCode = itm.FCode,
								Name1 = itm.Name1,
								Name2 = itm.Name2,
								FType = itm.FType,
							}).ToList();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}


		/// <summary>
		/// select all Return sales and purchases Account from Acc Table
		/// </summary>
		/// <returns>List of Account or null if Fail</returns>
		public List<Acc1> GetAllReturnType(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.AccReturnTypes(this.Branch);
					return (from itm in result
							select new Acc1
							{
								Branch = itm.Branch,
								Code = itm.Code,
								FCode = itm.FCode,
								Name1 = itm.Name1,
								Name2 = itm.Name2,
								FType = itm.FType,
							}).ToList();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

		/// <summary>
		/// Check if Account Father account
		/// </summary>
		/// <returns>True if father or False if not</returns>
		public Boolean IsFather(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					return (myContext.AccGetParents(this.Branch, this.Code).Count() > 0);
				}
			}
			catch (Exception)
			{
				return false;
			}
		}


		/// <summary>
		/// select Single Account from Acc Table
		/// </summary>
		/// <returns>True of success or false if Fail</returns>
		public Boolean GetAcc(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.AccGet(this.Branch, this.Code).FirstOrDefault();
					if (result != null)
					{
                        this.Branch = result.Branch;
                        this.Code = result.Code;
                        this.FCode = result.FCode;
                        this.MCode = result.MCode;
                        this.FLevel = result.FLevel;
                        this.Name1 = result.Name1;
                        this.Name2 = result.Name2;
                        this.DAcc = result.DAcc;
                        this.CAcc = result.CAcc;
                        this.MDAcc = result.MDAcc;
                        this.MCAcc = result.MCAcc;
                        this.TDAcc = result.TDAcc;
                        this.TCAcc = result.TCAcc;
                        this.ODAcc = result.ODAcc;
                        this.OCAcc = result.OCAcc;
                        this.FDAcc = result.FDAcc;
                        this.FCAcc = result.FCAcc;
                        this.Coin = result.Coin;
                        this.LastLevel = result.LastLevel;
                        this.DepPer = result.DepPer;
                        this.DepCode = result.DepCode;
                        this.FixPurch = result.FixPurch;
                        this.FixCurrent = result.FixCurrent;
                        this.FixPurDate = result.FixPurDate;
                        this.DepAmount = result.DepAmount;
                        this.TelNo = result.TelNo;
                        this.FaxNo = result.FaxNo;
                        this.MobileNo = result.MobileNo;
                        this.FixCurDate = result.FixCurDate;
                        this.Address = result.Address;
                        this.CRLimit = result.CRLimit;
                        this.HCRLimit = result.HCRLimit;
                        this.LCRLimit = result.LCRLimit;
                        this.CustPer = result.CustPer;
                        this.Salesman = result.Salesman;
                        this.BatchCode = result.BatchCode;
                        this.DepDo = result.DepDo;
                        this.DepMethod = result.DepMethod;
                        this.DDAcc = result.DDAcc;
                        this.DCAcc = result.DCAcc;
                        this.Remark = result.Remark;
                        this.FType = result.FType;
                        this.SType = result.SType;
                        this.Stype1 = result.Stype1;
                        this.HCRPeriod = result.HCRPeriod;
                        this.TranType = result.TranType;
                        this.TranBal = result.TranBal;
                        this.TranNo = result.TranNo;
                        this.ACDep = result.ACDep;
                        this.FUpdate = result.FUpdate;
                        this.CheckCostCenter = result.CheckCostCenter;
                        this.CheckEmp = result.CheckEmp;
                        this.CheckProject = result.CheckProject;
                        this.CheckArea = result.CheckArea;
                        this.CheckCostAcc = result.CheckCostAcc;
                        this.CheckCarNo = result.CheckCarNo;
                        this.Area = result.Area;
                        this.CostCenter = result.CostCenter;
                        this.Project = result.Project;
                        this.CostAcc = result.CostAcc;
                        this.EmpCode = result.EmpCode;
                        this.CarNo = result.CarNo;
                        return true;
					}
					else
					{
						return false;
					}
				}
			}
			catch (Exception)
			{
				return false;
			}
		}


        /// <summary>
        /// select Single Account from Acc Table
        /// </summary>
        /// <returns>True of success or false if Fail</returns>
        public Boolean GetAcc2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.AccGet(this.Branch, this.Code).FirstOrDefault();
                    if (result != null && result.FLevel == 5)
                    {
                       this.Branch = result.Branch;
		               this.Code = result.Code;
		               this.FCode = result.FCode;
		               this.MCode = result.MCode;
		               this.FLevel = result.FLevel;
		               this.Name1 = result.Name1;
		               this.Name2 = result.Name2;
		               this.DAcc = result.DAcc; 
		               this.CAcc = result.CAcc;
		               this.MDAcc = result.MDAcc;
		               this.MCAcc = result.MCAcc;
		               this.TDAcc = result.TDAcc;
		               this.TCAcc = result.TCAcc;
		               this.ODAcc = result.ODAcc;
		               this.OCAcc = result.OCAcc;
		               this.FDAcc = result.FDAcc;
		               this.FCAcc = result.FCAcc;
		               this.Coin = result.Coin;
		               this.LastLevel = result.LastLevel;
		               this.DepPer = result.DepPer;
		               this.DepCode = result.DepCode;
		               this.FixPurch = result.FixPurch;
		               this.FixCurrent = result.FixCurrent;
		               this.FixPurDate = result.FixPurDate;
		               this.DepAmount = result.DepAmount;
		               this.TelNo = result.TelNo;
		               this.FaxNo = result.FaxNo;
		               this.MobileNo = result.MobileNo;
		               this.FixCurDate = result.FixCurDate;
		               this.Address = result.Address;
		               this.CRLimit = result.CRLimit;
		               this.HCRLimit = result.HCRLimit;
		               this.LCRLimit = result.LCRLimit;
		               this.CustPer = result.CustPer;
		               this.Salesman = result.Salesman;
		               this.BatchCode = result.BatchCode;
		               this.DepDo = result.DepDo;
		               this.DepMethod = result.DepMethod;
		               this.DDAcc= result.DDAcc;
		               this.DCAcc = result.DCAcc;
		               this.Remark = result.Remark;
		               this.FType = result.FType;
		               this.SType = result.SType;
		               this.Stype1 = result.Stype1;
		               this.HCRPeriod = result.HCRPeriod;
		               this.TranType = result.TranType;
		               this.TranBal = result.TranBal;
		               this.TranNo = result.TranNo;
		               this.ACDep = result.ACDep;
		               this.FUpdate = result.FUpdate;
		               this.CheckCostCenter = result.CheckCostCenter;
		               this.CheckEmp = result.CheckEmp;
		               this.CheckProject = result.CheckProject;
		               this.CheckArea = result.CheckArea;
		               this.CheckCostAcc = result.CheckCostAcc;
                       this.CheckCarNo = result.CheckCarNo;
                       this.Area = result.Area;
                       this.CostCenter = result.CostCenter;
                       this.Project = result.Project;
                       this.CostAcc = result.CostAcc;
                       this.EmpCode = result.EmpCode;
                       this.CarNo = result.CarNo;
                       return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


		/// <summary>
		/// select Single Account from Acc Table
		/// </summary>
		/// <returns>True of success or false if Fail</returns>
		public Boolean GetAccMCode(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.AccGetMCode(this.Branch, this.FCode, this.MCode).FirstOrDefault();
					if (result != null)
					{
                        this.Branch = result.Branch;
                        this.Code = result.Code;
                        this.FCode = result.FCode;
                        this.MCode = result.MCode;
                        this.FLevel = result.FLevel;
                        this.Name1 = result.Name1;
                        this.Name2 = result.Name2;
                        this.DAcc = result.DAcc;
                        this.CAcc = result.CAcc;
                        this.MDAcc = result.MDAcc;
                        this.MCAcc = result.MCAcc;
                        this.TDAcc = result.TDAcc;
                        this.TCAcc = result.TCAcc;
                        this.ODAcc = result.ODAcc;
                        this.OCAcc = result.OCAcc;
                        this.FDAcc = result.FDAcc;
                        this.FCAcc = result.FCAcc;
                        this.Coin = result.Coin;
                        this.LastLevel = result.LastLevel;
                        this.DepPer = result.DepPer;
                        this.DepCode = result.DepCode;
                        this.FixPurch = result.FixPurch;
                        this.FixCurrent = result.FixCurrent;
                        this.FixPurDate = result.FixPurDate;
                        this.DepAmount = result.DepAmount;
                        this.TelNo = result.TelNo;
                        this.FaxNo = result.FaxNo;
                        this.MobileNo = result.MobileNo;
                        this.FixCurDate = result.FixCurDate;
                        this.Address = result.Address;
                        this.CRLimit = result.CRLimit;
                        this.HCRLimit = result.HCRLimit;
                        this.LCRLimit = result.LCRLimit;
                        this.CustPer = result.CustPer;
                        this.Salesman = result.Salesman;
                        this.BatchCode = result.BatchCode;
                        this.DepDo = result.DepDo;
                        this.DepMethod = result.DepMethod;
                        this.DDAcc = result.DDAcc;
                        this.DCAcc = result.DCAcc;
                        this.Remark = result.Remark;
                        this.FType = result.FType;
                        this.SType = result.SType;
                        this.Stype1 = result.Stype1;
                        this.HCRPeriod = result.HCRPeriod;
                        this.TranType = result.TranType;
                        this.TranBal = result.TranBal;
                        this.TranNo = result.TranNo;
                        this.ACDep = result.ACDep;
                        this.FUpdate = result.FUpdate;
                        this.CheckCostCenter = result.CheckCostCenter;
                        this.CheckEmp = result.CheckEmp;
                        this.CheckProject = result.CheckProject;
                        this.CheckArea = result.CheckArea;
                        this.CheckCostAcc = result.CheckCostAcc;
                        this.CheckCarNo = result.CheckCarNo;
                        this.Area = result.Area;
                        this.CostCenter = result.CostCenter;
                        this.Project = result.Project;
                        this.CostAcc = result.CostAcc;
                        this.EmpCode = result.EmpCode;
                        this.CarNo = result.CarNo;
                        return true;
					}
					else
					{
						return false;
					}
				}
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Get New Code for Cat Table
		/// </summary>
		/// <returns>New code or null if fail</returns>
		public string GetNewCode(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					// Pending work check if there any item have same Cat. 
					var result = myContext.AccMaxCode(this.Branch, this.FCode);
					return (from myAcc in result
							select myAcc.myCode).FirstOrDefault();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

		public List<FixedAsset> GetFixedAsset(string ConnectionStr,string FDate, string EDate)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.AccGetFixedAsset(this.Branch,FDate,EDate);
					return (from itm in result
							select new FixedAsset
							{
								Code = itm.Code,
								Name1 = itm.Name1,
								Name2 = itm.Name2,
								cacc = itm.CAcc,
								dacc = itm.DAcc,
								DepBal = itm.DepBal == null ? 0 : itm.DepBal,
								depcode = itm.DepCode,
								odacc = itm.ODAcc,
                                dep = itm.Dep == null ? 0 : itm.Dep,
                                deplost = itm.DepLost == null ? 0 : itm.DepLost
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
	public class FixedAsset
	{
		public string Code { get; set; }
		public string Name1 { get; set; }
		public string Name2 { get; set; }
		public System.Nullable<double> odacc { get; set; }
		public System.Nullable<double> dacc { get; set; }
		public System.Nullable<double> cacc { get; set; }
        public System.Nullable<double> dep { get; set; }
        public System.Nullable<double> deplost { get; set; }
		public string depcode { get; set; }
		public System.Nullable<double> DepBal { get; set; }
		public double Bal
		{
			get
			{                
				return (double)(this.odacc - this.DepBal + this.dacc - this.cacc - this.dep + this.deplost);
			}
		}

		public FixedAsset()
		{
			this.Code = "";
			this.Name1 = "";
			this.Name2 = "";
			this.odacc = 0;
			this.dacc = 0;
			this.cacc = 0;
			this.depcode = "";
			this.DepBal = 0;
		}
	}

    [Serializable]
    public class FixCalc
    {
        public string Code { get; set; }
        public string DepCode { get; set; }
        public string ACDep { get; set; }
        public double Amount { get; set; }
        public double Per { get; set; }
        public DateTime FDate { get; set; }
        public DateTime TDate { get; set; }
        public string Area { get; set; }
        public string CostCenter { get; set; }
        public string Project { get; set; }
        public string CostAcc { get; set; }
        public string EmpCode { get; set; }
        public string CarNo { get; set; }
        public double Total
        {
            get
            {
                return ((this.TDate - this.FDate).Days + 1) * (this.Amount * this.Per) / 36500;
            }
        }
        public double Net { get; set; }
        public double Net2
        {
            get
            {
                return Net - Total;
            }
        }
        public double Total2
        {
            get
            {
                if (Net2 < 0)
                {
                    return Net - 1;
                }
                else return Total;
            }
        }
    }

    [Serializable]
    public class PeriodAcc
    {
        public string DbCode { get; set; }
        public string CrCode { get; set; }
        public double? Amount { get; set; }
        public double? OpenAmount { get; set; }

        public PeriodAcc()
        {
            this.DbCode = "";
            this.CrCode = "";
            this.Amount = 0;
            this.OpenAmount = 0;
        }

        public List<PeriodAcc> GetPeriod(short Branch,string FDate,string EDate,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JvGetStatements(Branch, FDate, EDate);
                    return (from itm in result
                            select new PeriodAcc
                            {
                                 Amount = itm.Amount,
                                 CrCode = itm.CrCode,
                                 DbCode = itm.DbCode,
                                 OpenAmount = itm.OpenAmount
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<PeriodAcc> GetPeriod2(short Branch, string SDate,string FDate, string EDate, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JvGetStatements2(Branch,SDate, FDate, EDate);
                    return (from itm in result
                            select new PeriodAcc
                            {
                                Amount = itm.Amount,
                                CrCode = itm.CrCode,
                                DbCode = itm.DbCode,
                                OpenAmount = itm.OpenAmount
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
