using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class MyPO
    {
        public short Branch { get; set; }
        public short LocNumber { get; set; }
        public short FType { get; set; }
        public int Number { get; set; }
        public short FNo { get; set; }
        public string FDate { get; set; }
        public string Item { get; set; }
        public double? Qty { get; set; }
        public double? Price { get; set; }
        public short? Approved { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public string VouNo { get; set; }
        public string VouNo2 { get; set; }
        public double Amount
        {
            get
            {
                return (double)(this.Price * this.Qty);
            }
        }

        public MyPO()
        {
            this.Branch = 0;
            this.LocNumber = 0;
            this.FType = 0;
            this.Number = 0;
            this.FNo = 1;
            this.FDate = "";
            this.Item = "";
            this.Qty = 1;
            this.Price = 0;
            this.Approved = 0;
            this.UserName = "";
            this.UserDate = "";
            this.VouNo = "";
            this.VouNo2 = "";
        }

        /// <summary>
        /// Add Item in MyPo Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.MyPOInsert(this.Branch, this.LocNumber , this.FType , this.Number , this.FNo , this.FDate,this.Item , this.Qty , this.Price , this.Approved , this.UserName , this.UserDate, this.VouNo , this.VouNo2);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Update Approved Status for Item in MyPo Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool UpdateStatus(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.MyPOUpDateStatus(this.Branch, this.LocNumber, this.FType, this.Number, this.FNo,this.Approved);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Item from MyPro Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.MyPODelete(this.Branch, this.LocNumber,this.FType, this.Number);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select all Cars from MyPO Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<MyPO> Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.MyPOGet(this.Branch, this.LocNumber, this.FType, this.Number);
                    return (from itm in result
                            select new MyPO
                            {
                                Branch = itm.Branch,
                                LocNumber = itm.LocNumber,
                                FType = itm.FType,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                FDate = itm.FDate,
                                Item = itm.Item,
                                Qty = itm.Qty,
                                Price = itm.Price,
                                Approved = itm.Approved,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                VouNo = itm.VouNo,
                                VouNo2 = itm.VouNo2
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cars from MyPO Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public MyPO GetVouNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.MyPOGetByVouNo(this.Branch, this.LocNumber, this.FType, this.VouNo);
                    return (from itm in result
                            select new MyPO
                            {
                                Branch = itm.Branch,
                                LocNumber = itm.LocNumber,
                                FType = itm.FType,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                FDate = itm.FDate,
                                Item = itm.Item,
                                Qty = itm.Qty,
                                Price = itm.Price,
                                Approved = itm.Approved,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                VouNo = itm.VouNo,
                                VouNo2 = itm.VouNo2
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cars from MyPO Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public MyPO Find2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.MyPOGetFNo(this.Branch, this.LocNumber, this.FType, this.Number, this.FNo);
                    return (from itm in result
                            select new MyPO
                            {
                                Branch = itm.Branch,
                                LocNumber = itm.LocNumber,
                                FType = itm.FType,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                FDate = itm.FDate,
                                Item = itm.Item,
                                Qty = itm.Qty,
                                Price = itm.Price,
                                Approved = itm.Approved,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                VouNo = itm.VouNo,
                                VouNo2 = itm.VouNo2
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Cars from MyPO Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<MyPO> NotApproved(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.MyPOGetNotApproved(this.Branch, this.LocNumber);
                    return (from itm in result
                            select new MyPO
                            {
                                Branch = itm.Branch,
                                LocNumber = itm.LocNumber,
                                FType = itm.FType,
                                Number = itm.Number,
                                FDate = itm.FDate,
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cars from MyPO Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<MyPO> NotPaid(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.MyPOGetNotPaid(this.Branch, this.LocNumber);
                    return (from itm in result
                            select new MyPO
                            {
                                Branch = itm.Branch,
                                LocNumber = itm.LocNumber,
                                FType = itm.FType,
                                Number = itm.Number,
                                FDate = itm.FDate,
                                Price = itm.amount
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Get New Code for MyPO Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public int? GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.MyPOMaxCode(this.Branch, this.LocNumber , this.FType);
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
}