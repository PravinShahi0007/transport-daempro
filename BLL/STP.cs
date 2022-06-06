using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class STP
    {
        public short Branch { get; set; }
        public short Ftype { get; set; }
        public int VouNo { get; set; }
        public short VouLoc { get; set; }
        public short FNo { get; set; }
        public string VouDate { get; set; }
        public System.Nullable<int> RefNo { get; set; }
        public System.Nullable<short> RefNoLoc { get; set; }
        public System.Nullable<short> RefType { get; set; }
        public System.Nullable<short> FNo2 { get; set; }
        public string Remark { get; set; }
        public string ITCode { get; set; }
        public string UnitCode { get; set; }
        public System.Nullable<double> Quan { get; set; }
        public System.Nullable<double> Quan2 { get; set; }
        public System.Nullable<double> Quan4 { get; set; }
        public System.Nullable<double> Price { get; set; }
        public System.Nullable<double> Bal { get; set; }
        public string CrCode { get; set; }
        public string DbCode { get; set; }
        public System.Nullable<double> ExpAmount { get; set; }
        public System.Nullable<double> ExpPer { get; set; }
        public string ExpRef { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public System.Nullable<short> InvType { get; set; }
        public string VouNo2 { 
            get {
                return this.VouLoc.ToString() + "/" + this.VouNo.ToString();
            }
        }

        public STP()
        {
            this.Branch = 1;
            this.Ftype = 0;
            this.VouNo = 0;
            this.VouLoc = 1;
            this.FNo = 1;
            this.VouDate = "";
            this.RefNo = 0;
            this.RefNoLoc = 1;
            this.RefType = 0;
            this.FNo2 = 1;
            this.Remark = "";
            this.ITCode = "";
            this.UnitCode = "-1";
            this.Quan = 0;
            this.Quan2 = 0;
            this.Quan4 = 0;
            this.Price = 0;
            this.Bal = 0;
            this.CrCode = "";
            this.DbCode = "";
            this.ExpAmount = 0;
            this.ExpPer = 0;
            this.ExpRef = "";
            this.UserName = "";
            this.UserDate = "";
            this.InvType = 0;
        }

        public List<STP> GetNotAgree(short myFNo, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.StpAgree(myFNo);
                    return (from itm in result
                            select new STP
                            {
                                Ftype = itm.fType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        

        /// <summary>
        /// Add Item in PTP Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.STPInsert(this.Branch,this.Ftype, this.VouNo, this.VouLoc, this.FNo, this.VouDate, this.RefNo, this.RefNoLoc,this.RefType,this.FNo2, this.Remark, this.ITCode, this.UnitCode, this.Quan,this.Quan2,this.Quan4, this.Price,this.Bal,this.CrCode,this.DbCode,this.ExpAmount,this.ExpPer,this.ExpRef, this.UserName, this.UserDate,this.InvType);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Voucher from STP Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.STPDelete(this.Branch,this.Ftype, this.VouNo, this.VouLoc);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select Vou from STP Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<STP> Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.STPGet(this.Branch,this.Ftype, this.VouNo, this.VouLoc);
                    return (from itm in result
                            select new STP
                            {
                                Branch = itm.Branch,
                                Ftype = itm.FType,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                FNo = itm.FNo,
                                VouDate = itm.VouDate,
                                RefNo = itm.RefNo,
                                RefNoLoc = itm.RefNoLoc,
                                RefType = itm.RefType,
                                FNo2 = itm.FNo2,
                                Remark = itm.Remark,
                                ITCode = itm.ITCode,
                                Quan = itm.Quan,
                                Quan2 = itm.Quan2,
                                Quan4 = itm.Quan4,
                                Price = itm.Price,
                                Bal = itm.Bal,
                                CrCode = itm.CrCode,
                                DbCode = itm.DbCode,
                                ExpAmount = itm.ExpAmount,
                                ExpPer = itm.ExpPer,
                                ExpRef = itm.ExpRef,
                                UnitCode = itm.UnitCode,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                InvType = itm.InvType
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select Vou from STP Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<STP> FindNoPrice(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.STPNoPrice();
                    return (from itm in result
                            select new STP
                            {
                                Branch = itm.Branch,
                                Ftype = itm.FType,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                FNo = itm.FNo,
                                VouDate = itm.VouDate,
                                RefNo = itm.RefNo,
                                RefNoLoc = itm.RefNoLoc,
                                RefType = itm.RefType,
                                FNo2 = itm.FNo2,
                                Remark = itm.Remark,
                                ITCode = itm.ITCode,
                                Quan = itm.Quan,
                                Quan2 = itm.Quan2,
                                Quan4 = itm.Quan4,
                                Price = itm.Price,
                                Bal = itm.Bal,
                                CrCode = itm.CrCode,
                                DbCode = itm.DbCode,
                                ExpAmount = itm.ExpAmount,
                                ExpPer = itm.ExpPer,
                                ExpRef = itm.ExpRef,
                                UnitCode = itm.UnitCode,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                InvType = itm.InvType
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all PReq center from PReq Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public Double GetItemCostPrice(Double Qty,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    double bal = 0;
                    double TotPrice = 0;
                    double CurQuan = 0;
                    double NetQuan = Qty;
                    Stock myStock = new Stock();
                    myStock.Branch = this.Branch;
                    myStock.Number = this.VouLoc;
                    myStock.Code = this.ITCode;
                    myStock = myStock.GetItem(ConnectionStr);
                    if(myStock != null)
                    {
                        bal = (double)(myStock.IOpen - myStock.ISale);
                        if (bal > 0)
                        {
                            Item myItem = new Item();
                            myItem.Branch = this.Branch;
                            myItem.ITCode = this.ITCode;
                            myItem = myItem.find(ConnectionStr);
                            if(myItem != null)
                            {
                                if (bal > Qty)
                                {
                                    return (double)myItem.ITCPrice;
                                }
                                else
                                {
                                    CurQuan = bal;
                                    TotPrice = bal * (double)myItem.ITCPrice;
                                    NetQuan = Qty - bal;
                                    bal = 0;
                                }
                            }
                        }                       
                    }

                    if (NetQuan > 0)
                    {
                        //List<STPCostPrice> myResult = new List<STPCostPrice>();
                        //var result = myContext.STPGetQty(this.Branch, this.VouLoc, this.ITCode);
                        //myResult =  (from itm in result
                        //        select new STPCostPrice
                        //        {
                        //            FType = itm.FType,
                        //            Quan = itm.FType == 501 ? itm.Quan : itm.Quan * -1,
                        //            Price = itm.Price
                        //        }).ToList();

                        List<STPCostPrice> myResult = new List<STPCostPrice>();
                        List<STPCostPrice> myResult2 = new List<STPCostPrice>();
                        var result = myContext.STPGetQty(this.Branch, this.VouLoc, this.ITCode);
                        myResult2 = (from itm in result
                                     //where itm.FType == 501
                                     select new STPCostPrice
                                     {
                                         FType = itm.FType,
                                         Quan = itm.Quan,
                                         VouNo = itm.VouNo,
                                         RefNo = itm.RefNo,
                                         Price = itm.Price
                                     }).ToList();

                        foreach (STPCostPrice itm in myResult2)
                        {
                            if (itm.FType == 502)
                            {
                                foreach (STPCostPrice sitm in myResult)
                                {
                                    if (sitm.VouNo == itm.RefNo)
                                    {
                                        sitm.Quan = sitm.Quan - itm.Quan;
                                        break;
                                    }
                                }
                                itm.Quan = 0;
                            }
                            else myResult.Add(itm);
                        }

                        foreach (STPCostPrice itm in myResult)
                        {
                            if (NetQuan > 0)
                            {
                                bal = bal + (double)itm.Quan;
                                if (bal > 0)
                                {
                                    if (bal >= NetQuan)
                                    {
                                        CurQuan += NetQuan;
                                        TotPrice += (double)(NetQuan * itm.Price);
                                        NetQuan = 0;
                                        bal = 0;
                                    }
                                    else
                                    {
                                        CurQuan += bal;
                                        TotPrice += (double)(bal * itm.Price);
                                        NetQuan -= bal;
                                        bal = 0;
                                    }
                                }
                            }
                            else break;
                        }
                    }
                    if (CurQuan > 0 && TotPrice > 0)
                    {
                        return Math.Round(TotPrice / CurQuan, 5);
                    }
                    else return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }


        public List<string> GetItemCostPrice2(Double Qty, Double PQty, string ConnectionStr)
        {
            try
            {
                List<string> items = new List<string>();
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    double bal = 0;
                    double TotPrice = 0;
                    double CurQuan = 0;
                    double NetQuan = Qty;
                    Stock myStock = new Stock();
                    myStock.Branch = this.Branch;
                    myStock.Number = this.VouLoc;
                    myStock.Code = this.ITCode;
                    myStock = myStock.GetItem(ConnectionStr);
                    if (myStock != null)
                    {
                        bal = (double)(myStock.IOpen - myStock.ISale - PQty);
                        if (bal > 0)
                        {
                            Item myItem = new Item();
                            myItem.Branch = this.Branch;
                            myItem.ITCode = this.ITCode;
                            myItem = myItem.find(ConnectionStr);
                            if (myItem != null)
                            {
                                if (bal > Qty)
                                {
                                    items.Add(myItem.ITCPrice.ToString() + "&" + Qty.ToString());
                                    return items;
                                }
                                else
                                {
                                    CurQuan = bal;
                                    TotPrice = bal * (double)myItem.ITCPrice;
                                    NetQuan = Qty - bal;
                                    items.Add(myItem.ITCPrice.ToString() + "&" + bal.ToString());
                                    bal = 0;                                    
                                }
                            }
                        }
                    }

                    if (NetQuan > 0)
                    {
                        List<STPCostPrice> myResult = new List<STPCostPrice>();
                        List<STPCostPrice> myResult2 = new List<STPCostPrice>();
                        var result = myContext.STPGetQty(this.Branch, this.VouLoc, this.ITCode);
                        myResult2 = (from itm in result
                                    //where itm.FType == 501
                                    select new STPCostPrice
                                    {
                                        FType = itm.FType,
                                        Quan = itm.Quan,
                                        VouNo = itm.VouNo,
                                        RefNo = itm.RefNo,
                                        Price = itm.Price
                                    }).ToList();

                        foreach (STPCostPrice itm in myResult2)
                        {
                            if (itm.FType == 502)
                            {
                                foreach (STPCostPrice sitm in myResult)
                                {
                                    if (sitm.VouNo == itm.RefNo && itm.Price == sitm.Price)
                                    {
                                        sitm.Quan = sitm.Quan - itm.Quan;
                                        break;
                                    }
                                }
                                itm.Quan = 0;
                            }
                            else myResult.Add(itm);
                        }


                        foreach (STPCostPrice itm in myResult)
                        {                            
                            if (NetQuan > 0)
                            {
                                bal = bal + (double)itm.Quan;
                                if (bal > 0)
                                {
                                    if (bal >= NetQuan)
                                    {
                                        CurQuan += NetQuan;
                                        TotPrice += (double)(NetQuan * itm.Price);
                                        items.Add(itm.Price.ToString() + "&" + NetQuan.ToString());
                                        NetQuan = 0;
                                        bal = 0;
                                        break;
                                    }
                                    else
                                    {
                                        CurQuan += bal;
                                        TotPrice += (double)(bal * itm.Price);
                                        items.Add(itm.Price.ToString() + "&" + bal.ToString());
                                        NetQuan -= bal;
                                        bal = 0;
                                    }
                                }
                            }
                            else break;
                        }
                    }
                    if (CurQuan > 0 && TotPrice > 0)
                    {
                        return items;
                    }
                    else return new List<string> { "0" };
                    
                }
            }
            catch (Exception)
            {
                return new List<string> { "0" };
            }
        }



        /// <summary>
        /// select all PReq center from PReq Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<STP> FindRef2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.STPFindRef(this.Branch, this.Ftype, this.RefNo, this.RefNoLoc, this.InvType).GroupBy(test => test.VouNo).Select(grp => grp.First()).ToList();
                    return (from itm in result
                            select new STP
                            {
                                Branch = itm.Branch,
                                Ftype = itm.FType,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                FNo = itm.FNo,
                                VouDate = itm.VouDate,
                                RefNo = itm.RefNo,
                                RefNoLoc = itm.RefNoLoc,
                                RefType = itm.RefType,
                                FNo2 = itm.FNo2,
                                Remark = itm.Remark,
                                ITCode = itm.ITCode,
                                Quan = itm.Quan,
                                Quan2 = itm.Quan2,
                                Quan4 = itm.Quan4,
                                Price = itm.Price,
                                Bal = itm.Bal,
                                CrCode = itm.CrCode,
                                DbCode = itm.DbCode,
                                ExpAmount = itm.ExpAmount,
                                ExpPer = itm.ExpPer,
                                ExpRef = itm.ExpRef,
                                UnitCode = itm.UnitCode,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                InvType = itm.InvType
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }




        /// <summary>
        /// select all PReq center from PReq Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<STP> FindRef(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.STPFindRef(this.Branch, this.Ftype, this.RefNo, this.RefNoLoc, this.InvType);
                    return (from itm in result
                            select new STP
                            {
                                Branch = itm.Branch,
                                Ftype = itm.FType,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                FNo = itm.FNo,
                                VouDate = itm.VouDate,
                                RefNo = itm.RefNo,
                                RefNoLoc = itm.RefNoLoc,
                                RefType = itm.RefType,
                                FNo2 = itm.FNo2,
                                Remark = itm.Remark,
                                ITCode = itm.ITCode,
                                Quan = itm.Quan,
                                Quan2 = itm.Quan2,
                                Quan4 = itm.Quan4,
                                Price = itm.Price,
                                Bal = itm.Bal,
                                CrCode = itm.CrCode,
                                DbCode = itm.DbCode,
                                ExpAmount = itm.ExpAmount,
                                ExpPer = itm.ExpPer,
                                ExpRef = itm.ExpRef,                                 
                                UnitCode = itm.UnitCode,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                InvType = itm.InvType
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all PReq center from PReq Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<vSTP> FindRef0(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vSTPFindRef(this.Branch, this.Ftype, this.RefNo, this.RefNoLoc, this.InvType);
                    return (from itm in result
                            select new vSTP
                            {
                                Branch = itm.Branch,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                FNo = itm.FNo,
                                VouDate = itm.VouDate,
                                RefNo = itm.RefNo,
                                RefNoLoc = itm.RefNoLoc,
                                RefType = itm.RefType,
                                FNo2 = itm.FNo2,
                                Remark = itm.Remark,
                                ITCode = itm.ITCode,
                                Quan = itm.Quan,
                                Quan2 = itm.Quan2,
                                Quan4 = itm.Quan4,
                                Price = itm.Price,
                                Bal = itm.Bal,
                                CrCode = itm.CrCode,
                                DbCode = itm.DbCode,
                                ExpAmount = itm.ExpAmount,
                                ExpPer = itm.ExpPer,
                                ExpRef = itm.ExpRef,
                                UnitCode = itm.UnitCode,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                InvType = itm.InvType,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                UnitName1 = itm.UnitName1,
                                UnitName2 = itm.UnitName2,
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
        /// select all PReq center from PReq Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<vSTP> Find2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vSTPGet(this.Branch,this.Ftype, this.VouNo, this.VouLoc);
                    return (from itm in result
                            select new vSTP
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                FNo = itm.FNo,
                                VouDate = itm.VouDate,
                                RefNo = itm.RefNo,
                                RefNoLoc = itm.RefNoLoc,
                                RefType = itm.RefType,
                                FNo2 = itm.FNo2,
                                Remark = itm.Remark,
                                ITCode = itm.ITCode,
                                Quan = itm.Quan,
                                Quan2 = itm.Quan2,
                                Quan4 = itm.Quan4,
                                Price = itm.Price,
                                Bal = itm.Bal,
                                CrCode = itm.CrCode,
                                DbCode = itm.DbCode,
                                ExpAmount = itm.ExpAmount,
                                ExpPer = itm.ExpPer,
                                ExpRef = itm.ExpRef,
                                UnitCode = itm.UnitCode,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                UnitName1 = itm.UnitName1,
                                UnitName2 = itm.UnitName2,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                InvType = itm.InvType                                 
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all PReq center from PReq Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<vSTP> GetStatement(string FDate, string EDate, string ICat, string ItemCard, int? Job, string CarNo,bool Purchase, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vSTPGetStatement(this.Branch, EDate, ICat, ItemCard, Job, CarNo,Purchase);
                    return (from itm in result
                          //  where (FDate != "" && DateTime.Parse(itm.VouDate) >= DateTime.Parse(FDate)) || FDate == ""
                            select new vSTP
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                FNo = itm.FNo,
                                VouDate = itm.VouDate,
                                RefNo = itm.RefNo,
                                RefNoLoc = itm.RefNoLoc,
                                RefType = itm.RefType,
                                FNo2 = itm.FNo2,
                                Remark = itm.Remark,
                                ITCode = itm.ITCode,
                                Quan = itm.Quan,
                                Quan2 = itm.Quan2,
                                Quan4 = itm.Quan4,
                                Price = itm.Price,
                                Bal = itm.Bal,
                                CrCode = itm.CrCode,
                                DbCode = itm.DbCode,
                                ExpAmount = itm.ExpAmount,
                                ExpPer = itm.ExpPer,
                                ExpRef = itm.ExpRef,
                                UnitCode = itm.UnitCode,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                UnitName1 = itm.UnitName1,
                                UnitName2 = itm.UnitName2,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                InvType = itm.InvType
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all PReq center from PReq Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<vSTP> Find3(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vSTPGet(this.Branch, this.Ftype, this.VouNo, this.VouLoc);
                    return (from itm in result
                            where itm.Quan - itm.Quan2 > 0
                            select new vSTP
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                FNo = itm.FNo,
                                VouDate = itm.VouDate,
                                RefNo = itm.RefNo,
                                RefNoLoc = itm.RefNoLoc,
                                RefType = itm.RefType,
                                FNo2 = itm.FNo2,
                                Remark = itm.Remark,
                                ITCode = itm.ITCode,
                                Quan = itm.Quan,
                                Quan2 = itm.Quan2,
                                Quan4 = itm.Quan4,
                                Price = itm.Price,
                                Bal = itm.Bal,
                                CrCode = itm.CrCode,
                                DbCode = itm.DbCode,
                                ExpAmount = itm.ExpAmount,
                                ExpPer = itm.ExpPer,
                                ExpRef = itm.ExpRef,
                                UnitCode = itm.UnitCode,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                UnitName1 = itm.UnitName1,
                                UnitName2 = itm.UnitName2,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                InvType = itm.InvType
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Get New Code for PReq Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public int? GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.STPMaxCode(this.Branch,this.Ftype, this.VouLoc);
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
    public class STPCostPrice
    {
        public short FType { get; set; }
        public int VouNo { get; set; }
        public short VouLoc { get; set; }
        public System.Nullable<double> Quan { get; set; }
        public System.Nullable<double> Price { get; set; }
        public int? RefNo { get; set; }
        public short? RefNoLoc { get; set; }
    }


    [Serializable]
    public class vSTP
    {
        public bool? Status { get; set; }
        public short Branch { get; set; }
        public short FType { get; set; }
        public int VouNo { get; set; }
        public short VouLoc { get; set; }
        public short FNo { get; set; }
        public string VouDate { get; set; }
        public System.Nullable<int> RefNo { get; set; }
        public System.Nullable<short> RefNoLoc { get; set; }
        public System.Nullable<short> RefType { get; set; }
        public System.Nullable<short> FNo2 { get; set; }
        public string Remark { get; set; }
        public string ITCode { get; set; }
        public string ITName1 { get; set; }
        public string ITName2 { get; set; }
        public string UnitCode { get; set; }
        public string UnitName1 { get; set; }
        public string UnitName2 { get; set; }
        public System.Nullable<double> Quan { get; set; }
        public System.Nullable<double> Quan2 { get; set; }
        public System.Nullable<double> Quan4 { get; set; }
        public System.Nullable<double> Price { get; set; }
        public System.Nullable<double> Bal { get; set; }
        public string CrCode { get; set; }
        public string DbCode { get; set; }
        public System.Nullable<double> ExpAmount { get; set; }
        public System.Nullable<double> ExpPer { get; set; }
        public string ExpRef { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public System.Nullable<short> InvType { get; set; }
        public double Amount
        {
            get
            {
                return (double)this.Price * (double)this.Quan;
            }
        }
        public double Bal2
        {
            get
            {
                return (double)Quan + (double)Bal;
            }
        }


        public vSTP()
        {
            this.Status = false;
            this.Branch = 1;
            this.FType = 0;
            this.VouNo = 0;
            this.VouLoc = 1;
            this.FNo = 1;
            this.VouDate = "";
            this.RefNo = 0;
            this.RefNoLoc = 1;
            this.RefType = 0;
            this.FNo2 = 1;
            this.Remark = "";
            this.ITCode = "";
            this.UnitCode = "-1";
            this.Quan = 0;
            this.Quan2 = 0;
            this.Quan4 = 0;
            this.Price = 0;
            this.Bal = 0;
            this.CrCode = "";
            this.DbCode = "";
            this.ExpAmount = 0;
            this.ExpPer = 0;
            this.ExpRef = "";
            this.ITName1 = "";
            this.ITName2 = "";
            this.UnitName1 = "";
            this.UnitName2 = "";
            this.UserName = "";
            this.UserDate = "";
            this.InvType = 0;
        }
    }
}
