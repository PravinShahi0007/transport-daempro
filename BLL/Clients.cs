using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Clients
    {
        public short Branch { get; set; }
        public string Code { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string IdNo { get; set; }
        public short? IdType { get; set; }
        public string IdFrom { get; set; }
        public string IdDate { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string OfficeNo { get; set; }
        public string Postal { get; set; }
        public string Manage1 { get; set; }
        public string Job1 { get; set; }
        public string MobileNo1 { get; set; }
        public string Manage2 { get; set; }
        public string Job2 { get; set; }
        public string MobileNo2 { get; set; }
        public string Manage3 { get; set; }
        public string Job3 { get; set; }
        public string MobileNo3 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public short? Payment { get; set; }
        public string Account { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Addr3 { get; set; }
        public string Addr4 { get; set; }
        public string Addr5 { get; set; }
        public string Addr6 { get; set; }
        public string Addr7 { get; set; }
        public string Addr8 { get; set; }

        public Clients()
        {
            this.Branch = 1;
            this.Code = "";
            this.Name1 = "";
            this.Name2 = "";
            this.IdNo = "";
            this.IdType = 0;
            this.IdFrom = "";
            this.IdDate = "";
            this.Address = "";
            this.MobileNo = "";
            this.Email = "";
            this.OfficeNo = "";
            this.Postal = "";
            this.Manage1 = "";
            this.Job1 = "";
            this.MobileNo1 = "";
            this.Manage2 = "";
            this.Job2 = "";
            this.MobileNo2 = "";
            this.Manage3 = "";
            this.Job3 = "";
            this.MobileNo3 = "";
            this.Email1 = "";
            this.Email2 = "";
            this.Email3 = "";
            this.Account = "-1";
            this.Payment = 0;
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
        /// Add Client in Clients Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CustInsert(this.Branch, this.Code, this.Name1, this.Name2, this.IdNo, this.IdType, this.IdFrom, this.IdDate, this.Address, this.MobileNo, this.Email, this.OfficeNo, this.Postal, this.Manage1, this.Job1, this.MobileNo1, this.Manage2, this.Job2, this.MobileNo2, this.Manage3, this.Job3, this.MobileNo3,this.Email1,this.Email2,this.Email3,this.Payment,this.Account,this.Addr1,this.Addr2,this.Addr3,this.Addr4,this.Addr5,this.Addr6,this.Addr7,this.Addr8);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Client from Clients Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CustDelete(this.Branch, this.Code);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Client in Clients Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CustUpdate(this.Branch, this.Code, this.Name1, this.Name2, this.IdNo, this.IdType, this.IdFrom, this.IdDate, this.Address, this.MobileNo, this.Email, this.OfficeNo, this.Postal, this.Manage1, this.Job1, this.MobileNo1, this.Manage2, this.Job2, this.MobileNo2, this.Manage3, this.Job3, this.MobileNo3, this.Email1, this.Email2, this.Email3, this.Payment, this.Account, this.Addr1, this.Addr2, this.Addr3, this.Addr4, this.Addr5, this.Addr6, this.Addr7, this.Addr8);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select all Clients from Clients Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<Clients> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CustGetAll(this.Branch);
                    return (from itm in result
                            select new Clients
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Address = itm.Address,
                                IdDate = itm.IDDate,
                                IdFrom = itm.IDFrom,
                                IdNo = itm.IDNo,
                                IdType = itm.IDType,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                Postal = itm.Postal,
                                OfficeNo = itm.OfficeNo,
                                Manage1 = itm.Manage1,
                                Job1 = itm.Job1,
                                MobileNo1 = itm.MobileNo1,
                                Manage2 = itm.Manage2,
                                Job2 = itm.Job2,
                                MobileNo2 = itm.MobileNo2,
                                Manage3 = itm.Manage3,
                                Job3 = itm.Job3,
                                MobileNo3 = itm.MobileNo3,
                                Email1 = itm.Email1,
                                Email2 = itm.Email2,
                                Email3 = itm.Email3,
                                Account = itm.Account,
                                Payment = itm.Payment,
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
        /// select a Client from Clients Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public Clients Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CustGet(this.Branch, this.Code);
                    return (from itm in result
                            select new Clients
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Address = itm.Address,
                                IdDate = itm.IDDate,
                                IdFrom = itm.IDFrom,
                                IdNo = itm.IDNo,
                                IdType = itm.IDType,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                Postal = itm.Postal,
                                OfficeNo = itm.OfficeNo,
                                Manage1 = itm.Manage1,
                                Job1 = itm.Job1,
                                MobileNo1 = itm.MobileNo1,
                                Manage2 = itm.Manage2,
                                Job2 = itm.Job2,
                                MobileNo2 = itm.MobileNo2,
                                Manage3 = itm.Manage3,
                                Job3 = itm.Job3,
                                MobileNo3 = itm.MobileNo3,
                                Email1 = itm.Email1,
                                Email2 = itm.Email2,
                                Email3 = itm.Email3,
                                Account = itm.Account,
                                Payment = itm.Payment,
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
        /// select a Client from Clients Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public Clients Find2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CustGet2(this.Account);
                    return (from itm in result
                            select new Clients
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Address = itm.Address,
                                IdDate = itm.IDDate,
                                IdFrom = itm.IDFrom,
                                IdNo = itm.IDNo,
                                IdType = itm.IDType,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                Postal = itm.Postal,
                                OfficeNo = itm.OfficeNo,
                                Manage1 = itm.Manage1,
                                Job1 = itm.Job1,
                                MobileNo1 = itm.MobileNo1,
                                Manage2 = itm.Manage2,
                                Job2 = itm.Job2,
                                MobileNo2 = itm.MobileNo2,
                                Manage3 = itm.Manage3,
                                Job3 = itm.Job3,
                                MobileNo3 = itm.MobileNo3,
                                Email1 = itm.Email1,
                                Email2 = itm.Email2,
                                Email3 = itm.Email3,
                                Account = itm.Account,
                                Payment = itm.Payment,
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
        /// Get New Code for Center Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public string GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CustMaxCode(this.Branch);
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
}