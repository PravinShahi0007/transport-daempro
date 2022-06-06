using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class FExcel
    {
        public int Num { get; set; }
        public string F01 { get; set; }
        public string F02 { get; set; }
        public string F03 { get; set; }
        public string F04 { get; set; }
        public string F05 { get; set; }
        public string F06 { get; set; }
        public string F07 { get; set; }
        public string F08 { get; set; }
        public string F09 { get; set; }
        public string F10 { get; set; }
        public string F11 { get; set; }
        public string F12 { get; set; }
        public string F13 { get; set; }
        public string F14 { get; set; }
        public string F15 { get; set; }
        public string F16 { get; set; }
        public string F17 { get; set; }
        public string F18 { get; set; }
        public string F19 { get; set; }
        public string F20 { get; set; }
        public string F21 { get; set; }
        public string F22 { get; set; }
        public string F23 { get; set; }
        public string F24 { get; set; }
        public string F25 { get; set; }
        public string F26 { get; set; }
        public string F27 { get; set; }
        public string F28 { get; set; }
        public string F29 { get; set; }
        public string F30 { get; set; }
        public string F31 { get; set; }
        public string F32 { get; set; }
        public string F33 { get; set; }
        public string F34 { get; set; }
        public string F35 { get; set; }
        public string F36 { get; set; }
        public string F37 { get; set; }
        public string F38 { get; set; }
        public string F39 { get; set; }
        public string F40 { get; set; }
        public string F41 { get; set; }
        public string F42 { get; set; }
        public string F43 { get; set; }
        public string F44 { get; set; }
        public string F45 { get; set; }
        public string F46 { get; set; }
        public string F47 { get; set; }
        public string F48 { get; set; }
        public string F49 { get; set; }
        public string F50 { get; set; }

        public FExcel()
        {
            this.Num = 0;
            this.F01 = "";
            this.F02 = "";
            this.F03 = "";
            this.F04 = "";
            this.F05 = "";
            this.F06 = "";
            this.F07 = "";
            this.F08 = "";
            this.F09 = "";
            this.F10 = "";
            this.F11 = "";
            this.F12 = "";
            this.F13 = "";
            this.F14 = "";
            this.F15 = "";
            this.F16 = "";
            this.F17 = "";
            this.F18 = "";
            this.F19 = "";
            this.F20 = "";
            this.F21 = "";
            this.F22 = "";
            this.F23 = "";
            this.F24 = "";
            this.F25 = "";
            this.F26 = "";
            this.F27 = "";
            this.F28 = "";
            this.F29 = "";
            this.F30 = "";
            this.F31 = "";
            this.F32 = "";
            this.F33 = "";
            this.F34 = "";
            this.F35 = "";
            this.F36 = "";
            this.F37 = "";
            this.F38 = "";
            this.F39 = "";
            this.F40 = "";
            this.F41 = "";
            this.F42 = "";
            this.F43 = "";
            this.F44 = "";
            this.F45 = "";
            this.F46 = "";
            this.F47 = "";
            this.F48 = "";
            this.F49 = "";
            this.F50 = "";
        }

        /// <summary>
        /// Add Car in Cars Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.FExcelAdd(this.Num,
                                        this.F01,
                                        this.F02,
                                        this.F03,
                                        this.F04,
                                        this.F05,
                                        this.F06,
                                        this.F07,
                                        this.F08,
                                        this.F09,
                                        this.F10,
                                        this.F11,
                                        this.F12,
                                        this.F13,
                                        this.F14,
                                        this.F15,
                                        this.F16,
                                        this.F17,
                                        this.F18,
                                        this.F19,
                                        this.F20,
                                        this.F21,
                                        this.F22,
                                        this.F23,
                                        this.F24,
                                        this.F25,
                                        this.F26,
                                        this.F27,
                                        this.F28,
                                        this.F29,
                                        this.F30,
                                        this.F31,
                                        this.F32,
                                        this.F33,
                                        this.F34,
                                        this.F35,
                                        this.F36,
                                        this.F37,
                                        this.F38,
                                        this.F39,
                                        this.F40,
                                        this.F41,
                                        this.F42,
                                        this.F43,
                                        this.F44,
                                        this.F45,
                                        this.F46,
                                        this.F47,
                                        this.F48,
                                        this.F49,
                                        this.F50
                            );
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Car from Cars Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool DeleteAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.FExcelDeleteAll();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// select all Cars from Cars Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<FExcel> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.FExcelGetAll();
                    return (from itm in result
                            select new FExcel
                            {
                                Num = itm.Num,
                                F01 = itm.F01,
                                F02 = itm.F02,
                                F03 = itm.F03,
                                F04 = itm.F04,
                                F05 = itm.F05,
                                F06 = itm.F06,
                                F07 = itm.F07,
                                F08 = itm.F08,
                                F09 = itm.F09,
                                F10 = itm.F10,
                                F11 = itm.F11,
                                F12 = itm.F12,
                                F13 = itm.F13,
                                F14 = itm.F14,
                                F15 = itm.F15,
                                F16 = itm.F16,
                                F17 = itm.F17,
                                F18 = itm.F18,
                                F19 = itm.F19,
                                F20 = itm.F20,
                                F21 = itm.F21,
                                F22 = itm.F22,
                                F23 = itm.F23,
                                F24 = itm.F24,
                                F25 = itm.F25,
                                F26 = itm.F26,
                                F27 = itm.F27,
                                F28 = itm.F28,
                                F29 = itm.F29,
                                F30 = itm.F30,
                                F31 = itm.F31,
                                F32 = itm.F32,
                                F33 = itm.F33,
                                F34 = itm.F34,
                                F35 = itm.F35,
                                F36 = itm.F36,
                                F37 = itm.F37,
                                F38 = itm.F38,
                                F39 = itm.F39,
                                F40 = itm.F40,
                                F41 = itm.F41,
                                F42 = itm.F42,
                                F43 = itm.F43,
                                F44 = itm.F44,
                                F45 = itm.F45,
                                F46 = itm.F46,
                                F47 = itm.F47,
                                F48 = itm.F48,
                                F49 = itm.F49,
                                F50 = itm.F50                                 
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
