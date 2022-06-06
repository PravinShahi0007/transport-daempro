using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
	[Serializable]
	public class Cars
	{
		public short Branch { get; set; }
		public int CarsType { get; set; }
		public string Code { get; set; }
		public string PlateNo { get; set; }
		public string CarType { get; set; }
		public string CarType2 { get; set; }
		public System.Nullable<int> KMeter { get; set; }
		public System.Nullable<int> ChOilKMeter { get; set; }
		public string ChOilDate { get; set; }
		public System.Nullable<int> ChDezelKMeter { get; set; }
		public string ChDezelDate { get; set; }
		public string DriverCode { get; set; }
		public string Taraz { get; set; }
		public string Model { get; set; }
		public string FType2 { get; set; }
		public string OldCarMove { get; set; }
		public string CarMove { get; set; }
		public string WorkShopCode { get; set; }
		public string FixAssetCode { get; set; }
		public int? FollowType { get; set; }
		public int? Follow2 { get; set; }
		public bool? Status { get; set; }
		public string PHDate1 { get; set; }
		public string PHDate2 { get; set; }
		public string PHDate3 { get; set; }
		public string PHDate4 { get; set; }
        public string PHDate5 { get; set; }
		public string PLoc1 { get; set; }
		public string PLoc2 { get; set; }
		public string PLoc3 { get; set; }
		public string PLoc4 { get; set; }
        public string PLoc5 { get; set; }
        public string PLoc { get; set; }
		public string strDate1 { get; set; }
		public string strDate2 { get; set; }
		public string strDate3 { get; set; }
		public string strDate4 { get; set; }
        public string strDate5 { get; set; }
        public string DriverName { get; set; }
        public string Brand { get; set; }
        public string CarStruct { get; set; }
        public string CarSerial { get; set; }        
        public double? P1am { get; set; }
        public short? P1m { get; set; }
        public double? P2am { get; set; }
        public short? P2m { get; set; }
        public double? P3am { get; set; }
        public short? P3m { get; set; }
        public double? P4am { get; set; }
        public short? P4m { get; set; }
        public double? P5am { get; set; }
        public short? P5m { get; set; }
        public double? P6am { get; set; }
        public short? P6m { get; set; }
        public string P1LDate { get; set; }
        public string P2LDate { get; set; }
        public string P3LDate { get; set; }
        public string P4LDate { get; set; }
        public string P5LDate { get; set; }
        public string P6LDate { get; set; }
		
        public string CodeName
		{
			get
			{
				return this.Code + " " + this.CarType;
			}
		}
		public string Name
		{
			get{
				 return this.CarType;
			}
		}
		public string Name2
		{
			get
			{
				return this.CarType2;
			}
		}

		public Cars()
		{
			this.Branch = 0;
			this.CarsType = 1;
			this.Code = "";
			this.PlateNo = "";
			this.CarType = "";
			this.CarType2 = "";
			this.KMeter = 0;
			this.ChOilDate = "";
			this.ChOilKMeter = 0;
			this.ChDezelDate = "";
			this.ChDezelKMeter = 0;
			this.DriverCode = "-1";
			this.Taraz = "";
			this.Model = "";
			this.FType2 = "-1";
			this.OldCarMove = "";
			this.CarMove = "";
			this.FollowType = -1;
			this.Follow2 = -1;
			this.Status = true;
			this.PHDate1 = "";
			this.PHDate2 = "";
			this.PHDate3 = "";
			this.PHDate4 = "";
            this.PHDate5 = "";
			this.strDate1 = "";
			this.strDate2 = "";
			this.strDate3 = "";
			this.strDate4 = "";
            this.strDate5 = "";
			this.PLoc1 = "";
			this.PLoc2 = "";
			this.PLoc3 = "";
			this.PLoc4 = "";
            this.PLoc5 = "";
            this.PLoc = "";
            this.DriverName = "";
            this.Brand = "";
            this.CarStruct = "";
            this.CarSerial = "";
            this.P1am = 0;
            this.P1m = 0;
            this.P2am = 0;
            this.P2m = 0;
            this.P3am = 0;
            this.P3m = 0;
            this.P4am = 0;
            this.P4m = 0;
            this.P5am = 0;
            this.P5m = 0;
            this.P6am = 0;
            this.P6m = 0;
            this.P1LDate = "";
            this.P2LDate = "";
            this.P3LDate = "";
            this.P4LDate = "";
            this.P5LDate = "";
            this.P6LDate = "";
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
                    myContext.CarsInsert(this.Branch, this.CarsType, this.Code, this.PlateNo, this.CarType, this.CarType2, this.KMeter, this.ChOilKMeter, this.ChOilDate, this.ChDezelKMeter, this.ChDezelDate, this.DriverCode, this.Taraz, this.Model, this.FType2, this.OldCarMove, this.CarMove, this.WorkShopCode, this.FixAssetCode, this.FollowType, this.Follow2, this.Status, this.PHDate1, this.PHDate2, this.PHDate3, this.PHDate4, this.PLoc1, this.PLoc2, this.PLoc3, this.PLoc4, this.PHDate5, this.PLoc5, this.PLoc, this.Brand, this.CarStruct, this.CarSerial, this.P1am, this.P1m, this.P2am, this.P2m, this.P3am, this.P3m, this.P4am, this.P4m, this.P5am, this.P5m, this.P6am, this.P6m, this.P1LDate, this.P2LDate, this.P3LDate, this.P4LDate, this.P5LDate, this.P6LDate);
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
					myContext.CarsDelete(this.Branch,this.CarsType, this.Code);
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
                    myContext.CarsUpdate(this.Branch, this.CarsType, this.Code, this.PlateNo, this.CarType, this.CarType2, this.KMeter, this.ChOilKMeter, this.ChOilDate, this.ChDezelKMeter, this.ChDezelDate, this.DriverCode, this.Taraz, this.Model, this.FType2, this.OldCarMove, this.CarMove, this.WorkShopCode, this.FixAssetCode, this.FollowType, this.Follow2, this.Status, this.PHDate1, this.PHDate2, this.PHDate3, this.PHDate4, this.PLoc1, this.PLoc2, this.PLoc3, this.PLoc4, this.PHDate5, this.PLoc5, this.PLoc, this.Brand, this.CarStruct, this.CarSerial, this.P1am, this.P1m, this.P2am, this.P2m, this.P3am, this.P3m, this.P4am, this.P4m, this.P5am, this.P5m, this.P6am, this.P6m, this.P1LDate, this.P2LDate, this.P3LDate, this.P4LDate, this.P5LDate, this.P6LDate);
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
		public List<Cars> GetAll0(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.CarsGetAll(this.Branch,this.CarsType);
					return (from itm in result
							select new Cars
							{
								Branch = itm.Branch,
								Code = itm.Code,
								CarType = itm.CarType,
								CarType2 = itm.CarType2,
								PlateNo = itm.PlateNo,
								ChDezelDate = itm.ChDezelDate,
								ChDezelKMeter = itm.ChDezelKMeter,
								ChOilDate = itm.ChOilDate,
								ChOilKMeter = itm.ChOilKMeter,
								KMeter = itm.KMeter,
								DriverCode = itm.DriverCode,
								Model = itm.Model,
								Taraz = itm.Taraz,
								CarMove = itm.CarMove,
								FType2 = itm.FType2,
								OldCarMove = itm.OldCarMove,
								CarsType = itm.CarsType,
								FixAssetCode = itm.FixAssetCode,
								Follow2 = itm.Follow2,
								FollowType = itm.FollowType,
								WorkShopCode = itm.WorkShopCode,
								Status = itm.Status,
								PHDate1 = itm.PHDate1,
								PHDate2 = itm.PHDate2,
								PHDate3 = itm.PHDate3,
								PHDate4 = itm.PHDate4,
								PLoc1 = itm.PLoc1,
								PLoc2 = itm.PLoc2,
								PLoc3 = itm.PLoc3,
								PLoc4 = itm.PLoc4,
                                PHDate5 = itm.PHDate5,
                                PLoc5 = itm.PLoc5,
                                PLoc = itm.PLoc,
                                Brand = itm.Brand,
                                CarSerial = itm.CarSerial,
                                CarStruct = itm.CarStruct,
                                P1am = itm.P1am,
                                P1m = itm.P1m,
                                P2am = itm.P2am,
                                P2m = itm.P2m,
                                P3am = itm.P3am,
                                P3m = itm.P3m,
                                P4am = itm.P4am,
                                P4m = itm.P4m,
                                P5am = itm.P5am,
                                P5m = itm.P5m,
                                P6am = itm.P6am,
                                P6m = itm.P6m,
                                P1LDate = itm.P1LDate,
                                P2LDate = itm.P2LDate,
                                P3LDate = itm.P3LDate,
                                P4LDate = itm.P4LDate,
                                P5LDate = itm.P5LDate,
                                P6LDate = itm.P6LDate                                                                                                  
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
		public List<Cars> GetAll(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.CarsGetAll(this.Branch, this.CarsType);
					return (from itm in result
							where (bool)itm.Status
							select new Cars
							{
								Branch = itm.Branch,
								Code = itm.Code,
								CarType = itm.CarType,
								CarType2 = itm.CarType2,
								PlateNo = itm.PlateNo,
								ChDezelDate = itm.ChDezelDate,
								ChDezelKMeter = itm.ChDezelKMeter,
								ChOilDate = itm.ChOilDate,
								ChOilKMeter = itm.ChOilKMeter,
								KMeter = itm.KMeter,
								DriverCode = itm.DriverCode,
								Model = itm.Model,
								Taraz = itm.Taraz,
								CarMove = itm.CarMove,
								FType2 = itm.FType2,
								OldCarMove = itm.OldCarMove,
								CarsType = itm.CarsType,
								FixAssetCode = itm.FixAssetCode,
								Follow2 = itm.Follow2,
								FollowType = itm.FollowType,
								WorkShopCode = itm.WorkShopCode,
								Status = itm.Status,
								PHDate1 = itm.PHDate1,
								PHDate2 = itm.PHDate2,
								PHDate3 = itm.PHDate3,
								PHDate4 = itm.PHDate4,
								PLoc1 = itm.PLoc1,
								PLoc2 = itm.PLoc2,
								PLoc3 = itm.PLoc3,
								PLoc4 = itm.PLoc4,
                                PHDate5 = itm.PHDate5,
                                PLoc5 = itm.PLoc5,
                                PLoc = itm.PLoc,
                                Brand = itm.Brand,
                                CarSerial = itm.CarSerial,
                                CarStruct = itm.CarStruct,
                                P1am = itm.P1am,
                                P1m = itm.P1m,
                                P2am = itm.P2am,
                                P2m = itm.P2m,
                                P3am = itm.P3am,
                                P3m = itm.P3m,
                                P4am = itm.P4am,
                                P4m = itm.P4m,
                                P5am = itm.P5am,
                                P5m = itm.P5m,
                                P6am = itm.P6am,
                                P6m = itm.P6m,
                                P1LDate = itm.P1LDate,
                                P2LDate = itm.P2LDate,
                                P3LDate = itm.P3LDate,
                                P4LDate = itm.P4LDate,
                                P5LDate = itm.P5LDate,
                                P6LDate = itm.P6LDate                                                                                                                                   
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
		public List<Cars> GetAll2(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.CarsGetAll(this.Branch, this.CarsType);
					return (from itm in result
							where (bool)itm.Status
							orderby itm.PlateNo
							select new Cars
							{
								Branch = itm.Branch,
								Code = itm.Code,
								CarType = itm.CarType,
								CarType2 = itm.CarType2,
								PlateNo = itm.PlateNo,
								ChDezelDate = itm.ChDezelDate,
								ChDezelKMeter = itm.ChDezelKMeter,
								ChOilDate = itm.ChOilDate,
								ChOilKMeter = itm.ChOilKMeter,
								KMeter = itm.KMeter,
								DriverCode = itm.DriverCode,
								Model = itm.Model,
								Taraz = itm.Taraz,
								CarMove = itm.CarMove,
								FType2 = itm.FType2,
								OldCarMove = itm.OldCarMove,
								CarsType = itm.CarsType,
								FixAssetCode = itm.FixAssetCode,
								Follow2 = itm.Follow2,
								FollowType = itm.FollowType,
								WorkShopCode = itm.WorkShopCode,
								Status = itm.Status,
								PHDate1 = itm.PHDate1,
								PHDate2 = itm.PHDate2,
								PHDate3 = itm.PHDate3,
								PHDate4 = itm.PHDate4,
								PLoc1 = itm.PLoc1,
								PLoc2 = itm.PLoc2,
								PLoc3 = itm.PLoc3,
								PLoc4 = itm.PLoc4,
                                PHDate5 = itm.PHDate5,
                                PLoc5 = itm.PLoc5,
                                PLoc = itm.PLoc,
                                Brand = itm.Brand,
                                CarSerial = itm.CarSerial,
                                CarStruct = itm.CarStruct,
                                P1am = itm.P1am,
                                P1m = itm.P1m,
                                P2am = itm.P2am,
                                P2m = itm.P2m,
                                P3am = itm.P3am,
                                P3m = itm.P3m,
                                P4am = itm.P4am,
                                P4m = itm.P4m,
                                P5am = itm.P5am,
                                P5m = itm.P5m,
                                P6am = itm.P6am,
                                P6m = itm.P6m,
                                P1LDate = itm.P1LDate,
                                P2LDate = itm.P2LDate,
                                P3LDate = itm.P3LDate,
                                P4LDate = itm.P4LDate,
                                P5LDate = itm.P5LDate,
                                P6LDate = itm.P6LDate                                                                                                                                   
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
        public List<Cars> GetAllPlate(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarsGetPlateAll();
                    return (from itm in result
                            where (bool)itm.Status
                            orderby itm.PlateNo
                            select new Cars
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                CarType = itm.CarType,
                                CarType2 = itm.CarType2,
                                PlateNo = itm.PlateNo,
                                ChDezelDate = itm.ChDezelDate,
                                ChDezelKMeter = itm.ChDezelKMeter,
                                ChOilDate = itm.ChOilDate,
                                ChOilKMeter = itm.ChOilKMeter,
                                KMeter = itm.KMeter,
                                DriverCode = itm.DriverCode,
                                Model = itm.Model,
                                Taraz = itm.Taraz,
                                CarMove = itm.CarMove,
                                FType2 = itm.FType2,
                                OldCarMove = itm.OldCarMove,
                                CarsType = itm.CarsType,
                                FixAssetCode = itm.FixAssetCode,
                                Follow2 = itm.Follow2,
                                FollowType = itm.FollowType,
                                WorkShopCode = itm.WorkShopCode,
                                Status = itm.Status,
                                PHDate1 = itm.PHDate1,
                                PHDate2 = itm.PHDate2,
                                PHDate3 = itm.PHDate3,
                                PHDate4 = itm.PHDate4,
                                PLoc1 = itm.PLoc1,
                                PLoc2 = itm.PLoc2,
                                PLoc3 = itm.PLoc3,
                                PLoc4 = itm.PLoc4,
                                PHDate5 = itm.PHDate5,
                                PLoc5 = itm.PLoc5,
                                PLoc = itm.PLoc,
                                Brand = itm.Brand,
                                CarSerial = itm.CarSerial,
                                CarStruct = itm.CarStruct,
                                P1am = itm.P1am,
                                P1m = itm.P1m,
                                P2am = itm.P2am,
                                P2m = itm.P2m,
                                P3am = itm.P3am,
                                P3m = itm.P3m,
                                P4am = itm.P4am,
                                P4m = itm.P4m,
                                P5am = itm.P5am,
                                P5m = itm.P5m,
                                P6am = itm.P6am,
                                P6m = itm.P6m,
                                P1LDate = itm.P1LDate,
                                P2LDate = itm.P2LDate,
                                P3LDate = itm.P3LDate,
                                P4LDate = itm.P4LDate,
                                P5LDate = itm.P5LDate,
                                P6LDate = itm.P6LDate                                                                                                                                   
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
		public List<Cars> GetAll20(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.CarsGetAll2(this.Branch);
					return (from itm in result
                            where (itm.CarsType == 1 || itm.CarsType == 3 || itm.CarsType == 32 || itm.CarsType == 33) 
							orderby itm.PlateNo
							select new Cars
							{
								Branch = itm.Branch,
								Code = itm.Code,
								CarType = itm.CarType,
								CarType2 = itm.CarType2,
								PlateNo = itm.PlateNo,
								ChDezelDate = itm.ChDezelDate,
								ChDezelKMeter = itm.ChDezelKMeter,
								ChOilDate = itm.ChOilDate,
								ChOilKMeter = itm.ChOilKMeter,
								KMeter = itm.KMeter,
								DriverCode = itm.DriverCode,
								Model = itm.Model,
								Taraz = itm.Taraz,
								CarMove = itm.CarMove,
								FType2 = itm.FType2,
								OldCarMove = itm.OldCarMove,
								CarsType = itm.CarsType,
								FixAssetCode = itm.FixAssetCode,
								Follow2 = itm.Follow2,
								FollowType = itm.FollowType,
								WorkShopCode = itm.WorkShopCode,
								Status = itm.Status,
								PHDate1 = itm.PHDate1,
								PHDate2 = itm.PHDate2,
								PHDate3 = itm.PHDate3,
								PHDate4 = itm.PHDate4,
								PLoc1 = itm.PLoc1,
								PLoc2 = itm.PLoc2,
								PLoc3 = itm.PLoc3,
								PLoc4 = itm.PLoc4,
                                PHDate5 = itm.PHDate5,
                                PLoc5 = itm.PLoc5,
                                PLoc = itm.PLoc,
                                Brand = itm.Brand,
                                CarSerial = itm.CarSerial,
                                CarStruct = itm.CarStruct,
                                P1am = itm.P1am,
                                P1m = itm.P1m,
                                P2am = itm.P2am,
                                P2m = itm.P2m,
                                P3am = itm.P3am,
                                P3m = itm.P3m,
                                P4am = itm.P4am,
                                P4m = itm.P4m,
                                P5am = itm.P5am,
                                P5m = itm.P5m,
                                P6am = itm.P6am,
                                P6m = itm.P6m,
                                P1LDate = itm.P1LDate,
                                P2LDate = itm.P2LDate,
                                P3LDate = itm.P3LDate,
                                P4LDate = itm.P4LDate,
                                P5LDate = itm.P5LDate,
                                P6LDate = itm.P6LDate                                                                                                                                   
							}).ToList();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}


        public List<Cars> GetAll200(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarsGetAll2(this.Branch);
                    return (from itm in result
                            where (itm.CarsType == 1 || itm.CarsType == 3 || itm.CarsType == 32 || itm.CarsType == 33) && (bool)itm.Status
                            orderby itm.PlateNo
                            select new Cars
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                CarType = itm.CarType,
                                CarType2 = itm.CarType2,
                                PlateNo = itm.PlateNo,
                                ChDezelDate = itm.ChDezelDate,
                                ChDezelKMeter = itm.ChDezelKMeter,
                                ChOilDate = itm.ChOilDate,
                                ChOilKMeter = itm.ChOilKMeter,
                                KMeter = itm.KMeter,
                                DriverCode = itm.DriverCode,
                                Model = itm.Model,
                                Taraz = itm.Taraz,
                                CarMove = itm.CarMove,
                                FType2 = itm.FType2,
                                OldCarMove = itm.OldCarMove,
                                CarsType = itm.CarsType,
                                FixAssetCode = itm.FixAssetCode,
                                Follow2 = itm.Follow2,
                                FollowType = itm.FollowType,
                                WorkShopCode = itm.WorkShopCode,
                                Status = itm.Status,
                                PHDate1 = itm.PHDate1,
                                PHDate2 = itm.PHDate2,
                                PHDate3 = itm.PHDate3,
                                PHDate4 = itm.PHDate4,
                                PLoc1 = itm.PLoc1,
                                PLoc2 = itm.PLoc2,
                                PLoc3 = itm.PLoc3,
                                PLoc4 = itm.PLoc4,
                                PHDate5 = itm.PHDate5,
                                PLoc5 = itm.PLoc5,
                                PLoc = itm.PLoc,
                                Brand = itm.Brand,
                                CarSerial = itm.CarSerial,
                                CarStruct = itm.CarStruct,
                                P1am = itm.P1am,
                                P1m = itm.P1m,
                                P2am = itm.P2am,
                                P2m = itm.P2m,
                                P3am = itm.P3am,
                                P3m = itm.P3m,
                                P4am = itm.P4am,
                                P4m = itm.P4m,
                                P5am = itm.P5am,
                                P5m = itm.P5m,
                                P6am = itm.P6am,
                                P6m = itm.P6m,
                                P1LDate = itm.P1LDate,
                                P2LDate = itm.P2LDate,
                                P3LDate = itm.P3LDate,
                                P4LDate = itm.P4LDate,
                                P5LDate = itm.P5LDate,
                                P6LDate = itm.P6LDate
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
		public List<Cars> GetAll21(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.CarsGetAll2(this.Branch);
					return (from itm in result                           
							select new Cars
							{
								Branch = itm.Branch,
								Code = itm.Code,
								CarType = itm.CarType,
								CarType2 = itm.CarType2,
								PlateNo = itm.PlateNo,
								ChDezelDate = itm.ChDezelDate,
								ChDezelKMeter = itm.ChDezelKMeter,
								ChOilDate = itm.ChOilDate,
								ChOilKMeter = itm.ChOilKMeter,
								KMeter = itm.KMeter,
								DriverCode = itm.DriverCode,
								Model = itm.Model,
								Taraz = itm.Taraz,
								CarMove = itm.CarMove,
								FType2 = itm.FType2,
								OldCarMove = itm.OldCarMove,
								CarsType = itm.CarsType,
								FixAssetCode = itm.FixAssetCode,
								Follow2 = itm.Follow2,
								FollowType = itm.FollowType,
								WorkShopCode = itm.WorkShopCode,
								Status = itm.Status,
								PHDate1 = itm.PHDate1,
								PHDate2 = itm.PHDate2,
								PHDate3 = itm.PHDate3,
								PHDate4 = itm.PHDate4,
								PLoc1 = itm.PLoc1,
								PLoc2 = itm.PLoc2,
								PLoc3 = itm.PLoc3,
								PLoc4 = itm.PLoc4,
                                PHDate5 = itm.PHDate5,
                                PLoc5 = itm.PLoc5,
                                PLoc = itm.PLoc,
                                Brand = itm.Brand,
                                CarSerial = itm.CarSerial,
                                CarStruct = itm.CarStruct,
                                P1am = itm.P1am,
                                P1m = itm.P1m,
                                P2am = itm.P2am,
                                P2m = itm.P2m,
                                P3am = itm.P3am,
                                P3m = itm.P3m,
                                P4am = itm.P4am,
                                P4m = itm.P4m,
                                P5am = itm.P5am,
                                P5m = itm.P5m,
                                P6am = itm.P6am,
                                P6m = itm.P6m,
                                P1LDate = itm.P1LDate,
                                P2LDate = itm.P2LDate,
                                P3LDate = itm.P3LDate,
                                P4LDate = itm.P4LDate,
                                P5LDate = itm.P5LDate,
                                P6LDate = itm.P6LDate                                                                                                                                  
							}).ToList();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

		/// <summary>
		/// select a Car from Cars Table
		/// </summary>
		/// <returns>List of Account center or null if Fail</returns>
		public Cars Find(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.CarsGet(this.Branch,this.CarsType, this.Code);
					return (from itm in result
							select new Cars
							{
								Branch = itm.Branch,
								Code = itm.Code,
								CarType = itm.CarType,
								CarType2 = itm.CarType2,
								PlateNo = itm.PlateNo,
								ChDezelDate = itm.ChDezelDate,
								ChDezelKMeter = itm.ChDezelKMeter,
								ChOilDate = itm.ChOilDate,
								ChOilKMeter = itm.ChOilKMeter,
								KMeter = itm.KMeter,
								DriverCode = itm.DriverCode,
								Model = itm.Model,
								Taraz = itm.Taraz,
								CarMove = itm.CarMove,
								FType2 = itm.FType2,
								OldCarMove = itm.OldCarMove,
								CarsType = itm.CarsType,
								FixAssetCode = itm.FixAssetCode,
								Follow2 = itm.Follow2,
								FollowType = itm.FollowType,
								WorkShopCode = itm.WorkShopCode,
								Status = itm.Status,
								PHDate1 = itm.PHDate1,
								PHDate2 = itm.PHDate2,
								PHDate3 = itm.PHDate3,
								PHDate4 = itm.PHDate4,
								PLoc1 = itm.PLoc1,
								PLoc2 = itm.PLoc2,
								PLoc3 = itm.PLoc3,
								PLoc4 = itm.PLoc4,
                                PHDate5 = itm.PHDate5,
                                PLoc5 = itm.PLoc5,
                                PLoc = itm.PLoc,
                                Brand = itm.Brand,
                                CarSerial = itm.CarSerial,
                                CarStruct = itm.CarStruct,
                                P1am = itm.P1am,
                                P1m = itm.P1m,
                                P2am = itm.P2am,
                                P2m = itm.P2m,
                                P3am = itm.P3am,
                                P3m = itm.P3m,
                                P4am = itm.P4am,
                                P4m = itm.P4m,
                                P5am = itm.P5am,
                                P5m = itm.P5m,
                                P6am = itm.P6am,
                                P6m = itm.P6m,
                                P1LDate = itm.P1LDate,
                                P2LDate = itm.P2LDate,
                                P3LDate = itm.P3LDate,
                                P4LDate = itm.P4LDate,
                                P5LDate = itm.P5LDate,
                                P6LDate = itm.P6LDate                                                                                                                                   
							}).FirstOrDefault();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

		/// <summary>
		/// select a Car from Cars Table
		/// </summary>
		/// <returns>List of Account center or null if Fail</returns>
		public Cars FindByWorkShop(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.CarsGetByWorkShop(this.Branch,this.WorkShopCode);
					return (from itm in result
							select new Cars
							{
								Branch = itm.Branch,
								Code = itm.Code,
								CarType = itm.CarType,
								CarType2 = itm.CarType2,
								PlateNo = itm.PlateNo,
								ChDezelDate = itm.ChDezelDate,
								ChDezelKMeter = itm.ChDezelKMeter,
								ChOilDate = itm.ChOilDate,
								ChOilKMeter = itm.ChOilKMeter,
								KMeter = itm.KMeter,
								DriverCode = itm.DriverCode,
								Model = itm.Model,
								Taraz = itm.Taraz,
								CarMove = itm.CarMove,
								FType2 = itm.FType2,
								OldCarMove = itm.OldCarMove,
								CarsType = itm.CarsType,
								FixAssetCode = itm.FixAssetCode,
								Follow2 = itm.Follow2,
								FollowType = itm.FollowType,
								WorkShopCode = itm.WorkShopCode,
								Status = itm.Status,
								PHDate1 = itm.PHDate1,
								PHDate2 = itm.PHDate2,
								PHDate3 = itm.PHDate3,
								PHDate4 = itm.PHDate4,
								PLoc1 = itm.PLoc1,
								PLoc2 = itm.PLoc2,
								PLoc3 = itm.PLoc3,
								PLoc4 = itm.PLoc4,
                                PHDate5 = itm.PHDate5,
                                PLoc5 = itm.PLoc5,
                                PLoc = itm.PLoc,
                                Brand = itm.Brand,
                                CarSerial = itm.CarSerial,
                                CarStruct = itm.CarStruct,
                                P1am = itm.P1am,
                                P1m = itm.P1m,
                                P2am = itm.P2am,
                                P2m = itm.P2m,
                                P3am = itm.P3am,
                                P3m = itm.P3m,
                                P4am = itm.P4am,
                                P4m = itm.P4m,
                                P5am = itm.P5am,
                                P5m = itm.P5m,
                                P6am = itm.P6am,
                                P6m = itm.P6m,
                                P1LDate = itm.P1LDate,
                                P2LDate = itm.P2LDate,
                                P3LDate = itm.P3LDate,
                                P4LDate = itm.P4LDate,
                                P5LDate = itm.P5LDate,
                                P6LDate = itm.P6LDate                                                                                                                                   
							}).FirstOrDefault();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

		/// <summary>
		/// select a Car from Cars Table
		/// </summary>
		/// <returns>List of Account center or null if Fail</returns>
		public Cars FindByDriver(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.CarsGetByDriver(this.Branch, this.DriverCode);
					return (from itm in result
							where (bool)itm.Status
							select new Cars
							{
								Branch = itm.Branch,
								Code = itm.Code,
								CarType = itm.CarType,
								CarType2 = itm.CarType2,
								PlateNo = itm.PlateNo,
								ChDezelDate = itm.ChDezelDate,
								ChDezelKMeter = itm.ChDezelKMeter,
								ChOilDate = itm.ChOilDate,
								ChOilKMeter = itm.ChOilKMeter,
								KMeter = itm.KMeter,
								DriverCode = itm.DriverCode,
								Model = itm.Model,
								Taraz = itm.Taraz,
								CarMove = itm.CarMove,
								FType2 = itm.FType2,
								OldCarMove = itm.OldCarMove,
								CarsType = itm.CarsType,
								FixAssetCode = itm.FixAssetCode,
								Follow2 = itm.Follow2,
								FollowType = itm.FollowType,
								WorkShopCode = itm.WorkShopCode,
								Status = itm.Status,
								PHDate1 = itm.PHDate1,
								PHDate2 = itm.PHDate2,
								PHDate3 = itm.PHDate3,
								PHDate4 = itm.PHDate4,
								PLoc1 = itm.PLoc1,
								PLoc2 = itm.PLoc2,
								PLoc3 = itm.PLoc3,
								PLoc4 = itm.PLoc4,
                                PHDate5 = itm.PHDate5,
                                PLoc5 = itm.PLoc5,
                                PLoc = itm.PLoc,
                                Brand = itm.Brand,
                                CarSerial = itm.CarSerial,
                                CarStruct = itm.CarStruct,
                                P1am = itm.P1am,
                                P1m = itm.P1m,
                                P2am = itm.P2am,
                                P2m = itm.P2m,
                                P3am = itm.P3am,
                                P3m = itm.P3m,
                                P4am = itm.P4am,
                                P4m = itm.P4m,
                                P5am = itm.P5am,
                                P5m = itm.P5m,
                                P6am = itm.P6am,
                                P6m = itm.P6m,
                                P1LDate = itm.P1LDate,
                                P2LDate = itm.P2LDate,
                                P3LDate = itm.P3LDate,
                                P4LDate = itm.P4LDate,
                                P5LDate = itm.P5LDate,
                                P6LDate = itm.P6LDate                                                                                                                                   
							}).FirstOrDefault();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

        /// <summary>
        /// select a Car from Cars Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public Cars FindByDriver0(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarsGetByDriver2(this.Branch, this.DriverCode);
                    return (from itm in result
                            select new Cars
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                CarType = itm.CarType,
                                CarType2 = itm.CarType2,
                                PlateNo = itm.PlateNo,
                                ChDezelDate = itm.ChDezelDate,
                                ChDezelKMeter = itm.ChDezelKMeter,
                                ChOilDate = itm.ChOilDate,
                                ChOilKMeter = itm.ChOilKMeter,
                                KMeter = itm.KMeter,
                                DriverCode = itm.DriverCode,
                                Model = itm.Model,
                                Taraz = itm.Taraz,
                                CarMove = itm.CarMove,
                                FType2 = itm.FType2,
                                OldCarMove = itm.OldCarMove,
                                CarsType = itm.CarsType,
                                FixAssetCode = itm.FixAssetCode,
                                Follow2 = itm.Follow2,
                                FollowType = itm.FollowType,
                                WorkShopCode = itm.WorkShopCode,
                                Status = itm.Status,
                                PHDate1 = itm.PHDate1,
                                PHDate2 = itm.PHDate2,
                                PHDate3 = itm.PHDate3,
                                PHDate4 = itm.PHDate4,
                                PLoc1 = itm.PLoc1,
                                PLoc2 = itm.PLoc2,
                                PLoc3 = itm.PLoc3,
                                PLoc4 = itm.PLoc4,
                                PHDate5 = itm.PHDate5,
                                PLoc5 = itm.PLoc5,
                                PLoc = itm.PLoc,
                                Brand = itm.Brand,
                                CarSerial = itm.CarSerial,
                                CarStruct = itm.CarStruct,
                                P1am = itm.P1am,
                                P1m = itm.P1m,
                                P2am = itm.P2am,
                                P2m = itm.P2m,
                                P3am = itm.P3am,
                                P3m = itm.P3m,
                                P4am = itm.P4am,
                                P4m = itm.P4m,
                                P5am = itm.P5am,
                                P5m = itm.P5m,
                                P6am = itm.P6am,
                                P6m = itm.P6m,
                                P1LDate = itm.P1LDate,
                                P2LDate = itm.P2LDate,
                                P3LDate = itm.P3LDate,
                                P4LDate = itm.P4LDate,
                                P5LDate = itm.P5LDate,
                                P6LDate = itm.P6LDate
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

		/// <summary>
		/// select a Car from Cars Table
		/// </summary>
		/// <returns>List of Account center or null if Fail</returns>
		public Cars FindByPlateNo(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.CarsGetByPlateNo(this.Branch, this.PlateNo);
					return (from itm in result
							select new Cars
							{
								Branch = itm.Branch,
								Code = itm.Code,
								CarType = itm.CarType,
								CarType2 = itm.CarType2,
								PlateNo = itm.PlateNo,
								ChDezelDate = itm.ChDezelDate,
								ChDezelKMeter = itm.ChDezelKMeter,
								ChOilDate = itm.ChOilDate,
								ChOilKMeter = itm.ChOilKMeter,
								KMeter = itm.KMeter,
								DriverCode = itm.DriverCode,
								Model = itm.Model,
								Taraz = itm.Taraz,
								CarMove = itm.CarMove,
								FType2 = itm.FType2,
								OldCarMove = itm.OldCarMove,
								CarsType = itm.CarsType,
								FixAssetCode = itm.FixAssetCode,
								Follow2 = itm.Follow2,
								FollowType = itm.FollowType,
								WorkShopCode = itm.WorkShopCode,
								Status = itm.Status,
								PHDate1 = itm.PHDate1,
								PHDate2 = itm.PHDate2,
								PHDate3 = itm.PHDate3,
								PHDate4 = itm.PHDate4,
								PLoc1 = itm.PLoc1,
								PLoc2 = itm.PLoc2,
								PLoc3 = itm.PLoc3,
								PLoc4 = itm.PLoc4,
                                PHDate5 = itm.PHDate5,
                                PLoc5 = itm.PLoc5,
                                PLoc = itm.PLoc,
                                Brand = itm.Brand,
                                CarSerial = itm.CarSerial,
                                CarStruct = itm.CarStruct,
                                P1am = itm.P1am,
                                P1m = itm.P1m,
                                P2am = itm.P2am,
                                P2m = itm.P2m,
                                P3am = itm.P3am,
                                P3m = itm.P3m,
                                P4am = itm.P4am,
                                P4m = itm.P4m,
                                P5am = itm.P5am,
                                P5m = itm.P5m,
                                P6am = itm.P6am,
                                P6m = itm.P6m,
                                P1LDate = itm.P1LDate,
                                P2LDate = itm.P2LDate,
                                P3LDate = itm.P3LDate,
                                P4LDate = itm.P4LDate,
                                P5LDate = itm.P5LDate,
                                P6LDate = itm.P6LDate                                                                                                                                   
							}).FirstOrDefault();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

        /// <summary>
        /// select a Car from Cars Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public Cars FindByDriver2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarsGetByDriver2(this.Branch, this.DriverCode);
                    return (from itm in result
                            where (bool)itm.Status
                            select new Cars
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                CarType = itm.CarType,
                                CarType2 = itm.CarType2,
                                PlateNo = itm.PlateNo,
                                ChDezelDate = itm.ChDezelDate,
                                ChDezelKMeter = itm.ChDezelKMeter,
                                ChOilDate = itm.ChOilDate,
                                ChOilKMeter = itm.ChOilKMeter,
                                KMeter = itm.KMeter,
                                DriverCode = itm.DriverCode,
                                Model = itm.Model,
                                Taraz = itm.Taraz,
                                CarMove = itm.CarMove,
                                FType2 = itm.FType2,
                                OldCarMove = itm.OldCarMove,
                                CarsType = itm.CarsType,
                                FixAssetCode = itm.FixAssetCode,
                                Follow2 = itm.Follow2,
                                FollowType = itm.FollowType,
                                WorkShopCode = itm.WorkShopCode,
                                Status = itm.Status,
                                PHDate1 = itm.PHDate1,
                                PHDate2 = itm.PHDate2,
                                PHDate3 = itm.PHDate3,
                                PHDate4 = itm.PHDate4,
                                PLoc1 = itm.PLoc1,
                                PLoc2 = itm.PLoc2,
                                PLoc3 = itm.PLoc3,
                                PLoc4 = itm.PLoc4,
                                PHDate5 = itm.PHDate5,
                                PLoc5 = itm.PLoc5,
                                PLoc = itm.PLoc,
                                Brand = itm.Brand,
                                CarSerial = itm.CarSerial,
                                CarStruct = itm.CarStruct,
                                P1am = itm.P1am,
                                P1m = itm.P1m,
                                P2am = itm.P2am,
                                P2m = itm.P2m,
                                P3am = itm.P3am,
                                P3m = itm.P3m,
                                P4am = itm.P4am,
                                P4m = itm.P4m,
                                P5am = itm.P5am,
                                P5m = itm.P5m,
                                P6am = itm.P6am,
                                P6m = itm.P6m,
                                P1LDate = itm.P1LDate,
                                P2LDate = itm.P2LDate,
                                P3LDate = itm.P3LDate,
                                P4LDate = itm.P4LDate,
                                P5LDate = itm.P5LDate,
                                P6LDate = itm.P6LDate
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


		/// <summary>
		/// Get New Code for Cars Table
		/// </summary>
		/// <returns>New code or null if fail</returns>
		public string GetNewCode(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.CarsMaxCode(this.Branch,this.CarsType);
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

	[Serializable]
	public class TrackMove
	{
		public int? FNo { get; set; }
		public string Code { get; set; }
		public string PlateNo { get; set; }
		public string CarType { get; set; }
		public string DriverCode { get; set; }
		public string Driver { get; set; }
        public string RepairReqNo { get; set; }
		public string CarMoveNo { get; set; }
		public string CarMoveDate { get; set; }
		public string CarMoveFrom { get; set; }
		public string CarMoveFromLoc { get; set; }
		public string CarMoveTo { get; set; }
		public string CarMoveToLoc { get; set; }
		public string CarMoveFTime { get; set; }
		public string CarMoveFTime2
		{
			get
			{
				return CarMoveDate + " " + CarMoveFTime;
			}
		}
		public string CarMoveRCVNo { get; set; }
		public string CarMoveRCVDate { get; set; }
		public string CarMoveRCVFTime { get; set; }
		public string CarMoveRCVFTime2 { 
			get{
				return CarMoveRCVDate + " " + CarMoveRCVFTime;
			}
		}
		public string RCVFTime { get; set; }
		public string RCVFTime2 { get; set; }
		public double? Diff { 
			get {
				if (!string.IsNullOrEmpty(RCVFTime) && !string.IsNullOrEmpty(CarMoveRCVFTime))
				{
					TimeSpan ts = new TimeSpan();
					ts = DateTime.Parse(this.RCVFTime) - DateTime.Parse(this.CarMoveRCVDate + " " + this.CarMoveRCVFTime.Replace("ص", "AM").Replace("م", "PM"));
					return (ts.Days * 24) + ts.Hours + (ts.Minutes/60);
				}
				else return 0;
			}
		}
		public string Status { get; set;}
		public double? KMeter { get; set; }
		public double? Qty { get; set; }
   
		/// <summary>
		/// select a Car from Cars Table
		/// </summary>
		/// <returns>List of Account center or null if Fail</returns>
		public List<TrackMove> CarDriverPerGetCars(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.vCarDriverPerGetCar();
					return (from itm in result
							select new TrackMove
							{
								 Code = itm.CarCode,
								 PlateNo = itm.PlateNo,
								 CarType = itm.CarType                                 
							}).ToList();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

		/// <summary>
		/// select a Car from Cars Table
		/// </summary>
		/// <returns>List of Account center or null if Fail</returns>
		public List<TrackMove> CarDriverPerGetDrivers(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.vCarDriverPerGetDriver();
					return (from itm in result
							select new TrackMove
							{
								DriverCode = itm.DriverCode,
								Driver = itm.DriverName
							}).ToList();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}


		/// <summary>
		/// select a Car from Cars Table
		/// </summary>
		/// <returns>List of Account center or null if Fail</returns>
		public List<TrackMove> CarDriverPerGetFromLoc(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.vCarDriverPerGetFromLoc();
					return (from itm in result
							select new TrackMove
							{
								CarMoveFrom = itm.FromLoc,
								CarMoveFromLoc = itm.FromLocName
							}).ToList();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}


		/// <summary>
		/// select a Car from Cars Table
		/// </summary>
		/// <returns>List of Account center or null if Fail</returns>
		public List<TrackMove> CarDriverPerGetToLoc(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.vCarDriverPerGetToLoc();
					return (from itm in result
							select new TrackMove
							{
								CarMoveTo = itm.ToLoc,
								CarMoveToLoc = itm.ToLocName
							}).ToList();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

		/// <summary>
		/// select a Car from Cars Table
		/// </summary>
		/// <returns>List of Account center or null if Fail</returns>
		public List<TrackMove> CarDriverPerGetAll(string FDate,string EDate,string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.vCarDriverPerGetAll(FDate,EDate,this.Code,this.DriverCode,this.CarMoveFrom,this.CarMoveTo);
					int i = 1;
					return (from itm in result
							select new TrackMove
							{
								 FNo = i++,
								 CarMoveNo = int.Parse(itm.VouLoc).ToString() + "/" + itm.Number.ToString(),
								 CarMoveDate = itm.GDate,
								 CarMoveFrom = itm.FromLoc,
								 CarMoveFromLoc = itm.FromLocName,
								 CarMoveTo = itm.ToLoc,
								 CarMoveToLoc = itm.ToLocName,
								 DriverCode = itm.DriverCode,
								 Driver = itm.DriverName,
								 Code = itm.CarCode,
								 PlateNo = itm.PlateNo,
								 CarType = itm.CarType,
								 CarMoveFTime = itm.FTime,
								 CarMoveRCVNo = itm.LocNumber.ToString() + "/" + itm.RCVNumber.ToString(),
								 CarMoveRCVDate = itm.RCVDate,
								 CarMoveRCVFTime = itm.RCVFTime,
								 KMeter = string.IsNullOrEmpty(itm.RCVDate) ?  0 : itm.KMeter,
								 RCVFTime2 = DateTime.Parse(itm.GDate + " " + itm.FTime.Replace("ص", "AM").Replace("م", "PM")).AddHours(GetRCV(itm.FTime2)).ToShortTimeString(),
								 RCVFTime = DateTime.Parse(itm.GDate + " " + itm.FTime.Replace("ص", "AM").Replace("م", "PM")).AddHours(GetRCV(itm.FTime2)).ToString(),
								 Status = !string.IsNullOrEmpty(itm.RCVDate) ? 
											Diff <0 ? "وصلت متاخره" : "تم الوصول" :
											string.IsNullOrEmpty(RCVFTime) ? " *****في الطريق" : 
											DateTime.Now>DateTime.Parse(RCVFTime) ? "تأخرت في الطريق" : "في الطريق",
								 Qty = itm.Qty
							}).ToList();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

		public double GetRCV(string itm)
		{
			double i = 0;
			double.TryParse(itm, out i);
			return i;
		}


      



		//------------------------------------------------------------------
		/// <summary>
		/// select a Car from Cars Table
		/// </summary>
		/// <returns>List of Account center or null if Fail</returns>
		public List<TrackMove> CarDriverPer0GetCars(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.vCarDriverPer0GetCar();
					return (from itm in result
							select new TrackMove
							{
								Code = itm.CarCode,
								PlateNo = itm.PlateNo,
								CarType = itm.CarType
							}).ToList();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

		/// <summary>
		/// select a Car from Cars Table
		/// </summary>
		/// <returns>List of Account center or null if Fail</returns>
		public List<TrackMove> CarDriverPer0GetDrivers(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.vCarDriverPer0GetDriver();
					return (from itm in result
							select new TrackMove
							{
								DriverCode = itm.DriverCode,
								Driver = itm.DriverName
							}).ToList();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}


		/// <summary>
		/// select a Car from Cars Table
		/// </summary>
		/// <returns>List of Account center or null if Fail</returns>
		public List<TrackMove> CarDriverPer0GetFromLoc(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.vCarDriverPer0GetFromLoc();
					return (from itm in result
							select new TrackMove
							{
								CarMoveFrom = itm.FromLoc,
								CarMoveFromLoc = itm.FromLocName
							}).ToList();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}


		/// <summary>
		/// select a Car from Cars Table
		/// </summary>
		/// <returns>List of Account center or null if Fail</returns>
		public List<TrackMove> CarDriverPer0GetToLoc(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.vCarDriverPer0GetToLoc();
					return (from itm in result
							select new TrackMove
							{
								CarMoveTo = itm.ToLoc,
								CarMoveToLoc = itm.ToLocName
							}).ToList();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

		/// <summary>
		/// select a Car from Cars Table
		/// </summary>
		/// <returns>List of Account center or null if Fail</returns>
		public List<TrackMove> CarDriverPer0GetAll(string FDate, string EDate, string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.vCarDriverPer0GetAll(FDate, EDate, this.Code, this.DriverCode, this.CarMoveFrom, this.CarMoveTo);
					int i = 1;
					return (from itm in result
							select new TrackMove
							{
								FNo = i++,
								CarMoveNo = int.Parse(itm.VouLoc).ToString() + "/" + itm.Number.ToString(),
								CarMoveDate = itm.GDate,
								CarMoveFrom = itm.FromLoc,
								CarMoveFromLoc = itm.FromLocName,
								CarMoveTo = itm.ToLoc,
								CarMoveToLoc = itm.ToLocName,
								DriverCode = itm.DriverCode,
								Driver = itm.DriverName,
								Code = itm.CarCode,
								PlateNo = itm.PlateNo,
								CarType = itm.CarType,
								CarMoveFTime = itm.FTime,
								CarMoveRCVNo = itm.LocNumber.ToString() + "/" + itm.RCVNumber.ToString(),
								CarMoveRCVDate = itm.RCVDate,
								CarMoveRCVFTime = itm.RCVFTime,
								KMeter = string.IsNullOrEmpty(itm.RCVDate) ? 0 : itm.KMeter,
								RCVFTime2 = DateTime.Parse(itm.GDate + " " + itm.FTime.Replace("ص", "AM").Replace("م", "PM")).AddHours(GetRCV(itm.FTime2)).ToShortTimeString(),
								RCVFTime = DateTime.Parse(itm.GDate + " " + itm.FTime.Replace("ص", "AM").Replace("م", "PM")).AddHours(GetRCV(itm.FTime2)).ToString(),
								Status = !string.IsNullOrEmpty(itm.RCVDate) ?
										   Diff < 0 ? "وصلت متاخره" : "تم الوصول" :
										   string.IsNullOrEmpty(RCVFTime) ? " *****في الطريق" :
										   DateTime.Now > DateTime.Parse(RCVFTime) ? "تأخرت في الطريق" : "في الطريق",
								Qty = 0
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


