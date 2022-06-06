using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class SalOP
    {
        public short Year1 { get; set; }
        public short Month1 { get; set; }
        public int Section { get; set; }
        public int EmpCode { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public System.Nullable<double> Abs0 { get; set; }
        public System.Nullable<double> Abs1 { get; set; }
        public System.Nullable<double> Abs2 { get; set; }
        public System.Nullable<double> Abs3 { get; set; }
        public System.Nullable<double> Abs4 { get; set; }
        public System.Nullable<double> Abs5 { get; set; }
        public System.Nullable<double> Over0 { get; set; }
        public System.Nullable<double> Over1 { get; set; }
        public System.Nullable<double> Over2 { get; set; }
        public System.Nullable<double> Over3 { get; set; }
        public System.Nullable<double> Pen0 { get; set; }
        public string cnn { get; set; }
        public string Remark { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public System.Nullable<double> Ded03 { get; set; }
        public System.Nullable<double> Add0 { get; set; }
        public System.Nullable<double> Ded3 { get; set; }
        public System.Nullable<double> Net0 { 
            get
            {
                return this.Abs1 + this.Abs2;
            }
       }
        public System.Nullable<double> Net00
        {
            get
            {
                if(this.Add0 == 0) return this.Net0 - this.Abs3 - this.Ded03 - this.Ded3;
                else return this.Add0 - this.Abs3 - this.Ded03 - this.Ded3;
            }
        }
        public System.Nullable<double> Per0
        {
            get
            {
                if (this.Net0 == 0) return 0;
                else return Math.Round((double)(((this.Ded03 + this.Abs3) / this.Net0) * 100),2);
            }
        }
        public string MakeDiv
        {
            get
            {
                string vStr = @"<div class='containerStep'>
                                  <ul class='progressbar'>
                                  <li class='active'>" + this.UserName + @"<br/>" + this.UserDate + @"</li>";

//                 if (this.TransferUser != "" && this.TransferUser == this.UserName) 
//                     vStr = @"<div class='containerStep'>
//                                  <ul class='progressbar'>
//                                  <li class='current'>" + this.UserName + @"<br/>" + this.UserDate + @"</li>";


                    Agreement myAgree = new Agreement();
                    myAgree.FType = 400;
                    myAgree.LocType = this.Year1;
                    myAgree.LocNumber = this.Month1;
                    myAgree.Number = this.Section;

                    int i = 1;
                    foreach (Agreement itm in myAgree.Find(this.cnn))
                    {
                        i++;
                       if (itm.Agree == 1)
                           vStr += @"<li class='active'>" + itm.AgreeUser + @"<br/>" + itm.AgreeUserDate + @"</li>";
                       else if (itm.Agree == 2) vStr += @"<li class='refuse'>" + itm.AgreeUser + @"<br/>" + itm.AgreeUserDate + @"</li>";
                    }

                    if (i < 8)
                    {
                        doAgree mydAgree = new doAgree();
                        mydAgree.FType = 400;
                        mydAgree.LocType = this.Year1;
                        mydAgree.LocNumber = this.Month1;
                        mydAgree.Number = this.Section;
                        mydAgree.FNo = (short)(i);
                        mydAgree = mydAgree.FindFNo(this.cnn);
                        if (mydAgree != null) vStr += @"<li class='current'>" + (mydAgree.UserName + " " + mydAgree.UserName2 + " " +mydAgree.UserGroup) + @"</li>";
                    }

            /*
                if(this.FStep1 != "-1") 
                {
                    Agreement myAgree
                    if(this.Status == 0 )                    
                    {
                        vStr += @"<li class='current'>" + (this.FStep1 == "1" ? this.Manag1 : this.FStep1)  + @"</li>";                    
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
                            else if (vService.Agree == 2) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
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
                            else if (vService.Agree == 2) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
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
                            else if (vService.Agree == 2) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
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
                            else if (vService.Agree == 2) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
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
                            else if (vService.Agree == 2) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
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
                            else if (vService.Agree == 2) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
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
                            else if (vService.Agree == 2) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
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
                            else if (vService.Agree == 2) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
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
                            else if (vService.Agree == 2) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
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
                            else if (vService.Agree == 2) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
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
                            else if (vService.Agree == 2) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
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
                            else if (vService.Agree == 2) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
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
                            else if (vService.Agree == 2) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
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
                            else if (vService.Agree == 2) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
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
                            else if (vService.Agree == 2) vStr += @"<li class='transfer'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                            else vStr += @"<li class='refuse'>" + vService.AgreeUser + @"<br/>" + vService.AgreeUserDate + @"</li>";
                        }
                        else
                        {
                            if (this.Status == -1) vStr += @"<li>" + (this.FStep8 == "1" ? this.Manag1 : this.FStep8) + @"</li>";
                            else vStr += @"<li class='active'>" + (this.FStep8 == "1" ? this.Manag1 : this.FStep8) + @"</li>";
                        }
                    }                        
                }
                 */
                vStr += @"</ul></div>";

                return vStr;
            }
        }



        public SalOP()
        {
            this.Year1 = 0;
            this.Month1 = 0;
            this.Section = 0;
            this.EmpCode = 0;
            this.Name = "";
            this.Name2 = "";
            this.Abs0 = 0;
            this.Abs1 = 0;
            this.Abs2 = 0;
            this.Abs3 = 0;
            this.Abs4 = 0;
            this.Abs5 = 0;
            this.Over0 = 0;
            this.Over1 = 0;
            this.Over2 = 0;
            this.Over3 = 0;
            this.Pen0 = 0;
            this.Remark = "";
            this.UserName = "";
            this.UserDate = "";
            this.Ded03 = 0;
            this.Ded3 = 0;
            this.Add0 = 0;
            this.cnn = "";
        }
        
        /// <summary>
        /// Add Area in Area Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.SalOPAdd(this.Year1, this.Month1, this.Section, this.EmpCode, this.Abs0, this.Abs1, this.Abs2,this.Abs3, this.Abs4, this.Abs5,this.Over0, this.Over1, this.Over2, this.Over3, this.Pen0,this.Remark,this.UserName,this.UserDate,this.Ded03);
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
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.SalOPDelete(this.Year1, this.Month1, this.Section);
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
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.SalOPUpdate(this.Year1, this.Month1, this.Section, this.EmpCode, this.Abs0, this.Abs1, this.Abs2, this.Abs3, this.Abs4,this.Abs5, this.Over0, this.Over1, this.Over2, this.Over3, this.Pen0, this.Remark,this.UserName,this.UserDate,this.Ded03);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        
        /// <summary>
        /// select all Account center from Area Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<SalOP> GetDep(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vSalOPGetMonthDep(this.Year1, this.Month1, this.Section);
                    return (from itm in result
                            select new SalOP
                            {
                                 EmpCode = itm.EmpCode,
                                 Name = itm.Name,
                                 Name2 = itm.Name2,
                                 Month1 = itm.Month1,
                                 Abs0 = itm.Abs0,
                                 Abs1 = itm.Abs1,
                                 Abs2 = itm.Abs2,
                                 Abs3 = itm.Abs3,
                                 Abs4 = itm.Abs4,
                                 Abs5 = itm.Abs5,
                                 Over0 = itm.Over0,
                                 Over1 = itm.Over1,
                                 Over2 = itm.Over2,
                                 Over3 = itm.Over3,
                                 Pen0 = itm.Pen0,
                                 Remark = itm.Remark,
                                 Section = itm.Section,
                                 Year1 = itm.Year1,
                                 UserName = itm.UserName,
                                 UserDate = itm.UserDate,
                                 Ded03 = itm.Ded03,
                                 cnn = ConnectionStr
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Account center from Area Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<SalOP> GetMonth(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vSalOPGetMonth(this.Year1, this.Month1);
                    return (from itm in result
                            select new SalOP
                            {
                                EmpCode = itm.EmpCode,
                                Name = itm.Name,
                                Name2 = itm.Name2,
                                Month1 = itm.Month1,
                                Abs0 = itm.Abs0,
                                Abs1 = itm.Abs1,
                                Abs2 = itm.Abs2,
                                Abs3 = itm.Abs3,
                                Abs4 = itm.Abs4,
                                Abs5 = itm.Abs5,
                                Over0 = itm.Over0,
                                Over1 = itm.Over1,
                                Over2 = itm.Over2,
                                Over3 = itm.Over3,
                                Pen0 = itm.Pen0,
                                Remark = itm.Remark,
                                Section = itm.Section,
                                Year1 = itm.Year1,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Ded03 = itm.Ded03,
                                cnn = ConnectionStr
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Account center from Area Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<SalOP> GetMonth2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vSalOPGetMonth2(this.Year1, this.Month1);
                    return (from itm in result
                            select new SalOP
                            {
                                Name = itm.Name1,
                                Month1 = itm.Month1,
                                Section = itm.Section,
                                Year1 = itm.Year1,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                cnn = ConnectionStr
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Account center from Area Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<SalOP> GetEmpYear(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.SalOPGetYearEmp(this.Year1, this.EmpCode);
                    return (from itm in result
                            select new SalOP
                            {
                                EmpCode = itm.EmpCode,
                                Month1 = itm.Month1,
                                Abs0 = itm.Abs0,
                                Abs1 = itm.Abs1,
                                Abs2 = itm.Abs2,
                                Abs3 = itm.Abs3,
                                Abs4 = itm.Abs4,
                                Abs5 = itm.Abs5,
                                Over0 = itm.Over0,
                                Over1 = itm.Over1,
                                Over2 = itm.Over2,
                                Over3 = itm.Over3,
                                Pen0 = itm.Pen0,
                                Remark = itm.Remark,
                                Section = itm.Section,
                                Year1 = itm.Year1,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Ded03 = itm.Ded03
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Account center from Area Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public SalOP GetMonthEmpCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.SalOPGetMonthEmp(this.Year1, this.Month1, this.EmpCode);
                    return (from itm in result
                            select new SalOP
                            {
                                EmpCode = itm.EmpCode,
                                Month1 = itm.Month1,
                                Abs0 = itm.Abs0,
                                Abs1 = itm.Abs1,
                                Abs2 = itm.Abs2,
                                Abs3 = itm.Abs3,
                                Abs4 = itm.Abs4,
                                Abs5 = itm.Abs5,
                                Over0 = itm.Over0,
                                Over1 = itm.Over1,
                                Over2 = itm.Over2,
                                Over3 = itm.Over3,
                                Pen0 = itm.Pen0,
                                Remark = itm.Remark,
                                Section = itm.Section,
                                Year1 = itm.Year1,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Ded03 = itm.Ded03
                            }
                            ).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}



