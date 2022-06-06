using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class CarType
    {
        public short Branch { get; set; }
        public string Code { get; set; }
        public string FCode { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public System.Nullable<bool> FUpdate { get; set; }
        public string LevelCode { get; set; }
        public string cnn { get; set; } 
        public string FType2
        {
            get
            {
                if (cnn != "" && LevelCode!="")
                {
                    PLevel myLevel = new PLevel();
                    myLevel.Branch = this.Branch;
                    myLevel.Code = this.LevelCode;
                    myLevel = myLevel.find(this.cnn);
                    if (myLevel != null) return myLevel.Name1;
                    else return "";
                }
                else return "";
            }
        }
        /// <summary>
        /// Add Cat in PCat Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CarTypeInsert(this.Branch, this.Code, this.FCode, this.Name1, this.Name2, this.FUpdate,this.LevelCode);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Cat from PCat Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CarTypeDelete(this.Branch, this.Code);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Cat in PCat Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CarTypeUpdate(this.Branch, this.Code, this.FCode, this.Name1, this.Name2, this.FUpdate , this.LevelCode);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// select all Cat from PCat Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<CarType> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarTypeGetAll(this.Branch, this.FCode);
                    return (from itm in result
                            select new CarType
                            {
                                cnn = ConnectionStr,
                                Branch = itm.Branch,
                                Code = itm.Code,
                                FCode = itm.FCode,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                FUpdate = itm.FUpdate,
                                LevelCode = itm.LevelCode
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cat from PCat Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<CarType> GetAll2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarTypeGetAll(this.Branch, this.FCode);
                    return (from itm in result
                            orderby itm.Name1
                            select new CarType
                            {
                                cnn = ConnectionStr,
                                Branch = itm.Branch,
                                Code = itm.Code,
                                FCode = itm.FCode,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                FUpdate = itm.FUpdate,
                                LevelCode = itm.LevelCode
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cat from PCat Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<CarType> GetAll3(string ConnectionStr,string iLang)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarTypeGetAll(this.Branch, this.FCode);
                    if (iLang.ToUpper() == "AR")
                    {
                        return (from itm in result
                                where (bool)itm.FUpdate
                                orderby itm.Name1
                                select new CarType
                                {
                                    cnn = ConnectionStr,
                                    Branch = itm.Branch,
                                    Code = itm.Code,
                                    FCode = itm.FCode,
                                    Name1 = itm.Name1,
                                    Name2 = itm.Name2,
                                    FUpdate = itm.FUpdate,
                                    LevelCode = itm.LevelCode
                                }).ToList();
                    }
                    else
                    {
                        return (from itm in result
                                where (bool)itm.FUpdate
                                orderby itm.Name2
                                select new CarType
                                {
                                    cnn = ConnectionStr,
                                    Branch = itm.Branch,
                                    Code = itm.Code,
                                    FCode = itm.FCode,
                                    Name1 = itm.Name1,
                                    Name2 = itm.Name2,
                                    FUpdate = itm.FUpdate,
                                    LevelCode = itm.LevelCode
                                }).ToList();
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Cat from PCat Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public CarType find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarTypeFind(this.Branch, this.Code);
                    return (from itm in result
                            select new CarType
                            {
                                cnn = ConnectionStr,
                                Branch = itm.Branch,
                                Code = itm.Code,
                                FCode = itm.FCode,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                FUpdate = itm.FUpdate,
                                LevelCode = itm.LevelCode
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Check if Cat is Father Cat
        /// </summary>
        /// <returns>True if father or False if not</returns>
        public Boolean IsFather(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    // Pending work check if there any item have same Cat. 
                    return (myContext.CarTypeGetParents(this.Branch, this.Code).Count() > 0);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Get New Code for Cat Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public string GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    // Pending work check if there any item have same Cat. 
                    var result = myContext.CarTypeMaxCode(this.Branch, this.FCode);
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
