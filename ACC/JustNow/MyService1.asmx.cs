using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;

namespace ACC.JustNow
{
    /// <summary>
    /// Summary description for MyService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class MyService1 : System.Web.Services.WebService
    {
        public MyService1()
        {
        }


        [WebMethod]
        public string HelloWorld(string test)
        {
            return "Hello World " + test;
        }


        [WebMethod]
        public List<TrackMove> GetTrackMoveIN(string AreaNo)
        {
           // if (Puk == "0502181968")
           // {
                return (List<TrackMove>)(HttpRuntime.Cache["OverTrack_" + AreaNo + "2014-2015-2016"]);
           // }
           // else return null;
        }
    }
}
