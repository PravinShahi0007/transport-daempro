using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Class1
    {
    }

    public partial class DataERPDataContext : System.Data.Linq.DataContext
    {
        partial void OnCreated()
        {

            //Put your desired timeout here.
            base.CommandTimeout = 36000;

            //If you do not want to hard code it, then take it 
            //from Application Settings / AppSettings
            //this.CommandTimeout = Settings.Default.CommandTimeout;
        }
    }

    public partial class DataERP2DataContext : System.Data.Linq.DataContext
    {
        partial void OnCreated()
        {

            //Put your desired timeout here.
            base.CommandTimeout = 36000;

            //If you do not want to hard code it, then take it 
            //from Application Settings / AppSettings
            //this.CommandTimeout = Settings.Default.CommandTimeout;
        }
    }

    public partial class DataERP3DataContext : System.Data.Linq.DataContext
    {
        partial void OnCreated()
        {

            //Put your desired timeout here.
            base.CommandTimeout = 36000;

            //If you do not want to hard code it, then take it 
            //from Application Settings / AppSettings
            //this.CommandTimeout = Settings.Default.CommandTimeout;
        }
    }
}
