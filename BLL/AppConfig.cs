using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class AppConfig
    {
        public string Time1 { get; set; }
        public string Time2 { get; set; }
        public string Time3 { get; set; }


        public AppConfig()
        {
            Time1 = "";
            Time2 = "";
            Time3 = "";
           
        }


        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.AppConfigUpdate(this.Time1,this.Time2,this.Time3);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <returns>AppConfig or null if Fail</returns>
        public AppConfig GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.AppConfigGet();
                    return (from itm in result
                            select new AppConfig
                            {
                                Time1 = itm.Time1,
                                Time2 = itm.Time2,
                                Time3 = itm.Time3
                              
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
