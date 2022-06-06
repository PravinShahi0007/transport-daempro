using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class MyHelp
    {
        public string Code { get; set; }
        public string FCode { get; set; }
        public System.Nullable<short> FLevel { get; set; }
        public string Item { get; set; }
        public string Item2 { get; set; }
        public string SubItem { get; set; }
        public string SubItem2 { get; set; }

        /// <summary>
        /// select all Codes for Spec. FType from Codes Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<MyHelp> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.HelpGetAll();
                    return (from itm in result
                            select new MyHelp
                            {
                                 Code = itm.Code,
                                 FCode = itm.FCode,
                                 FLevel = itm.FLevel,
                                 Item = itm.Item,
                                 Item2 = itm.Item2,
                                 SubItem = itm.SubItem,
                                 SubItem2 = itm.SubItem2
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }

    [Serializable]
    public class MyHelp2
    {
        public string Code { get; set; }
        public string FCode { get; set; }
        public System.Nullable<short> FLevel { get; set; }
        public string Item { get; set; }
        public string SubItem { get; set; }
    }


}
