using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{

    [Serializable]
    public class CostCenter
    {
        public short Branch { get; set; }
        public string Code { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string FType2 { get; set; } // for test
        public System.Nullable<int> InvNo { get; set; }
        public System.Nullable<int> RecNo { get; set; }
        public System.Nullable<int> PayNo { get; set; }
        public string CashAcc { get; set; }
        public string ExpAcc { get; set; }
        public string InComeAcc { get; set; }
        public string SiteAcc { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public string Project { get; set; }
        public string Area { get; set; }
        public System.Nullable<int> CarMoveNo { get; set; }
        public string City { get; set; }
        public System.Nullable<int> CarRcvNo { get; set; }
        public string DezelAcc { get; set; }
        public string TripAcc { get; set; }
        public string CurExpAcc { get; set; }
        public string ClientsAcc { get; set; }
        public string PettyExpAcc { get; set; }
        public string DiscountAcc { get; set; }
        public string RadAcc { get; set; }
        public string LoanAcc { get; set; }
        public double? CrLimit { get; set; }
        public double? LandHour { get; set; }
        public double? LandDay { get; set; }
        public string LateAcc { get; set; }
        public string CancelInvAcc { get; set; }
        public bool? OnLine { get; set; }
        public string Location { get; set; }
        public string Lng { get; set; }
        public string Lat { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Addr3 { get; set; }
        public string Addr4 { get; set; }
        public string Addr5 { get; set; }
        public string Addr6 { get; set; }
        public string Addr7 { get; set; }
        public string Addr8 { get; set; }

        public CostCenter()
        {
            this.Branch = 0;
            this.Code = "";
            this.Name1 = "";
            this.Name2 = "";
            this.FType2 = "";
            this.InvNo = 0;
            this.RecNo = 0;
            this.PayNo = 0;
            this.CashAcc = "-1";
            this.ExpAcc = "-1";
            this.InComeAcc = "-1";
            this.SiteAcc = "-1";
            this.UserName = "";
            this.UserDate = "";
            this.Project = "-1";
            this.Area = "-1";
            this.CarMoveNo = 0;
            this.City = "-1";
	        this.CarRcvNo = 0;
	        this.DezelAcc = "-1";
	        this.TripAcc = "-1";
	        this.CurExpAcc = "-1";
	        this.ClientsAcc = "-1";
	        this.PettyExpAcc = "-1";
	        this.DiscountAcc = "-1";
            this.RadAcc = "-1";
            this.LoanAcc = "-1";
            this.CrLimit = 0;
            this.LandHour = 0;
            this.LandDay = 0;
            this.LateAcc = "-1";
            this.CancelInvAcc = "-1";
            this.OnLine = true;
            this.Location = "Branches1.html";
            this.Lng = "";
            this.Lat = "";
            this.Address = "";
            this.Address2 = "";
            this.Addr1 = "";
            this.Addr2 = "";
            this.Addr3 = "";
            this.Addr4 = "";
            this.Addr5 = "";
            this.Addr6 = "";
            this.Addr7 = "";
            this.Addr8 = "";

        }

        /// <summary>
        /// Add Cost center in Cost Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CostInsert(this.Branch, this.Code, this.Name1, this.Name2, this.InvNo, this.RecNo, this.PayNo, this.CashAcc, this.ExpAcc, this.InComeAcc, this.SiteAcc, this.UserName, this.UserDate, this.Project, this.Area, this.CarMoveNo, this.City, this.CarRcvNo, this.DezelAcc, this.TripAcc, this.CurExpAcc, this.ClientsAcc, this.PettyExpAcc, this.DiscountAcc, this.RadAcc, this.LoanAcc, this.CrLimit, this.LandHour, this.LandDay, this.LateAcc, this.CancelInvAcc, this.OnLine, this.Location, this.Address, this.Address2, this.Addr1, this.Addr2, this.Addr3, this.Addr4, this.Addr5, this.Addr6, this.Addr7, this.Addr8);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Cost center from Cost Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CostDelete(this.Branch, this.Code);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Cost center in Cost Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CostUpdate(this.Branch, this.Code, this.Name1, this.Name2, this.InvNo, this.RecNo, this.PayNo, this.CashAcc, this.ExpAcc, this.InComeAcc, this.SiteAcc, this.UserName, this.UserDate, this.Project, this.Area, this.CarMoveNo, this.City, this.CarRcvNo, this.DezelAcc, this.TripAcc, this.CurExpAcc, this.ClientsAcc, this.PettyExpAcc, this.DiscountAcc, this.RadAcc, this.LoanAcc, this.CrLimit, this.LandHour, this.LandDay, this.LateAcc, this.CancelInvAcc, this.OnLine, this.Location, this.Address, this.Address2, this.Addr1, this.Addr2, this.Addr3, this.Addr4, this.Addr5, this.Addr6, this.Addr7, this.Addr8);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// select all Cost center from Cost Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<CostCenter> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CostGetAll(this.Branch);
                    return (from itm in result
                            select new CostCenter
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                InvNo = itm.InvNo,
                                RecNo = itm.RecNo,
                                PayNo = itm.PayNo,
                                CashAcc = itm.CashAcc,
                                ExpAcc = itm.ExpAcc,
                                InComeAcc = itm.InComeAcc,
                                SiteAcc = itm.SiteAcc,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Area = itm.Area,
                                Project = itm.Project,
                                CarMoveNo = itm.CarMoveNo,
                                City = itm.City,
                                CarRcvNo = itm.CarRcvNo,
                                DezelAcc = itm.DezelAcc,
                                TripAcc = itm.TripAcc,
                                CurExpAcc = itm.CurExpAcc,
                                ClientsAcc = itm.ClientsAcc,
                                PettyExpAcc = itm.PettyExpAcc,
                                DiscountAcc = itm.DiscountAcc,
                                RadAcc = itm.RadAcc,
                                CrLimit = itm.CrLimit,
                                LoanAcc = itm.LoanAcc,
                                CancelInvAcc = itm.CancelInvAcc,
                                LateAcc = itm.LateAcc,
                                LandDay = itm.LandDay,
                                LandHour = itm.LandHour,
                                OnLine = itm.OnLine,
                                Location = itm.Location,
                                Lat = itm.Lat,
                                Lng = itm.Lng,
                                Address = itm.Address,
                                Address2 = itm.Address2,
                                Addr1 = itm.Addr1,
                                Addr2 = itm.Addr2,
                                Addr3 = itm.Addr3,
                                Addr4 = itm.Addr4,
                                Addr5 = itm.Addr5,
                                Addr6 = itm.Addr6,
                                Addr7 = itm.Addr7,
                                Addr8 = itm.Addr8                              
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Cost center from Cost Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<CostCenter> GetByCity(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CostGetByCity(this.Branch,this.City);
                    return (from itm in result
                            select new CostCenter
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                InvNo = itm.InvNo,
                                RecNo = itm.RecNo,
                                PayNo = itm.PayNo,
                                CashAcc = itm.CashAcc,
                                ExpAcc = itm.ExpAcc,
                                InComeAcc = itm.InComeAcc,
                                SiteAcc = itm.SiteAcc,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Area = itm.Area,
                                Project = itm.Project,
                                CarMoveNo = itm.CarMoveNo,
                                City = itm.City,
                                CarRcvNo = itm.CarRcvNo,
                                DezelAcc = itm.DezelAcc,
                                TripAcc = itm.TripAcc,
                                CurExpAcc = itm.CurExpAcc,
                                ClientsAcc = itm.ClientsAcc,
                                PettyExpAcc = itm.PettyExpAcc,
                                DiscountAcc = itm.DiscountAcc,
                                RadAcc = itm.RadAcc,
                                CrLimit = itm.CrLimit,
                                LoanAcc = itm.LoanAcc,
                                CancelInvAcc = itm.CancelInvAcc,
                                LateAcc = itm.LateAcc,
                                LandDay = itm.LandDay,
                                LandHour = itm.LandHour,
                                OnLine = itm.OnLine,
                                Location = itm.Location,
                                Lat = itm.Lat,
                                Lng = itm.Lng,
                                Address = itm.Address,
                                Address2 = itm.Address2,
                                Addr1 = itm.Addr1,
                                Addr2 = itm.Addr2,
                                Addr3 = itm.Addr3,
                                Addr4 = itm.Addr4,
                                Addr5 = itm.Addr5,
                                Addr6 = itm.Addr6,
                                Addr7 = itm.Addr7,
                                Addr8 = itm.Addr8                              
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        /// <summary>
        /// select all Cost center from Cost Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<CostCenter> GetAll2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CostGetAll(this.Branch);
                    return (from itm in result
                            orderby itm.Name1
                            select new CostCenter
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                InvNo = itm.InvNo,
                                RecNo = itm.RecNo,
                                PayNo = itm.PayNo,
                                CashAcc = itm.CashAcc,
                                ExpAcc = itm.ExpAcc,
                                InComeAcc = itm.InComeAcc,
                                SiteAcc = itm.SiteAcc,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Area = itm.Area,
                                Project = itm.Project,
                                CarMoveNo = itm.CarMoveNo,
                                City = itm.City,
                                CarRcvNo = itm.CarRcvNo,
                                DezelAcc = itm.DezelAcc,
                                TripAcc = itm.TripAcc,
                                CurExpAcc = itm.CurExpAcc,
                                ClientsAcc = itm.ClientsAcc,
                                PettyExpAcc = itm.PettyExpAcc,
                                DiscountAcc = itm.DiscountAcc,
                                RadAcc = itm.RadAcc,
                                CrLimit = itm.CrLimit,
                                LoanAcc = itm.LoanAcc,
                                CancelInvAcc = itm.CancelInvAcc,
                                LandDay = itm.LandDay,
                                LandHour = itm.LandHour,
                                LateAcc = itm.LateAcc,
                                OnLine = itm.OnLine,
                                Location = itm.Location,
                                Lat = itm.Lat,
                                Lng = itm.Lng,
                                Addr1 = itm.Addr1,
                                Addr2 = itm.Addr2,
                                Addr3 = itm.Addr3,
                                Addr4 = itm.Addr4,
                                Addr5 = itm.Addr5,
                                Addr6 = itm.Addr6,
                                Addr7 = itm.Addr7,
                                Addr8 = itm.Addr8                              
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cost center from Cost Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<CostCenter> GetAllOnLine(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CostGetAllOnLine(this.Branch);
                    return (from itm in result
                            orderby itm.Name1
                            select new CostCenter
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                InvNo = itm.InvNo,
                                RecNo = itm.RecNo,
                                PayNo = itm.PayNo,
                                CashAcc = itm.CashAcc,
                                ExpAcc = itm.ExpAcc,
                                InComeAcc = itm.InComeAcc,
                                SiteAcc = itm.SiteAcc,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Area = itm.Area,
                                Project = itm.Project,
                                CarMoveNo = itm.CarMoveNo,
                                City = itm.City,
                                CarRcvNo = itm.CarRcvNo,
                                DezelAcc = itm.DezelAcc,
                                TripAcc = itm.TripAcc,
                                CurExpAcc = itm.CurExpAcc,
                                ClientsAcc = itm.ClientsAcc,
                                PettyExpAcc = itm.PettyExpAcc,
                                DiscountAcc = itm.DiscountAcc,
                                RadAcc = itm.RadAcc,
                                CrLimit = itm.CrLimit,
                                LoanAcc = itm.LoanAcc,
                                CancelInvAcc = itm.CancelInvAcc,
                                LandDay = itm.LandDay,
                                LandHour = itm.LandHour,
                                LateAcc = itm.LateAcc,
                                OnLine = itm.OnLine,
                                Location = itm.Location,
                                Lat = itm.Lat,
                                Lng = itm.Lng,
                                Address = itm.Address,
                                Address2 = itm.Address2,
                                Addr1 = itm.Addr1,
                                Addr2 = itm.Addr2,
                                Addr3 = itm.Addr3,
                                Addr4 = itm.Addr4,
                                Addr5 = itm.Addr5,
                                Addr6 = itm.Addr6,
                                Addr7 = itm.Addr7,
                                Addr8 = itm.Addr8                              
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cost center from Cost Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public CostCenter find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CostGet(this.Branch,this.Code);
                    return (from itm in result
                            select new CostCenter
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                InvNo = itm.InvNo,
                                RecNo = itm.RecNo,
                                PayNo = itm.PayNo,
                                CashAcc = itm.CashAcc,
                                ExpAcc = itm.ExpAcc,
                                InComeAcc = itm.InComeAcc,
                                SiteAcc = itm.SiteAcc,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Area = itm.Area,
                                Project = itm.Project,
                                CarMoveNo = itm.CarMoveNo,
                                City = itm.City,
                                CarRcvNo = itm.CarRcvNo,
                                DezelAcc = itm.DezelAcc,
                                TripAcc = itm.TripAcc,
                                CurExpAcc = itm.CurExpAcc,
                                ClientsAcc = itm.ClientsAcc,
                                PettyExpAcc = itm.PettyExpAcc,
                                DiscountAcc = itm.DiscountAcc,
                                RadAcc = itm.RadAcc,
                                CrLimit = itm.CrLimit,
                                LoanAcc = itm.LoanAcc,
                                CancelInvAcc = itm.CancelInvAcc,
                                LandDay = itm.LandDay,
                                LandHour = itm.LandHour,
                                LateAcc = itm.LateAcc,
                                OnLine = itm.OnLine,
                                Location = itm.Location,
                                Lat = itm.Lat,
                                Lng = itm.Lng,
                                Address = itm.Address,
                                Address2 = itm.Address2,
                                Addr1 = itm.Addr1,
                                Addr2 = itm.Addr2,
                                Addr3 = itm.Addr3,
                                Addr4 = itm.Addr4,
                                Addr5 = itm.Addr5,
                                Addr6 = itm.Addr6,
                                Addr7 = itm.Addr7,
                                Addr8 = itm.Addr8                              
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get New Code for Cost Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public string GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CostMaxCode(this.Branch);
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
    public class vCostCenterResult
    {
        public string Code { get; set; }
        public string Name1 { get; set; }
        public string Code2 { get; set; }
        public string Name2 { get; set; }
        public double? Income { get; set; }
        public double? Expenses { get; set; }
        public double? Net { 
            get {
                return Income - Expenses;
            }
        }
        public double? Income1 { get; set; }
        public double? Expenses1 { get; set; }
        public double? Income2 { get; set; }
        public double? Expenses2 { get; set; }
        public double? Income3 { get; set; }
        public double? Expenses3 { get; set; }
        public double? Income4 { get; set; }
        public double? Expenses4 { get; set; }
        public double? Income5 { get; set; }
        public double? Expenses5 { get; set; }
        public double? Income6 { get; set; }
        public double? Expenses6 { get; set; }
        public double? Income7 { get; set; }
        public double? Expenses7 { get; set; }
        public double? Income8 { get; set; }
        public double? Expenses8 { get; set; }
        public double? Income9 { get; set; }
        public double? Expenses9 { get; set; }
        public double? Income10 { get; set; }
        public double? Expenses10 { get; set; }
        public double? Income11 { get; set; }
        public double? Expenses11 { get; set; }
        public double? Income12 { get; set; }
        public double? Expenses12 { get; set; }
        public double? IncomePer { get; set; }
        public double? ExpensesPer { get; set; }
        public double? IncomePer2 { get; set; }
        public double? ExpensesPer2 { get; set; }
        public double? NetPer { get; set; }

        public vCostCenterResult()
        {
            this.Code = "";
            this.Name1 = "";
            this.Code2 = "";
            this.Name2 = "";
            this.Income = 0;
            this.Expenses = 0;
            this.Income1 = 0;
            this.Expenses1 = 0;
            this.Income2 = 0;
            this.Expenses2 = 0;
            this.Income3  = 0;
            this.Expenses3 = 0;
            this.Income4 = 0;
            this.Expenses4 = 0;
            this.Income5 = 0;
            this.Expenses5 = 0;
            this.Income6 = 0;
            this.Expenses6 = 0;
            this.Income7 = 0;
            this.Expenses7 = 0;
            this.Income8 = 0;
            this.Expenses8 = 0;
            this.Income9 = 0;
            this.Expenses9 = 0;
            this.Income10 = 0;
            this.Expenses10 = 0;
            this.Income11 = 0;
            this.Expenses11 = 0;
            this.Income12 = 0;
            this.Expenses12 = 0;
            this.IncomePer = 0;
            this.ExpensesPer = 0;
            this.IncomePer2 = 0;
            this.ExpensesPer2 = 0;
            this.NetPer = 0;
        }


        /// <summary>
        /// select all Cost center from Cost Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<vCostCenterResult> GetAll(int FType,string FDate, string EDate,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result2 = myContext.vCostCenterResultAll2(FDate, EDate);                    
                    vCostCenterResult vc = new vCostCenterResult();
                    vc = (from itm in result2
                              select new vCostCenterResult {
                               Income = itm.Income,
                               Expenses = itm.Expenses
                              }).FirstOrDefault();

                    if (FType == 0)
                    {
                        var result = myContext.vAreaResultAll(FDate, EDate);
                        return (from itm in result
                                select new vCostCenterResult
                                {
                                    Code = itm.Area,
                                    Name1 = itm.Name1,
                                    Name2 = itm.Name2,
                                    Income = Math.Round((double)itm.Income, 2),
                                    Expenses = Math.Round((double)itm.Expenses, 2),
                                    IncomePer = Math.Round((double)((itm.Income * 100) / vc.Income), 2),
                                    ExpensesPer = Math.Round((double)((itm.Expenses * 100) / vc.Expenses), 2),
                                    NetPer = Math.Round((double)(((itm.Income - itm.Expenses) * 100) / vc.Net), 2)
                                }).ToList();
                    }
                    else if (FType == 1)
                    {
                        var result = myContext.vCostCenterResultAll(FDate, EDate);
                        return (from itm in result
                                select new vCostCenterResult
                                {
                                    Code = itm.CostCenter,
                                    Name1 = itm.Name1,
                                    Name2 = itm.Name2,
                                    Income = Math.Round((double)itm.Income, 2),
                                    Expenses = Math.Round((double)itm.Expenses, 2),
                                    IncomePer = Math.Round((double)((itm.Income * 100) / vc.Income), 2),
                                    ExpensesPer = Math.Round((double)((itm.Expenses * 100) / vc.Expenses), 2),
                                    NetPer = Math.Round((double)(((itm.Income - itm.Expenses) * 100) / vc.Net), 2)
                                }).ToList();
                    }
                    else if (FType == 2)
                    {
                        var result = myContext.vProjectResultAll(FDate, EDate);
                        return (from itm in result
                                select new vCostCenterResult
                                {
                                    Code = itm.Project,
                                    Name1 = itm.Name1,
                                    Name2 = itm.Name2,
                                    Income = Math.Round((double)itm.Income, 2),
                                    Expenses = Math.Round((double)itm.Expenses, 2),
                                    IncomePer = Math.Round((double)((itm.Income * 100) / vc.Income), 2),
                                    ExpensesPer = Math.Round((double)((itm.Expenses * 100) / vc.Expenses), 2),
                                    NetPer = Math.Round((double)(((itm.Income - itm.Expenses) * 100) / vc.Net), 2)
                                }).ToList();
                    }
                    else if (FType == 3)
                    {
                        var result = myContext.vCostAccResultAll(FDate, EDate);
                        return (from itm in result
                                select new vCostCenterResult
                                {
                                    Code = itm.CostAcc,
                                    Name1 = itm.Name1,
                                    Name2 = itm.Name2,
                                    Income = Math.Round((double)itm.Income, 2),
                                    Expenses = Math.Round((double)itm.Expenses, 2),
                                    IncomePer = Math.Round((double)((itm.Income * 100) / vc.Income), 2),
                                    ExpensesPer = Math.Round((double)((itm.Expenses * 100) / vc.Expenses), 2),
                                    NetPer = Math.Round((double)(((itm.Income - itm.Expenses) * 100) / vc.Net), 2)
                                }).ToList();
                    }
                    else if (FType == 4)
                    {
                        var result = myContext.vCarResultAll(FDate, EDate);
                        return (from itm in result
                                select new vCostCenterResult
                                {
                                    Code = itm.CarNo,
                                    Name1 = itm.CarType,
                                    Name2 = itm.CarType2,
                                    Income = Math.Round((double)itm.Income, 2),
                                    Expenses = Math.Round((double)itm.Expenses, 2),
                                    IncomePer = Math.Round((double)((itm.Income * 100) / vc.Income), 2),
                                    ExpensesPer = Math.Round((double)((itm.Expenses * 100) / vc.Expenses), 2),
                                    NetPer = Math.Round((double)(((itm.Income - itm.Expenses) * 100) / vc.Net), 2)
                                }).ToList();
                    }
                    else
                    {
                        var result = myContext.vEmpResultAll(FDate, EDate);
                        return (from itm in result
                                select new vCostCenterResult
                                {
                                    Code = itm.EmpCode,
                                    Name1 = itm.Name,
                                    Name2 = itm.Name2,
                                    Income = Math.Round((double)itm.Income, 2),
                                    Expenses = Math.Round((double)itm.Expenses, 2),
                                    IncomePer = Math.Round((double)((itm.Income * 100) / vc.Income), 2),
                                    ExpensesPer = Math.Round((double)((itm.Expenses * 100) / vc.Expenses), 2),
                                    NetPer = Math.Round((double)(((itm.Income - itm.Expenses) * 100) / vc.Net), 2)
                                }).ToList();
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<vCostCenterResult> GetDetails(int FType,string center,string FDate, string EDate, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result2 = myContext.vCostCenterDetails2(FDate, EDate);
                    List<vCostCenterResult> vc = new List<vCostCenterResult>();
                    vc = (from itm in result2
                          select new vCostCenterResult
                          {
                              Code = itm.Code,
                              Income = itm.amount
                          }).ToList();

                    if (FType == 0)
                    {
                        var result = myContext.vAreaDetails(FDate, EDate, center);
                        return (from itm in result
                                where itm.amount != 0
                                select new vCostCenterResult
                                {
                                    Code = itm.Code,
                                    Name1 = itm.Name1,
                                    Name2 = itm.Name2,
                                    Income = (itm.Code.StartsWith("4") ? Math.Round((double)itm.amount, 2) : 0),
                                    Expenses = (itm.Code.StartsWith("3") ? Math.Round((double)itm.amount, 2) : 0),
                                    IncomePer = Math.Round((double)(((itm.Code.StartsWith("4") ? Math.Round((double)itm.amount, 2) : 0) * 100) / ((from ssitm in vc
                                                                                                                                                   where ssitm.Code == itm.Code
                                                                                                                                                   select ssitm.Income).FirstOrDefault() != null ?
                                                                                                                                                  (from ssitm in vc
                                                                                                                                                   where ssitm.Code == itm.Code
                                                                                                                                                   select ssitm.Income).FirstOrDefault() : 1
                                                                                                                                                  )), 2),
                                    ExpensesPer = Math.Round((double)(((itm.Code.StartsWith("3") ? Math.Round((double)itm.amount, 2) : 0) * 100) / ((from ssitm in vc
                                                                                                                                                     where ssitm.Code == itm.Code
                                                                                                                                                     select ssitm.Income).FirstOrDefault() != null ? (from ssitm in vc
                                                                                                                                                                                                      where ssitm.Code == itm.Code
                                                                                                                                                                                                      select ssitm.Income).FirstOrDefault() : 1)), 2)
                                }).ToList();
                    }
                    else if(FType == 1)
                    {
                        var result = myContext.vCostCenterDetails(FDate, EDate, center);
                        return (from itm in result
                                where itm.amount != 0
                                select new vCostCenterResult
                                {
                                    Code = itm.Code,
                                    Name1 = itm.Name1,
                                    Name2 = itm.Name2,
                                    Income = (itm.Code.StartsWith("4") ? Math.Round((double)itm.amount, 2) : 0),
                                    Expenses = (itm.Code.StartsWith("3") ? Math.Round((double)itm.amount, 2) : 0),
                                    IncomePer = Math.Round((double)(((itm.Code.StartsWith("4") ? Math.Round((double)itm.amount, 2) : 0) * 100) / ((from ssitm in vc
                                                                                                                                                   where ssitm.Code == itm.Code
                                                                                                                                                   select ssitm.Income).FirstOrDefault() != null ?
                                                                                                                                                  (from ssitm in vc
                                                                                                                                                   where ssitm.Code == itm.Code
                                                                                                                                                   select ssitm.Income).FirstOrDefault() : 1
                                                                                                                                                  )), 2),
                                    ExpensesPer = Math.Round((double)(((itm.Code.StartsWith("3") ? Math.Round((double)itm.amount, 2) : 0) * 100) / ((from ssitm in vc
                                                                                                                                                     where ssitm.Code == itm.Code
                                                                                                                                                     select ssitm.Income).FirstOrDefault() != null ? (from ssitm in vc
                                                                                                                                                                                                      where ssitm.Code == itm.Code
                                                                                                                                                                                                      select ssitm.Income).FirstOrDefault() : 1)), 2)
                                }).ToList();
                    }
                    else if (FType == 2)
                    {
                        var result = myContext.vProjectDetails(FDate, EDate, center);
                        return (from itm in result
                                where itm.amount != 0
                                select new vCostCenterResult
                                {
                                    Code = itm.Code,
                                    Name1 = itm.Name1,
                                    Name2 = itm.Name2,
                                    Income = (itm.Code.StartsWith("4") ? Math.Round((double)itm.amount, 2) : 0),
                                    Expenses = (itm.Code.StartsWith("3") ? Math.Round((double)itm.amount, 2) : 0),
                                    IncomePer = Math.Round((double)(((itm.Code.StartsWith("4") ? Math.Round((double)itm.amount, 2) : 0) * 100) / ((from ssitm in vc
                                                                                                                                                   where ssitm.Code == itm.Code
                                                                                                                                                   select ssitm.Income).FirstOrDefault() != null ?
                                                                                                                                                  (from ssitm in vc
                                                                                                                                                   where ssitm.Code == itm.Code
                                                                                                                                                   select ssitm.Income).FirstOrDefault() : 1
                                                                                                                                                  )), 2),
                                    ExpensesPer = Math.Round((double)(((itm.Code.StartsWith("3") ? Math.Round((double)itm.amount, 2) : 0) * 100) / ((from ssitm in vc
                                                                                                                                                     where ssitm.Code == itm.Code
                                                                                                                                                     select ssitm.Income).FirstOrDefault() != null ? (from ssitm in vc
                                                                                                                                                                                                      where ssitm.Code == itm.Code
                                                                                                                                                                                                      select ssitm.Income).FirstOrDefault() : 1)), 2)
                                }).ToList();
                    }
                    else if (FType == 3)
                    {
                        var result = myContext.vCostAccDetails(FDate, EDate, center);
                        return (from itm in result
                                where itm.amount != 0
                                select new vCostCenterResult
                                {
                                    Code = itm.Code,
                                    Name1 = itm.Name1,
                                    Name2 = itm.Name2,
                                    Income = (itm.Code.StartsWith("4") ? Math.Round((double)itm.amount, 2) : 0),
                                    Expenses = (itm.Code.StartsWith("3") ? Math.Round((double)itm.amount, 2) : 0),
                                    IncomePer = Math.Round((double)(((itm.Code.StartsWith("4") ? Math.Round((double)itm.amount, 2) : 0) * 100) / ((from ssitm in vc
                                                                                                                                                   where ssitm.Code == itm.Code
                                                                                                                                                   select ssitm.Income).FirstOrDefault() != null ?
                                                                                                                                                  (from ssitm in vc
                                                                                                                                                   where ssitm.Code == itm.Code
                                                                                                                                                   select ssitm.Income).FirstOrDefault() : 1
                                                                                                                                                  )), 2),
                                    ExpensesPer = Math.Round((double)(((itm.Code.StartsWith("3") ? Math.Round((double)itm.amount, 2) : 0) * 100) / ((from ssitm in vc
                                                                                                                                                     where ssitm.Code == itm.Code
                                                                                                                                                     select ssitm.Income).FirstOrDefault() != null ? (from ssitm in vc
                                                                                                                                                                                                      where ssitm.Code == itm.Code
                                                                                                                                                                                                      select ssitm.Income).FirstOrDefault() : 1)), 2)
                                }).ToList();
                    }
                    else if (FType == 4)
                    {
                        var result = myContext.vCarDetails(FDate, EDate, center);
                        return (from itm in result
                                where itm.amount != 0
                                select new vCostCenterResult
                                {
                                    Code = itm.Code,
                                    Name1 = itm.Name1,
                                    Name2 = itm.Name2,
                                    Income = (itm.Code.StartsWith("4") ? Math.Round((double)itm.amount, 2) : 0),
                                    Expenses = (itm.Code.StartsWith("3") ? Math.Round((double)itm.amount, 2) : 0),
                                    IncomePer = Math.Round((double)(((itm.Code.StartsWith("4") ? Math.Round((double)itm.amount, 2) : 0) * 100) / ((from ssitm in vc
                                                                                                                                                   where ssitm.Code == itm.Code
                                                                                                                                                   select ssitm.Income).FirstOrDefault() != null ?
                                                                                                                                                  (from ssitm in vc
                                                                                                                                                   where ssitm.Code == itm.Code
                                                                                                                                                   select ssitm.Income).FirstOrDefault() : 1
                                                                                                                                                  )), 2),
                                    ExpensesPer = Math.Round((double)(((itm.Code.StartsWith("3") ? Math.Round((double)itm.amount, 2) : 0) * 100) / ((from ssitm in vc
                                                                                                                                                     where ssitm.Code == itm.Code
                                                                                                                                                     select ssitm.Income).FirstOrDefault() != null ? (from ssitm in vc
                                                                                                                                                                                                      where ssitm.Code == itm.Code
                                                                                                                                                                                                      select ssitm.Income).FirstOrDefault() : 1)), 2)
                                }).ToList();
                    }
                    else if (FType == 6)
                    {
                        var result = myContext.vCostCenterDetails(FDate, EDate, center);
                        return (from itm in result
                                where itm.amount != 0
                                group itm by new { itm.Code, itm.Name1, itm.Name2 }
                                into g
                                select new vCostCenterResult
                                {
                                    Code = g.Key.Code,
                                    Name1 = g.Key.Name1,
                                    Name2 = g.Key.Name2,
                                    Income = (g.Key.Code.StartsWith("4") ? g.Sum(p => Math.Round((double)p.amount, 2)) : 0),
                                    Expenses = (g.Key.Code.StartsWith("3") ? g.Sum(p => Math.Round((double)p.amount, 2)) : 0),
                                    IncomePer = Math.Round((double)(((g.Key.Code.StartsWith("4") ? g.Sum(p => Math.Round((double)p.amount, 2)) : 0) * 100) / ((from ssitm in vc
                                                                                                                                                   where ssitm.Code == g.Key.Code
                                                                                                                                                   select ssitm.Income).FirstOrDefault() != null ?
                                                                                                                                                  (from ssitm in vc
                                                                                                                                                   where ssitm.Code == g.Key.Code
                                                                                                                                                   select ssitm.Income).FirstOrDefault() : 1
                                                                                                                                                  )), 2),
                                    ExpensesPer = Math.Round((double)(((g.Key.Code.StartsWith("3") ? g.Sum(p => Math.Round((double)p.amount, 2)) : 0) * 100) / ((from ssitm in vc
                                                                                                                                                     where ssitm.Code == g.Key.Code
                                                                                                                                                     select ssitm.Income).FirstOrDefault() != null ? (from ssitm in vc
                                                                                                                                                                                                      where ssitm.Code == g.Key.Code
                                                                                                                                                                                                      select ssitm.Income).FirstOrDefault() : 1)), 2)
                                }).ToList();
                    }
                    else 
                    {
                        var result = myContext.vEmpDetails(FDate, EDate, center);
                        return (from itm in result
                                where itm.amount != 0
                                select new vCostCenterResult
                                {
                                    Code = itm.Code,
                                    Name1 = itm.Name1,
                                    Name2 = itm.Name2,
                                    Income = (itm.Code.StartsWith("4") ? Math.Round((double)itm.amount, 2) : 0),
                                    Expenses = (itm.Code.StartsWith("3") ? Math.Round((double)itm.amount, 2) : 0),
                                    IncomePer = Math.Round((double)(((itm.Code.StartsWith("4") ? Math.Round((double)itm.amount, 2) : 0) * 100) / ((from ssitm in vc
                                                                                                                                                   where ssitm.Code == itm.Code
                                                                                                                                                   select ssitm.Income).FirstOrDefault() != null ?
                                                                                                                                                  (from ssitm in vc
                                                                                                                                                   where ssitm.Code == itm.Code
                                                                                                                                                   select ssitm.Income).FirstOrDefault() : 1
                                                                                                                                                  )), 2),
                                    ExpensesPer = Math.Round((double)(((itm.Code.StartsWith("3") ? Math.Round((double)itm.amount, 2) : 0) * 100) / ((from ssitm in vc
                                                                                                                                                     where ssitm.Code == itm.Code
                                                                                                                                                     select ssitm.Income).FirstOrDefault() != null ? (from ssitm in vc
                                                                                                                                                                                                      where ssitm.Code == itm.Code
                                                                                                                                                                                                      select ssitm.Income).FirstOrDefault() : 1)), 2)
                                }).ToList();
                    }
                }                     
            }
            catch (Exception)
            {
                return null;
            }
        }


    }


}
