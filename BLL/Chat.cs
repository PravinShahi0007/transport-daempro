using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Chat
    {
        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public DateTime? MyDate { get; set; }
        public string Msg { get; set; }
        public bool? FRead { get; set; }
        public bool? FDisplay { get; set; }
        /// <summary>
        /// 
        /// Add Area in Area Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.ChatInsert(this.FromUser, this.ToUser, this.MyDate, this.Msg , this.FRead , this.FDisplay);
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
                    myContext.ChatDelete(this.MyDate);
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
        public bool SetRead(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.ChatRead(this.ToUser);
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
        public List<Chat> GetAllUser(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.ChatGetAll(this.FromUser);
                    return (from itm in result
                            select new Chat
                            {
                                FromUser = itm.FromUser,
                                Msg = itm.Msg + " أرسلت من قبل " + itm.FromUser + " إلى " + (itm.ToUser == "-1" ? "الجميع" : itm.ToUser),
                                MyDate = itm.MyDate,
                                ToUser = itm.ToUser == "-1" ? "الجميع" : itm.ToUser,
                                FRead = itm.FRead,
                                FDisplay = itm.FDisplay
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
        public List<Chat> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.ChatGetAlls();
                    return (from itm in result
                            select new Chat
                            {
                                FromUser = itm.FromUser,
                                Msg = itm.Msg + " أرسلت من قبل " + itm.FromUser + " إلى " + (itm.ToUser == "-1" ? "الجميع" : itm.ToUser),
                                MyDate = itm.MyDate,
                                ToUser = itm.ToUser == "-1" ? "الجميع" : itm.ToUser,
                                FRead = itm.FRead,
                                FDisplay = itm.FDisplay
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
        public List<Chat> GetAll2(string ConnectionStr,DateTime StartDate,DateTime EndDate)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.ChatGetAll2(StartDate,EndDate,this.FromUser);
                    return (from itm in result
                            select new Chat
                            {
                                FromUser = itm.FromUser,
                                Msg = itm.Msg + " أرسلت من قبل " + itm.FromUser + " إلى " + (itm.ToUser == "-1" ? "الجميع" : itm.ToUser),
                                MyDate = itm.MyDate,
                                ToUser = itm.ToUser == "-1" ? "الجميع" : itm.ToUser,
                                FRead = itm.FRead,
                                FDisplay = itm.FDisplay
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
