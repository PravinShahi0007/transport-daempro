using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class EndPeriodRep
    {
        public int TASK { get; set; }
        public short FNo { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public System.Nullable<bool> Details { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string Add3 { get; set; }
        public string Add4 { get; set; }
        public string Add5 { get; set; }
        public string Add6 { get; set; }
        public string Add7 { get; set; }
        public string Add8 { get; set; }
        public string Add9 { get; set; }
        public string Add10 { get; set; }
        public string Sub1 { get; set; }
        public string Sub2 { get; set; }
        public string Sub3 { get; set; }
        public string Sub4 { get; set; }
        public string Sub5 { get; set; }
        public string Sub6 { get; set; }
        public string Sub7 { get; set; }
        public string Sub8 { get; set; }
        public string Sub9 { get; set; }
        public string Sub10 { get; set; }
        public string AddCost1 { get; set; }
        public string AddCost2 { get; set; }
        public string AddCost3 { get; set; }
        public string AddCost4 { get; set; }
        public string AddCost5 { get; set; }
        public string AddCost6 { get; set; }
        public string AddCost7 { get; set; }
        public string AddCost8 { get; set; }
        public string AddCost9 { get; set; }
        public string AddCost10 { get; set; }
        public string SubCost1 { get; set; }
        public string SubCost2 { get; set; }
        public string SubCost3 { get; set; }
        public string SubCost4 { get; set; }
        public string SubCost5 { get; set; }


        /// <summary>
        /// select all Account from Acc Table
        /// </summary>
        /// <returns>List of Account or null if Fail</returns>
        public List<Acc1> GetBalanceSheet(string ConnectionStr, bool CheckPeriod, string FDate, string EDate, string AreaNo , string StoreNo)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.EndPeriodRepGet(1);
                    List<EndPeriodRep> rep = new List<EndPeriodRep>();
                    rep = (from itm in result
                            select new EndPeriodRep
                            {
                               TASK = itm.TASK,
                               FNo = itm.FNo,
                               Name1 = itm.Name1,
                               Name2 = itm.Name2,
                               Add1 = itm.Add1,
                               Add2 = itm.Add2,
                               Add3 = itm.Add3,
                               Add4 = itm.Add4,
                               Add5 = itm.Add5,
                               Add6 = itm.Add6,
                               Add7 = itm.Add7,
                               Add8 = itm.Add8,
                               Add9 = itm.Add9,
                               Add10 = itm.Add10,
                               Sub1 = itm.Sub1,
                               Sub2 = itm.Sub2,
                               Sub3 = itm.Sub3,
                               Sub4 = itm.Sub4,
                               Sub5 = itm.Sub5,
                               Sub6 = itm.Sub6,
                               Sub7 = itm.Sub7,
                               Sub8 = itm.Sub8,
                               Sub9 = itm.Sub9,
                               Sub10 = itm.Sub10,
                               Details = itm.Details,
                               AddCost1 = itm.AddCost1,
                               AddCost2 = itm.AddCost2,
                               AddCost3 = itm.AddCost3,
                               AddCost4 = itm.AddCost4,
                               AddCost5 = itm.AddCost5,
                               AddCost6 = itm.AddCost6,
                               AddCost7 = itm.AddCost7,
                               AddCost8 = itm.AddCost8,
                               AddCost9 = itm.AddCost9,
                               AddCost10 = itm.AddCost10,
                               SubCost1 = itm.SubCost1,
                               SubCost2 = itm.SubCost2,
                               SubCost3 = itm.SubCost3,
                               SubCost4 = itm.SubCost4,
                               SubCost5 = itm.SubCost5                              
                            }).ToList();

                    PeriodAcc pa = new PeriodAcc();
                    List<PeriodAcc> lp = new List<PeriodAcc>();
                    if (!CheckPeriod)
                    {
                        lp = pa.GetPeriod(1, FDate, EDate, ConnectionStr);
                    }
                    List<Acc> lacc = new List<Acc>();
                    Acc myacc = new Acc();
                    myacc.Branch = 1;
                    lacc = (from itm in myacc.Getall(ConnectionStr)
                              select new Acc
                              {
                                  Branch = itm.Branch,
                                  Code = itm.Code,
                                  FCode = itm.FCode,
                                  MCode = itm.MCode,
                                  FLevel = itm.FLevel,
                                  Name1 = itm.Name1,
                                  Name2 = itm.Name2,
                                  DAcc = CheckPeriod ? itm.DAcc : 0,
                                  CAcc = CheckPeriod ? itm.CAcc : 0,
                                  MDAcc = itm.MDAcc,
                                  MCAcc = itm.MCAcc,
                                  TDAcc = itm.TDAcc,
                                  TCAcc = itm.TCAcc,
                                  ODAcc = CheckPeriod ? itm.ODAcc:0,
                                  OCAcc = CheckPeriod ? itm.OCAcc:0,
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
                                  FUpdate = itm.FUpdate
                              }).ToList();

                    if (!CheckPeriod)
                    {
                        foreach (PeriodAcc itm in lp)
                        {
                            if (!string.IsNullOrEmpty(itm.DbCode))
                            {
                                if (itm.DbCode != "-1")
                                {
                                    foreach (Acc myAcc in lacc)
                                    {
                                        if (myAcc.Code == itm.DbCode.Substring(0, 1))
                                        {
                                            myAcc.ODAcc += itm.OpenAmount;
                                            myAcc.DAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.DbCode.Substring(0, 2))
                                        {
                                            myAcc.ODAcc += itm.OpenAmount;
                                            myAcc.DAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.DbCode.Substring(0, 4))
                                        {
                                            myAcc.ODAcc += itm.OpenAmount;
                                            myAcc.DAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.DbCode.Substring(0, 6))
                                        {
                                            myAcc.ODAcc += itm.OpenAmount;
                                            myAcc.DAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.DbCode)
                                        {
                                            myAcc.ODAcc += itm.OpenAmount;
                                            myAcc.DAcc += itm.Amount;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (Acc myAcc in lacc)
                                {
                                    if (itm.CrCode != "-1")
                                    {
                                        if (myAcc.Code == itm.CrCode.Substring(0, 1))
                                        {
                                            myAcc.OCAcc += itm.OpenAmount;
                                            myAcc.CAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.CrCode.Substring(0, 2))
                                        {
                                            myAcc.OCAcc += itm.OpenAmount;
                                            myAcc.CAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.CrCode.Substring(0, 4))
                                        {
                                            myAcc.OCAcc += itm.OpenAmount;
                                            myAcc.CAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.CrCode.Substring(0, 6))
                                        {
                                            myAcc.OCAcc += itm.OpenAmount;
                                            myAcc.CAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.CrCode)
                                        {
                                            myAcc.OCAcc += itm.OpenAmount;
                                            myAcc.CAcc += itm.Amount;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    List<FixedAsset> lf = new List<FixedAsset>();
                    myacc = new Acc();
                    myacc.Branch = 1;
                    lf = myacc.GetFixedAsset(ConnectionStr, FDate, EDate);

                    double pc = setValue((from eitm in lacc
                                          where eitm.Code == "220301"
                                          select eitm.Bal).FirstOrDefault()) * -1;

                    double pcc = setValue((from eitm in lacc
                                          where eitm.Code == "220402"
                                          select eitm.Bal).FirstOrDefault()) * -1;                       

                    List<Acc1> myResult = new List<Acc1>();
                    double Bal = 0;
                    string HRef = "";
                    foreach (EndPeriodRep itm in rep)
                    {
                        if (string.IsNullOrEmpty(itm.Add1) && string.IsNullOrEmpty(itm.Add2) && string.IsNullOrEmpty(itm.Add3) && string.IsNullOrEmpty(itm.Add4) && string.IsNullOrEmpty(itm.Add5) && string.IsNullOrEmpty(itm.Add6) &&
                            string.IsNullOrEmpty(itm.Add7) && string.IsNullOrEmpty(itm.Add8) && string.IsNullOrEmpty(itm.Add9) && string.IsNullOrEmpty(itm.Add10) && string.IsNullOrEmpty(itm.Sub1) && string.IsNullOrEmpty(itm.Sub2) && string.IsNullOrEmpty(itm.Sub3) &&
                            string.IsNullOrEmpty(itm.Sub4) && string.IsNullOrEmpty(itm.Sub5))
                        {
                            myResult.Add(new Acc1
                            {     
                                Branch = itm.FNo,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                FCode = ""
                            });
                        }
                        else
                        {
                            HRef = "";
                            if (itm.Add1 == "DIV")
                            {
                                myResult.Add(new Acc1
                                {
                                    Branch = itm.FNo,
                                    Name1 = itm.Name1,
                                    Name2 = itm.Name2,
                                    FType = "______________",
                                    FCode = ""
                                });

                            }
                            else if (itm.Add1 == "DIV2")
                            {
                                myResult.Add(new Acc1
                                {
                                    Branch = itm.FNo,
                                    Name1 = itm.Name1,
                                    Name2 = itm.Name2,
                                    FType = "══════════",
                                    FCode = ""
                                });
                            }
                            else
                            {
                                Bal = 0;
                                if (itm.Add1 == "FIX")
                                {
                                    Bal += setValue((from eitm in lf
                                            select eitm.Bal).Sum());
                                    if ((bool)itm.Details && Bal != 0)
                                    {                                        
                                        HRef = "WebFixedAsset.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FDate=" + FDate + "&EDate=" + EDate;
                                    }
                                }
                                else if (itm.Add1.StartsWith("PC"))
                                {
                                    if (pcc > 0) Bal += pc;
                                    else
                                    {
                                        double ps = 12 * double.Parse(itm.Add1.Substring(2));

                                        if (ps > pc) Bal += pc;
                                        else Bal += ps;

                                    }

                                }
                                else if (itm.Add1 == "ZAKA")
                                {
                                    double x = 0;
                                    //setValue((from eitm in lacc
                                    //                        where eitm.Code == "220304002"
                                    //                        select eitm.CAcc).FirstOrDefault());
                                    Bal += (x == 0 ? setValue((from eitm in lacc
                                                               where eitm.Code == "220304002"
                                                               select eitm.Bal).FirstOrDefault()) * -1 : x);
                                }
                                else if (!string.IsNullOrEmpty(itm.Add1))
                                {
                                    Bal += setValue((from eitm in lacc
                                            where eitm.Code == itm.Add1
                                            select eitm.Bal).FirstOrDefault()) * (itm.Add1.StartsWith("2") ? -1 : 1);

                                }
                                if (!string.IsNullOrEmpty(itm.Add2))
                                {
                                    if (itm.Add2 == "ZAKA")
                                    {
                                        double x = 0;
                                        //setValue((from eitm in lacc
                                        //                        where eitm.Code == "220304002"
                                        //                        select eitm.CAcc).FirstOrDefault());
                                        Bal += (x == 0 ? setValue((from eitm in lacc
                                                                   where eitm.Code == "220304002"
                                                                   select eitm.Bal).FirstOrDefault()) * -1 : x);
                                    }
                                    else
                                    {
                                        Bal += setValue((from eitm in lacc
                                                         where eitm.Code == itm.Add2
                                                         select eitm.Bal).FirstOrDefault()) * (itm.Add2.StartsWith("2") ? -1 : 1);
                                    }

                                }
                                if (!string.IsNullOrEmpty(itm.Add3))
                                {
                                    Bal += setValue((from eitm in lacc
                                            where eitm.Code == itm.Add3
                                            select eitm.Bal).FirstOrDefault()) * (itm.Add3.StartsWith("2") ? -1 : 1);

                                }
                                if (!string.IsNullOrEmpty(itm.Add4))
                                {
                                    Bal += setValue((from eitm in lacc
                                            where eitm.Code == itm.Add4
                                                     select eitm.Bal).FirstOrDefault()) * (itm.Add4.StartsWith("2") ? -1 : 1);

                                }
                                if (!string.IsNullOrEmpty(itm.Add5))
                                {
                                    Bal += setValue((from eitm in lacc
                                            where eitm.Code == itm.Add5
                                                 select eitm.Bal).FirstOrDefault()) * (itm.Add5.StartsWith("2") ? -1 : 1);

                                }
                                if (!string.IsNullOrEmpty(itm.Add6))
                                {
                                    Bal += setValue((from eitm in lacc
                                            where eitm.Code == itm.Add6
                                                select eitm.Bal).FirstOrDefault()) * (itm.Add6.StartsWith("2") ? -1 : 1);

                                }
                                if (!string.IsNullOrEmpty(itm.Add7))
                                {
                                    Bal += setValue((from eitm in lacc
                                            where eitm.Code == itm.Add7
                                                     select eitm.Bal).FirstOrDefault()) * (itm.Add7.StartsWith("2") ? -1 : 1);

                                }
                                if (!string.IsNullOrEmpty(itm.Add8))
                                {
                                    Bal += setValue((from eitm in lacc
                                            where eitm.Code == itm.Add8
                                                     select eitm.Bal).FirstOrDefault()) * (itm.Add8.StartsWith("2") ? -1 : 1);

                                }
                                if (!string.IsNullOrEmpty(itm.Add9))
                                {
                                    Bal += setValue((from eitm in lacc
                                                     where eitm.Code == itm.Add9
                                                     select eitm.Bal).FirstOrDefault()) * (itm.Add9.StartsWith("2") ? -1 : 1);

                                }
                                if (!string.IsNullOrEmpty(itm.Add10))
                                {
                                    Bal += setValue((from eitm in lacc
                                                     where eitm.Code == itm.Add10
                                                     select eitm.Bal).FirstOrDefault()) * (itm.Add10.StartsWith("2") ? -1 : 1);

                                }
                                if (itm.Sub1.StartsWith("PC"))
                                {
                                    if (pcc == 0)
                                    {
                                        double ps = 12 * double.Parse(itm.Sub1.Substring(2));
                                        if (ps > pc) Bal -= pc;
                                        else Bal -= ps;
                                    }
                                }
                                else if (!string.IsNullOrEmpty(itm.Sub1))
                                {
                                    Bal -= setValue((from eitm in lacc
                                                     where eitm.Code == itm.Sub1
                                                     select eitm.Bal).FirstOrDefault());

                                }
                                if (!string.IsNullOrEmpty(itm.Sub2))
                                {
                                    Bal -= setValue((from eitm in lacc
                                            where eitm.Code == itm.Sub2
                                            select eitm.Bal).FirstOrDefault());

                                }
                                if (!string.IsNullOrEmpty(itm.Sub3))
                                {
                                    Bal -= (from eitm in lacc
                                            where eitm.Code == itm.Sub3
                                            select eitm.Bal).FirstOrDefault();

                                }
                                if (!string.IsNullOrEmpty(itm.Sub4))
                                {
                                    Bal -= (from eitm in lacc
                                            where eitm.Code == itm.Sub4
                                            select eitm.Bal).FirstOrDefault();

                                }
                                if (!string.IsNullOrEmpty(itm.Sub5))
                                {
                                    Bal -= (from eitm in lacc
                                            where eitm.Code == itm.Sub5
                                            select eitm.Bal).FirstOrDefault() * (itm.Sub5.StartsWith("2") ? -1 : 1);

                                }

                                if (Bal != 0)
                                {
                                    if ((bool)itm.Details && HRef=="")
                                    {
                                        HRef = "WebBalanceSheet.aspx?Task=1&FNo="+ itm.FNo.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FDate=" + FDate + "&EDate=" + EDate;
                                    }

                                    myResult.Add(new Acc1
                                    {
                                        Branch = itm.FNo,
                                        Name1 = itm.Name1,
                                        Name2 = itm.Name2,
                                        FCode = HRef,
                                        FType = string.Format("{0:N0}", Bal)
                                    });
                                }
                            }

                        }

                    }
                    return myResult;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public double setValue(double? x)
        {
            if (x == null) return 0;
            else return (double)x;
        }

        /// <summary>
        /// select all Account from Acc Table
        /// </summary>
        /// <returns>List of Account or null if Fail</returns>
        public List<Acc1> GetBalanceSheetDetails(string ConnectionStr, bool CheckPeriod, string FDate, string EDate, string Task, string FNo)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.EndPeriodRepGet(1);
                    EndPeriodRep rep = new EndPeriodRep();
                    rep = (from itm in result
                           where itm.FNo == short.Parse(FNo)
                           select new EndPeriodRep
                           {
                               TASK = itm.TASK,
                               FNo = itm.FNo,
                               Name1 = itm.Name1,
                               Name2 = itm.Name2,
                               Add1 = itm.Add1,
                               Add2 = itm.Add2,
                               Add3 = itm.Add3,
                               Add4 = itm.Add4,
                               Add5 = itm.Add5,
                               Add6 = itm.Add6,
                               Add7 = itm.Add7,
                               Add8 = itm.Add8,
                               Add9 = itm.Add9,
                               Add10 = itm.Add10,
                               Sub1 = itm.Sub1,
                               Sub2 = itm.Sub2,
                               Sub3 = itm.Sub3,
                               Sub4 = itm.Sub4,
                               Sub5 = itm.Sub5,
                               Details = itm.Details,
                               AddCost1 = itm.AddCost1,
                               AddCost2 = itm.AddCost2,
                               AddCost3 = itm.AddCost3,
                               AddCost4 = itm.AddCost4,
                               AddCost5 = itm.AddCost5,
                               AddCost6 = itm.AddCost6,
                               AddCost7 = itm.AddCost7,
                               AddCost8 = itm.AddCost8,
                               AddCost9 = itm.AddCost9,
                               AddCost10 = itm.AddCost10,
                               SubCost1 = itm.SubCost1,
                               SubCost2 = itm.SubCost2,
                               SubCost3 = itm.SubCost3,
                               SubCost4 = itm.SubCost4,
                               SubCost5 = itm.SubCost5
                           }).FirstOrDefault();

                    PeriodAcc pa = new PeriodAcc();
                    List<PeriodAcc> lp = new List<PeriodAcc>();
                    if (!CheckPeriod)
                    {
                        lp = pa.GetPeriod(1, FDate, EDate, ConnectionStr);
                    }
                    List<Acc> lacc = new List<Acc>();
                    Acc myacc = new Acc();
                    myacc.Branch = 1;
                    lacc = (from itm in myacc.Getall(ConnectionStr)
                            select new Acc
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                FCode = itm.FCode,
                                MCode = itm.MCode,
                                FLevel = itm.FLevel,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                DAcc = CheckPeriod ? itm.DAcc : 0,
                                CAcc = CheckPeriod ? itm.CAcc : 0,
                                MDAcc = itm.MDAcc,
                                MCAcc = itm.MCAcc,
                                TDAcc = itm.TDAcc,
                                TCAcc = itm.TCAcc,
                                ODAcc = CheckPeriod ? itm.ODAcc : 0,
                                OCAcc = CheckPeriod ? itm.OCAcc : 0,
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
                                FUpdate = itm.FUpdate
                            }).ToList();

                    if (!CheckPeriod)
                    {
                        foreach (PeriodAcc itm in lp)
                        {
                            if (!string.IsNullOrEmpty(itm.DbCode))
                            {
                                if (itm.DbCode != "-1")
                                {
                                    foreach (Acc myAcc in lacc)
                                    {
                                        if (myAcc.Code == itm.DbCode.Substring(0, 1))
                                        {
                                            myAcc.ODAcc += itm.OpenAmount;
                                            myAcc.DAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.DbCode.Substring(0, 2))
                                        {
                                            myAcc.ODAcc += itm.OpenAmount;
                                            myAcc.DAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.DbCode.Substring(0, 4))
                                        {
                                            myAcc.ODAcc += itm.OpenAmount;
                                            myAcc.DAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.DbCode.Substring(0, 6))
                                        {
                                            myAcc.ODAcc += itm.OpenAmount;
                                            myAcc.DAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.DbCode)
                                        {
                                            myAcc.ODAcc += itm.OpenAmount;
                                            myAcc.DAcc += itm.Amount;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (Acc myAcc in lacc)
                                {
                                    if (itm.CrCode != "-1")
                                    {
                                        if (myAcc.Code == itm.CrCode.Substring(0, 1))
                                        {
                                            myAcc.OCAcc += itm.OpenAmount;
                                            myAcc.CAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.CrCode.Substring(0, 2))
                                        {
                                            myAcc.OCAcc += itm.OpenAmount;
                                            myAcc.CAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.CrCode.Substring(0, 4))
                                        {
                                            myAcc.OCAcc += itm.OpenAmount;
                                            myAcc.CAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.CrCode.Substring(0, 6))
                                        {
                                            myAcc.OCAcc += itm.OpenAmount;
                                            myAcc.CAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.CrCode)
                                        {
                                            myAcc.OCAcc += itm.OpenAmount;
                                            myAcc.CAcc += itm.Amount;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    double pc = setValue((from eitm in lacc
                                          where eitm.Code == "220301"
                                          select eitm.Bal).FirstOrDefault()) * -1;

                    double pcc = setValue((from eitm in lacc
                                           where eitm.Code == "220402"
                                           select eitm.Bal).FirstOrDefault()) * -1;                       

                    List<Acc1> myResult = new List<Acc1>();
                    double Bal = 0;
                    double myBal = 0;
                    if (string.IsNullOrEmpty(rep.Add1) && string.IsNullOrEmpty(rep.Add2) && string.IsNullOrEmpty(rep.Add3) && string.IsNullOrEmpty(rep.Add4) && string.IsNullOrEmpty(rep.Add5) && string.IsNullOrEmpty(rep.Add6) &&
                        string.IsNullOrEmpty(rep.Add7) && string.IsNullOrEmpty(rep.Add8) && string.IsNullOrEmpty(rep.Add9) && string.IsNullOrEmpty(rep.Add10) && string.IsNullOrEmpty(rep.Sub1) && string.IsNullOrEmpty(rep.Sub2) && string.IsNullOrEmpty(rep.Sub3) &&
                        string.IsNullOrEmpty(rep.Sub4) && string.IsNullOrEmpty(rep.Sub5))
                    {
                        myResult.Add(new Acc1
                        {
                            Name1 = rep.Name1,
                            Name2 = rep.Name2,
                            FCode = ""
                        });
                    }
                    else
                    {
                        Bal = 0;
                        myBal = 0;
                        if (!string.IsNullOrEmpty(rep.Add1))
                        {
                            if (rep.Add1.StartsWith("PC"))
                            {
                                if (pcc > 0) myBal = pc;
                                else
                                {
                                    double ps = 12 * double.Parse(rep.Add1.Substring(2));
                                    if (ps > pc)
                                    {
                                        myBal = pc;
                                    }
                                    else
                                    {
                                        myBal = ps;
                                    }
                                }
                                if (myBal != 0)
                                {
                                    Bal += myBal;
                                    myResult.Add(new Acc1
                                    {
                                        Name1 = "أوراق دفع قصيرة الأجل",
                                        FType = string.Format("{0:N0}", myBal)
                                    });
                                }
                            }
                            else
                            {
                                myBal = 0;
                                myBal = setValue((from eitm in lacc
                                                  where eitm.Code == rep.Add1
                                                  select eitm.Bal).FirstOrDefault()) * (rep.Add1.StartsWith("2") ? -1 : 1);
                                Bal += myBal;
                                if (myBal != 0)
                                {
                                    myResult.Add(new Acc1
                                    {
                                        Name1 = (from eitm in lacc
                                                 where eitm.Code == rep.Add1
                                                 select eitm.Name1).FirstOrDefault(),
                                        FType = string.Format("{0:N0}", myBal)
                                    });
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(rep.Add2))
                        {
                            myBal = 0;
                            myBal = setValue((from eitm in lacc
                                                where eitm.Code == rep.Add2
                                                select eitm.Bal).FirstOrDefault()) * (rep.Add2.StartsWith("2") ? -1 : 1);
                            Bal += myBal;
                            if (myBal != 0)
                            {
                                myResult.Add(new Acc1
                                {
                                    Name1 = (from eitm in lacc
                                             where eitm.Code == rep.Add2
                                             select eitm.Name1).FirstOrDefault(),
                                    FType = string.Format("{0:N0}", myBal)
                                });
                            }
                        }
                        if (!string.IsNullOrEmpty(rep.Add3))
                        {
                            myBal = 0;
                            myBal = setValue((from eitm in lacc
                                                where eitm.Code == rep.Add3
                                                select eitm.Bal).FirstOrDefault()) * (rep.Add3.StartsWith("2") ? -1 : 1);
                            Bal += myBal;
                            if (myBal != 0)
                            {
                                myResult.Add(new Acc1
                                {
                                    Name1 = (from eitm in lacc
                                                where eitm.Code == rep.Add3
                                                select eitm.Name1).FirstOrDefault(),
                                    FType = string.Format("{0:N0}", myBal)
                                });
                            }
                        }
                        if (!string.IsNullOrEmpty(rep.Add4))
                        {
                            myBal = 0;
                            myBal = setValue((from eitm in lacc
                                                where eitm.Code == rep.Add4
                                                select eitm.Bal).FirstOrDefault()) * (rep.Add4.StartsWith("2") ? -1 : 1);
                            Bal += myBal;
                            if (myBal != 0)
                            {
                                myResult.Add(new Acc1
                                {
                                    Name1 = (from eitm in lacc
                                             where eitm.Code == rep.Add4
                                             select eitm.Name1).FirstOrDefault(),
                                    FType = string.Format("{0:N0}", myBal)
                                });
                            }
                        }
                        if (!string.IsNullOrEmpty(rep.Add5))
                        {
                            myBal = 0;
                            myBal = setValue((from eitm in lacc
                                                where eitm.Code == rep.Add5
                                                select eitm.Bal).FirstOrDefault()) * (rep.Add5.StartsWith("2") ? -1 : 1);
                            Bal += myBal;
                            if (myBal != 0)
                            {
                                myResult.Add(new Acc1
                                {
                                    Name1 = (from eitm in lacc
                                             where eitm.Code == rep.Add5
                                             select eitm.Name1).FirstOrDefault(),
                                    FType = string.Format("{0:N0}", myBal)
                                });
                            }
                        }
                        if (!string.IsNullOrEmpty(rep.Add6))
                        {
                            myBal = 0;
                            myBal = setValue((from eitm in lacc
                                                where eitm.Code == rep.Add6
                                                select eitm.Bal).FirstOrDefault()) * (rep.Add6.StartsWith("2") ? -1 : 1);
                            Bal += myBal;
                            if (myBal != 0)
                            {
                                myResult.Add(new Acc1
                                {
                                    Name1 = (from eitm in lacc
                                             where eitm.Code == rep.Add6
                                             select eitm.Name1).FirstOrDefault(),
                                    FType = string.Format("{0:N0}", myBal)
                                });
                            }
                        }
                        if (!string.IsNullOrEmpty(rep.Add7))
                        {
                            myBal = 0;                                 
                            myBal = setValue((from eitm in lacc
                                                where eitm.Code == rep.Add7
                                                select eitm.Bal).FirstOrDefault()) * (rep.Add7.StartsWith("2") ? -1 : 1);
                            Bal += myBal;
                            if (myBal != 0)
                            {
                                myResult.Add(new Acc1
                                {
                                    Name1 = (from eitm in lacc
                                             where eitm.Code == rep.Add7
                                             select eitm.Name1).FirstOrDefault(),
                                    FType = string.Format("{0:N0}", myBal)
                                });
                            }
                        }
                        if (!string.IsNullOrEmpty(rep.Add8))
                        {
                            myBal = 0;
                            myBal = setValue((from eitm in lacc
                                                where eitm.Code == rep.Add8
                                                select eitm.Bal).FirstOrDefault()) * (rep.Add8.StartsWith("2") ? -1 : 1);
                            Bal += myBal;
                            if (myBal != 0)
                            {
                                myResult.Add(new Acc1
                                {
                                    Name1 = (from eitm in lacc
                                             where eitm.Code == rep.Add8
                                             select eitm.Name1).FirstOrDefault(),
                                    FType = string.Format("{0:N0}", myBal)
                                });
                            }
                        }
                        if (!string.IsNullOrEmpty(rep.Add9))
                        {
                            myBal = 0;
                            myBal = setValue((from eitm in lacc
                                                where eitm.Code == rep.Add9
                                                select eitm.Bal).FirstOrDefault()) * (rep.Add9.StartsWith("2") ? -1 : 1);
                            Bal += myBal;
                            if (myBal != 0)
                            {
                                myResult.Add(new Acc1
                                {
                                    Name1 = (from eitm in lacc
                                             where eitm.Code == rep.Add9
                                             select eitm.Name1).FirstOrDefault(),
                                    FType = string.Format("{0:N0}", myBal)
                                });
                            }
                        }
                        if (!string.IsNullOrEmpty(rep.Add10))
                        {
                            myBal = 0;
                            myBal = setValue((from eitm in lacc
                                                where eitm.Code == rep.Add10
                                                select eitm.Bal).FirstOrDefault()) * (rep.Add10.StartsWith("2") ? -1 : 1);
                            Bal += myBal;
                            if (myBal != 0)
                            {
                                myResult.Add(new Acc1
                                {
                                    Name1 = (from eitm in lacc
                                             where eitm.Code == rep.Add10
                                             select eitm.Name1).FirstOrDefault(),
                                    FType = string.Format("{0:N0}", myBal)
                                });
                            }
                        }
                        else if (!string.IsNullOrEmpty(rep.Sub1))
                        {
                            myBal = 0;
                            myBal = setValue((from eitm in lacc
                                                where eitm.Code == rep.Sub1
                                                select eitm.Bal).FirstOrDefault());
                            Bal -= myBal;
                            if (myBal != 0)
                            {
                                myResult.Add(new Acc1
                                {
                                    Name1 = (from eitm in lacc
                                             where eitm.Code == rep.Sub1
                                             select eitm.Name1).FirstOrDefault(),
                                    FType = string.Format("{0:N0}", myBal * -1)
                                });
                            }
                        }
                        if (!string.IsNullOrEmpty(rep.Sub2))
                        {
                            myBal = 0;
                            myBal = setValue((from eitm in lacc
                                                where eitm.Code == rep.Sub2
                                                select eitm.Bal).FirstOrDefault());
                            Bal -= myBal;
                            if (myBal != 0)
                            {
                                myResult.Add(new Acc1
                                {
                                    Name1 = (from eitm in lacc
                                             where eitm.Code == rep.Sub2
                                             select eitm.Name1).FirstOrDefault(),
                                    FType = string.Format("{0:N0}", myBal * -1)
                                });
                            }
                        }
                        if (!string.IsNullOrEmpty(rep.Sub3))
                        {
                            myBal = 0;
                            myBal = (from eitm in lacc
                                    where eitm.Code == rep.Sub3
                                    select eitm.Bal).FirstOrDefault();
                            Bal -= myBal;
                            if (myBal != 0)
                            {
                                myResult.Add(new Acc1
                                {
                                    Name1 = (from eitm in lacc
                                             where eitm.Code == rep.Sub3
                                             select eitm.Name1).FirstOrDefault(),
                                    FType = string.Format("{0:N0}", myBal * -1)
                                });
                            }

                        }
                        if (!string.IsNullOrEmpty(rep.Sub4))
                        {
                            myBal = 0;
                            myBal = (from eitm in lacc
                                    where eitm.Code == rep.Sub4
                                    select eitm.Bal).FirstOrDefault();
                            Bal -= myBal;
                            if (myBal != 0)
                            {
                                myResult.Add(new Acc1
                                {
                                    Name1 = (from eitm in lacc
                                             where eitm.Code == rep.Sub4
                                             select eitm.Name1).FirstOrDefault(),
                                    FType = string.Format("{0:N0}", myBal * -1)
                                });
                            }
                        }
                        if (!string.IsNullOrEmpty(rep.Sub5))
                        {
                            myBal = 0;
                            myBal = (from eitm in lacc
                                    where eitm.Code == rep.Sub5
                                    select eitm.Bal).FirstOrDefault();
                            Bal += myBal;
                            if (myBal != 0)
                            {
                                myResult.Add(new Acc1
                                {
                                    Name1 = (from eitm in lacc
                                             where eitm.Code == rep.Sub5
                                             select eitm.Name1).FirstOrDefault(),
                                    FType = string.Format("{0:N0}", myBal)
                                });
                            }
                        }

                        if (Bal != 0)
                        {

                            myResult.Add(new Acc1
                            {
                                Name1 = "",
                                Name2 = "",
                                FType = "______________",
                                FCode = ""
                            });

                            myResult.Add(new Acc1
                            {
                                Name1 = "الاجمالي",
                                Name2 = "الاجمالي",
                                FType = string.Format("{0:N0}", Bal)
                            });

                            myResult.Add(new Acc1
                            {
                                Name1 = "",
                                Name2 = "",
                                FType = "══════════",
                                FCode = ""
                            });
                        }
                    }
                    return myResult;
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
        public List<Acc1> GetProfitLoss(string ConnectionStr, bool CheckPeriod, string FDate, string EDate, string AreaNo, string StoreNo)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.EndPeriodRepGet(2);
                    List<EndPeriodRep> rep = new List<EndPeriodRep>();
                    rep = (from itm in result
                           select new EndPeriodRep
                           {
                               TASK = itm.TASK,
                               FNo = itm.FNo,
                               Name1 = itm.Name1,
                               Name2 = itm.Name2,
                               Add1 = itm.Add1,
                               Add2 = itm.Add2,
                               Add3 = itm.Add3,
                               Add4 = itm.Add4,
                               Add5 = itm.Add5,
                               Add6 = itm.Add6,
                               Add7 = itm.Add7,
                               Add8 = itm.Add8,
                               Add9 = itm.Add9,
                               Add10 = itm.Add10,
                               Sub1 = itm.Sub1,
                               Sub2 = itm.Sub2,
                               Sub3 = itm.Sub3,
                               Sub4 = itm.Sub4,
                               Sub5 = itm.Sub5,
                               Details = itm.Details,
                               AddCost1 = itm.AddCost1,
                               AddCost2 = itm.AddCost2,
                               AddCost3 = itm.AddCost3,
                               AddCost4 = itm.AddCost4,
                               AddCost5 = itm.AddCost5,
                               AddCost6 = itm.AddCost6,
                               AddCost7 = itm.AddCost7,
                               AddCost8 = itm.AddCost8,
                               AddCost9 = itm.AddCost9,
                               AddCost10 = itm.AddCost10,
                               SubCost1 = itm.SubCost1,
                               SubCost2 = itm.SubCost2,
                               SubCost3 = itm.SubCost3,
                               SubCost4 = itm.SubCost4,
                               SubCost5 = itm.SubCost5
                           }).ToList();

                    PeriodAcc pa = new PeriodAcc();
                    List<PeriodAcc> lp = new List<PeriodAcc>();
                    if (!CheckPeriod)
                    {
                        lp = pa.GetPeriod(1, FDate, EDate, ConnectionStr);
                    }
                    List<Acc> lacc = new List<Acc>();
                    Acc myacc = new Acc();
                    myacc.Branch = 1;
                    lacc = (from itm in myacc.Getall(ConnectionStr)
                            select new Acc
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                FCode = itm.FCode,
                                MCode = itm.MCode,
                                FLevel = itm.FLevel,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                DAcc = CheckPeriod ? itm.DAcc : 0,
                                CAcc = CheckPeriod ? itm.CAcc : 0,
                                MDAcc = itm.MDAcc,
                                MCAcc = itm.MCAcc,
                                TDAcc = itm.TDAcc,
                                TCAcc = itm.TCAcc,
                                ODAcc = CheckPeriod ? itm.ODAcc:0,
                                OCAcc = CheckPeriod ? itm.OCAcc:0,
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
                                FUpdate = itm.FUpdate
                            }).ToList();

                    if (!CheckPeriod)
                    {
                        foreach (PeriodAcc itm in lp)
                        {
                            if (!string.IsNullOrEmpty(itm.DbCode))
                            {
                                if (itm.DbCode != "-1")
                                {
                                    foreach (Acc myAcc in lacc)
                                    {
                                        if (myAcc.Code == itm.DbCode.Substring(0, 1))
                                        {
                                            myAcc.ODAcc += itm.OpenAmount;
                                            myAcc.DAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.DbCode.Substring(0, 2))
                                        {
                                            myAcc.ODAcc += itm.OpenAmount;
                                            myAcc.DAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.DbCode.Substring(0, 4))
                                        {
                                            myAcc.ODAcc += itm.OpenAmount;
                                            myAcc.DAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.DbCode.Substring(0, 6))
                                        {
                                            myAcc.ODAcc += itm.OpenAmount;
                                            myAcc.DAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.DbCode)
                                        {
                                            myAcc.ODAcc += itm.OpenAmount;
                                            myAcc.DAcc += itm.Amount;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (Acc myAcc in lacc)
                                {
                                    if (itm.CrCode != "-1")
                                    {
                                        if (myAcc.Code == itm.CrCode.Substring(0, 1))
                                        {
                                            myAcc.OCAcc += itm.OpenAmount;
                                            myAcc.CAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.CrCode.Substring(0, 2))
                                        {
                                            myAcc.OCAcc += itm.OpenAmount;
                                            myAcc.CAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.CrCode.Substring(0, 4))
                                        {
                                            myAcc.OCAcc += itm.OpenAmount;
                                            myAcc.CAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.CrCode.Substring(0, 6))
                                        {
                                            myAcc.OCAcc += itm.OpenAmount;
                                            myAcc.CAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.CrCode)
                                        {
                                            myAcc.OCAcc += itm.OpenAmount;
                                            myAcc.CAcc += itm.Amount;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }



                    List<vCostCenterResult> vc = new List<vCostCenterResult>();
                    vCostCenterResult myInv = new vCostCenterResult();
                    vc = myInv.GetAll(1,FDate,EDate,ConnectionStr);

                    List<vCostCenterResult> lcs = new List<vCostCenterResult>();
                    myInv = new vCostCenterResult();
                    lcs = myInv.GetDetails(1, "00015", FDate, EDate, ConnectionStr);
                    lcs.AddRange(myInv.GetDetails(1, "00016", FDate, EDate, ConnectionStr));
                    lcs.AddRange(myInv.GetDetails(1, "00017", FDate, EDate, ConnectionStr));

                    List<vCostCenterResult> lcs14 = new List<vCostCenterResult>();
                    myInv = new vCostCenterResult();
                    lcs14 = myInv.GetDetails(1, "00014", FDate, EDate, ConnectionStr);


                    List<Acc1> myResult = new List<Acc1>();
                    double Bal = 0;
                    string HRef = "";
                    foreach (EndPeriodRep itm in rep)
                    {
                        if (string.IsNullOrEmpty(itm.Add1) && string.IsNullOrEmpty(itm.Add2) && string.IsNullOrEmpty(itm.Add3) && string.IsNullOrEmpty(itm.Add4) && string.IsNullOrEmpty(itm.Add5) && string.IsNullOrEmpty(itm.Add6) &&
                            string.IsNullOrEmpty(itm.Add7) && string.IsNullOrEmpty(itm.Add8) && string.IsNullOrEmpty(itm.Add9) && string.IsNullOrEmpty(itm.Add10) && string.IsNullOrEmpty(itm.Sub1) && string.IsNullOrEmpty(itm.Sub2) && string.IsNullOrEmpty(itm.Sub3) &&
                            string.IsNullOrEmpty(itm.Sub4) && string.IsNullOrEmpty(itm.Sub5))
                        {
                            myResult.Add(new Acc1
                            {
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                FCode = ""
                            });
                        }
                        else
                        {
                            HRef = "";
                            Bal = 0;
                            if (itm.Add1 == "DIV")
                            {
                                myResult.Add(new Acc1
                                {
                                    Name1 = itm.Name1,
                                    Name2 = itm.Name2,
                                    FType = "______________",
                                    FCode = ""
                                });

                            }
                            else if (itm.Add1 == "DIV2")
                            {
                                myResult.Add(new Acc1
                                {
                                    Name1 = itm.Name1,
                                    Name2 = itm.Name2,
                                    FType = "══════════",
                                    FCode = ""
                                });
                            }
                            else
                            {
                                Bal = 0;
                                if (!string.IsNullOrEmpty(itm.Add1))
                                {
                                    if (itm.Add1 == "EXP1")
                                    {
                                        Bal -= setValue((from eitm in vc
                                                         where eitm.Code == "00015" || eitm.Code == "00016" || eitm.Code == "00017"
                                                         select eitm.Expenses).Sum());
                                        Bal += setValue((from eitm in lcs
                                                         where eitm.Code.StartsWith(itm.Sub1)
                                                         select eitm.Expenses).Sum());

                                    }
                                    else if (itm.Add1 == "EXP2")
                                    {
                                        Bal -= setValue((from eitm in vc
                                                         where eitm.Code != "00014" && eitm.Code != "00015" && eitm.Code != "00016" && eitm.Code != "00017"
                                                         select eitm.Expenses).Sum());

                                        Bal += setValue((from eitm in lacc
                                                         where eitm.Code == "310201"
                                                         select eitm.MBal).FirstOrDefault()) - (
                                            setValue((from eitm in lcs
                                                      where eitm.Code.StartsWith("310201")
                                                      select eitm.Expenses).Sum())
                                            + setValue((from eitm in lcs14
                                                        where eitm.Code.StartsWith("310201")
                                                        select eitm.Expenses).Sum()));


                                    }
                                    else if (itm.Add1 == "EXP3")
                                    {
                                        Bal -= setValue((from eitm in vc
                                                         where eitm.Code == "00014"
                                                         select eitm.Expenses).FirstOrDefault());
                                        Bal += setValue((from eitm in lcs14
                                                         where eitm.Code.StartsWith("310201")
                                                         select eitm.Expenses).Sum());

                                    }
                                    else if (itm.Add1 == "EXP")
                                    {
                                        Bal -= setValue((from eitm in vc
                                                         select eitm.Expenses).Sum());
                                    }
                                    else
                                    {
                                        Bal += setValue((from eitm in lacc
                                                         where eitm.Code == itm.Add1
                                                         select eitm.MBal).FirstOrDefault()) * (itm.Add1.StartsWith("4") ? -1 : 1);
                                    }
                                }
                                if (!string.IsNullOrEmpty(itm.Add2))
                                {
                                    Bal += setValue((from eitm in lacc
                                                     where eitm.Code == itm.Add2
                                                     select eitm.MBal).FirstOrDefault()) * (itm.Add2.StartsWith("4") ? -1 : 1);

                                }
                                if (!string.IsNullOrEmpty(itm.Add3))
                                {
                                    Bal += setValue((from eitm in lacc
                                                     where eitm.Code == itm.Add3
                                                     select eitm.MBal).FirstOrDefault()) * (itm.Add3.StartsWith("4") ? -1 : 1);

                                }
                                if (!string.IsNullOrEmpty(itm.Add4))
                                {
                                    Bal += setValue((from eitm in lacc
                                                     where eitm.Code == itm.Add4
                                                     select eitm.MBal).FirstOrDefault()) * (itm.Add4.StartsWith("4") ? -1 : 1);

                                }
                                if (!string.IsNullOrEmpty(itm.Add5))
                                {
                                    Bal += setValue((from eitm in lacc
                                                     where eitm.Code == itm.Add5
                                                     select eitm.MBal).FirstOrDefault()) * (itm.Add5.StartsWith("4") ? -1 : 1);

                                }
                                if (!string.IsNullOrEmpty(itm.Add6))
                                {
                                    Bal += setValue((from eitm in lacc
                                                     where eitm.Code == itm.Add6
                                                     select eitm.MBal).FirstOrDefault()) * (itm.Add6.StartsWith("4") ? -1 : 1);

                                }
                                if (!string.IsNullOrEmpty(itm.Add7))
                                {
                                    Bal += setValue((from eitm in lacc
                                                     where eitm.Code == itm.Add7
                                                     select eitm.MBal).FirstOrDefault()) * (itm.Add7.StartsWith("4") ? -1 : 1);

                                }
                                if (!string.IsNullOrEmpty(itm.Add8))
                                {
                                    Bal += setValue((from eitm in lacc
                                                     where eitm.Code == itm.Add8
                                                     select eitm.MBal).FirstOrDefault()) * (itm.Add8.StartsWith("4") ? -1 : 1);

                                }
                                if (!string.IsNullOrEmpty(itm.Add9))
                                {
                                    Bal += setValue((from eitm in lacc
                                                     where eitm.Code == itm.Add9
                                                     select eitm.MBal).FirstOrDefault()) * (itm.Add9.StartsWith("4") ? -1 : 1);

                                }
                                if (!string.IsNullOrEmpty(itm.Add10))
                                {
                                    Bal += setValue((from eitm in lacc
                                                     where eitm.Code == itm.Add10
                                                     select eitm.MBal).FirstOrDefault()) * (itm.Add10.StartsWith("4") ? -1 : 1);

                                }
                                else if (!string.IsNullOrEmpty(itm.Sub1))
                                {
                                    if (itm.Sub1 == "ZAKA")
                                    {
                                        double x = 0;
                                        //setValue((from eitm in lacc
                                        //                        where eitm.Code == "220304002"
                                        //                        select eitm.CAcc).FirstOrDefault());
                                        Bal += (x == 0 ? Math.Abs(setValue((from eitm in lacc
                                                         where eitm.Code == "220304002"
                                                         select eitm.Bal).FirstOrDefault())): x);
                                    }
                                    else if (itm.Sub1.StartsWith("1") || itm.Sub1.StartsWith("2"))
                                    {
                                        Bal -= setValue((from eitm in lacc
                                                         where eitm.Code == itm.Sub1
                                                         select eitm.Bal).FirstOrDefault()) * (itm.Sub1.StartsWith("2") ? -1 : 1);
                                    }
                                    else
                                    {
                                        Bal -= setValue((from eitm in lacc
                                                         where eitm.Code == itm.Sub1
                                                         select eitm.MBal).FirstOrDefault());
                                    }

                                }
                                if (!string.IsNullOrEmpty(itm.Sub2))
                                {
                                    if (itm.Sub1.StartsWith("1") || itm.Sub1.StartsWith("2"))
                                    {
                                        Bal -= setValue((from eitm in lacc
                                                         where eitm.Code == itm.Sub2
                                                         select eitm.Bal).FirstOrDefault()) * (itm.Sub2.StartsWith("2") ? -1 : 1); 
                                    }
                                    else
                                    {
                                        Bal -= setValue((from eitm in lacc
                                                         where eitm.Code == itm.Sub2
                                                         select eitm.MBal).FirstOrDefault());
                                    }

                                }
                                if (!string.IsNullOrEmpty(itm.Sub3))
                                {
                                    if (itm.Sub3.StartsWith("1") || itm.Sub3.StartsWith("2"))
                                    {
                                        Bal -= setValue((from eitm in lacc
                                                where eitm.Code == itm.Sub3
                                                         select eitm.Bal).FirstOrDefault()) * (itm.Sub3.StartsWith("2") ? -1 : 1); 
                                    }
                                    else
                                    {
                                        Bal -= setValue((from eitm in lacc
                                                where eitm.Code == itm.Sub3
                                                select eitm.MBal).FirstOrDefault());
                                    }

                                }
                                if (!string.IsNullOrEmpty(itm.Sub4))
                                {
                                    if (itm.Sub4.StartsWith("1") || itm.Sub4.StartsWith("2"))
                                    {
                                        Bal -= setValue((from eitm in lacc
                                                where eitm.Code == itm.Sub4
                                                select eitm.Bal).FirstOrDefault());
                                    }
                                    else
                                    {
                                        Bal -= setValue((from eitm in lacc
                                                where eitm.Code == itm.Sub4
                                                select eitm.MBal).FirstOrDefault());
                                    }

                                }
                                if (!string.IsNullOrEmpty(itm.Sub5))
                                {
                                    if (itm.Sub1.StartsWith("1") || itm.Sub1.StartsWith("2"))
                                    {
                                        Bal -= setValue((from eitm in lacc
                                                where eitm.Code == itm.Sub5
                                                select eitm.Bal).FirstOrDefault());
                                    }
                                    else
                                    {
                                        Bal -= setValue((from eitm in lacc
                                                where eitm.Code == itm.Sub5
                                                select eitm.MBal).FirstOrDefault());
                                    }

                                }
                                if (!string.IsNullOrEmpty(itm.Sub6))
                                {
                                    Bal -= setValue((from eitm in lacc
                                            where eitm.Code == itm.Sub6
                                            select eitm.MBal).FirstOrDefault());

                                }
                                if (!string.IsNullOrEmpty(itm.Sub7))
                                {
                                    Bal -= setValue((from eitm in lacc
                                            where eitm.Code == itm.Sub7
                                            select eitm.MBal).FirstOrDefault());

                                }
                                if (!string.IsNullOrEmpty(itm.Sub8))
                                {
                                    Bal -= setValue((from eitm in lacc
                                            where eitm.Code == itm.Sub8
                                            select eitm.MBal).FirstOrDefault());

                                }
                                if (!string.IsNullOrEmpty(itm.Sub9))
                                {
                                    Bal -= setValue((from eitm in lacc
                                            where eitm.Code == itm.Sub9
                                            select eitm.MBal).FirstOrDefault());

                                }
                                if (!string.IsNullOrEmpty(itm.Sub10))
                                {
                                    Bal -= setValue((from eitm in lacc
                                            where eitm.Code == itm.Sub10
                                            select eitm.MBal).FirstOrDefault());

                                }

                                if (Bal != 0)
                                {
                                    if ((bool)itm.Details && HRef == "")
                                    {
                                        HRef = "WebIncome.aspx?Task=2&FNo=" + itm.FNo.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FDate=" + FDate + "&EDate=" + EDate;
                                    }

                                    myResult.Add(new Acc1
                                    {
                                        Name1 = itm.Name1,
                                        Name2 = itm.Name2,
                                        FCode = HRef,
                                        FType = string.Format("{0:N0}", Math.Round(Bal,0))
                                    });
                                }
                            }

                        }

                    }
                    return myResult;
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
        public List<Acc1> GetProfitLossDetails(string ConnectionStr, bool CheckPeriod, string FDate, string EDate, string Task, string FNo)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.EndPeriodRepGet(2);
                    List<EndPeriodRep> rep = new List<EndPeriodRep>();
                    rep = (from itm in result
                           where itm.FNo == short.Parse(FNo)
                           select new EndPeriodRep
                           {
                               TASK = itm.TASK,
                               FNo = itm.FNo,
                               Name1 = itm.Name1,
                               Name2 = itm.Name2,
                               Add1 = itm.Add1,
                               Add2 = itm.Add2,
                               Add3 = itm.Add3,
                               Add4 = itm.Add4,
                               Add5 = itm.Add5,
                               Add6 = itm.Add6,
                               Add7 = itm.Add7,
                               Add8 = itm.Add8,
                               Add9 = itm.Add9,
                               Add10 = itm.Add10,
                               Sub1 = itm.Sub1,
                               Sub2 = itm.Sub2,
                               Sub3 = itm.Sub3,
                               Sub4 = itm.Sub4,
                               Sub5 = itm.Sub5,
                               Details = itm.Details,
                               AddCost1 = itm.AddCost1,
                               AddCost2 = itm.AddCost2,
                               AddCost3 = itm.AddCost3,
                               AddCost4 = itm.AddCost4,
                               AddCost5 = itm.AddCost5,
                               AddCost6 = itm.AddCost6,
                               AddCost7 = itm.AddCost7,
                               AddCost8 = itm.AddCost8,
                               AddCost9 = itm.AddCost9,
                               AddCost10 = itm.AddCost10,
                               SubCost1 = itm.SubCost1,
                               SubCost2 = itm.SubCost2,
                               SubCost3 = itm.SubCost3,
                               SubCost4 = itm.SubCost4,
                               SubCost5 = itm.SubCost5
                           }).ToList();

                    PeriodAcc pa = new PeriodAcc();
                    List<PeriodAcc> lp = new List<PeriodAcc>();
                    if (!CheckPeriod)
                    {
                        lp = pa.GetPeriod(1, FDate, EDate, ConnectionStr);
                    }
                    List<Acc> lacc = new List<Acc>();
                    Acc myacc = new Acc();
                    myacc.Branch = 1;
                    lacc = (from itm in myacc.Getall(ConnectionStr)
                            select new Acc
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                FCode = itm.FCode,
                                MCode = itm.MCode,
                                FLevel = itm.FLevel,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                DAcc = CheckPeriod ? itm.DAcc : 0,
                                CAcc = CheckPeriod ? itm.CAcc : 0,
                                MDAcc = itm.MDAcc,
                                MCAcc = itm.MCAcc,
                                TDAcc = itm.TDAcc,
                                TCAcc = itm.TCAcc,
                                ODAcc = CheckPeriod ? itm.ODAcc:0,
                                OCAcc = CheckPeriod ? itm.OCAcc:0,
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
                                FUpdate = itm.FUpdate
                            }).ToList();

                    if (!CheckPeriod)
                    {
                        foreach (PeriodAcc itm in lp)
                        {
                            if (!string.IsNullOrEmpty(itm.DbCode))
                            {
                                if (itm.DbCode != "-1")
                                {
                                    foreach (Acc myAcc in lacc)
                                    {
                                        if (myAcc.Code == itm.DbCode.Substring(0, 1))
                                        {
                                            myAcc.ODAcc += itm.OpenAmount;
                                            myAcc.DAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.DbCode.Substring(0, 2))
                                        {
                                            myAcc.ODAcc += itm.OpenAmount;
                                            myAcc.DAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.DbCode.Substring(0, 4))
                                        {
                                            myAcc.ODAcc += itm.OpenAmount;
                                            myAcc.DAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.DbCode.Substring(0, 6))
                                        {
                                            myAcc.ODAcc += itm.OpenAmount;
                                            myAcc.DAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.DbCode)
                                        {
                                            myAcc.ODAcc += itm.OpenAmount;
                                            myAcc.DAcc += itm.Amount;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (Acc myAcc in lacc)
                                {
                                    if (itm.CrCode != "-1")
                                    {
                                        if (myAcc.Code == itm.CrCode.Substring(0, 1))
                                        {
                                            myAcc.OCAcc += itm.OpenAmount;
                                            myAcc.CAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.CrCode.Substring(0, 2))
                                        {
                                            myAcc.OCAcc += itm.OpenAmount;
                                            myAcc.CAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.CrCode.Substring(0, 4))
                                        {
                                            myAcc.OCAcc += itm.OpenAmount;
                                            myAcc.CAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.CrCode.Substring(0, 6))
                                        {
                                            myAcc.OCAcc += itm.OpenAmount;
                                            myAcc.CAcc += itm.Amount;
                                        }
                                        else if (myAcc.Code == itm.CrCode)
                                        {
                                            myAcc.OCAcc += itm.OpenAmount;
                                            myAcc.CAcc += itm.Amount;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    List<vCostCenterResult> vc = new List<vCostCenterResult>();
                    vCostCenterResult myInv = new vCostCenterResult();
                    vc = myInv.GetAll(1, FDate, EDate, ConnectionStr);

                    List<vCostCenterResult> lcs = new List<vCostCenterResult>();
                    myInv = new vCostCenterResult();
                    lcs = myInv.GetDetails(1, "00015", FDate, EDate, ConnectionStr);
                    lcs.AddRange(myInv.GetDetails(1, "00016", FDate, EDate, ConnectionStr));
                    lcs.AddRange(myInv.GetDetails(1, "00017", FDate, EDate, ConnectionStr));

                    List<vCostCenterResult> lcs14 = new List<vCostCenterResult>();
                    myInv = new vCostCenterResult();
                    lcs14 = myInv.GetDetails(1, "00014", FDate, EDate, ConnectionStr);


                    List<Acc1> myResult = new List<Acc1>();
                    double Bal = 0;
                    double myBal = 0;
                    string HRef = "";
                    foreach (EndPeriodRep itm in rep)
                    {
                        if (string.IsNullOrEmpty(itm.Add1) && string.IsNullOrEmpty(itm.Add2) && string.IsNullOrEmpty(itm.Add3) && string.IsNullOrEmpty(itm.Add4) && string.IsNullOrEmpty(itm.Add5) && string.IsNullOrEmpty(itm.Add6) &&
                            string.IsNullOrEmpty(itm.Add7) && string.IsNullOrEmpty(itm.Add8) && string.IsNullOrEmpty(itm.Add9) && string.IsNullOrEmpty(itm.Add10) && string.IsNullOrEmpty(itm.Sub1) && string.IsNullOrEmpty(itm.Sub2) && string.IsNullOrEmpty(itm.Sub3) &&
                            string.IsNullOrEmpty(itm.Sub4) && string.IsNullOrEmpty(itm.Sub5))
                        {
                            myResult.Add(new Acc1
                            {
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                FCode = ""
                            });
                        }
                        else
                        {
                            HRef = "";
                            Bal = 0;
                            if (itm.Add1 == "DIV")
                            {
                                myResult.Add(new Acc1
                                {
                                    Name1 = itm.Name1,
                                    Name2 = itm.Name2,
                                    FType = "______________",
                                    FCode = ""
                                });

                            }
                            else if (itm.Add1 == "DIV2")
                            {
                                myResult.Add(new Acc1
                                {
                                    Name1 = itm.Name1,
                                    Name2 = itm.Name2,
                                    FType = "══════════",
                                    FCode = ""
                                });
                            }
                            else
                            {
                                Bal = 0;
                                if (!string.IsNullOrEmpty(itm.Add1))
                                {
                                    if (itm.Add1 == "EXP1")
                                    {
                                        myBal = 0;
                                        foreach(vCostCenterResult eitm in vc)
                                        {
                                            if(eitm.Code == "00015" || eitm.Code == "00016" || eitm.Code == "00017")
                                            {
                                                myBal = (double)eitm.Expenses;
                                                Bal -= myBal;
                                                if (myBal != 0)
                                                {
                                                    myResult.Add(new Acc1
                                                    {
                                                        Name1 = eitm.Name1,
                                                        FType = string.Format("{0:N0}", myBal * -1)
                                                    });
                                                }
                                            }
                                        }

                                        foreach (vCostCenterResult eitm in lcs)
                                        {
                                            if (eitm.Code.StartsWith(itm.Sub1))
                                            {
                                                myBal = (double)eitm.Expenses;
                                                Bal += myBal;
                                                if (myBal != 0)
                                                {
                                                    myResult.Add(new Acc1
                                                    {
                                                        Name1 = eitm.Name1,
                                                        FType = string.Format("{0:N0}", myBal)
                                                    });
                                                }
                                            }
                                        }

                                    }
                                    else if (itm.Add1 == "EXP2")
                                    {
                                        myBal = 0;
                                        foreach (vCostCenterResult eitm in vc)
                                        {
                                            if (eitm.Code != "00014" && eitm.Code != "00015" && eitm.Code != "00016" && eitm.Code != "00017")
                                            {
                                                myBal = (double)eitm.Expenses;
                                                Bal -= myBal;
                                                if (myBal != 0)
                                                {
                                                    myResult.Add(new Acc1
                                                    {
                                                        Name1 = eitm.Name1,
                                                        FType = string.Format("{0:N0}", myBal * -1)
                                                    });
                                                }
                                            }
                                        }

                                        myBal = 0;
                                        myBal = setValue((from eitm in lacc
                                                          where eitm.Code == "310201"
                                                          select eitm.MBal).FirstOrDefault());
                                        Bal += myBal;
                                        if (myBal != 0)
                                        {
                                            myResult.Add(new Acc1
                                            {
                                                Name1 = (from eitm in lacc
                                                         where eitm.Code == "310201"
                                                         select eitm.Name1).FirstOrDefault(),
                                                FType = string.Format("{0:N0}", myBal)
                                            });
                                        }

                                        foreach (vCostCenterResult eitm in lcs)
                                        {
                                            if (eitm.Code.StartsWith("310201"))
                                            {
                                                myBal = (double)eitm.Expenses;
                                                Bal -= myBal;
                                                if (myBal != 0)
                                                {
                                                    myResult.Add(new Acc1
                                                    {
                                                        Name1 = eitm.Name1,
                                                        FType = string.Format("{0:N0}", myBal * -1)
                                                    });
                                                }
                                            }
                                        }

                                        foreach (vCostCenterResult eitm in lcs14)
                                        {
                                            if (eitm.Code.StartsWith("310201"))
                                            {
                                                myBal = (double)eitm.Expenses;
                                                Bal -= myBal;
                                                if (myBal != 0)
                                                {
                                                    myResult.Add(new Acc1
                                                    {
                                                        Name1 = eitm.Name1,
                                                        FType = string.Format("{0:N0}", myBal * -1)
                                                    });
                                                }
                                            }
                                        }
                                    }
                                    else if (itm.Add1 == "EXP3")
                                    {
                                        myBal = 0;
                                        foreach (vCostCenterResult eitm in vc)
                                        {
                                            if (eitm.Code == "00014")
                                            {
                                                myBal = (double)eitm.Expenses;
                                                Bal -= myBal;
                                                if (myBal != 0)
                                                {
                                                    myResult.Add(new Acc1
                                                    {
                                                        Name1 = eitm.Name1,
                                                        FType = string.Format("{0:N0}", myBal * -1)
                                                    });
                                                }
                                            }
                                        }

                                        foreach (vCostCenterResult eitm in lcs14)
                                        {
                                            if (eitm.Code.StartsWith("310201"))
                                            {
                                                myBal = (double)eitm.Expenses;
                                                Bal += myBal;
                                                if (myBal != 0)
                                                {
                                                    myResult.Add(new Acc1
                                                    {
                                                        Name1 = eitm.Name1,
                                                        FType = string.Format("{0:N0}", myBal)
                                                    });
                                                }
                                            }
                                        }

                                    }
                                    else if (itm.Add1 == "EXP")
                                    {
                                        myBal = 0;
                                        foreach (vCostCenterResult eitm in vc)
                                        {
                                            myBal = (double)eitm.Expenses;
                                            Bal -= myBal;
                                            if (myBal != 0)
                                            {
                                                myResult.Add(new Acc1
                                                {
                                                    Name1 = eitm.Name1,
                                                    FType = string.Format("{0:N0}", myBal * -1)
                                                });
                                            }
                                        }
                                    }
                                    else
                                    {
                                        myBal = 0;
                                        myBal = setValue((from eitm in lacc
                                                          where eitm.Code == itm.Add1
                                                          select eitm.MBal).FirstOrDefault()) * (itm.Add1.StartsWith("4") ? -1 : 1);
                                        Bal += myBal;
                                        if (myBal != 0)
                                        {
                                            myResult.Add(new Acc1
                                            {
                                                Name1 = (from eitm in lacc
                                                         where eitm.Code == itm.Add1
                                                         select eitm.Name1).FirstOrDefault(),
                                                FType = string.Format("{0:N0}", myBal)
                                            });
                                        }
                                    }
                                }
                                if (!string.IsNullOrEmpty(itm.Add2))
                                {
                                    myBal = 0;
                                    myBal = setValue((from eitm in lacc
                                                      where eitm.Code == itm.Add2
                                                      select eitm.MBal).FirstOrDefault()) * (itm.Add2.StartsWith("4") ? -1 : 1);
                                    Bal += myBal;
                                    if (myBal != 0)
                                    {
                                        myResult.Add(new Acc1
                                        {
                                            Name1 = (from eitm in lacc
                                                     where eitm.Code == itm.Add2
                                                     select eitm.Name1).FirstOrDefault(),
                                            FType = string.Format("{0:N0}", myBal)
                                        });
                                    }
                                }
                                if (!string.IsNullOrEmpty(itm.Add3))
                                {
                                    myBal = 0;
                                    myBal = setValue((from eitm in lacc
                                                      where eitm.Code == itm.Add3
                                                      select eitm.MBal).FirstOrDefault()) * (itm.Add3.StartsWith("4") ? -1 : 1);
                                    Bal += myBal;
                                    if (myBal != 0)
                                    {
                                        myResult.Add(new Acc1
                                        {
                                            Name1 = (from eitm in lacc
                                                     where eitm.Code == itm.Add3
                                                     select eitm.Name1).FirstOrDefault(),
                                            FType = string.Format("{0:N0}", myBal)
                                        });
                                    }

                                }
                                if (!string.IsNullOrEmpty(itm.Add4))
                                {
                                    myBal = 0;
                                    myBal = setValue((from eitm in lacc
                                                      where eitm.Code == itm.Add4
                                                      select eitm.MBal).FirstOrDefault()) * (itm.Add4.StartsWith("4") ? -1 : 1);
                                    Bal += myBal;
                                    if (myBal != 0)
                                    {
                                        myResult.Add(new Acc1
                                        {
                                            Name1 = (from eitm in lacc
                                                     where eitm.Code == itm.Add4
                                                     select eitm.Name1).FirstOrDefault(),
                                            FType = string.Format("{0:N0}", myBal)
                                        });
                                    }
                                }
                                if (!string.IsNullOrEmpty(itm.Add5))
                                {
                                    myBal = 0;
                                    myBal = setValue((from eitm in lacc
                                                      where eitm.Code == itm.Add5
                                                      select eitm.MBal).FirstOrDefault()) * (itm.Add5.StartsWith("4") ? -1 : 1);
                                    Bal += myBal;
                                    if (myBal != 0)
                                    {
                                        myResult.Add(new Acc1
                                        {
                                            Name1 = (from eitm in lacc
                                                     where eitm.Code == itm.Add5
                                                     select eitm.Name1).FirstOrDefault(),
                                            FType = string.Format("{0:N0}", myBal)
                                        });
                                    }
                                }
                                if (!string.IsNullOrEmpty(itm.Add6))
                                {
                                    myBal = 0;
                                    myBal = setValue((from eitm in lacc
                                                      where eitm.Code == itm.Add6
                                                      select eitm.MBal).FirstOrDefault()) * (itm.Add6.StartsWith("4") ? -1 : 1);
                                    Bal += myBal;
                                    if (myBal != 0)
                                    {
                                        myResult.Add(new Acc1
                                        {
                                            Name1 = (from eitm in lacc
                                                     where eitm.Code == itm.Add6
                                                     select eitm.Name1).FirstOrDefault(),
                                            FType = string.Format("{0:N0}", myBal)
                                        });
                                    }
                                }
                                if (!string.IsNullOrEmpty(itm.Add7))
                                {
                                    myBal = 0;
                                    myBal = setValue((from eitm in lacc
                                                      where eitm.Code == itm.Add7
                                                      select eitm.MBal).FirstOrDefault()) * (itm.Add7.StartsWith("4") ? -1 : 1);
                                    Bal += myBal;
                                    if (myBal != 0)
                                    {
                                        myResult.Add(new Acc1
                                        {
                                            Name1 = (from eitm in lacc
                                                     where eitm.Code == itm.Add7
                                                     select eitm.Name1).FirstOrDefault(),
                                            FType = string.Format("{0:N0}", myBal)
                                        });
                                    }
                                }
                                if (!string.IsNullOrEmpty(itm.Add8))
                                {
                                    myBal = 0;
                                    myBal = setValue((from eitm in lacc
                                                      where eitm.Code == itm.Add8
                                                      select eitm.MBal).FirstOrDefault()) * (itm.Add8.StartsWith("4") ? -1 : 1);
                                    Bal += myBal;
                                    if (myBal != 0)
                                    {
                                        myResult.Add(new Acc1
                                        {
                                            Name1 = (from eitm in lacc
                                                     where eitm.Code == itm.Add8
                                                     select eitm.Name1).FirstOrDefault(),
                                            FType = string.Format("{0:N0}", myBal)
                                        });
                                    }

                                }
                                if (!string.IsNullOrEmpty(itm.Add9))
                                {
                                    myBal = 0;
                                    myBal = setValue((from eitm in lacc
                                                      where eitm.Code == itm.Add9
                                                      select eitm.MBal).FirstOrDefault()) * (itm.Add9.StartsWith("4") ? -1 : 1);
                                    Bal += myBal;
                                    if (myBal != 0)
                                    {
                                        myResult.Add(new Acc1
                                        {
                                            Name1 = (from eitm in lacc
                                                     where eitm.Code == itm.Add9
                                                     select eitm.Name1).FirstOrDefault(),
                                            FType = string.Format("{0:N0}", myBal)
                                        });
                                    }
                                }
                                if (!string.IsNullOrEmpty(itm.Add10))
                                {
                                    myBal = 0;
                                    myBal = setValue((from eitm in lacc
                                                      where eitm.Code == itm.Add10
                                                      select eitm.MBal).FirstOrDefault()) * (itm.Add10.StartsWith("4") ? -1 : 1);
                                    Bal += myBal;
                                    if (myBal != 0)
                                    {
                                        myResult.Add(new Acc1
                                        {
                                            Name1 = (from eitm in lacc
                                                     where eitm.Code == itm.Add10
                                                     select eitm.Name1).FirstOrDefault(),
                                            FType = string.Format("{0:N0}", myBal)
                                        });
                                    }
                                }
                                else if (!string.IsNullOrEmpty(itm.Sub1))
                                {
                                    if (itm.Sub1 == "ZAKA")
                                    {
                                        myBal = 0;
                                        //myBal = setValue((from eitm in lacc
                                        //                  where eitm.Code == "220304002"
                                        //                  select eitm.CAcc).FirstOrDefault());
                                        if (myBal == 0)
                                        {
                                            myBal = setValue((from eitm in lacc
                                                              where eitm.Code == "220304002"
                                                              select eitm.Bal).FirstOrDefault());
                                        }
                                        Bal -= myBal;
                                        if (myBal != 0)
                                        {
                                            myResult.Add(new Acc1
                                            {
                                                Name1 = (from eitm in lacc
                                                         where eitm.Code == "220304002"
                                                         select eitm.Name1).FirstOrDefault(),
                                                FType = string.Format("{0:N0}", myBal)
                                            });
                                        }

                                    }
                                    else if (itm.Sub1.StartsWith("1") || itm.Sub1.StartsWith("2"))
                                    {
                                        myBal = 0;
                                        myBal = (from eitm in lacc
                                                 where eitm.Code == itm.Sub1
                                                 select eitm.Bal).FirstOrDefault() * (itm.Sub1.StartsWith("2") ? -1 : 1);
                                        Bal -= myBal;
                                        if (myBal != 0)
                                        {
                                            myResult.Add(new Acc1
                                            {
                                                Name1 = (from eitm in lacc
                                                         where eitm.Code == itm.Sub1
                                                         select eitm.Name1).FirstOrDefault(),
                                                FType = string.Format("{0:N0}", myBal * -1)
                                            });
                                        }
                                    }
                                    else
                                    {
                                        myBal = 0;
                                        myBal = (from eitm in lacc
                                                 where eitm.Code == itm.Sub1
                                                 select eitm.MBal).FirstOrDefault();
                                        Bal -= myBal;
                                        if (myBal != 0)
                                        {
                                            myResult.Add(new Acc1
                                            {
                                                Name1 = (from eitm in lacc
                                                         where eitm.Code == itm.Sub1
                                                         select eitm.Name1).FirstOrDefault(),
                                                FType = string.Format("{0:N0}", myBal * -1)
                                            });
                                        }
                                    }
                                }
                                if (!string.IsNullOrEmpty(itm.Sub2))
                                {
                                    if (itm.Sub1.StartsWith("1") || itm.Sub1.StartsWith("2"))
                                    {
                                        myBal = 0;
                                        myBal = (from eitm in lacc
                                                 where eitm.Code == itm.Sub2
                                                 select eitm.Bal).FirstOrDefault() * (itm.Sub2.StartsWith("2") ? -1 : 1);
                                        Bal -= myBal;
                                        if (myBal != 0)
                                        {
                                            myResult.Add(new Acc1
                                            {
                                                Name1 = (from eitm in lacc
                                                         where eitm.Code == itm.Sub2
                                                         select eitm.Name1).FirstOrDefault(),
                                                FType = string.Format("{0:N0}", myBal * -1)
                                            });
                                        }
                                    }
                                    else
                                    {
                                        myBal = 0;
                                        myBal = (from eitm in lacc
                                                 where eitm.Code == itm.Sub2
                                                 select eitm.MBal).FirstOrDefault();
                                        Bal -= myBal;
                                        if (myBal != 0)
                                        {
                                            myResult.Add(new Acc1
                                            {
                                                Name1 = (from eitm in lacc
                                                         where eitm.Code == itm.Sub2
                                                         select eitm.Name1).FirstOrDefault(),
                                                FType = string.Format("{0:N0}", myBal * -1)
                                            });
                                        }
                                    }

                                }
                                if (!string.IsNullOrEmpty(itm.Sub3))
                                {
                                    if (itm.Sub3.StartsWith("1") || itm.Sub3.StartsWith("2"))
                                    {
                                        myBal = 0;
                                        myBal = (from eitm in lacc
                                                 where eitm.Code == itm.Sub3
                                                 select eitm.Bal).FirstOrDefault() * (itm.Sub3.StartsWith("2") ? -1 : 1);
                                        Bal -= myBal;
                                        if (myBal != 0)
                                        {
                                            myResult.Add(new Acc1
                                            {
                                                Name1 = (from eitm in lacc
                                                         where eitm.Code == itm.Sub3
                                                         select eitm.Name1).FirstOrDefault(),
                                                FType = string.Format("{0:N0}", myBal * -1)
                                            });
                                        }
                                    }
                                    else
                                    {
                                        myBal = 0;
                                        myBal = (from eitm in lacc
                                                 where eitm.Code == itm.Sub3
                                                 select eitm.MBal).FirstOrDefault();
                                        Bal -= myBal;
                                        if (myBal != 0)
                                        {
                                            myResult.Add(new Acc1
                                            {
                                                Name1 = (from eitm in lacc
                                                         where eitm.Code == itm.Sub3
                                                         select eitm.Name1).FirstOrDefault(),
                                                FType = string.Format("{0:N0}", myBal * -1)
                                            });
                                        }
                                    }
                                }
                                if (!string.IsNullOrEmpty(itm.Sub4))
                                {
                                    if (itm.Sub4.StartsWith("1") || itm.Sub4.StartsWith("2"))
                                    {
                                        myBal = 0;
                                        myBal = (from eitm in lacc
                                                 where eitm.Code == itm.Sub4
                                                 select eitm.Bal).FirstOrDefault();
                                        Bal -= myBal;
                                        if (myBal != 0)
                                        {
                                            myResult.Add(new Acc1
                                            {
                                                Name1 = (from eitm in lacc
                                                         where eitm.Code == itm.Sub4
                                                         select eitm.Name1).FirstOrDefault(),
                                                FType = string.Format("{0:N0}", myBal * -1)
                                            });
                                        }
                                    }
                                    else
                                    {
                                        myBal = 0;
                                        myBal = (from eitm in lacc
                                                 where eitm.Code == itm.Sub4
                                                 select eitm.MBal).FirstOrDefault();
                                        Bal -= myBal;
                                        if (myBal != 0)
                                        {
                                            myResult.Add(new Acc1
                                            {
                                                Name1 = (from eitm in lacc
                                                         where eitm.Code == itm.Sub4
                                                         select eitm.Name1).FirstOrDefault(),
                                                FType = string.Format("{0:N0}", myBal * -1)
                                            });
                                        }
                                    }

                                }
                                if (!string.IsNullOrEmpty(itm.Sub5))
                                {
                                    if (itm.Sub1.StartsWith("1") || itm.Sub1.StartsWith("2"))
                                    {
                                        myBal = 0;
                                        myBal = (from eitm in lacc
                                                 where eitm.Code == itm.Sub5
                                                 select eitm.Bal).FirstOrDefault();
                                        Bal -= myBal;
                                        if (myBal != 0)
                                        {
                                            myResult.Add(new Acc1
                                            {
                                                Name1 = (from eitm in lacc
                                                         where eitm.Code == itm.Sub5
                                                         select eitm.Name1).FirstOrDefault(),
                                                FType = string.Format("{0:N0}", myBal * -1)
                                            });
                                        }
                                    }
                                    else
                                    {
                                        myBal = 0;
                                        myBal = (from eitm in lacc
                                                 where eitm.Code == itm.Sub5
                                                 select eitm.MBal).FirstOrDefault();
                                        Bal -= myBal;
                                        if (myBal != 0)
                                        {
                                            myResult.Add(new Acc1
                                            {
                                                Name1 = (from eitm in lacc
                                                         where eitm.Code == itm.Sub5
                                                         select eitm.Name1).FirstOrDefault(),
                                                FType = string.Format("{0:N0}", myBal * -1)
                                            });
                                        }
                                    }

                                }
                                if (!string.IsNullOrEmpty(itm.Sub6))
                                {
                                    Bal -= setValue((from eitm in lacc
                                                     where eitm.Code == itm.Sub6
                                                     select eitm.MBal).FirstOrDefault());

                                }
                                if (!string.IsNullOrEmpty(itm.Sub7))
                                {
                                    Bal -= setValue((from eitm in lacc
                                                     where eitm.Code == itm.Sub7
                                                     select eitm.MBal).FirstOrDefault());

                                }
                                if (!string.IsNullOrEmpty(itm.Sub8))
                                {
                                    Bal -= setValue((from eitm in lacc
                                                     where eitm.Code == itm.Sub8
                                                     select eitm.MBal).FirstOrDefault());

                                }
                                if (!string.IsNullOrEmpty(itm.Sub9))
                                {
                                    Bal -= setValue((from eitm in lacc
                                                     where eitm.Code == itm.Sub9
                                                     select eitm.MBal).FirstOrDefault());

                                }
                                if (!string.IsNullOrEmpty(itm.Sub10))
                                {
                                    Bal -= setValue((from eitm in lacc
                                                     where eitm.Code == itm.Sub10
                                                     select eitm.MBal).FirstOrDefault());

                                }                             
                            }

                        }
                        if (Bal != 0)
                        {

                            myResult.Add(new Acc1
                            {
                                Name1 = "",
                                Name2 = "",
                                FType = "______________",
                                FCode = ""
                            });

                            myResult.Add(new Acc1
                            {
                                Name1 = "الاجمالي",
                                Name2 = "الاجمالي",
                                FType = string.Format("{0:N0}", Bal)
                            });

                            myResult.Add(new Acc1
                            {
                                Name1 = "",
                                Name2 = "",
                                FType = "══════════",
                                FCode = ""
                            });
                        }
                    }
                    return myResult;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}

