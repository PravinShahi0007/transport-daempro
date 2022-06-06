using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Configuration;
using BLL;

namespace ACC
{
    /// <summary>
    /// Summary description for AutoComplete
    /// </summary>
    [WebService(Namespace = "http://isofttec.net/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AutoComplete : System.Web.Services.WebService
    {
        public AutoComplete()
        {
        }


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(EnableSession = true)]
        public string[] GetSupportData(string prefixText, int count, string contextKey)
        {
            if (count == 0)
            {
                count = 10;
            }

            List<string> items = new List<string>();
            if (contextKey == "0")
            {
                items = (from itm in (List<string>)(HttpRuntime.Cache["RecMobileNoList" + HttpContext.Current.Session["CNN2"].ToString()])
                         where itm.StartsWith(prefixText)
                         select itm).ToList();
            }
            else if (contextKey == "1")
            {
                items = (from itm in (List<string>)(HttpRuntime.Cache["MobileNoList" + HttpContext.Current.Session["CNN2"].ToString()])
                         where itm.StartsWith(prefixText)
                         select itm).ToList();
            }
            else if (contextKey == "2")
            {
                items = (from itm in (List<string>)(HttpRuntime.Cache["IDNoList" + HttpContext.Current.Session["CNN2"].ToString()])
                         where itm.StartsWith(prefixText)
                         select itm).ToList();
            }
            else if (contextKey == "3")
            {
                items = (from itm in (List<string>)(HttpRuntime.Cache["VouNoList" + HttpContext.Current.Session["CNN2"].ToString()])
                         where itm.StartsWith(prefixText)
                         select itm).ToList();
            }
            else if (contextKey == "4")
            {
                items = (from itm in (List<string>)(HttpRuntime.Cache["PlateNoList" + HttpContext.Current.Session["CNN2"].ToString()])
                         where itm.Contains(prefixText)
                         select itm).ToList();
            }
            else if (contextKey == "5")
            {
                items = (from itm in (List<string>)(HttpRuntime.Cache["ChassisNoList" + HttpContext.Current.Session["CNN2"].ToString()])
                         where itm.Contains(prefixText)
                         select itm).ToList();
            }
            else if (contextKey == "6")
            {
                items = (from itm in (List<string>)(HttpRuntime.Cache["NameList" + HttpContext.Current.Session["CNN2"].ToString()])
                         where itm.Contains(prefixText)
                         select itm).ToList();
            }
            else if (contextKey == "7")
            {
                items = (from itm in (List<string>)(HttpRuntime.Cache["RecNameList" + HttpContext.Current.Session["CNN2"].ToString()])
                         where itm.Contains(prefixText)
                         select itm).ToList();
            }
            else if (contextKey == "10")
            {
                items = (from itm in (List<string>)(HttpRuntime.Cache["LRecMobileNoList" + HttpContext.Current.Session["CNN2"].ToString()])
                         where itm.StartsWith(prefixText)
                         select itm).ToList();
            }
            else if (contextKey == "11")
            {
                items = (from itm in (List<string>)(HttpRuntime.Cache["LMobileNoList" + HttpContext.Current.Session["CNN2"].ToString()])
                         where itm.StartsWith(prefixText)
                         select itm).ToList();
            }
            else if (contextKey == "12")
            {
                items = (from itm in (List<string>)(HttpRuntime.Cache["LIDNoList" + HttpContext.Current.Session["CNN2"].ToString()])
                         where itm.StartsWith(prefixText)
                         select itm).ToList();
            }
            else if (contextKey == "13")
            {
                items = (from itm in (List<string>)(HttpRuntime.Cache["LVouNoList" + HttpContext.Current.Session["CNN2"].ToString()])
                         where itm.StartsWith(prefixText)
                         select itm).ToList();
            }
            else if (contextKey == "16")
            {
                items = (from itm in (List<string>)(HttpRuntime.Cache["LNameList" + HttpContext.Current.Session["CNN2"].ToString()])
                         where itm.Contains(prefixText)
                         select itm).ToList();
            }
            else if (contextKey == "17")
            {
                items = (from itm in (List<string>)(HttpRuntime.Cache["LRecNameList" + HttpContext.Current.Session["CNN2"].ToString()])
                         where itm.Contains(prefixText)
                         select itm).ToList();
            }
            if (contextKey == "20")
            {
                items = (from itm in (List<string>)(HttpRuntime.Cache["ERecMobileNoList" + HttpContext.Current.Session["CNN2"].ToString()])
                         where itm.StartsWith(prefixText)
                         select itm).ToList();
            }
            else if (contextKey == "21")
            {
                items = (from itm in (List<string>)(HttpRuntime.Cache["EMobileNoList" + HttpContext.Current.Session["CNN2"].ToString()])
                         where itm.StartsWith(prefixText)
                         select itm).ToList();
            }
            else if (contextKey == "22")
            {
                items = (from itm in (List<string>)(HttpRuntime.Cache["EIDNoList" + HttpContext.Current.Session["CNN2"].ToString()])
                         where itm.StartsWith(prefixText)
                         select itm).ToList();
            }
            else if (contextKey == "23")
            {
                items = (from itm in (List<string>)(HttpRuntime.Cache["EVouNoList" + HttpContext.Current.Session["CNN2"].ToString()])
                         where itm.StartsWith(prefixText)
                         select itm).ToList();
            }
            else if (contextKey == "26")
            {
                items = (from itm in (List<string>)(HttpRuntime.Cache["ENameList" + HttpContext.Current.Session["CNN2"].ToString()])
                         where itm.Contains(prefixText)
                         select itm).ToList();
            }
            else if (contextKey == "27")
            {
                items = (from itm in (List<string>)(HttpRuntime.Cache["ERecNameList" + HttpContext.Current.Session["CNN2"].ToString()])
                         where itm.Contains(prefixText)
                         select itm).ToList();
            }
            return items.Take(count).ToArray();
        }

        [WebMethod(EnableSession = true)]
        public string[] GetCompletionEMP(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            SEmp myItem = new SEmp();
            List<string> items = new List<string>();
            items = (from itm in (List<SEmp>)(HttpRuntime.Cache["Emps" + HttpContext.Current.Session["CNN2"].ToString()])
                     where !string.IsNullOrEmpty(itm.Name) && itm.Name.ToUpper().Contains(prefixText.ToUpper())
                     select itm.EmpCode + " . " + itm.Name).ToList();
            return items.Take(count).ToArray();
        }

        [WebMethod(EnableSession = true)]
        public string[] GetCompletionEMP2(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            SEmp myItem = new SEmp();
            List<string> items = new List<string>();
            items = (from itm in (List<SEmp>)(HttpRuntime.Cache["Emps" + HttpContext.Current.Session["CNN2"].ToString()])
                     where !string.IsNullOrEmpty(itm.Name2) && itm.Name2.ToUpper().Contains(prefixText.ToUpper())
                     select itm.EmpCode + " . " + itm.Name2).ToList();
            return items.Take(count).ToArray();
        }

        [WebMethod(EnableSession = true)]
        public string[] GetCompletionEMPCode(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            SEmp myItem = new SEmp();
            List<string> items = new List<string>();
            items = (from itm in (List<SEmp>)(HttpRuntime.Cache["Emps" + HttpContext.Current.Session["CNN2"].ToString()])
                     where itm.EmpCode.ToString().StartsWith(prefixText)
                     select itm.EmpCode + " . " + itm.Name).ToList();
            return items.Take(count).ToArray();
        }


        [WebMethod(EnableSession = true)]
        public string[] GetCompletionList(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            Acc myAcc = new Acc();
            myAcc.Branch = 1;
            List<string> items = new List<string>();
            items = (from itm in (List<Acc1>)(HttpRuntime.Cache["LastACC" + HttpContext.Current.Session["CNN2"].ToString()])
                     where itm.Code.StartsWith(prefixText)
                     select itm.Code + " . " + itm.Name1).ToList();

            return items.Take(count).ToArray();
        }

        [WebMethod(EnableSession = true)]
        public string[] GetCompletionCodeName(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            Acc myAcc = new Acc();
            myAcc.Branch = 1;
            List<string> items = new List<string>();
            items = (from itm in (List<Acc1>)(HttpRuntime.Cache["LastACC" + HttpContext.Current.Session["CNN2"].ToString()])
                     where itm.Code.StartsWith(prefixText) || itm.Name1.ToUpper().Contains(prefixText.ToUpper()) || itm.Name2.ToUpper().Contains(prefixText.ToUpper())
                     select itm.Code + " . " + itm.Name1).ToList();

            return items.Take(count).ToArray();
        }

        [WebMethod(EnableSession = true)]
        public string[] GetCompletionCars(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            Cars myCar = new Cars();
            myCar.Branch = 1;
            if (HttpRuntime.Cache["Cars" + Session["CNN2"].ToString()] == null) HttpRuntime.Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            List<string> items = new List<string>();
            items = (from itm in (List<Cars>)(HttpRuntime.Cache["Cars" + Session["CNN2"].ToString()])
                     where (itm.CarsType == 1 || itm.CarsType == 3 || itm.CarsType == 32 || itm.CarsType == 33) && (!string.IsNullOrEmpty(itm.PlateNo) && itm.PlateNo.ToUpper().Contains(prefixText.ToUpper()))
                     orderby itm.PlateNo
                     select itm.PlateNo).ToList();
            return items.Take(count).ToArray();
        }


        [WebMethod(EnableSession = true)]
        public string[] GetCompletionCars2(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            Cars myCar = new Cars();
            myCar.Branch = 1;
            if (HttpRuntime.Cache["Cars" + Session["CNN2"].ToString()] == null) HttpRuntime.Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

            List<string> items = new List<string>();
            items = (from itm in (List<Cars>)(HttpRuntime.Cache["Cars" + Session["CNN2"].ToString()])
                     where (!string.IsNullOrEmpty(itm.PlateNo) && itm.PlateNo.ToUpper().Contains(prefixText.ToUpper())) || (!string.IsNullOrEmpty(itm.Name) && itm.Name.ToUpper().Contains(prefixText.ToUpper()))
                     orderby itm.PlateNo
                     select itm.Code + " . " + itm.CarType).ToList();
            return items.Take(count).ToArray();
        }


        [WebMethod(EnableSession = true)]
        public string[] GetCompletionCars20(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            Cars myCar = new Cars();
            myCar.Branch = 1;
            if (HttpRuntime.Cache["Cars" + Session["CNN2"].ToString()] == null) HttpRuntime.Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

            List<string> items = new List<string>();
            items = (from itm in (List<Cars>)(HttpRuntime.Cache["Cars" + Session["CNN2"].ToString()])
                     where (!string.IsNullOrEmpty(itm.PlateNo) && itm.PlateNo.ToUpper().Contains(prefixText.ToUpper())) 
                     orderby itm.PlateNo
                     select itm.Code + " . " + itm.PlateNo).ToList();
            return items.Take(count).ToArray();
        }

        [WebMethod(EnableSession = true)]
        public string[] GetCompletionCars21(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            Cars myCar = new Cars();
            myCar.Branch = 1;
            if (HttpRuntime.Cache["Cars" + Session["CNN2"].ToString()] == null) HttpRuntime.Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

            List<string> items = new List<string>();
            items = (from itm in (List<Cars>)(HttpRuntime.Cache["Cars" + Session["CNN2"].ToString()])
                     where (!string.IsNullOrEmpty(itm.CarType) && itm.CarType.ToUpper().Contains(prefixText.ToUpper()))
                     orderby itm.PlateNo
                     select itm.Code + " . " + itm.CarType).ToList();
            return items.Take(count).ToArray();
        }


        [WebMethod(EnableSession = true)]
        public string[] GetCompletionListAll(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            Acc myAcc = new Acc();
            myAcc.Branch = 1;
            List<string> items = new List<string>();
            items = (from itm in (List<Acc>)(HttpRuntime.Cache["AllACC" + HttpContext.Current.Session["CNN2"].ToString()])
                     where itm.Code.StartsWith(prefixText)
                     select itm.Code + " . " + itm.Name1).ToList();

            return items.Take(count).ToArray();
        }

        [WebMethod(EnableSession = true)]
        public string[] GetCompletionListAll2(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            Acc myAcc = new Acc();
            myAcc.Branch = 1;
            List<string> items = new List<string>();
            items = (from itm in (List<Acc>)(HttpRuntime.Cache["AllACC" + HttpContext.Current.Session["CNN2"].ToString()])
                     where !string.IsNullOrEmpty(itm.Name1) && itm.Name1.StartsWith(prefixText)
                     select itm.Code + " . " + itm.Name1).ToList();

            return items.Take(count).ToArray();
        }

        [WebMethod(EnableSession = true)]
        public string[] GetCompletionList2(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            Acc myAcc = new Acc();
            myAcc.Branch = 1;
            List<string> items = new List<string>();
            items = (from itm in (List<Acc1>)(HttpRuntime.Cache["LastACC" + HttpContext.Current.Session["CNN2"].ToString()])
                     where !string.IsNullOrEmpty(itm.Name1) && itm.Name1.ToUpper().Contains(prefixText.ToUpper())
                     select itm.Code + " . " + itm.Name1).ToList();
            return items.Take(count).ToArray();
        }

        [WebMethod(EnableSession = true)]
        public string[] GetCompletionList3(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            CostCenter myCostCenter = new CostCenter();
            myCostCenter.Branch = 1;
            List<string> items = new List<string>();
            if (HttpRuntime.Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) HttpRuntime.Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

            items = (from itm in (List<CostCenter>)(HttpRuntime.Cache["LastCostCenter" + Session["CNN2"].ToString()]) 
                     where !string.IsNullOrEmpty(itm.Name1) && itm.Name1.ToUpper().Contains(prefixText.ToUpper())
                     select itm.Code + " . " + itm.Name1).ToList();
            
            return items.Take(count).ToArray();
        }


        [WebMethod(EnableSession = true)]
        public string[] GetCompletionList4(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            AccProject myProject = new AccProject();
            myProject.Branch = 1;
            if (HttpRuntime.Cache["LastProject" + Session["CNN2"].ToString()] == null) HttpRuntime.Cache.Insert("LastProject" + Session["CNN2"].ToString(), myProject.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            List<string> items = new List<string>();
            items = (from itm in (List<AccProject>)(HttpRuntime.Cache["LastProject" + Session["CNN2"].ToString()])
                     where !string.IsNullOrEmpty(itm.Name1) && itm.Name1.ToUpper().Contains(prefixText.ToUpper())
                     select itm.Code + " . " + itm.Name1).ToList();
            return items.Take(count).ToArray();
        }

        [WebMethod(EnableSession = true)]
        public string[] GetCompletionList5(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            Area myArea = new Area();
            myArea.Branch = 1;
            if (HttpRuntime.Cache["LastArea" + Session["CNN2"].ToString()] == null) HttpRuntime.Cache.Insert("LastArea" + Session["CNN2"].ToString(), myArea.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            List<string> items = new List<string>();
            items = (from itm in (List<Area>)(HttpRuntime.Cache["LastArea" + Session["CNN2"].ToString()])
                     where !string.IsNullOrEmpty(itm.Name1) && itm.Name1.ToUpper().Contains(prefixText.ToUpper())
                     select itm.Code + " . " + itm.Name1).ToList();
            return items.Take(count).ToArray();
        }


        [WebMethod(EnableSession = true)]
        public string[] GetCompletionList6(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            CostAcc myCostAcc = new CostAcc();
            myCostAcc.Branch = 1;
            if (HttpRuntime.Cache["LastCostAcc" + Session["CNN2"].ToString()] == null) HttpRuntime.Cache.Insert("LastCostAcc" + Session["CNN2"].ToString(), myCostAcc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            List<string> items = new List<string>();
            items = (from itm in (List<CostAcc>)(HttpRuntime.Cache["LastCostAcc" + Session["CNN2"].ToString()])
                     where !string.IsNullOrEmpty(itm.Name1) && itm.Name1.ToUpper().Contains(prefixText.ToUpper())
                     select itm.Code + " . " + itm.Name1).ToList();
            return items.Take(count).ToArray();
        }


        [WebMethod(EnableSession = true)]
        public string[] GetCompletionList7(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            //CostAcc myCostAcc = new CostAcc();
            //myCostAcc.Branch = 1;
            List<string> items = new List<string>();
            //items = (from itm in myCostAcc.GetAll(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString)
            //         where itm.Name1.ToUpper().Contains(prefixText.ToUpper())
            //         select itm.Code + " . " + itm.Name1).ToList();
            return items.Take(count).ToArray();
        }

        [WebMethod(EnableSession = true)]
        public string[] GetCompletionStock(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            Item myItem = new Item();
            myItem.Branch = 1;
            List<string> items = new List<string>();
            items = (from itm in (List<Item>)(HttpRuntime.Cache["Items" + HttpContext.Current.Session["CNN2"].ToString()])
                     where itm.ITCode.Contains(prefixText)
                     select itm.ITCode + " . " + itm.ITName2).ToList();

            return items.Take(count).ToArray();
        }

        [WebMethod(EnableSession = true)]
        public string[] GetCompletionStock0(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            Item myItem = new Item();
            myItem.Branch = 1;
            List<string> items = new List<string>();
            items = (from itm in (List<Item>)(HttpRuntime.Cache["Items" + HttpContext.Current.Session["CNN2"].ToString()])
                     where itm.ITCode2.StartsWith(prefixText)
                     select itm.ITName2 + " . " + itm.ITCode2  + " . " + itm.ITCode).ToList();
            return items.Take(count).ToArray();
        }

        [WebMethod(EnableSession = true)]
        public string[] GetCompletionStock2(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            Item myItem = new Item();
            myItem.Branch = 1;
            List<string> items = new List<string>();
            items = (from itm in (List<Item>)(HttpRuntime.Cache["Items" + HttpContext.Current.Session["CNN2"].ToString()])
                     where !string.IsNullOrEmpty(itm.ITName2) && itm.ITName2.ToUpper().Contains(prefixText.ToUpper())
                     select itm.ITCode + " . " + itm.ITName2).ToList();
            return items.Take(count).ToArray();
        }

        [WebMethod(EnableSession = true)]
        public string[] GetDrivers(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            List<string> items = new List<string>();
            items = (from itm in (List<Drivers>)(HttpRuntime.Cache["Drivers" + HttpContext.Current.Session["CNN2"].ToString()])
                     where (bool)itm.Status && !string.IsNullOrEmpty(itm.Name1) && itm.Name1.ToUpper().Contains(prefixText.ToUpper())
                     select itm.Name1 + " . " + itm.MobileNo).ToList();
            return items.Take(count).ToArray();
        }

        [WebMethod(EnableSession = true)]
        public List<TrackMove> GetTrackMoveIN(string AreaNo, string Puk)
        {
            if (Puk == "0502181968")
            {
                return (List<TrackMove>)(HttpRuntime.Cache["OverTrack_" + AreaNo + HttpContext.Current.Session["CNN2"].ToString()]);
            }
            else return null;
        }

    }
}