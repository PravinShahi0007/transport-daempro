using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class eServices
    {
        public short  DocType { get; set; }
        public int    DocNo { get; set; }
        public string DocDate { get; set; }
        public string DocTime { get; set; }
        public int? EmpCode { get; set; }
        public short? FType { get; set; }
        public string SDate { get; set; }
        public string Notes { get; set; }
        public short? Status { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public string TransferUser { get; set; }
        public short? VacDays	{ get; set; }
        public short? VacDays0	{ get; set; }
        public short? VacDays1	{ get; set; }
        public double? VacDaysam	{ get; set; }
        public string EDate { get; set; }
        public string Notes2 { get; set; }
        public int? Field1 { get; set; }
        public string Field01 { get; set; }


        public eServices()
        {
            this.DocType = 0;
            this.DocNo = 0;
            this.DocDate = "";
            this.DocTime = "";
            this.EmpCode = 0;
            this.FType = 0;
            this.SDate = "";
            this.Notes = "";
            this.Status = 0;
            this.UserName = "";
            this.UserDate = "";
            this.TransferUser = "";
            this.VacDays = 0;
            this.VacDays0 = 0;
            this.VacDays1 = 0;
            this.VacDaysam = 0;
            this.EDate = "";
            this.Notes2 = "";
            this.Field1 = 0;
            this.Field01 = "";
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
                    myContext.eServicesAdd(this.DocType, this.DocNo, this.DocDate, this.DocTime, this.EmpCode, this.FType, this.SDate, this.Notes, this.Status, this.UserName, this.UserDate , this.TransferUser,this.VacDays,this.VacDays0,this.VacDays1,this.VacDaysam,this.Notes2,this.EDate,this.Field1,this.Field01);
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
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.eServicesDelete(this.DocType, this.DocNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Area in Area Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.eServicesUpdate(this.DocType, this.DocNo, this.DocDate, this.DocTime, this.EmpCode, this.FType, this.SDate, this.Notes, this.Status, this.UserName, this.UserDate, this.TransferUser, this.VacDays, this.VacDays0, this.VacDays1, this.VacDaysam, this.Notes2, this.EDate, this.Field1, this.Field01);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Update Area in Area Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool StatusUpdate(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.eServicesUpdateStatus(this.DocType, this.DocNo, this.Status, this.TransferUser);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select  Cost Acc  from CostAcc Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public eServices find(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.eServicesGet(this.DocType, this.DocNo);
                    return (from itm in result
                            select new eServices
                            {
                                DocType = itm.DocType,
                                DocNo = itm.DocNo,
                                DocDate = itm.DocDate,
                                DocTime = itm.DocTime,
                                EmpCode = itm.EmpCode,
                                FType = itm.FType,
                                SDate = itm.sDate,
                                Notes = itm.Notes,
                                Status = itm.Status,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                TransferUser = itm.TransferUser,
                                VacDays = itm.VacDays,
                                VacDays0 = itm.VacDays0,
                                VacDays1 = itm.VacDays1,
                                VacDaysam = itm.VacDaysam,
                                EDate = itm.EDate,
                                Notes2 = itm.Notes2,
                                Field1 = itm.Field1,
                                Field01 = itm.Field01
                            }).FirstOrDefault();
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
        public eServices GetActive(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.eServicesGetOpen(this.DocType, this.EmpCode);
                    return (from itm in result
                            select new eServices
                            {
                                DocType = itm.DocType,
                                DocNo = itm.DocNo,
                                DocDate = itm.DocDate,
                                DocTime = itm.DocTime,
                                EmpCode = itm.EmpCode,
                                FType = itm.FType,
                                SDate = itm.sDate,
                                Notes = itm.Notes,
                                Status = itm.Status,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                TransferUser = itm.TransferUser,
                                VacDays = itm.VacDays,
                                VacDays0 = itm.VacDays0,
                                VacDays1 = itm.VacDays1,
                                VacDaysam = itm.VacDaysam,
                                EDate = itm.EDate,
                                Notes2 = itm.Notes2,
                                Field1 = itm.Field1,
                                Field01 = itm.Field01
                            }).FirstOrDefault();
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
        public List<eServices> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.eServicesGetAll(this.DocType, this.EmpCode);
                    return (from itm in result
                            select new eServices
                            {
                                DocType = itm.DocType,
                                DocNo = itm.DocNo,
                                DocDate = itm.DocDate,
                                DocTime = itm.DocTime,
                                EmpCode = itm.EmpCode,
                                FType = itm.FType,
                                SDate = itm.sDate,
                                Notes = itm.Notes,
                                Status = itm.Status,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                TransferUser = itm.TransferUser,
                                VacDays = itm.VacDays,
                                VacDays0 = itm.VacDays0,
                                VacDays1 = itm.VacDays1,
                                VacDaysam = itm.VacDaysam,
                                EDate = itm.EDate,
                                Notes2 = itm.Notes2,
                                Field1 = itm.Field1,
                                Field01 = itm.Field01
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
        public List<veServices> GetByStatus(string RoleName,string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.veServicesGetStatus(RoleName,this.UserName, this.Status, this.DocType);
                    return (from itm in result
                            select new veServices
                            {
                                DocType = itm.DocType,
                                DocNo = itm.DocNo,
                                DocDate = itm.DocDate,
                                DocTime = itm.DocTime,
                                EmpCode = itm.EmpCode,
                                FType = itm.FType,
                                SDate = itm.sDate,
                                Notes = itm.Notes,
                                Status = itm.Status,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpName = itm.EmpName,
                                FCreate = itm.FCreate,
                                FormName = itm.FormName,                                
                                FStep1 = itm.FStep1,
                                FStep2 = itm.FStep2,
                                FStep3 = itm.FStep3,
                                FStep4 = itm.FStep4,
                                FStep5 = itm.FStep5,
                                FStep6 = itm.FStep6,
                                FStep7 = itm.FStep7,
                                FStep8 = itm.FStep8,
                                Manag1 = itm.Manag1,
                                Manag2 = itm.Manag2,
                                Name = itm.Name,
                                Name2 = itm.Name2,
                                LoginUserName = itm.LoginUserName,
                                CNN = ConnectionStr,
                                SType1 = itm.SType1,
                                SType2 = itm.SType2,
                                SType3 = itm.SType3,
                                SType4 = itm.SType4,
                                SType5 = itm.SType5,
                                SType6 = itm.SType6,
                                SType7 = itm.SType7,
                                SType8 = itm.SType8,
                                TransferUser = itm.TransferUser,
                                VacDays = itm.VacDays,
                                VacDays0 = itm.VacDays0,
                                VacDays1 = itm.VacDays1,
                                VacDaysam = itm.VacDaysam,
                                EDate = itm.EDate
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
        public List<veServices> GetActive(string MyUserName,string MyRoleName,string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.veServicesGetActive(MyUserName, MyRoleName);
                    return (from itm in result
                            select new veServices
                            {
                                DocType = itm.DocType,
                                DocNo = itm.DocNo,
                                DocDate = itm.DocDate,
                                DocTime = itm.DocTime,
                                EmpCode = itm.EmpCode,
                                FType = itm.FType,
                                SDate = itm.sDate,
                                Notes = itm.Notes,
                                Status = itm.Status,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpName = itm.EmpName,
                                FCreate = itm.FCreate,
                                FormName = itm.FormName,
                                FStep1 = itm.FStep1,
                                FStep2 = itm.FStep2,
                                FStep3 = itm.FStep3,
                                FStep4 = itm.FStep4,
                                FStep5 = itm.FStep5,
                                FStep6 = itm.FStep6,
                                FStep7 = itm.FStep7,
                                FStep8 = itm.FStep8,
                                Manag1 = itm.Manag1,
                                Manag2 = itm.Manag2,
                                Name = itm.Name,
                                Name2 = itm.Name2,
                                LoginUserName = itm.LoginUserName,
                                CNN = ConnectionStr,
                                SType1 = itm.SType1,
                                SType2 = itm.SType2,
                                SType3 = itm.SType3,
                                SType4 = itm.SType4,
                                SType5 = itm.SType5,
                                SType6 = itm.SType6,
                                SType7 = itm.SType7,
                                SType8 = itm.SType8,
                                TransferUser = itm.TransferUser,
                                VacDays = itm.VacDays,
                                VacDays0 = itm.VacDays0,
                                VacDays1 = itm.VacDays1,
                                VacDaysam = itm.VacDaysam,
                                EDate = itm.EDate
                            }).ToList();
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
        public int? GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.eServicesMaxCode(this.DocType);
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
    public class veServices : eServices
    {
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string FormName { get; set; }
        public string FCreate { get; set; }
        public string FStep1 { get; set; }
        public string FStep2 { get; set; }
        public string FStep3 { get; set; }
        public string FStep4 { get; set; }
        public string FStep5 { get; set; }
        public string FStep6 { get; set; }
        public string FStep7 { get; set; }
        public string FStep8 { get; set; }
        public short? SType1 { get; set; }
        public short? SType2 { get; set; }
        public short? SType3 { get; set; }
        public short? SType4 { get; set; }
        public short? SType5 { get; set; }
        public short? SType6 { get; set; }
        public short? SType7 { get; set; }
        public short? SType8 { get; set; }
        public bool? Action1 { get; set; }
        public bool? Action2 { get; set; }
        public bool? Action3 { get; set; }
        public bool? Action4 { get; set; }
        public bool? Action5 { get; set; }
        public bool? Action6 { get; set; }
        public bool? Action7 { get; set; }
        public bool? Action8 { get; set; }
        public string EmpName { get; set; }
        public string Manag1 { get; set; }
        public string Manag2 { get; set; }
        public string CNN { get; set; }
        public string LoginUserName { get; set; }        
        public string MakeDiv { 
            get{
                 string vStr = @"<div class='containerStep'>
                                  <ul class='progressbar'>
                                  <li class='active'>" + this.UserName + @"<br/>" + this.UserDate + @"</li>";
                 if (this.TransferUser != "" && this.TransferUser == this.UserName)
                 {
                     vStr = @"<div class='containerStep'>
                                  <ul class='progressbar'>
                                  <li class='current'>" + this.UserName + @"<br/>" + this.UserDate + @"</li>";
                 }

                if(this.FStep1 != "-1") 
                {
                    if(this.Status == 0 )                    
                    {
                        eServicesAgree vService = new eServicesAgree();
                        vService.DocType = this.DocType;
                        vService.DocNo = this.DocNo;
                        vService.FNo = 1;
                        vService = vService.findFNo(this.CNN);
                        if (vService != null)
                        {
                            if (vService.Agree == 1)
                            {
                                if (this.TransferUser != "" && this.TransferUser == vService.AgreeUser) vStr += @"<li class='current'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                                else vStr += @"<li class='active'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            }
                            else if (vService.Agree == 88 || vService.Agree == 2) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            else vStr += @"<li class='refuse'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                        }
                        else vStr += @"<li>" + (this.FStep1 == "1" ? this.Manag1 : this.FStep1) + @"</li>";
                    }
                    else if(this.Status == 1)
                    {
                        eServicesAgree vService = new eServicesAgree();
                        vService.DocType = this.DocType;
                        vService.DocNo = this.DocNo;
                        vService.FNo = 1;
                        vService = vService.findFNo(this.CNN);
                        if (vService != null)
                        {
                            if (vService.Agree == 1)
                            {
                                if (this.TransferUser != "" && this.TransferUser == vService.AgreeUser) vStr += @"<li class='current'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                                else vStr += @"<li class='active'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            }
                            else if (vService.Agree == 88 || vService.Agree == 2) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            else vStr += @"<li class='refuse'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                        }
                        else vStr += @"<li class='current'>" + (this.FStep1 == "1" ? this.Manag1 : this.FStep1)  + @"</li>";                    
                    }
                    else
                    {
                        eServicesAgree vService = new eServicesAgree();
                        vService.DocType = this.DocType;
                        vService.DocNo = this.DocNo;
                        vService.FNo = 1;
                        vService = vService.findFNo(this.CNN);
                        if (vService != null)
                        {
                            if (vService.Agree == 1)
                            {
                                if (this.TransferUser != "" && this.TransferUser == vService.AgreeUser) vStr += @"<li class='current'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                                else vStr += @"<li class='active'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            }
                            else if (vService.Agree == 2 || vService.Agree == 88) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            else vStr += @"<li class='refuse'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                        }
                        else
                        {
                            if (this.Status == -1) vStr += @"<li>" + (this.FStep1 == "1" ? this.Manag1 : this.FStep1) + @"</li>";
                            else vStr += @"<li class='active'>" + (this.FStep1 == "1" ? this.Manag1 : this.FStep1) + @"</li>";
                        }
                    }                        
                }
                if(this.FStep2 != "-1") 
                {
                    if (this.Status == 0)
                    {
                        eServicesAgree vService = new eServicesAgree();
                        vService.DocType = this.DocType;
                        vService.DocNo = this.DocNo;
                        vService.FNo = 2;
                        vService = vService.findFNo(this.CNN);
                        if (vService != null)
                        {
                            if (vService.Agree == 1)
                            {
                                if (this.TransferUser != "" && this.TransferUser == vService.AgreeUser) vStr += @"<li class='current'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                                else vStr += @"<li class='active'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            }
                            else if (vService.Agree == 2 || vService.Agree == 88) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            else vStr += @"<li class='refuse'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                        }
                        else vStr += @"<li>" + (this.FStep2 == "1" ? this.Manag1 : this.FStep2) + @"</li>";
                    }
                    else if(this.Status == 1 )                    
                    {
                        vStr += @"<li class='current'>" + (this.FStep2 == "1" ? this.Manag1 : this.FStep2) + @"</li>";
                    }
                    else
                    {
                        eServicesAgree vService = new eServicesAgree();
                        vService.DocType = this.DocType;
                        vService.DocNo = this.DocNo;
                        vService.FNo = 2;
                        vService = vService.findFNo(this.CNN);
                        if (vService != null)
                        {
                            if (vService.Agree == 1)
                            {
                                if (this.TransferUser != "" && this.TransferUser == vService.AgreeUser) vStr += @"<li class='current'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                                else vStr += @"<li class='active'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            }
                            else if (vService.Agree == 2 || vService.Agree == 88) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            else vStr += @"<li class='refuse'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                        }
                        else
                        {
                            if (this.Status == -1) vStr += @"<li>" + (this.FStep2 == "1" ? this.Manag1 : this.FStep2) + @"</li>";
                            else vStr += @"<li class='active'>" + (this.FStep2 == "1" ? this.Manag1 : this.FStep2) + @"</li>";
                        }
                    }                        
                }
                if(this.FStep3 != "-1") 
                {
                    if (this.Status > -1 && this.Status <2)
                    {
                        eServicesAgree vService = new eServicesAgree();
                        vService.DocType = this.DocType;
                        vService.DocNo = this.DocNo;
                        vService.FNo = 3;
                        vService = vService.findFNo(this.CNN);
                        if (vService != null)
                        {
                            if (vService.Agree == 1)
                            {
                                if (this.TransferUser != "" && this.TransferUser == vService.AgreeUser) vStr += @"<li class='current'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                                else vStr += @"<li class='active'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            }
                            else if (vService.Agree == 2 || vService.Agree == 88) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            else vStr += @"<li class='refuse'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                        }
                        else vStr += @"<li>" + (this.FStep3 == "1" ? this.Manag1 : this.FStep3) + @"</li>";
                    }
                    else if(this.Status == 2 )                    
                    {
                        vStr += @"<li class='current'>" + (this.FStep3 == "1" ? this.Manag1 : this.FStep3) + @"</li>";                    
                    }
                    else
                    {
                        eServicesAgree vService = new eServicesAgree();
                        vService.DocType = this.DocType;
                        vService.DocNo = this.DocNo;
                        vService.FNo = 3;
                        vService = vService.findFNo(this.CNN);
                        if (vService != null)
                        {
                            if (vService.Agree == 1)
                            {
                                if (this.TransferUser != "" && this.TransferUser == vService.AgreeUser)  vStr += @"<li class='current'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                                else vStr += @"<li class='active'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            }
                            else if (vService.Agree == 2 || vService.Agree == 88) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            else vStr += @"<li class='refuse'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                        }
                        else
                        {
                            if (this.Status == -1) vStr += @"<li>" + (this.FStep3 == "1" ? this.Manag1 : this.FStep3) + @"</li>";
                            else vStr += @"<li class='active'>" + (this.FStep3 == "1" ? this.Manag1 : this.FStep3) + @"</li>";
                        }
                    }                        
                }
                if(this.FStep4 != "-1") 
                {
                    if (this.Status > -1 && this.Status < 3)
                    {
                        eServicesAgree vService = new eServicesAgree();
                        vService.DocType = this.DocType;
                        vService.DocNo = this.DocNo;
                        vService.FNo = 4;
                        vService = vService.findFNo(this.CNN);
                        if (vService != null)
                        {
                            if (vService.Agree == 1)
                            {
                                if (this.TransferUser != "" && this.TransferUser == vService.AgreeUser) vStr += @"<li class='current'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                                else vStr += @"<li class='active'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            }
                            else if (vService.Agree == 2 || vService.Agree == 88) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            else vStr += @"<li class='refuse'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                        }
                        else vStr += @"<li>" + (this.FStep4 == "1" ? this.Manag1 : this.FStep4) + @"</li>";
                    }
                    else if(this.Status == 3 )                    
                    {
                        vStr += @"<li class='current'>" + (this.FStep4 == "1" ? this.Manag1 : this.FStep4) + @"</li>";                    
                    }
                    else
                    {
                        eServicesAgree vService = new eServicesAgree();
                        vService.DocType = this.DocType;
                        vService.DocNo = this.DocNo;
                        vService.FNo = 4;
                        vService = vService.findFNo(this.CNN);
                        if (vService != null)
                        {
                            if (vService.Agree == 1)
                            {
                                if (this.TransferUser != "" && this.TransferUser == vService.AgreeUser) vStr += @"<li class='current'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                                else vStr += @"<li class='active'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            }
                            else if (vService.Agree == 2 || vService.Agree == 88) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            else vStr += @"<li class='refuse'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                        }
                        else
                        {
                            if (this.Status == -1) vStr += @"<li>" + (this.FStep4 == "1" ? this.Manag1 : this.FStep4) + @"</li>";
                            else vStr += @"<li class='active'>" + (this.FStep4 == "1" ? this.Manag1 : this.FStep4) + @"</li>";
                        }
                    }                        
                }
                if(this.FStep5 != "-1") 
                {
                    if (this.Status > -1 && this.Status < 4)
                    {
                        eServicesAgree vService = new eServicesAgree();
                        vService.DocType = this.DocType;
                        vService.DocNo = this.DocNo;
                        vService.FNo = 5;
                        vService = vService.findFNo(this.CNN);
                        if (vService != null)
                        {
                            if (vService.Agree == 1)
                            {
                                if (this.TransferUser != "" && this.TransferUser == vService.AgreeUser) vStr += @"<li class='current'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                                else vStr += @"<li class='active'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            }
                            else if (vService.Agree == 2 || vService.Agree == 88) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            else vStr += @"<li class='refuse'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                        }
                        else vStr += @"<li>" + (this.FStep5 == "1" ? this.Manag1 : this.FStep5) + @"</li>";
                    }
                    else if(this.Status == 4 )                    
                    {
                        vStr += @"<li class='current'>" + (this.FStep5 == "1" ? this.Manag1 : this.FStep5) + @"</li>";                    
                    }
                    else
                    {
                        eServicesAgree vService = new eServicesAgree();
                        vService.DocType = this.DocType;
                        vService.DocNo = this.DocNo;
                        vService.FNo = 5;
                        vService = vService.findFNo(this.CNN);
                        if (vService != null)
                        {
                            if (vService.Agree == 1)
                            {
                                if (this.TransferUser != "" && this.TransferUser == vService.AgreeUser) vStr += @"<li class='current'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                                else vStr += @"<li class='active'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            }
                            else if (vService.Agree == 2 || vService.Agree == 88) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            else vStr += @"<li class='refuse'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                        }
                        else
                        {
                            if (this.Status == -1) vStr += @"<li>" + (this.FStep5 == "1" ? this.Manag1 : this.FStep5) + @"</li>";
                            else vStr += @"<li class='active'>" + (this.FStep5 == "1" ? this.Manag1 : this.FStep5) + @"</li>";
                        }
                    }                        
                }
                if(this.FStep6 != "-1") 
                {
                    if (this.Status > -1 && this.Status < 5)
                    {
                        eServicesAgree vService = new eServicesAgree();
                        vService.DocType = this.DocType;
                        vService.DocNo = this.DocNo;
                        vService.FNo = 6;
                        vService = vService.findFNo(this.CNN);
                        if (vService != null)
                        {
                            if (vService.Agree == 1)
                            {
                                if (this.TransferUser != "" && this.TransferUser == vService.AgreeUser) vStr += @"<li class='current'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                                else vStr += @"<li class='active'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            }
                            else if (vService.Agree == 2 || vService.Agree == 88) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            else vStr += @"<li class='refuse'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                        }
                        else vStr += @"<li>" + (this.FStep6 == "1" ? this.Manag1 : this.FStep6) + @"</li>";
                    }
                    else if(this.Status == 5 )                    
                    {
                        vStr += @"<li class='current'>" + (this.FStep6 == "1" ? this.Manag1 : this.FStep6) + @"</li>";                    
                    }
                    else
                    {
                        eServicesAgree vService = new eServicesAgree();
                        vService.DocType = this.DocType;
                        vService.DocNo = this.DocNo;
                        vService.FNo = 6;
                        vService = vService.findFNo(this.CNN);
                        if (vService != null)
                        {
                            if (vService.Agree == 1)
                            {
                                if (this.TransferUser != "" && this.TransferUser == vService.AgreeUser) vStr += @"<li class='current'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                                else vStr += @"<li class='active'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            }
                            else if (vService.Agree == 2 || vService.Agree == 88) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            else vStr += @"<li class='refuse'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                        }
                        else
                        {
                            if (this.Status == -1) vStr += @"<li>" + (this.FStep6 == "1" ? this.Manag1 : this.FStep6) + @"</li>";
                            else vStr += @"<li class='active'>" + (this.FStep6 == "1" ? this.Manag1 : this.FStep6) + @"</li>";
                        }
                    }                        
                }
                if(this.FStep7 != "-1") 
                {
                    if (this.Status > -1 && this.Status < 6)
                    {
                        eServicesAgree vService = new eServicesAgree();
                        vService.DocType = this.DocType;
                        vService.DocNo = this.DocNo;
                        vService.FNo = 7;
                        vService = vService.findFNo(this.CNN);
                        if (vService != null)
                        {
                            if (vService.Agree == 1)
                            {
                                if (this.TransferUser != "" && this.TransferUser == vService.AgreeUser) vStr += @"<li class='current'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                                else vStr += @"<li class='active'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            }
                            else if (vService.Agree == 2 || vService.Agree == 88) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            else vStr += @"<li class='refuse'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                        }
                        else vStr += @"<li>" + (this.FStep7 == "1" ? this.Manag1 : this.FStep7) + @"</li>";
                    }
                    else if(this.Status == 6 )                    
                    {
                        vStr += @"<li class='current'>" + (this.FStep7 == "1" ? this.Manag1 : this.FStep7) + @"</li>";                    
                    }
                    else
                    {
                        eServicesAgree vService = new eServicesAgree();
                        vService.DocType = this.DocType;
                        vService.DocNo = this.DocNo;
                        vService.FNo = 7;
                        vService = vService.findFNo(this.CNN);
                        if (vService != null)
                        {
                            if (vService.Agree == 1)
                            {
                                if (this.TransferUser != "" && this.TransferUser == vService.AgreeUser) vStr += @"<li class='current'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                                else vStr += @"<li class='active'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            }
                            else if (vService.Agree == 2 || vService.Agree == 88) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            else vStr += @"<li class='refuse'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                        }
                        else
                        {
                            if (this.Status == -1) vStr += @"<li>" + (this.FStep7 == "1" ? this.Manag1 : this.FStep7) + @"</li>";
                            else vStr += @"<li class='active'>" + (this.FStep7 == "1" ? this.Manag1 : this.FStep7) + @"</li>";
                        }
                    }                        
                }
                if(this.FStep8 != "-1") 
                {
                    if (this.Status > -1 && this.Status < 7)
                    {
                        eServicesAgree vService = new eServicesAgree();
                        vService.DocType = this.DocType;
                        vService.DocNo = this.DocNo;
                        vService.FNo = 8;
                        vService = vService.findFNo(this.CNN);
                        if (vService != null)
                        {
                            if (vService.Agree == 1)
                            {
                                if (this.TransferUser != "" && this.TransferUser == vService.AgreeUser) vStr += @"<li class='current'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                                else vStr += @"<li class='active'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            }
                            else if (vService.Agree == 2 || vService.Agree == 88) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            else vStr += @"<li class='refuse'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                        }
                        else vStr += @"<li>" + (this.FStep8 == "1" ? this.Manag1 : this.FStep8) + @"</li>";
                    }
                    else if(this.Status == 7 )                    
                    {
                        vStr += @"<li class='current'>" + (this.FStep8 == "1" ? this.Manag1 : this.FStep8) + @"</li>";                    
                    }
                    else
                    {
                        eServicesAgree vService = new eServicesAgree();
                        vService.DocType = this.DocType;
                        vService.DocNo = this.DocNo;
                        vService.FNo = 8;
                        vService = vService.findFNo(this.CNN);
                        if (vService != null)
                        {
                            if (vService.Agree == 1)
                            {
                                if (this.TransferUser != "" && this.TransferUser == vService.AgreeUser) vStr += @"<li class='current'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                                else vStr += @"<li class='active'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            }
                            else if (vService.Agree == 2 || vService.Agree == 88) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            else vStr += @"<li class='refuse'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                        }
                        else
                        {
                            if (this.Status == -1) vStr += @"<li>" + (this.FStep8 == "1" ? this.Manag1 : this.FStep8) + @"</li>";
                            else vStr += @"<li class='active'>" + (this.FStep8 == "1" ? this.Manag1 : this.FStep8) + @"</li>";
                        }
                    }                        
                }
                vStr += @"</ul></div>";

                return vStr;
            }
        }


        /// <summary>
        /// select  Cost Acc  from CostAcc Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public veServices find0(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.veServicesGet(this.DocType, this.DocNo);
                    return (from itm in result
                            select new veServices
                            {
                                DocType = itm.DocType,
                                DocNo = itm.DocNo,
                                DocDate = itm.DocDate,
                                DocTime = itm.DocTime,
                                EmpCode = itm.EmpCode,
                                FType = itm.FType,
                                SDate = itm.sDate,
                                Notes = itm.Notes,
                                Status = itm.Status,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpName = itm.EmpName,
                                FCreate = itm.FCreate,
                                FormName = itm.FormName,
                                FStep1 = itm.FStep1,
                                FStep2 = itm.FStep2,
                                FStep3 = itm.FStep3,
                                FStep4 = itm.FStep4,
                                FStep5 = itm.FStep5,
                                FStep6 = itm.FStep6,
                                FStep7 = itm.FStep7,
                                FStep8 = itm.FStep8,
                                Manag1 = itm.Manag1,
                                Manag2 = itm.Manag2,
                                Name = itm.Name,
                                Name2 = itm.Name2,
                                LoginUserName = itm.LoginUserName,
                                CNN = ConnectionStr,
                                SType1 = itm.SType1,
                                SType2 = itm.SType2,
                                SType3 = itm.SType3,
                                SType4 = itm.SType4,
                                SType5 = itm.SType5,
                                SType6 = itm.SType6,
                                SType7 = itm.SType7,
                                SType8 = itm.SType8,
                                TransferUser = itm.TransferUser,
                                Action1 = itm.Action1,
                                Action2 = itm.Action2,
                                Action3 = itm.Action3,
                                Action4 = itm.Action4,
                                Action5 = itm.Action5,
                                Action6 = itm.Action6,
                                Action7 = itm.Action7,
                                Action8 = itm.Action8                                 
                            }).FirstOrDefault();
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
        public List<veServices> GetAll0(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.veServicesGetAll(this.DocType, this.EmpCode);
                    return (from itm in result
                            select new veServices
                            {
                                DocType = itm.DocType,
                                DocNo = itm.DocNo,
                                DocDate = itm.DocDate,
                                DocTime = itm.DocTime,
                                EmpCode = itm.EmpCode,
                                FType = itm.FType,
                                SDate = itm.sDate,
                                Notes = itm.Notes,
                                Status = itm.Status,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpName = itm.EmpName,
                                FCreate = itm.FCreate,
                                FormName = itm.FormName,
                                FStep1 = itm.FStep1,
                                FStep2 = itm.FStep2,
                                FStep3 = itm.FStep3,
                                FStep4 = itm.FStep4,
                                FStep5 = itm.FStep5,
                                FStep6 = itm.FStep6,
                                FStep7 = itm.FStep7,
                                FStep8 = itm.FStep8,
                                Manag1 = itm.Manag1,
                                Manag2 = itm.Manag2,
                                Name = itm.Name,
                                Name2 = itm.Name2,
                                LoginUserName = itm.LoginUserName,
                                CNN = ConnectionStr,
                                SType1 = itm.SType1,
                                SType2 = itm.SType2,
                                SType3 = itm.SType3,
                                SType4 = itm.SType4,
                                SType5 = itm.SType5,
                                SType6 = itm.SType6,
                                SType7 = itm.SType7,
                                SType8 = itm.SType8,
                                TransferUser = itm.TransferUser,
                                Action1 = itm.Action1,
                                Action2 = itm.Action2,
                                Action3 = itm.Action3,
                                Action4 = itm.Action4,
                                Action5 = itm.Action5,
                                Action6 = itm.Action6,
                                Action7 = itm.Action7,
                                Action8 = itm.Action8
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
