using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    [Serializable]
    public class Shop
    {
        public short FType { get; set; }
        public short Bran { get; set; }
        public short Number { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Manager { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Remark { get; set; }
        public string CSal_No { get; set; }
        public string CrSal_No { get; set; }
        public string RCSal_No { get; set; }
        public string RCRSal_No { get; set; }
        public string CPur_No { get; set; }
        public string CrPur_No { get; set; }
        public string RCPur_No { get; set; }
        public string RCRPur_No { get; set; }
        public string Transfer { get; set; }
        public string RecepNo { get; set; }
        public string CRecepNo { get; set; }
        public string PayNo { get; set; }
        public string CPayNo { get; set; }
        public string JourNo { get; set; }
        public string JOrderNo { get; set; }
        public string POrderNo { get; set; }
        public string ProcessNo { get; set; }
        public string Cash_Acc { get; set; }
        public string CSal_Acc { get; set; }
        public string CrSal_Acc { get; set; }
        public string RCSal_Acc { get; set; }
        public string RCRSal_Acc { get; set; }
        public string CPur_Acc { get; set; }
        public string CrPur_Acc { get; set; }
        public string RCPur_Acc { get; set; }
        public string RCRPur_Acc { get; set; }
        public string PDisc_Acc { get; set; }
        public string SDisc_Acc { get; set; }
        public string Service_Acc { get; set; }
        public string Tips_Acc { get; set; }


        public Shop()
        {
            FType = 0;
            Bran = 0;
            Number = 0;
            Name1 = "";
            Name2 = "";
            Manager = "";
            Address = "";
            Tel = "";
            Remark = "";
            CSal_No = "";
            CrSal_No = "";
            RCSal_No = "";
            RCRSal_No = "";
            CPur_No = "";
            CrPur_No = "";
            RCPur_No = "";
            RCRPur_No = "";
            Transfer = "";
            RecepNo = "";
            CRecepNo = "";
            PayNo = "";
            CPayNo = "";
            JourNo = "";
            JOrderNo = "";
            POrderNo = "";
            ProcessNo = "";
            Cash_Acc = "";
            CSal_Acc = "";
            CrSal_Acc = "";
            RCSal_Acc = "";
            RCRSal_Acc = "";
            CPur_Acc = "";
            CrPur_Acc = "";
            RCPur_Acc = "";
            RCRPur_Acc = "";
            PDisc_Acc = "";
            SDisc_Acc = "";
            Service_Acc = "";
            Tips_Acc = "";
        }


        /// <summary>
        /// Add Branch or Stores in Shop Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShopInsert(this.FType, this.Bran, this.Number, this.Name1, this.Name2, this.Manager, this.Address, this.Tel, this.Remark, this.CSal_No,
                        this.CrSal_No, this.RCSal_No, this.RCRSal_No, this.CPur_No, this.CrPur_No, this.RCPur_No, this.RCRPur_No, this.Transfer, this.RecepNo, this.PayNo,
                        this.CRecepNo, this.CPayNo, this.JourNo, this.JOrderNo, this.POrderNo, this.ProcessNo, this.Cash_Acc, this.CSal_Acc, this.CrSal_Acc, this.RCSal_Acc,
                        this.RCRSal_Acc, this.CPur_Acc, this.CrPur_Acc, this.RCPur_Acc, this.RCRPur_Acc, this.PDisc_Acc, this.SDisc_Acc, this.Service_Acc, this.Tips_Acc);

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Branch or Stores from Shop Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShopDelete(this.FType, this.Bran, this.Number);

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Branch or Store in Shop Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShopUpdate(this.FType, this.Bran, this.Number, this.Name1, this.Name2, this.Manager, this.Address, this.Tel, this.Remark, this.CSal_No,
                        this.CrSal_No, this.RCSal_No, this.RCRSal_No, this.CPur_No, this.CrPur_No, this.RCPur_No, this.RCRPur_No, this.Transfer, this.RecepNo, this.PayNo,
                        this.CRecepNo, this.CPayNo, this.JourNo, this.JOrderNo, this.POrderNo, this.ProcessNo, this.Cash_Acc, this.CSal_Acc, this.CrSal_Acc, this.RCSal_Acc,
                        this.RCRSal_Acc, this.CPur_Acc, this.CrPur_Acc, this.RCPur_Acc, this.RCRPur_Acc, this.PDisc_Acc, this.SDisc_Acc, this.Service_Acc, this.Tips_Acc);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// select all Branch or Stores from Shop Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<Shop> GetAllType(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShopGetAll(this.FType, this.Bran);
                    return (from itm in result
                            select new Shop
                            {
                                FType = itm.FType,
                                Bran = itm.Bran,
                                Number = itm.Number,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Manager = itm.Manager,
                                Address = itm.Address,
                                Tel = itm.Tel,
                                Remark = itm.Remark,
                                CSal_No = itm.CSal_No,
                                CrSal_No = itm.CrSal_No,
                                RCSal_No = itm.RCSal_No,
                                RCRSal_No = itm.RCRSal_No,
                                CPur_No = itm.CPur_No,
                                CrPur_No = itm.CrPur_No,
                                RCPur_No = itm.RCPur_No,
                                RCRPur_No = itm.RCRPur_No,
                                Transfer = itm.Transfer,
                                RecepNo = itm.RecepNo,
                                PayNo = itm.PayNo,
                                CRecepNo = itm.CRecepNo,
                                CPayNo = itm.CPayNo,
                                JourNo = itm.JourNo,
                                JOrderNo = itm.JOrderNo,
                                POrderNo = itm.POrderNo,
                                ProcessNo = itm.ProcessNo,
                                Cash_Acc = itm.Cash_Acc,
                                CSal_Acc = itm.CSal_Acc,
                                CrSal_Acc = itm.CrSal_Acc,
                                RCSal_Acc = itm.CrSal_Acc,
                                RCRSal_Acc = itm.RCRSal_Acc,
                                CPur_Acc = itm.CPur_Acc,
                                CrPur_Acc = itm.CrPur_Acc,
                                RCPur_Acc = itm.RCPur_Acc,
                                RCRPur_Acc = itm.RCPur_Acc,
                                PDisc_Acc = itm.PDisc_Acc,
                                SDisc_Acc = itm.SDisc_Acc,
                                Service_Acc = itm.Service_Acc,
                                Tips_Acc = itm.Tips_Acc
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Branch or Stores from Shop Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<Shop> GetAllType2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShopGetAll2(this.FType);
                    return (from itm in result
                            select new Shop
                            {
                                FType = itm.FType,
                                Bran = itm.Bran,
                                Number = itm.Number,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Manager = itm.Manager,
                                Address = itm.Address,
                                Tel = itm.Tel,
                                Remark = itm.Remark,
                                CSal_No = itm.CSal_No,
                                CrSal_No = itm.CrSal_No,
                                RCSal_No = itm.RCSal_No,
                                RCRSal_No = itm.RCRSal_No,
                                CPur_No = itm.CPur_No,
                                CrPur_No = itm.CrPur_No,
                                RCPur_No = itm.RCPur_No,
                                RCRPur_No = itm.RCRPur_No,
                                Transfer = itm.Transfer,
                                RecepNo = itm.RecepNo,
                                PayNo = itm.PayNo,
                                CRecepNo = itm.CRecepNo,
                                CPayNo = itm.CPayNo,
                                JourNo = itm.JourNo,
                                JOrderNo = itm.JOrderNo,
                                POrderNo = itm.POrderNo,
                                ProcessNo = itm.ProcessNo,
                                Cash_Acc = itm.Cash_Acc,
                                CSal_Acc = itm.CSal_Acc,
                                CrSal_Acc = itm.CrSal_Acc,
                                RCSal_Acc = itm.CrSal_Acc,
                                RCRSal_Acc = itm.RCRSal_Acc,
                                CPur_Acc = itm.CPur_Acc,
                                CrPur_Acc = itm.CrPur_Acc,
                                RCPur_Acc = itm.RCPur_Acc,
                                RCRPur_Acc = itm.RCPur_Acc,
                                PDisc_Acc = itm.PDisc_Acc,
                                SDisc_Acc = itm.SDisc_Acc,
                                Service_Acc = itm.Service_Acc,
                                Tips_Acc = itm.Tips_Acc
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select Single Branch or Store from Shop Table
        /// </summary>
        /// <returns>True of success or false if Fail</returns>
        public Boolean GetShop(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShopGet(this.FType, this.Bran, this.Number).FirstOrDefault();
                    if (result != null)
                    {
                        this.FType = result.FType;
                        this.Bran = result.Bran;
                        this.Number = result.Number;
                        this.Name1 = result.Name1;
                        this.Name2 = result.Name2;
                        this.Manager = result.Manager;
                        this.Address = result.Address;
                        this.Tel = result.Tel;
                        this.Remark = result.Remark;
                        this.CSal_No = result.CSal_No;
                        this.CrSal_No = result.CrSal_No;
                        this.RCSal_No = result.RCSal_No;
                        this.RCRSal_No = result.RCRSal_No;
                        this.CPur_No = result.CPur_No;
                        this.CrPur_No = result.CrPur_No;
                        this.RCPur_No = result.RCPur_No;
                        this.RCRPur_No = result.RCRPur_No;
                        this.Transfer = result.Transfer;
                        this.RecepNo = result.RecepNo;
                        this.PayNo = result.PayNo;
                        this.CRecepNo = result.CRecepNo;
                        this.CPayNo = result.CPayNo;
                        this.JourNo = result.JourNo;
                        this.JOrderNo = result.JOrderNo;
                        this.POrderNo = result.POrderNo;
                        this.ProcessNo = result.ProcessNo;
                        this.Cash_Acc = result.Cash_Acc;
                        this.CSal_Acc = result.CSal_Acc;
                        this.CrSal_Acc = result.CrSal_Acc;
                        this.RCSal_Acc = result.CrSal_Acc;
                        this.RCRSal_Acc = result.RCRSal_Acc;
                        this.CPur_Acc = result.CPur_Acc;
                        this.CrPur_Acc = result.CrPur_Acc;
                        this.RCPur_Acc = result.RCPur_Acc;
                        this.RCRPur_Acc = result.RCPur_Acc;
                        this.PDisc_Acc = result.PDisc_Acc;
                        this.SDisc_Acc = result.SDisc_Acc;
                        this.Service_Acc = result.Service_Acc;
                        this.Tips_Acc = result.Tips_Acc;
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
        /// Get New Code for Shop Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public string GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShopMaxCode(this.FType);
                    return (from Cat in result
                            select Cat.myCode).FirstOrDefault().ToString();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get New Code for Shop Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public string GetNewStore(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShopMaxStore(this.FType, this.Bran);
                    return (from Cat in result
                            select Cat.myCode).FirstOrDefault().ToString();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


    }

}
