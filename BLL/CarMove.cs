using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
	[Serializable]
	public class CarMove
	{
		public short Branch { get; set; }
		public string VouLoc { get; set; }
		public int Number { get; set; }
		public short FNo { get; set; }
		public string GDate { get; set; }
		public string HDate { get; set; }
		public string FromLoc { get; set; }
		public string ToLoc { get; set; }
		public string CarCode { get; set; }
		public string DriverCode { get; set; }
		public System.Nullable<int> InvoiceNo { get; set; }
		public string UserName { get; set; }
		public string UserDate { get; set; }
		public System.Nullable<short> InvoiceFNo { get; set; }
		public string InvoiceVouLoc { get; set; }
		public System.Nullable<short> Qty2 { get; set; }
		public System.Nullable<int> CarMoveNo { get; set; }
        public System.Nullable<double> Amount { get; set; }
		public string CarMoveLoc { get; set; }
		public string VouNo2 { get; set; }
		public string FTime { get; set; }
		public string FType2 { get; set; }
		public string Remark { get; set;}
		public int? FNo2 { get; set; }
        public bool? NoCost { get; set; }
        public bool? Rent { get; set; }
        public string RentPlateNo { get; set; }
        public double? RentValue { get; set; }
        public string RentDriver { get; set; }
        public string RentMobileNo { get; set; }
        public int? Status { get; set; }
        public string Flag { get; set; }

		public string CarMoveNo2 { 
			get {
					return int.Parse(this.VouLoc).ToString() + '/' + this.Number.ToString();
				} 
		}

		public CarMove()
		{
			this.Branch = 0;
			this.VouLoc = "";
			this.Number = 0;
			this.FNo = 1;
			this.GDate = "";
			this.HDate = "";
			this.FromLoc = "";
			this.ToLoc = "";
			this.CarCode = "";
			this.DriverCode = "";
			this.InvoiceNo = 0;
			this.UserName = "";
			this.UserDate = "";
			this.InvoiceFNo = 1;
			this.InvoiceVouLoc = "";
			this.Qty2 = 0;
			this.CarMoveNo = 0;
			this.CarMoveLoc = "-1";
			this.VouNo2 = "";
            this.FTime = String.Format("{0:HH:mm:ss}", moh.Nows());  //moh.Nows().ToShortTimeString();
			this.FType2 = "-1";
			this.Remark = "";
            this.Amount = 0;
            this.NoCost = false;
            this.Rent = false;
            this.RentPlateNo = "";
            this.RentValue = 0;
            this.RentDriver = "";
            this.RentMobileNo = "";
            this.Status = 0;
            this.Flag = "";
		}

		/// <summary>
		/// Add Car in CarMove Table
		/// </summary>
		/// <returns>True if Insert Success or False if Fail</returns>
		public bool Add(string ConnectionStr , bool PostQty)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					myContext.CarMoveInsert(this.Branch , this.VouLoc , this.Number , this.FNo , this.GDate , this.HDate , this.FromLoc , this.ToLoc , this.CarCode , this.DriverCode , this.InvoiceNo , this.UserName , this.UserDate , this.InvoiceFNo , this.InvoiceVouLoc , this.CarMoveNo , this.CarMoveLoc , PostQty,this.VouNo2,this.FTime,this.FType2,this.Remark,this.NoCost,this.Rent,this.RentPlateNo,this.RentValue,this.RentDriver,this.RentMobileNo, this.Status,this.Flag);
					return true;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Add Car in CarMove Table
		/// </summary>
		/// <returns>True if Insert Success or False if Fail</returns>
		public bool Post(string ConnectionStr,double Amount,string dezelAcc ,string tripAcc,string CurExpAcc, string Project, string Area, string CostAcc , double RentAmount)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					myContext.CarMovePost(this.Branch,this.VouLoc,this.Number,this.GDate,this.FromLoc,this.ToLoc,this.CarCode,
                        (this.DriverCode == "" || this.DriverCode == "-1" ? "-1" : this.DriverCode), this.UserName, this.UserDate, Amount, dezelAcc, tripAcc, CurExpAcc, Project, Area, CostAcc, this.NoCost, RentAmount);                        
                        //(this.DriverCode == "" || this.DriverCode == "-1"? "-1":"120503"+this.DriverCode),this.UserName,this.UserDate,Amount,dezelAcc,tripAcc,CurExpAcc,Project,Area,CostAcc,this.NoCost,RentAmount);                        
					return true;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}


        /// <summary>
        /// Add Car in CarMove Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool UpdateStatue(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CarMoveUpdateStatus(this.Branch, this.VouLoc, this.Number, this.Status);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


		/// <summary>
		/// Delete Car from CarMove Table
		/// </summary>
		/// <returns>True if Update Success or False if Fail</returns>
		public bool Delete(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					myContext.CarMoveDelete(this.Branch, this.VouLoc, this.Number);
					return true;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// select all Cars from CarMove Table
		/// </summary>
		/// <returns>List of Account center or null if Fail</returns>
		public List<CarMove> Find(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.CarMoveGet(this.Branch , this.VouLoc , this.Number);
					return (from itm in result
							select new CarMove
							{
								Branch = itm.Branch,
								VouLoc = itm.VouLoc,
								Number = itm.Number,
								FNo = itm.FNo,
								GDate = itm.GDate,
								HDate = itm.HDate,
								FromLoc = itm.FromLoc,
								ToLoc = itm.ToLoc,
								CarCode = itm.CarCode,
								DriverCode = itm.DriverCode,
								InvoiceNo = itm.InvoiceNo,
								UserName = itm.UserName,
								UserDate = itm.UserDate,
								InvoiceFNo = itm.InvoiceFNo,
								CarMoveLoc = itm.CarMoveLoc,
								CarMoveNo = itm.CarMoveNo,
								InvoiceVouLoc = itm.InvoiceVouLoc,
								Qty2 = itm.Qty2,
								VouNo2 = itm.VouNo2,
								FTime = itm.FTime,
								FType2 = itm.FType2,
								Remark = itm.Remark,
                                NoCost = itm.NoCost,
                                Rent = itm.Rent,
                                RentDriver = itm.RentDriver,
                                RentPlateNo = itm.RentPlateNo,
                                RentValue = itm.RentValue,
                                RentMobileNo = itm.RentMobileNo,
                                Status = itm.Status,
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
        /// select all Cars from CarMove Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CarMove> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarMoveGetAll(this.Branch);
                    return (from itm in result
                            select new CarMove
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                GDate = itm.GDate,
                                HDate = itm.HDate,
                                FromLoc = itm.FromLoc,
                                ToLoc = itm.ToLoc,
                                CarCode = itm.CarCode,
                                DriverCode = itm.DriverCode,
                                InvoiceNo = itm.InvoiceNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                InvoiceFNo = itm.InvoiceFNo,
                                CarMoveLoc = itm.CarMoveLoc,
                                CarMoveNo = itm.CarMoveNo,
                                InvoiceVouLoc = itm.InvoiceVouLoc,
                                Qty2 = itm.Qty2,
                                VouNo2 = itm.VouNo2,
                                FTime = itm.FTime,
                                FType2 = itm.FType2,
                                Remark = itm.Remark,
                                NoCost = itm.NoCost,
                                Rent = itm.Rent,
                                RentDriver = itm.RentDriver,
                                RentPlateNo = itm.RentPlateNo,
                                RentValue = itm.RentValue,
                                RentMobileNo = itm.RentMobileNo,
                                Status = itm.Status,
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
        /// select all Cars from CarMove Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CarMove> FindByDriverStatus(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarMoveGetByDriverStatus(this.DriverCode, this.Status);
                    return (from itm in result
                            select new CarMove
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                Number = itm.Number,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                ToLoc = itm.ToLoc,
                                FromLoc = itm.FromLoc
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Cars from CarMove Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CarMove> NotCarMoveRCV(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarMoveNotCarMoveRCV();

                    return (from itm in result
                            select new CarMove
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                Number = itm.Number,
                                GDate = itm.GDate,
                                HDate = itm.HDate,
                                FromLoc = itm.FromLoc,
                                ToLoc = itm.ToLoc,
                                CarCode = itm.CarCode,
                                DriverCode = itm.DriverCode,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                FTime = itm.FTime,
                                FType2 = itm.FType2,
                                Remark = itm.Remark,
                                NoCost = itm.NoCost,
                                Rent = itm.Rent,
                                RentDriver = itm.RentDriver,
                                RentPlateNo = itm.RentPlateNo,
                                RentValue = itm.RentValue,
                                RentMobileNo = itm.RentMobileNo
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Cars from CarMove Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CarMove> CarMoveNotPaid(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarMoveNotJv();
                    return (from itm in result                            
                            select new CarMove
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                Number = itm.Number,
                                GDate = itm.GDate,
                                Amount = itm.Net,
                                FromLoc = itm.FromLoc,
                                ToLoc = itm.ToLoc,
                                NoCost = itm.NoCost
                                //Qty2 = itm.Qty2
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Cars from CarMove Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public CarMove FindLast(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarMoveLast(this.CarCode);
                    return (from itm in result
                            select new CarMove
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                GDate = itm.GDate,
                                HDate = itm.HDate,
                                FromLoc = itm.FromLoc,
                                ToLoc = itm.ToLoc,
                                CarCode = itm.CarCode,
                                DriverCode = itm.DriverCode,
                                InvoiceNo = itm.InvoiceNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                InvoiceFNo = itm.InvoiceFNo,
                                CarMoveLoc = itm.CarMoveLoc,
                                CarMoveNo = itm.CarMoveNo,
                                InvoiceVouLoc = itm.InvoiceVouLoc,
                                Qty2 = itm.Qty2,
                                VouNo2 = itm.VouNo2,
                                FTime = itm.FTime,
                                FType2 = itm.FType2,
                                Remark = itm.Remark,
                                NoCost = itm.NoCost,
                                Rent = itm.Rent,
                                RentDriver = itm.RentDriver,
                                RentPlateNo = itm.RentPlateNo,
                                RentValue = itm.RentValue,
                                RentMobileNo = itm.RentMobileNo,
                                Status = itm.Status,
                                Flag = itm.Flag 
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Cars from CarMove Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public CarMove FindLastDriver(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarMoveLast2(this.DriverCode);
                    return (from itm in result
                            select new CarMove
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                GDate = itm.GDate,
                                HDate = itm.HDate,
                                FromLoc = itm.FromLoc,
                                ToLoc = itm.ToLoc,
                                CarCode = itm.CarCode,
                                DriverCode = itm.DriverCode,
                                InvoiceNo = itm.InvoiceNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                InvoiceFNo = itm.InvoiceFNo,
                                CarMoveLoc = itm.CarMoveLoc,
                                CarMoveNo = itm.CarMoveNo,
                                InvoiceVouLoc = itm.InvoiceVouLoc,
                                Qty2 = itm.Qty2,
                                VouNo2 = itm.VouNo2,
                                FTime = itm.FTime,
                                FType2 = itm.FType2,
                                Remark = itm.Remark,
                                NoCost = itm.NoCost,
                                Rent = itm.Rent,
                                RentDriver = itm.RentDriver,
                                RentPlateNo = itm.RentPlateNo,
                                RentValue = itm.RentValue,
                                RentMobileNo = itm.RentMobileNo,
                                Status = itm.Status,
                                Flag = itm.Flag  
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

		/// <summary>
		/// select all Cars from CarMove Table
		/// </summary>
		/// <returns>List of Account center or null if Fail</returns>
		public List<CarMove> CarMoveNotRcv(string ConnectionStr,List<CostCenter> lcs)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
                    //CostCenter cs = new CostCenter();
                    //cs.Branch = 1;
                    //List<CostCenter> lcs = new List<CostCenter>();
                    //lcs = cs.GetAll(ConnectionStr);
                     
					int i = 1;
					var result = myContext.CarMovevsRCV("-1");
					return (from itm in result
							select new CarMove
							{
								FNo2 = i++,
								Branch = itm.Branch,
								VouLoc = itm.VouLoc,
								Number = itm.Number,
                                GDate = itm.GDate,
                                Rent = itm.rent,
                                RentDriver = itm.rentdriver,
                                RentMobileNo = itm.rentmobileno,
                                RentValue = itm.rentvalue,
                                FTime = itm.FTime,
                                FromLoc = itm.FromLoc,
                                DriverCode = itm.ToLoc,                               
                                ToLoc = (from myitem in lcs
                                         where myitem.City == itm.ToLoc
                                         select myitem.Code).FirstOrDefault() == null ? "-1" : (from myitem in lcs
                                                                                                where myitem.City == itm.ToLoc
                                                                                                select myitem.Code).FirstOrDefault()

							}).ToList();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

		/// <summary>
		/// select all Cars from CarMove Table
		/// </summary>
		/// <returns>List of Account center or null if Fail</returns>
		public List<CarMove> GetByInv(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.CarMoveGetByInvoice(this.Branch,this.InvoiceNo, this.InvoiceVouLoc, this.InvoiceFNo,this.Flag);
					return (from itm in result
							orderby DateTime.Parse(itm.GDate)
							select new CarMove
							{
								Branch = itm.Branch,
								VouLoc = itm.VouLoc,
								Number = itm.Number,
								FNo = itm.FNo,
								GDate = itm.GDate,
								HDate = itm.HDate,
								FromLoc = itm.FromLoc,
								ToLoc = itm.ToLoc,
								CarCode = itm.CarCode,
								DriverCode = itm.DriverCode,
								InvoiceNo = itm.InvoiceNo,
								UserName = itm.UserName,
								UserDate = itm.UserDate,
								InvoiceFNo = itm.InvoiceFNo,
								CarMoveLoc = itm.CarMoveLoc,
								CarMoveNo = itm.CarMoveNo,
								InvoiceVouLoc = itm.InvoiceVouLoc,
								Qty2 = itm.Qty2,
								VouNo2 = itm.VouNo2,
								FTime = itm.FTime,
								FType2 = itm.FType2,
								Remark = itm.Remark,
                                NoCost = itm.NoCost,
                                Rent = itm.Rent,
                                RentDriver = itm.RentDriver,
                                RentPlateNo = itm.RentPlateNo,
                                RentValue = itm.RentValue,
                                RentMobileNo = itm.RentMobileNo,
                                Status = itm.Status,
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
		/// select all Cars from CarMove Table
		/// </summary>
		/// <returns>List of Account center or null if Fail</returns>
		public List<CarMove> GetByInv2(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.CarMoveGetByInvoice2(this.Branch, this.InvoiceNo, this.InvoiceVouLoc,this.Flag);
					return (from itm in result
							orderby DateTime.Parse(itm.GDate)
							select new CarMove
							{
								Branch = itm.Branch,
								VouLoc = itm.VouLoc,
								Number = itm.Number,
								FNo = itm.FNo,
								GDate = itm.GDate,
								HDate = itm.HDate,
								FromLoc = itm.FromLoc,
								ToLoc = itm.ToLoc,
								CarCode = itm.CarCode,
								DriverCode = itm.DriverCode,
								InvoiceNo = itm.InvoiceNo,
								UserName = itm.UserName,
								UserDate = itm.UserDate,
								InvoiceFNo = itm.InvoiceFNo,
								CarMoveLoc = itm.CarMoveLoc,
								CarMoveNo = itm.CarMoveNo,
								InvoiceVouLoc = itm.InvoiceVouLoc,
								Qty2 = itm.Qty2,
								VouNo2 = itm.VouNo2,
								FTime = itm.FTime,
								FType2 = itm.FType2,
								Remark = itm.Remark,
                                NoCost = itm.NoCost,
                                Rent = itm.Rent,
                                RentDriver = itm.RentDriver,
                                RentPlateNo = itm.RentPlateNo,
                                RentValue = itm.RentValue,
                                RentMobileNo = itm.RentMobileNo,
                                Status = itm.Status,
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
		/// select all Cars from CarMove Table
		/// </summary>
		/// <returns>List of Account center or null if Fail</returns>
		public List<myInv2> Get(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.vCarMoveGet(this.Branch, this.VouLoc, this.Number);
					List<myInv2> myList = new List<myInv2>();
					myList =  (from itm in result
							select new myInv2
							{
								Branch = itm.Branch,
								VouLoc = itm.VouLoc,
								VouNo = (int)itm.VouNo,
								VouType = (short)itm.VouType,
								HDate = itm.InvHDate,
								GDate = itm.InvGDate,
                                FNo = itm.FNo,
								Name = itm.Name,
								IDNo = itm.IDNo,
								IDType = itm.IDType,
								IDFrom = itm.IDFrom,
								IDDate = itm.IDDate,
								Address = itm.Address,
								MobileNo = itm.MobileNo,
								PlaceofLoading = itm.PlaceofLoading,
								Destination = itm.Destination,
								DestinationName1 = itm.DestinationName1,
								DestinationName2 = itm.DestinationName2,                                 
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
								InvoiceVouLoc = itm.InvoiceVouLoc,
								Status = true,
								InvoiceFNo = itm.InvoiceFNo,
								VouNo20 = itm.VouNo2,
								FTime = itm.FTime,
								InvFTime = itm.InvFTime,
								Transit = itm.Transit,
								FromLoc = itm.FromLoc,
								ToLoc = itm.ToLoc,    
                                SendStatus = string.IsNullOrEmpty(itm.Status) ? "1" : itm.Status,
                                //MobileNo2 = (!(bool)itm.Transit && itm.RecMobileNo.Trim()!= "" && itm.ToLoc == itm.Destination ? itm.RecMobileNo : "")
                                MobileNo2 = itm.RecMobileNo,                                 
                                myStatus = itm.myStatus,
                                Flag = itm.Flag
							}).ToList();

					foreach (myInv2 itm in myList)
					{
						int r1 = 0;
						int i = 0;
						try
						{
							r1 = itm.CarType.Split('@').Count();
							i = (int)itm.InvoiceFNo;
							if (r1 > 0)
							{
								if (r1 >= i) itm.CarType = itm.CarType.Split('@')[i - 1];
							}
						}
						catch(Exception)
						{
						
						}

						try
						{ 
							r1 = itm.Brand.Split('@').Count();
							if (r1 > 0)
							{
								if (r1 >= i) itm.Brand = itm.Brand.Split('@')[i - 1];
							}

							r1 = itm.PlateNo.Split('@').Count();
							if (r1 > 0)
							{
								if (r1 >= i) itm.PlateNo = itm.PlateNo.Split('@')[i - 1];
							}
						}
						catch (Exception)
						{

						}

						try
						{ 
							r1 = itm.ChassisNo.Split('@').Count();
							if (r1 > 0)
							{
								if (r1 >= i) itm.ChassisNo = itm.ChassisNo.Split('@')[i - 1];
							}
						}
						catch (Exception)
						{

						}

						try
						{ 
							r1 = itm.Color.Split('@').Count();
							if (r1 > 0)
							{
								if (r1 >= i) itm.Color = itm.Color.Split('@')[i - 1];
							}
						}
						catch (Exception)
						{

						}

						try
						{ 
							r1 = itm.Model.Split('@').Count();
							if (r1 > 0)
							{
								if (r1 >= i) itm.Model = itm.Model.Split('@')[i - 1];
							}
						}
						catch (Exception)
						{

						}
					}
					return myList;
				}
			}
			catch (Exception)
			{
				return null;
			}
		}


		/// <summary>
		/// select all Cars from CarMove Table
		/// </summary>
		/// <returns>List of Account center or null if Fail</returns>
		public List<myInv2> Gettr(string ConnectionStr,bool Checkall,string City,string Loc)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.vCarMovetr(this.Branch, City,Loc);
					List<myInv2> myList = new List<myInv2>();
					myList = (from itm in result
							  where Checkall || (!Checkall && itm.Destination == this.ToLoc)
							  select new myInv2
							  {
								  Branch = itm.Branch,
								  VouLoc = itm.VouLoc,
								  VouNo = (int)itm.VouNo,
								  VouType = (short)itm.VouType,
								  HDate = itm.InvHDate,
								  GDate = itm.InvGDate,
								  Name = itm.Name,
								  IDNo = itm.IDNo,
								  IDType = itm.IDType,
								  IDFrom = itm.IDFrom,
								  IDDate = itm.IDDate,
								  Address = itm.Address,
								  MobileNo = itm.MobileNo,
								  PlaceofLoading = itm.PlaceofLoading,
								  Destination = itm.Destination,
								  DestinationName1 = itm.DestinationName1,
								  DestinationName2 = itm.DestinationName2,
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
								  Site = itm.Site,
								  SiteAmount = itm.SiteAmount,
								  Customer = itm.Customer,
								  CustomerAmount = itm.CustomerAmount,
								  UserName = itm.UserName,
								  UserDate = itm.UserDate,
								  Qty = (short)itm.Qty,
								  Qty2 = (short)itm.Qty2,
								  InvoiceVouLoc = itm.InvoiceVouLoc,
								  Status = false,
								  InvoiceFNo = itm.InvoiceFNo,
								  CarMoveLoc = itm.VouLoc,
								  CarMoveNo = itm.Number,
								  VouNo20 = itm.VouNo2,
								  FTime = itm.FTime,
								  InvFTime = itm.InvFTime,
								  Transit = itm.Transit,
                                  Flag = itm.Flag
							  }).ToList();

					foreach (myInv2 itm in myList)
					{
						int r1 = 0;
						int i = 0;

						try
						{
							r1 = itm.CarType.Split('@').Count();
							i = (int)itm.InvoiceFNo;
							if (r1 > 0)
							{
								if (r1 >= i) itm.CarType = itm.CarType.Split('@')[i - 1];
							}
						}
						catch (Exception)
						{

						}

						try
						{
							r1 = itm.Brand.Split('@').Count();
							if (r1 > 0)
							{
								if (r1 >= i) itm.Brand = itm.Brand.Split('@')[i - 1];
							}
						}
						catch (Exception)
						{

						}


						try
						{
							r1 = itm.PlateNo.Split('@').Count();
							if (r1 > 0)
							{
								if (r1 >= i) itm.PlateNo = itm.PlateNo.Split('@')[i - 1];
							}
						}
						catch (Exception)
						{

						}


						try
						{
							r1 = itm.ChassisNo.Split('@').Count();
							if (r1 > 0)
							{
								if (r1 >= i) itm.ChassisNo = itm.ChassisNo.Split('@')[i - 1];
							}
						}
						catch (Exception)
						{

						}

						try
						{
							r1 = itm.Color.Split('@').Count();
							if (r1 > 0)
							{
								if (r1 >= i) itm.Color = itm.Color.Split('@')[i - 1];
							}
						}
						catch (Exception)
						{

						}

						try
						{
							r1 = itm.Model.Split('@').Count();
							if (r1 > 0)
							{
								if (r1 >= i) itm.Model = itm.Model.Split('@')[i - 1];
							}
						}
						catch (Exception)
						{

						}

					}
					return myList;
				}
			}
			catch (Exception)
			{
				return null;
			}
		}


		/// <summary>
		/// Get New Code for CarMove Table
		/// </summary>
		/// <returns>New code or null if fail</returns>
		public int? GetNewCode(string ConnectionStr)
		{
			try
			{
				using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
				{
					var result = myContext.CarMoveMaxCode(this.Branch, this.VouLoc);
					return (from Cat in result
							select Cat.myCode).FirstOrDefault();
				}
			}
			catch (Exception)
			{
				return 0;
			}
		}
	}

    [Serializable]
	public class CarMoveTrip
    {
        public bool Status { get; set; }
        public int FNo { get; set; }
        public string Model { get; set; }
        public string DestinationName1 { get; set; }
        public string Destination { get; set; }

        public CarMoveTrip()
        {
            this.Status = false;
            this.FNo = 0;
        }
    }

}