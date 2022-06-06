using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Functions1
    {
        public int FType { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string FormName { get; set; }
        public string FCreate { get; set; }
        public string FStep1 { get; set; }
        public string FStep2 { get; set; }
        public string FStep3 { get; set; }
        public string FStep4 { get; set; }
        public string FStep5 { get; set; }
        public string FStep6 { get; set; }
        public string FStep7 { get; set; }
        public string FStep8 { get; set; }
        public short? SType1 { get; set; }
        public short? SType2 { get; set; }
        public short? SType3 { get; set; }
        public short? SType4 { get; set; }
        public short? SType5 { get; set; }
        public short? SType6 { get; set; }
        public short? SType7 { get; set; }
        public short? SType8 { get; set; }
        public bool? Action1 { get; set; }
        public bool? Action2 { get; set; }
        public bool? Action3 { get; set; }
        public bool? Action4 { get; set; }
        public bool? Action5 { get; set; }
        public bool? Action6 { get; set; }
        public bool? Action7 { get; set; }
        public bool? Action8 { get; set; }


        public Functions1()
        {
            this.FType = 001;
            this.Name = "";
            this.Name2 = "";
            this.FormName = "";
            this.FCreate = "";
            this.FStep1 = "";
            this.FStep2 = "";
            this.FStep3 = "";
            this.FStep4 = "";
            this.FStep5 = "";
            this.FStep6 = "";
            this.FStep7 = "";
            this.FStep8 = "";
            this.SType1 = 0;
            this.SType2 = 0;
            this.SType3 = 0;
            this.SType4 = 0;
            this.SType5 = 0;
            this.SType6 = 0;
            this.SType7 = 0;
            this.SType8 = 0;
            this.Action1 = false;
            this.Action2 = false;
            this.Action3 = false;
            this.Action4 = false;
            this.Action5 = false;
            this.Action6 = false;
            this.Action7 = false;
            this.Action8 = false;
        }


        public bool insert(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.Functions1Add(this.FType, this.Name, this.Name2, this.FormName, this.FCreate, this.FStep1, this.FStep2, this.FStep3, this.FStep4, this.FStep5, this.FStep6, this.FStep7, this.FStep8, this.SType1, this.SType2, this.SType3, this.SType4, this.SType5, this.SType6, this.SType7, this.SType8, this.Action1, this.Action2, this.Action3, this.Action4, this.Action5, this.Action6, this.Action7, this.Action8);
            
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool Update(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.Functions1Update(this.FType, this.Name, this.Name2, this.FormName, this.FCreate, this.FStep1, this.FStep2, this.FStep3, this.FStep4, this.FStep5, this.FStep6, this.FStep7, this.FStep8, this.SType1, this.SType2, this.SType3, this.SType4, this.SType5, this.SType6, this.SType7, this.SType8, this.Action1, this.Action2, this.Action3, this.Action4, this.Action5, this.Action6, this.Action7, this.Action8);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }




        public List<Functions1> GetAll(bool Support,string AreaNo ,string StoreNo, string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.Functions1GetAll();
                    return (from sitm in result
                            where sitm.FormName != ""
                            select new Functions1
                            {
                                FType = sitm.FType,
                                FormName = sitm.FormName + @"?AreaNo=" + AreaNo + @"&StoreNo=" + StoreNo + (Support ? @"&Support=1" : ""),
                                Name = sitm.Name,
                                Name2 = sitm.Name2,
                                FCreate = sitm.FCreate,
                                FStep1 = sitm.FStep1,
                                FStep2 = sitm.FStep2,
                                FStep3 = sitm.FStep3,
                                FStep4 = sitm.FStep4,
                                FStep5 = sitm.FStep5,
                                FStep6 = sitm.FStep6,
                                FStep7 = sitm.FStep7,
                                FStep8 = sitm.FStep8,
                                SType1 = sitm.SType1,
                                SType2 = sitm.SType2,
                                SType3 = sitm.SType3,
                                SType4 = sitm.SType4,
                                SType5 = sitm.SType5,
                                SType6 = sitm.SType6,
                                SType7 = sitm.SType7,
                                SType8 = sitm.SType8,
                                Action1 = sitm.Action1,
                                Action2 = sitm.Action2,
                                Action3 = sitm.Action3,
                                Action4 = sitm.Action4,
                                Action5 = sitm.Action5,
                                Action6 = sitm.Action6,
                                Action7 = sitm.Action7,
                                Action8 = sitm.Action8
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.Functions1Delete(FType);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Functions1 Find(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.Functions1Find(FType);
                    return (from sitm in result
                            select new Functions1
                            {

                                FType = sitm.FType,
                                FormName = sitm.FormName,
                                Name = sitm.Name,
                                Name2 = sitm.Name2,
                                FCreate = sitm.FCreate,
                                FStep1 = sitm.FStep1,
                                FStep2 = sitm.FStep2,
                                FStep3 = sitm.FStep3,
                                FStep4 = sitm.FStep4,
                                FStep5 = sitm.FStep5,
                                FStep6 = sitm.FStep6,
                                FStep7 = sitm.FStep7,
                                FStep8 = sitm.FStep8,
                                SType1 = sitm.SType1,
                                SType2 = sitm.SType2,
                                SType3 = sitm.SType3,
                                SType4 = sitm.SType4,
                                SType5 = sitm.SType5,
                                SType6 = sitm.SType6,
                                SType7 = sitm.SType7,
                                SType8 = sitm.SType8,
                                Action1 = sitm.Action1,
                                Action2 = sitm.Action2,
                                Action3 = sitm.Action3,
                                Action4 = sitm.Action4,
                                Action5 = sitm.Action5,
                                Action6 = sitm.Action6,
                                Action7 = sitm.Action7,
                                Action8 = sitm.Action8
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
