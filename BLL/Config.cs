using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public static class Config
    {
        public static string GetImageName(string ConnectionStr)
        {
            using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
            {
                return "ERPImage"+myContext.ConfigGetImage().FirstOrDefault().myCode.ToString();
            }
        }
    }
}
