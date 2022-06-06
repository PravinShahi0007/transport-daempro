using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class FastRepair
    {
        public short Branch { get; set; }
        public short LocType { get; set; }
        public int VouNo { get; set; }
        public System.Nullable<short> VouLoc { get; set; }
        public string VouDate { get; set; }
        public string FTime { get; set; }
        public string CarNo { get; set; }
        public string DriverNo { get; set; }
        public System.Nullable<double> Am1 { get; set; }
        public System.Nullable<double> Am2 { get; set; }
        public System.Nullable<double> Am3 { get; set; }
        public System.Nullable<double> Am4 { get; set; }
        public System.Nullable<double> Am5 { get; set; }
        public System.Nullable<double> Am6 { get; set; }
        public System.Nullable<double> Am7 { get; set; }
        public System.Nullable<double> Am8 { get; set; }
        public System.Nullable<double> Am9 { get; set; }
        public System.Nullable<double> Am10 { get; set; }
        public System.Nullable<double> Am11 { get; set; }
        public System.Nullable<double> Am12 { get; set; }
        public System.Nullable<double> Am13 { get; set; }
        public System.Nullable<double> Am14 { get; set; }
        public System.Nullable<double> Am15 { get; set; }
        public System.Nullable<double> Am16 { get; set; }
        public System.Nullable<double> Am17 { get; set; }
        public System.Nullable<double> Am18 { get; set; }
        public System.Nullable<double> Am19 { get; set; }
        public System.Nullable<double> Am20 { get; set; }
        public System.Nullable<double> Am21 { get; set; }
        public System.Nullable<double> Am22 { get; set; }
        public System.Nullable<double> Am23 { get; set; }
        public System.Nullable<double> Am24 { get; set; }
        public System.Nullable<double> Am25 { get; set; }
        public System.Nullable<double> Am26 { get; set; }
        public System.Nullable<double> Am27 { get; set; }
        public System.Nullable<double> Am28 { get; set; }
        public System.Nullable<double> Am29 { get; set; }
        public System.Nullable<double> Am30 { get; set; }
        public System.Nullable<double> Am31 { get; set; }
        public System.Nullable<double> Am32 { get; set; }
        public System.Nullable<double> Am33 { get; set; }
        public System.Nullable<double> Am34 { get; set; }
        public System.Nullable<double> Am35 { get; set; }
        public System.Nullable<double> Am36 { get; set; }
        public string Remark { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public string InvDate1 { get; set; }
        public string InvDate2 { get; set; }
        public string InvDate3 { get; set; }
        public string InvDate4 { get; set; }
        public string InvDate5 { get; set; }
        public string InvDate6 { get; set; }
        public string InvDate7 { get; set; }
        public string InvDate8 { get; set; }
        public string InvDate9 { get; set; }
        public string InvDate10 { get; set; }
        public string InvDate11 { get; set; }
        public string InvDate12 { get; set; }
        public string InvDate13 { get; set; }
        public string InvDate14 { get; set; }
        public string InvDate15 { get; set; }
        public string InvDate16 { get; set; }
        public string InvDate17 { get; set; }
        public string InvDate18 { get; set; }
        public string InvDate19 { get; set; }
        public string InvDate20 { get; set; }
        public string InvDate21 { get; set; }
        public string InvDate22 { get; set; }
        public string InvDate23 { get; set; }
        public string InvDate24 { get; set; }
        public string InvDate25 { get; set; }
        public string InvDate26 { get; set; }
        public string InvDate27 { get; set; }
        public string InvDate28 { get; set; }
        public string InvDate29 { get; set; }
        public string InvDate30 { get; set; }
        public string InvDate31 { get; set; }
        public string InvDate32 { get; set; }
        public string InvDate33 { get; set; }
        public string InvDate34 { get; set; }
        public string InvDate35 { get; set; }
        public string InvDate36 { get; set; }
        public string InvNo1 { get; set; }
        public string InvNo2 { get; set; }
        public string InvNo3 { get; set; }
        public string InvNo4 { get; set; }
        public string InvNo5 { get; set; }
        public string InvNo6 { get; set; }
        public string InvNo7 { get; set; }
        public string InvNo8 { get; set; }
        public string InvNo9 { get; set; }
        public string InvNo10 { get; set; }
        public string InvNo11 { get; set; }
        public string InvNo12 { get; set; }
        public string InvNo13 { get; set; }
        public string InvNo14 { get; set; }
        public string InvNo15 { get; set; }
        public string InvNo16 { get; set; }
        public string InvNo17 { get; set; }
        public string InvNo18 { get; set; }
        public string InvNo19 { get; set; }
        public string InvNo20 { get; set; }
        public string InvNo21 { get; set; }
        public string InvNo22 { get; set; }
        public string InvNo23 { get; set; }
        public string InvNo24 { get; set; }
        public string InvNo25 { get; set; }
        public string InvNo26 { get; set; }
        public string InvNo27 { get; set; }
        public string InvNo28 { get; set; }
        public string InvNo29 { get; set; }
        public string InvNo30 { get; set; }
        public string InvNo31 { get; set; }
        public string InvNo32 { get; set; }
        public string InvNo33 { get; set; }
        public string InvNo34 { get; set; }
        public string InvNo35 { get; set; }
        public string InvNo36 { get; set; }
        public string InvQty1 { get; set; }
        public string InvQty2 { get; set; }
        public string InvQty3 { get; set; }
        public string InvQty4 { get; set; }
        public string InvQty5 { get; set; }
        public string InvQty6 { get; set; }
        public string InvQty7 { get; set; }
        public string InvQty8 { get; set; }
        public string InvQty9 { get; set; }
        public string InvQty10 { get; set; }
        public string InvQty11 { get; set; }
        public string InvQty12 { get; set; }
        public string InvQty13 { get; set; }
        public string InvQty14 { get; set; }
        public string InvQty15 { get; set; }
        public string InvQty16 { get; set; }
        public string InvQty17 { get; set; }
        public string InvQty18 { get; set; }
        public string InvQty19 { get; set; }
        public string InvQty20 { get; set; }
        public string InvQty21 { get; set; }
        public string InvQty22 { get; set; }
        public string InvQty23 { get; set; }
        public string InvQty24 { get; set; }
        public string InvQty25 { get; set; }
        public string InvQty26 { get; set; }
        public string InvQty27 { get; set; }
        public string InvQty28 { get; set; }
        public string InvQty29 { get; set; }
        public string InvQty30 { get; set; }
        public string InvQty31 { get; set; }
        public string InvQty32 { get; set; }
        public string InvQty33 { get; set; }
        public string InvQty34 { get; set; }
        public string InvQty35 { get; set; }
        public string InvQty36 { get; set; }
        public int? JobOrder { get; set; }
        public System.Nullable<double> Tax { get; set; }

        public FastRepair()
        {
            this.Branch = 1;
            this.LocType = 2;
            this.VouNo = 0;
            this.VouLoc = 0;
            this.VouDate = "";
            this.FTime = "";
            this.CarNo = "";
            this.DriverNo = "";
            this.Am1 = 0;
            this.Am2 = 0;
            this.Am3 = 0;
            this.Am4 = 0;
            this.Am5 = 0;
            this.Am6 = 0;
            this.Am7 = 0;
            this.Am8 = 0;
            this.Am9 = 0;
            this.Am10 = 0;
            this.Am11 = 0;
            this.Am12 = 0;
            this.Am13 = 0;
            this.Am14 = 0;
            this.Am15 = 0;
            this.Am16 = 0;
            this.Am17 = 0;
            this.Am18 = 0;
            this.Am19 = 0;
            this.Am20 = 0;
            this.Am21 = 0;
            this.Am22 = 0;
            this.Am23 = 0;
            this.Am24 = 0;
            this.Am25 = 0;
            this.Am26 = 0;
            this.Am27 = 0;
            this.Am28 = 0;
            this.Am29 = 0;
            this.Am30 = 0;
            this.Am31 = 0;
            this.Am32 = 0;
            this.Am33 = 0;
            this.Am34 = 0;
            this.Am35 = 0;
            this.Am36 = 0;
            this.Remark = "";
            this.UserName = "";
            this.UserDate = "";
            this.InvDate1 = "";
            this.InvDate2 = "";
            this.InvDate3 = "";
            this.InvDate4 = "";
            this.InvDate5 = "";
            this.InvDate6 = "";
            this.InvDate7 = "";
            this.InvDate8 = "";
            this.InvDate9 = "";
            this.InvDate10 = "";
            this.InvDate11 = "";
            this.InvDate12 = "";
            this.InvDate13 = "";
            this.InvDate14 = "";
            this.InvDate15 = "";
            this.InvDate16 = "";
            this.InvDate17 = "";
            this.InvDate18 = "";
            this.InvDate19 = "";
            this.InvDate20 = "";
            this.InvDate21 = "";
            this.InvDate22 = "";
            this.InvDate23 = "";
            this.InvDate24 = "";
            this.InvDate25 = "";
            this.InvDate26 = "";
            this.InvDate27 = "";
            this.InvDate28 = "";
            this.InvDate29 = "";
            this.InvDate30 = "";
            this.InvDate31 = "";
            this.InvDate32 = "";
            this.InvDate33 = "";
            this.InvDate34 = "";
            this.InvDate35 = "";
            this.InvDate36 = "";
            this.InvNo1 = "";
            this.InvNo2 = "";
            this.InvNo3 = "";
            this.InvNo4 = "";
            this.InvNo5 = "";
            this.InvNo6 = "";
            this.InvNo7 = "";
            this.InvNo8 = "";
            this.InvNo9 = "";
            this.InvNo10 = "";
            this.InvNo11 = "";
            this.InvNo12 = "";
            this.InvNo13 = "";
            this.InvNo14 = "";
            this.InvNo15 = "";
            this.InvNo16 = "";
            this.InvNo17 = "";
            this.InvNo18 = "";
            this.InvNo19 = "";
            this.InvNo20 = "";
            this.InvNo21 = "";
            this.InvNo22 = "";
            this.InvNo23 = "";
            this.InvNo24 = "";
            this.InvNo25 = "";
            this.InvNo26 = "";
            this.InvNo27 = "";
            this.InvNo28 = "";
            this.InvNo29 = "";
            this.InvNo30 = "";
            this.InvNo31 = "";
            this.InvNo32 = "";
            this.InvNo33 = "";
            this.InvNo34 = "";
            this.InvNo35 = "";
            this.InvNo36 = "";
            this.InvQty1 = "";
            this.InvQty2 = "";
            this.InvQty3 = "";
            this.InvQty4 = "";
            this.InvQty5 = "";
            this.InvQty6 = "";
            this.InvQty7 = "";
            this.InvQty8 = "";
            this.InvQty9 = "";
            this.InvQty10 = "";
            this.InvQty11 = "";
            this.InvQty12 = "";
            this.InvQty13 = "";
            this.InvQty14 = "";
            this.InvQty15 = "";
            this.InvQty16 = "";
            this.InvQty17 = "";
            this.InvQty18 = "";
            this.InvQty19 = "";
            this.InvQty20 = "";
            this.InvQty21 = "";
            this.InvQty22 = "";
            this.InvQty23 = "";
            this.InvQty24 = "";
            this.InvQty25 = "";
            this.InvQty26 = "";
            this.InvQty27 = "";
            this.InvQty28 = "";
            this.InvQty29 = "";
            this.InvQty30 = "";
            this.InvQty31 = "";
            this.InvQty32 = "";
            this.InvQty33 = "";
            this.InvQty34 = "";
            this.InvQty35 = "";
            this.InvQty36 = "";
            this.JobOrder = 0;
            this.Tax = 0;
        }

        /// <summary>
        /// Add Area in Area Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.FastRepairAdd(this.Branch,this.LocType, this.VouNo, this.VouLoc, this.VouDate, this.FTime, this.CarNo, this.DriverNo, this.Am1, this.Am2, this.Am3, this.Am4, this.Am5, this.Am6, this.Am7, this.Am8, this.Am9, this.Am10, this.Am11, this.Am12, this.Am13, this.Am14,
                    this.Am15, this.Am16, this.Am17, this.Am18, this.Am19, this.Am20, this.Am21, this.Am22, this.Am23, this.Am24, this.Am25, this.Am26, this.Am27, this.Am28, this.Am29, this.Am30,this.Am31,this.Am32,this.Am33,this.Am34,this.Am35,this.Am36,
                    this.Remark,this.UserName,this.UserDate,this.InvDate1,this.InvDate2,this.InvDate3,this.InvDate4,this.InvDate5,this.InvDate6,this.InvDate7,this.InvDate8,this.InvDate9,this.InvDate10,this.InvDate11,this.InvDate12,this.InvDate13,this.InvDate14,
                    this.InvDate15, this.InvDate16, this.InvDate17, this.InvDate18, this.InvDate19, this.InvDate20, this.InvDate21, this.InvDate22, this.InvDate23, this.InvDate24, this.InvDate25, this.InvDate26, this.InvDate27, this.InvDate28, this.InvDate29, this.InvDate30, this.InvDate31, this.InvDate32, this.InvDate33, this.InvDate34, this.InvDate35, this.InvDate36,                    
                    this.InvNo1,this.InvNo2,this.InvNo3,this.InvNo4,this.InvNo5,this.InvNo6,this.InvNo7,this.InvNo8,this.InvNo9,this.InvNo10,this.InvNo11,this.InvNo12,this.InvNo13,this.InvNo14,
                    this.InvNo15, this.InvNo16, this.InvNo17, this.InvNo18, this.InvNo19, this.InvNo20, this.InvNo21, this.InvNo22, this.InvNo23, this.InvNo24, this.InvNo25, this.InvNo26, this.InvNo27, this.InvNo28, this.InvNo29, this.InvNo30, this.InvNo31, this.InvNo32, this.InvNo33, this.InvNo34, this.InvNo35, this.InvNo36,
                    this.InvQty1, this.InvQty2, this.InvQty3, this.InvQty4, this.InvQty5, this.InvQty6, this.InvQty7, this.InvQty8, this.InvQty9, this.InvQty10, this.InvQty11, this.InvQty12, this.InvQty13, this.InvQty14,
                    this.InvQty15, this.InvQty16, this.InvQty17, this.InvQty18, this.InvQty19, this.InvQty20, this.InvQty21, this.InvQty22, this.InvQty23, this.InvQty24, this.InvQty25, this.InvQty26, this.InvQty27, this.InvQty28, this.InvQty29, this.InvQty30, this.InvQty31, this.InvQty32, this.InvQty33, this.InvQty34, this.InvQty35, this.InvQty36,this.JobOrder,this.Tax);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Add Area in Area Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Post(string Area,String Project, string CostCenter,string CostAcc,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.FastRepairPost(this.Branch, this.VouNo, this.LocType, this.VouLoc, this.VouDate, this.FTime, this.CarNo, this.DriverNo, this.Am1, this.Am2, this.Am3, this.Am4, this.Am5, this.Am6, this.Am7, this.Am8, this.Am9, this.Am10, this.Am11, this.Am12, this.Am13, this.Am14,
                    this.Am15, this.Am16, this.Am17, this.Am18, this.Am19, this.Am20, this.Am21, this.Am22, this.Am23, this.Am24, this.Am25, this.Am26, this.Am27, this.Am28, this.Am29, this.Am30, this.Am31, this.Am32, this.Am33, this.Am34, this.Am35, this.Am36,this.Remark, this.UserName, this.UserDate,
                    this.InvDate1, this.InvDate2, this.InvDate3, this.InvDate4, this.InvDate5, this.InvDate6, this.InvDate7, this.InvDate8, this.InvDate9, this.InvDate10, this.InvDate11, this.InvDate12, this.InvDate13, this.InvDate14,
                    this.InvDate15, this.InvDate16, this.InvDate17, this.InvDate18, this.InvDate19, this.InvDate20, this.InvDate21, this.InvDate22, this.InvDate23, this.InvDate24, this.InvDate25, this.InvDate26, this.InvDate27, this.InvDate28, this.InvDate29, this.InvDate30, this.InvDate31, this.InvDate32, this.InvDate33, this.InvDate34, this.InvDate35, this.InvDate36,
                    this.InvNo1, this.InvNo2, this.InvNo3, this.InvNo4, this.InvNo5, this.InvNo6, this.InvNo7, this.InvNo8, this.InvNo9, this.InvNo10, this.InvNo11, this.InvNo12, this.InvNo13, this.InvNo14,
                    this.InvNo15, this.InvNo16, this.InvNo17, this.InvNo18, this.InvNo19, this.InvNo20, this.InvNo21, this.InvNo22, this.InvNo23, this.InvNo24, this.InvNo25, this.InvNo26, this.InvNo27, this.InvNo28, this.InvNo29, this.InvNo30, this.InvNo31, this.InvNo32, this.InvNo33, this.InvNo34, this.InvNo35, this.InvNo36,this.Tax,Area,Project,CostCenter,CostAcc);
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
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.FastRepairDelete(this.Branch,this.LocType,this.VouLoc, this.VouNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Area in Area Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.FastRepairUpdate(this.Branch,this.LocType, this.VouNo, this.VouLoc, this.VouDate, this.FTime, this.CarNo, this.DriverNo, this.Am1, this.Am2, this.Am3, this.Am4, this.Am5, this.Am6, this.Am7, this.Am8, this.Am9, this.Am10, this.Am11, this.Am12, this.Am13, this.Am14,
                    this.Am15, this.Am16, this.Am17, this.Am18, this.Am19, this.Am20, this.Am21, this.Am22, this.Am23, this.Am24, this.Am25, this.Am26, this.Am27, this.Am28, this.Am29, this.Am30, this.Am31, this.Am32, this.Am33, this.Am34, this.Am35, this.Am36,
                    this.Remark, this.UserName, this.UserDate,
                    this.InvDate1, this.InvDate2, this.InvDate3, this.InvDate4, this.InvDate5, this.InvDate6, this.InvDate7, this.InvDate8, this.InvDate9, this.InvDate10, this.InvDate11, this.InvDate12, this.InvDate13, this.InvDate14,
                    this.InvDate15, this.InvDate16, this.InvDate17, this.InvDate18, this.InvDate19, this.InvDate20, this.InvDate21, this.InvDate22, this.InvDate23, this.InvDate24, this.InvDate25, this.InvDate26, this.InvDate27, this.InvDate28, this.InvDate29, this.InvDate30, this.InvDate31, this.InvDate32, this.InvDate33, this.InvDate34, this.InvDate35, this.InvDate36,
                    this.InvNo1, this.InvNo2, this.InvNo3, this.InvNo4, this.InvNo5, this.InvNo6, this.InvNo7, this.InvNo8, this.InvNo9, this.InvNo10, this.InvNo11, this.InvNo12, this.InvNo13, this.InvNo14,
                    this.InvNo15, this.InvNo16, this.InvNo17, this.InvNo18, this.InvNo19, this.InvNo20, this.InvNo21, this.InvNo22, this.InvNo23, this.InvNo24, this.InvNo25, this.InvNo26, this.InvNo27, this.InvNo28, this.InvNo29, this.InvNo30, this.InvNo31, this.InvNo32, this.InvNo33, this.InvNo34, this.InvNo35, this.InvNo36,
                    this.InvQty1, this.InvQty2, this.InvQty3, this.InvQty4, this.InvQty5, this.InvQty6, this.InvQty7, this.InvQty8, this.InvQty9, this.InvQty10, this.InvQty11, this.InvQty12, this.InvQty13, this.InvQty14,
                    this.InvQty15, this.InvQty16, this.InvQty17, this.InvQty18, this.InvQty19, this.InvQty20, this.InvQty21, this.InvQty22, this.InvQty23, this.InvQty24, this.InvQty25, this.InvQty26, this.InvQty27, this.InvQty28, this.InvQty29, this.InvQty30, this.InvQty31, this.InvQty32, this.InvQty33, this.InvQty34, this.InvQty35, this.InvQty36,this.JobOrder,this.Tax);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Update Area in Area Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool UnPost(string myCarNo , double myAm27,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.FastRepairUnPost(myCarNo,myAm27);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }




        public List<FastRepair> GetNotAgree(short myFNo, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.FastRepairAgree(myFNo);
                    return (from itm in result
                            select new FastRepair
                            {
                                VouLoc = itm.VouLoc,
                                LocType = itm.LocType,                                 
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select  Cost Acc  from CostAcc Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public FastRepair find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.FastRepairGet(this.Branch,this.LocType, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new FastRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                Am1 = itm.Am1,
                                Am2 = itm.Am2,
                                Am3 = itm.Am3,
                                Am4 = itm.Am4,
                                Am5 = itm.Am5,
                                Am6 = itm.Am6,
                                Am7 = itm.Am7,
                                Am8 = itm.Am8,
                                Am9 = itm.Am9,
                                Am10 = itm.Am10,
                                Am11 = itm.Am11,
                                Am12 = itm.Am12,
                                Am13 = itm.Am13,
                                Am14 = itm.Am14,
                                Am15 = itm.Am15,
                                Am16 = itm.Am16,
                                Am17 = itm.Am17,
                                Am18 = itm.Am18,
                                Am19 = itm.Am19,
                                Am20 = itm.Am20,
                                Am21 = itm.Am21,
                                Am22 = itm.Am22,
                                Am23 = itm.Am23,
                                Am24 = itm.Am24,
                                Am25 = itm.Am25,
                                Am26 = itm.Am26,
                                Am27 = itm.Am27,
                                Am28 = itm.Am28,
                                Am29 = itm.Am29,
                                Am30 = itm.Am30,
                                Am31 = itm.Am31,
                                Am32 = itm.Am32,
                                Am33 = itm.Am33,
                                Am34 = itm.Am34,
                                Am35= itm.Am35,
                                Am36 = itm.Am36,
                                Remark = itm.Remark,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                InvDate1 = itm.InvDate1,
                                InvDate2 = itm.InvDate2,
                                InvDate3 = itm.InvDate3,
                                InvDate4 = itm.InvDate4,
                                InvDate5 = itm.InvDate5,
                                InvDate6 = itm.InvDate6,
                                InvDate7 = itm.InvDate7,
                                InvDate8 = itm.InvDate8,
                                InvDate9 = itm.InvDate9,
                                InvDate10 = itm.InvDate10,
                                InvDate11 = itm.InvDate11,
                                InvDate12 = itm.InvDate12,
                                InvDate13 = itm.InvDate13,
                                InvDate14 = itm.InvDate14,
                                InvDate15 = itm.InvDate15,
                                InvDate16 = itm.InvDate16,
                                InvDate17 = itm.InvDate17,
                                InvDate18 = itm.InvDate18,
                                InvDate19 = itm.InvDate19,
                                InvDate20 = itm.InvDate20,
                                InvDate21 = itm.InvDate21,
                                InvDate22 = itm.InvDate22,
                                InvDate23 = itm.InvDate23,
                                InvDate24 = itm.InvDate24,
                                InvDate25 = itm.InvDate25,
                                InvDate26 = itm.InvDate26,
                                InvDate27 = itm.InvDate27,
                                InvDate28 = itm.InvDate28,
                                InvDate29 = itm.InvDate29,
                                InvDate30 = itm.InvDate30,
                                InvDate31 = itm.InvDate31,
                                InvDate32 = itm.InvDate32,
                                InvDate33 = itm.InvDate33,
                                InvDate34 = itm.InvDate34,
                                InvDate35 = itm.InvDate35,
                                InvDate36 = itm.InvDate36,
                                InvNo1 = itm.InvNo1,
                                InvNo2 = itm.InvNo2,
                                InvNo3 = itm.InvNo3,
                                InvNo4 = itm.InvNo4,
                                InvNo5 = itm.InvNo5,
                                InvNo6 = itm.InvNo6,
                                InvNo7 = itm.InvNo7,
                                InvNo8 = itm.InvNo8,
                                InvNo9 = itm.InvNo9,
                                InvNo10 = itm.InvNo10,
                                InvNo11 = itm.InvNo11,
                                InvNo12 = itm.InvNo12,
                                InvNo13 = itm.InvNo13,
                                InvNo14 = itm.InvNo14,
                                InvNo15 = itm.InvNo15,
                                InvNo16 = itm.InvNo16,
                                InvNo17 = itm.InvNo17,
                                InvNo18 = itm.InvNo18,
                                InvNo19 = itm.InvNo19,
                                InvNo20 = itm.InvNo20,
                                InvNo21 = itm.InvNo21,
                                InvNo22 = itm.InvNo22,
                                InvNo23 = itm.InvNo23,
                                InvNo24 = itm.InvNo24,
                                InvNo25 = itm.InvNo25,
                                InvNo26 = itm.InvNo26,
                                InvNo27 = itm.InvNo27,
                                InvNo28 = itm.InvNo28,
                                InvNo29 = itm.InvNo29,
                                InvNo30 = itm.InvNo30,
                                InvNo31 = itm.InvNo31,
                                InvNo32 = itm.InvNo32,
                                InvNo33 = itm.InvNo33,
                                InvNo34 = itm.InvNo34,
                                InvNo35 = itm.InvNo35,
                                InvNo36 = itm.InvNo36,
                                InvQty1 = itm.InvQty1,
                                InvQty2 = itm.InvQty2,
                                InvQty3 = itm.InvQty3,
                                InvQty4 = itm.InvQty4,
                                InvQty5 = itm.InvQty5,
                                InvQty6 = itm.InvQty6,
                                InvQty7 = itm.InvQty7,
                                InvQty8 = itm.InvQty8,
                                InvQty9 = itm.InvQty9,
                                InvQty10 = itm.InvQty10,
                                InvQty11 = itm.InvQty11,
                                InvQty12 = itm.InvQty12,
                                InvQty13 = itm.InvQty13,
                                InvQty14 = itm.InvQty14,
                                InvQty15 = itm.InvQty15,
                                InvQty16 = itm.InvQty16,
                                InvQty17 = itm.InvQty17,
                                InvQty18 = itm.InvQty18,
                                InvQty19 = itm.InvQty19,
                                InvQty20 = itm.InvQty20,
                                InvQty21 = itm.InvQty21,
                                InvQty22 = itm.InvQty22,
                                InvQty23 = itm.InvQty23,
                                InvQty24 = itm.InvQty24,
                                InvQty25 = itm.InvQty25,
                                InvQty26 = itm.InvQty26,
                                InvQty27 = itm.InvQty27,
                                InvQty28 = itm.InvQty28,
                                InvQty29 = itm.InvQty29,
                                InvQty30 = itm.InvQty30,
                                InvQty31 = itm.InvQty31,
                                InvQty32 = itm.InvQty32,
                                InvQty33 = itm.InvQty33,
                                InvQty34 = itm.InvQty34,
                                InvQty35 = itm.InvQty35,
                                InvQty36 = itm.InvQty36,
                                JobOrder = itm.JobOrder,
                                Tax = itm.Tax
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select  Cost Acc  from CostAcc Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        /// 
        public List<FRepair> FindRef(string[] myList,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    List<FRepair> fp = new List<FRepair>();
                    var result = myContext.FastRepairGetRef(this.Branch, this.JobOrder);
                    int MyNo = 0;
                    foreach (FastRepairGetRefResult itm in result)
                    {
                        MyNo = 0;
                        if (itm.Am1 > 0)
                        {                                                        
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[0],
                                Am = itm.Am1,
                                InvDate = itm.InvDate1,
                                InvNo = itm.InvNo1,
                                InvQty = itm.InvQty1
                            });
                        }
                        if (itm.Am2 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[1],
                                Am = itm.Am2,
                                InvDate = itm.InvDate2,
                                InvNo = itm.InvNo2,
                                InvQty = itm.InvQty2
                            });
                        }
                        if (itm.Am3 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[2],
                                Am = itm.Am3,
                                InvDate = itm.InvDate3,
                                InvNo = itm.InvNo3,
                                InvQty = itm.InvQty3
                            });
                        }
                        if (itm.Am4 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[3],
                                Am = itm.Am4,
                                InvDate = itm.InvDate4,
                                InvNo = itm.InvNo4,
                                InvQty = itm.InvQty4
                            });
                        }
                        if (itm.Am5 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[4],
                                Am = itm.Am5,
                                InvDate = itm.InvDate5,
                                InvNo = itm.InvNo5,
                                InvQty = itm.InvQty5
                            });
                        }
                        if (itm.Am6 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[5],
                                Am = itm.Am6,
                                InvDate = itm.InvDate6,
                                InvNo = itm.InvNo6,
                                InvQty = itm.InvQty6
                            });
                        }
                        if (itm.Am7 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[6],
                                Am = itm.Am7,
                                InvDate = itm.InvDate7,
                                InvNo = itm.InvNo7,
                                InvQty = itm.InvQty7
                            });
                        }
                        if (itm.Am8 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[7],
                                Am = itm.Am8,
                                InvDate = itm.InvDate8,
                                InvNo = itm.InvNo8,
                                InvQty = itm.InvQty8
                            });
                        }
                        if (itm.Am9 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[8],
                                Am = itm.Am9,
                                InvDate = itm.InvDate9,
                                InvNo = itm.InvNo9,
                                InvQty = itm.InvQty9
                            });
                        }
                        if (itm.Am10 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[9],
                                Am = itm.Am10,
                                InvDate = itm.InvDate10,
                                InvNo = itm.InvNo10,
                                InvQty = itm.InvQty10
                            });
                        }
                        if (itm.Am11 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[10],
                                Am = itm.Am11,
                                InvDate = itm.InvDate11,
                                InvNo = itm.InvNo11,
                                InvQty = itm.InvQty11
                            });
                        }
                        if (itm.Am12 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[11],
                                Am = itm.Am12,
                                InvDate = itm.InvDate12,
                                InvNo = itm.InvNo12,
                                InvQty = itm.InvQty12
                            });
                        }
                        if (itm.Am13 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[12],
                                Am = itm.Am13,
                                InvDate = itm.InvDate13,
                                InvNo = itm.InvNo13,
                                InvQty = itm.InvQty13
                            });
                        }
                        if (itm.Am14 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[13],
                                Am = itm.Am14,
                                InvDate = itm.InvDate14,
                                InvNo = itm.InvNo14,
                                InvQty = itm.InvQty14
                            });
                        }
                        if (itm.Am15 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[14],
                                Am = itm.Am15,
                                InvDate = itm.InvDate15,
                                InvNo = itm.InvNo15,
                                InvQty = itm.InvQty15
                            });
                        }
                        if (itm.Am16 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[15],
                                Am = itm.Am16,
                                InvDate = itm.InvDate16,
                                InvNo = itm.InvNo16,
                                InvQty = itm.InvQty16
                            });
                        }
                        if (itm.Am17 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[16],
                                Am = itm.Am17,
                                InvDate = itm.InvDate17,
                                InvNo = itm.InvNo17,
                                InvQty = itm.InvQty17
                            });
                        }
                        if (itm.Am18 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[17],
                                Am = itm.Am18,
                                InvDate = itm.InvDate18,
                                InvNo = itm.InvNo18,
                                InvQty = itm.InvQty18
                            });
                        }
                        if (itm.Am19 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[18],
                                Am = itm.Am19,
                                InvDate = itm.InvDate19,
                                InvNo = itm.InvNo19,
                                InvQty = itm.InvQty19
                            });
                        }
                        if (itm.Am20 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[19],
                                Am = itm.Am20,
                                InvDate = itm.InvDate20,
                                InvNo = itm.InvNo20,
                                InvQty = itm.InvQty20
                            });
                        }
                        if (itm.Am21 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[20],
                                Am = itm.Am21,
                                InvDate = itm.InvDate21,
                                InvNo = itm.InvNo21,
                                InvQty = itm.InvQty21
                            });
                        }
                        if (itm.Am22 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[21],
                                Am = itm.Am22,
                                InvDate = itm.InvDate22,
                                InvNo = itm.InvNo22,
                                InvQty = itm.InvQty22
                            });
                        }
                        if (itm.Am23 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[22],
                                Am = itm.Am23,
                                InvDate = itm.InvDate23,
                                InvNo = itm.InvNo23,
                                InvQty = itm.InvQty23
                            });
                        }
                        if (itm.Am24 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[23],
                                Am = itm.Am24,
                                InvDate = itm.InvDate24,
                                InvNo = itm.InvNo24,
                                InvQty = itm.InvQty24
                            });
                        }
                        if (Am25 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[24],
                                Am = itm.Am25,
                                InvDate = itm.InvDate25,
                                InvNo = itm.InvNo25,
                                InvQty = itm.InvQty25
                            });
                        }
                        if (itm.Am26 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[25],
                                Am = itm.Am26,
                                InvDate = itm.InvDate26,
                                InvNo = itm.InvNo26,
                                InvQty = itm.InvQty26
                            });
                        }
                        if (itm.Am27 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[26],
                                Am = itm.Am27,
                                InvDate = itm.InvDate27,
                                InvNo = itm.InvNo27,
                                InvQty = itm.InvQty27
                            });
                        }
                        if (Am28 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[27],
                                Am = itm.Am28,
                                InvDate = itm.InvDate28,
                                InvNo = itm.InvNo28,
                                InvQty = itm.InvQty28
                            });
                        }
                        if (itm.Am29 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[28],
                                Am = itm.Am29,
                                InvDate = itm.InvDate29,
                                InvNo = itm.InvNo29,
                                InvQty = itm.InvQty29
                            });
                        }
                        if (itm.Am30 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[29],
                                Am = itm.Am30,
                                InvDate = itm.InvDate30,
                                InvNo = itm.InvNo30,
                                InvQty = itm.InvQty30
                            });
                        }
                        if (itm.Am31 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[30],
                                Am = itm.Am31,
                                InvDate = itm.InvDate31,
                                InvNo = itm.InvNo31,
                                InvQty = itm.InvQty31
                            });
                        }
                        if (itm.Am32 > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[31],
                                Am = itm.Am32,
                                InvDate = itm.InvDate32,
                                InvNo = itm.InvNo32,
                                InvQty = itm.InvQty32
                            });
                        }
                        if (itm.Tax > 0)
                        {
                            fp.Add(new FRepair
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                DriverNo = itm.DriverNo,
                                CarNo = itm.CarNo,
                                FNo = ++MyNo,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                JobOrder = itm.JobOrder,
                                Remark = myList[32],
                                Am = itm.Tax,
                                InvDate = "",
                                InvNo = "",
                                InvQty = ""
                            });
                        }
                    }
                    return fp;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        /// <summary>
        /// Get New Code for Area Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public int? GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.FastRepairMaxCode(this.Branch,this.LocType,this.VouLoc);
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


    [Serializable]
    public class FRepair
    {
        public short Branch { get; set; }
        public short LocType { get; set; }
        public int VouNo { get; set; }
        public System.Nullable<short> VouLoc { get; set; }
        public System.Nullable<int> FNo { get; set; }
        public string VouDate { get; set; }
        public string FTime { get; set; }
        public string CarNo { get; set; }
        public string DriverNo { get; set; }
        public System.Nullable<double> Am { get; set; }
        public string Remark { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public string InvDate { get; set; }
        public string InvNo { get; set; }
        public string InvQty { get; set; }
        public int? JobOrder { get; set; }

        public FRepair()
        {
            this.Branch = 1;
            this.LocType = 2;
            this.VouNo = 0;
            this.VouLoc = 0;
            this.FNo = 0;
            this.VouDate = "";
            this.FTime = "";
            this.CarNo = "";
            this.DriverNo = "";
            this.Am = 0;
            this.Remark = "";
            this.UserName = "";
            this.UserDate = "";
            this.InvDate = "";
            this.InvNo = "";
            this.InvQty = "";
            this.JobOrder = 0;
        }
    }
}



