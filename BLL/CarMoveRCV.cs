using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class CarMoveRCV
    {
        public short Branch { get; set; }
        public short LocNumber { get; set; }
        public int Number { get; set; }
        public string CarMove { get; set; }
        public string Remark { get; set; }
        public string GDate { get; set; }
        public string FTime { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }

        public CarMoveRCV()
        {
            Branch = 1;
            LocNumber = 0;
            Number = 0;
            CarMove = "";
            Remark = "";
            GDate = "";
            FTime = "";
            UserName = "";
            UserDate = "";
        }

        /// <summary>
        /// Add Car Transfer Price in CarPrices Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CarMoveRCVInsert(this.Branch,this.LocNumber,this.Number,this.CarMove,this.Remark,this.GDate,this.FTime,this.UserName,this.UserDate);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Car Transfer Price from CarPrices Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CarMoveRCVDelete(this.Branch, this.LocNumber, this.Number);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Car Transfer Price in CarPrices Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CarMoveRCVUpdate(this.Branch, this.LocNumber, this.Number, this.CarMove, this.Remark, this.GDate, this.FTime, this.UserName, this.UserDate);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
           
        /// <summary>
        /// select all Car Transfer Prices from CarPrices Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public CarMoveRCV Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarMoveRCVFind(this.Branch, this.LocNumber, this.Number);
                    return (from itm in result
                            select new CarMoveRCV
                            {
                                 Branch = itm.Branch,
                                 CarMove = itm.CarMove,
                                 FTime = itm.FTime,
                                 GDate = itm.GDate,
                                 LocNumber = itm.LocNumber,
                                 Number = itm.Number,
                                 Remark = itm.Remark,
                                 UserDate = itm.UserDate,
                                 UserName = itm.UserName
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Car Transfer Prices from CarPrices Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CarMoveRCV> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarMoveRCVGetAll(this.Branch);
                    return (from itm in result
                            select new CarMoveRCV
                            {
                                Branch = itm.Branch,
                                CarMove = itm.CarMove,
                                FTime = itm.FTime,
                                GDate = itm.GDate,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                Remark = itm.Remark,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Car Transfer Prices from CarPrices Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public CarMoveRCV Find2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarMoveRCVFind2(this.Branch, this.CarMove);
                    return (from itm in result
                            select new CarMoveRCV
                            {
                                Branch = itm.Branch,
                                CarMove = itm.CarMove,
                                FTime = itm.FTime,
                                GDate = itm.GDate,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                Remark = itm.Remark,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName
                            }).FirstOrDefault();
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
                    var result = myContext.CarMoveRCVMaxCode(this.Branch, this.LocNumber);
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