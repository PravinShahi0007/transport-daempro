using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class ChkPromo
    {
        public double? SPer { get; set; }
        public double? SAmount { get; set; }
        public double? Per { get; set; }
        public double? Amount { get; set; }
        public string ErrMsg { get; set; }

        public ChkPromo()
        {
            this.SPer = 0;
            this.SAmount = 0;
            this.Per = 0;
            this.Amount = 0;
            this.ErrMsg = "";
        }
    }

    [Serializable]
    public class MyConfig
    {
        public short Branch { get; set; }
        public string FDate { get; set; }
        public string CompanyName { get; set; }
        public string CompanyName2 { get; set; }
        public string ImagePath { get; set; }
        public string ImagePath2 { get; set; }
        public int? ImageNo { get; set; }
        public string Add01	{ get; set; }
        public string Add02	{ get; set; }
        public string Add03	{ get; set; }
        public string Add04	{ get; set; }
        public string Add05	{ get; set; }
        public string Add06	{ get; set; }
        public string Add07	{ get; set; }
        public string Add08	{ get; set; }
        public string Add09	{ get; set; }
        public string Add10	{ get; set; }
        public string Add11 { get; set; }
        public string Add12 { get; set; }
        public string Add13 { get; set; }
        public string Add14 { get; set; }
        public string Add15 { get; set; }
        public string Ded01	{ get; set; }
        public string Ded02	{ get; set; }
        public string Ded03	{ get; set; }
        public string Ded04	{ get; set; }
        public string Ded05	{ get; set; }
        public string Ded06	{ get; set; }
        public string Ded07	{ get; set; }
        public string Ded08	{ get; set; }
        public string Ded09	{ get; set; }
        public string Ded10	{ get; set; }
        public string Ded11 { get; set; }
        public string Ded12 { get; set; }
        public string Ded13 { get; set; }
        public string Ded14 { get; set; }
        public string Ded15 { get; set; }
        public string AddAcc01	{ get; set; }
        public string AddAcc02	{ get; set; }
        public string AddAcc03	{ get; set; }
        public string AddAcc04	{ get; set; }
        public string AddAcc05	{ get; set; }
        public string AddAcc06	{ get; set; }
        public string AddAcc07	{ get; set; }
        public string AddAcc08	{ get; set; }
        public string AddAcc09	{ get; set; }
        public string AddAcc10	{ get; set; }
        public string AddAcc11 { get; set; }
        public string AddAcc12 { get; set; }
        public string AddAcc13 { get; set; }
        public string AddAcc14 { get; set; }
        public string AddAcc15 { get; set; }
        public string DedAcc01	{ get; set; }
        public string DedAcc02	{ get; set; }
        public string DedAcc03	{ get; set; }
        public string DedAcc04	{ get; set; }
        public string DedAcc05	{ get; set; }
        public string DedAcc06	{ get; set; }
        public string DedAcc07	{ get; set; }
        public string DedAcc08	{ get; set; }
        public string DedAcc09	{ get; set; }
        public string DedAcc10	{ get; set; }
        public string DedAcc11 { get; set; }
        public string DedAcc12 { get; set; }
        public string DedAcc13 { get; set; }
        public string DedAcc14 { get; set; }
        public string DedAcc15 { get; set; }
        public string Paper1	{ get; set; }
        public string Paper2	{ get; set; }
        public string Paper3	{ get; set; }
        public string Paper4	{ get; set; }
        public string Paper5	{ get; set; }
        public string Paper6	{ get; set; }
        public string Paper7	{ get; set; }
        public string Paper8	{ get; set; }
        public string Paper9	{ get; set; }
        public string Paper10   { get; set; }
        public string BasicAcc { get; set; }
        public string Add201 { get; set; }
        public string Add202 { get; set; }
        public string Add203 { get; set; }
        public string Add204 { get; set; }
        public string Add205 { get; set; }
        public string Add206 { get; set; }
        public string Add207 { get; set; }
        public string Add208 { get; set; }
        public string Add209 { get; set; }
        public string Add210 { get; set; }
        public string Add211 { get; set; }
        public string Add212 { get; set; }
        public string Add213 { get; set; }
        public string Add214 { get; set; }
        public string Add215 { get; set; }
        public string Ded201 { get; set; }
        public string Ded202 { get; set; }
        public string Ded203 { get; set; }
        public string Ded204 { get; set; }
        public string Ded205 { get; set; }
        public string Ded206 { get; set; }
        public string Ded207 { get; set; }
        public string Ded208 { get; set; }
        public string Ded209 { get; set; }
        public string Ded210 { get; set; }
        public string Ded211 { get; set; }
        public string Ded212 { get; set; }
        public string Ded213 { get; set; }
        public string Ded214 { get; set; }
        public string Ded215 { get; set; }
        public string PaperE1 { get; set; }
        public string PaperE2 { get; set; }
        public string PaperE3 { get; set; }
        public string PaperE4 { get; set; }
        public string PaperE5 { get; set; }
        public string PaperE6 { get; set; }
        public string PaperE7 { get; set; }
        public string PaperE8 { get; set; }
        public string PaperE9 { get; set; }
        public string PaperE10 { get; set; }
        public string BankExpAcc { get; set; }
        public string ClosePeriod { get; set; }
        public string P1db { get; set; }
        public string P1cr { get; set; }
        public string P2db { get; set; }
        public string P2cr { get; set; }
        public string P3db { get; set; }
        public string P3cr { get; set; }
        public string P4db { get; set; }
        public string P4cr { get; set; }
        public string P5db { get; set; }
        public string P5cr { get; set; }
        public string P6db { get; set; }
        public string P6cr { get; set; }
        public string P10db { get; set; }
        public string P10cr { get; set; }
        public string P11db { get; set; }
        public string P11cr { get; set; }
        public string P12db { get; set; }
        public string P12cr { get; set; }
        public string UpdateTime { get; set; }
        public string RepairAcc1 { get; set; }
        public string RepairAcc2 { get; set; }
        public string RepairAcc3 { get; set; }
        public string RepairAcc4 { get; set; }
        public string RepairAcc5 { get; set; }
        public string RepairAcc6 { get; set; }
        public string RepairAcc7 { get; set; }
        public string RepairAcc8 { get; set; }
        public string RepairAcc9 { get; set; }
        public string RepairAcc10 { get; set; }
        public string RepairAcc11 { get; set; }
        public string RepairAcc12 { get; set; }
        public string RepairAcc13 { get; set; }
        public string RepairAcc14 { get; set; }
        public string RepairAcc15 { get; set; }
        public string RepairAcc16 { get; set; }
        public string RepairAcc17 { get; set; }
        public string RepairAcc18 { get; set; }
        public string RepairAcc19 { get; set; }
        public string RepairAcc20 { get; set; }
        public string RepairAcc21 { get; set; }
        public string RepairAcc22 { get; set; }
        public string RepairAcc23 { get; set; }
        public string RepairAcc24 { get; set; }
        public string RepairAcc25 { get; set; }
        public string RepairAcc26 { get; set; }
        public string RepairAcc27 { get; set; }
        public string RepairAcc28 { get; set; }
        public string RepairAcc29 { get; set; }
        public string RepairAcc30 { get; set; }
		

        public MyConfig()        
        {
            this.Branch = 0;
            this.FDate = "";
            this.CompanyName = "";
            this.CompanyName2 = "";
            this.ImageNo = 1;
            this.ImagePath = "";
            this.ImagePath2 = "";
            this.Add01	= "";
            this.Add02	= "";
            this.Add03	= "";
            this.Add04	= "";
            this.Add05	= "";
            this.Add06	= "";
            this.Add07	= "";
            this.Add08	= "";
            this.Add09	= "";
            this.Add10	= "";
            this.Add11 = "";
            this.Add12 = "";
            this.Add13 = "";
            this.Add14 = "";
            this.Add15 = "";
            this.Ded01	= "";
            this.Ded02	= "";
            this.Ded03	= "";
            this.Ded04	= "";
            this.Ded05	= "";
            this.Ded06	= "";
            this.Ded07	= "";
            this.Ded08	= "";
            this.Ded09	= "";
            this.Ded10	= "";
            this.Ded11 = "";
            this.Ded12 = "";
            this.Ded13 = "";
            this.Ded14 = "";
            this.Ded15 = "";
            this.AddAcc01	= "-1";
            this.AddAcc02	= "-1";
            this.AddAcc03	= "-1";
            this.AddAcc04	= "-1";
            this.AddAcc05	= "-1";
            this.AddAcc06	= "-1";
            this.AddAcc07	= "-1";
            this.AddAcc08	= "-1";
            this.AddAcc09	= "-1";
            this.AddAcc10	= "-1";
            this.AddAcc11 = "-1";
            this.AddAcc12 = "-1";
            this.AddAcc13 = "-1";
            this.AddAcc14 = "-1";
            this.AddAcc15 = "-1";
            this.DedAcc01	= "-1";
            this.DedAcc02	= "-1";
            this.DedAcc03	= "-1";
            this.DedAcc04	= "-1";
            this.DedAcc05	= "-1";
            this.DedAcc06	= "-1";
            this.DedAcc07	= "-1";
            this.DedAcc08	= "-1";
            this.DedAcc09	= "-1";
            this.DedAcc10	= "-1";
            this.DedAcc11 = "-1";
            this.DedAcc12 = "-1";
            this.DedAcc13 = "-1";
            this.DedAcc14 = "-1";
            this.DedAcc15 = "-1";
            this.BasicAcc = "-1";
            this.Paper1	= "";
            this.Paper2	= "";
            this.Paper3	= "";
            this.Paper4	= "";
            this.Paper5	= "";
            this.Paper6	= "";
            this.Paper7	= "";
            this.Paper8	= "";
            this.Paper9	= "";
            this.Paper10 = "";
            this.Add201 = "";
            this.Add202 = "";
            this.Add203 = "";
            this.Add204 = "";
            this.Add205 = "";
            this.Add206 = "";
            this.Add207 = "";
            this.Add208 = "";
            this.Add209 = "";
            this.Add210 = "";
            this.Add211 = "";
            this.Add212 = "";
            this.Add213 = "";
            this.Add214 = "";
            this.Add215 = "";
            this.Ded201 = "";
            this.Ded202 = "";
            this.Ded203 = "";
            this.Ded204 = "";
            this.Ded205 = "";
            this.Ded206 = "";
            this.Ded207 = "";
            this.Ded208 = "";
            this.Ded209 = "";
            this.Ded210 = "";
            this.Ded211 = "";
            this.Ded212 = "";
            this.Ded213 = "";
            this.Ded214 = "";
            this.Ded215 = "";
            this.PaperE1 = "";
            this.PaperE2 = "";
            this.PaperE3 = "";
            this.PaperE4 = "";
            this.PaperE5 = "";
            this.PaperE6 = "";
            this.PaperE7 = "";
            this.PaperE8 = "";
            this.PaperE9 = "";
            this.PaperE10 = "";
            this.BankExpAcc = "-1";
            this.ClosePeriod = "";
            this.P1db = "";
            this.P1cr = "";
            this.P2db = "";
            this.P2cr = "";
            this.P3db = "";
            this.P3cr = "";
            this.P4db = "";
            this.P4cr = "";
            this.P5db = "";
            this.P5cr = "";
            this.P6db = "";
            this.P6cr = "";
            this.P10db = "";
            this.P10cr = "";
            this.P11db = "";
            this.P11cr = "";
            this.P12db = "";
            this.P12cr = "";
            this.UpdateTime = "";
            this.RepairAcc1 = "";
            this.RepairAcc2 = "";
            this.RepairAcc3 = "";
            this.RepairAcc4 = "";
            this.RepairAcc5 = "";
            this.RepairAcc6 = "";
            this.RepairAcc7 = "";
            this.RepairAcc8 = "";
            this.RepairAcc9 = "";
            this.RepairAcc10 = "";
            this.RepairAcc11 = "";
            this.RepairAcc12 = "";
            this.RepairAcc13 = "";
            this.RepairAcc14 = "";
            this.RepairAcc15 = "";
            this.RepairAcc16 = "";
            this.RepairAcc17 = "";
            this.RepairAcc18 = "";
            this.RepairAcc19 = "";
            this.RepairAcc20 = "";
            this.RepairAcc21 = "";
            this.RepairAcc22 = "";
            this.RepairAcc23 = "";
            this.RepairAcc24 = "";
            this.RepairAcc25 = "";
            this.RepairAcc26 = "";
            this.RepairAcc27 = "";
            this.RepairAcc28 = "";
            this.RepairAcc29 = "";
            this.RepairAcc30 = "";
        }

        /// <summary>
        /// Update Item City in City Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ConfigUpdate( this.Branch,
                                            this.FDate,
                                            this.CompanyName,
                                            this.CompanyName2,
                                            this.ImagePath,
                                            this.ImageNo,
                                            this.ImagePath2,                                            
                                            this.Add01,
                                            this.Add02,
                                            this.Add03,
                                            this.Add04,
                                            this.Add05,
                                            this.Add06,
                                            this.Add07,
                                            this.Add08,
                                            this.Add09,
                                            this.Add10,
                                            this.Add11,
                                            this.Add12,
                                            this.Add13,
                                            this.Add14,
                                            this.Add15,
                                            this.Ded01,
                                            this.Ded02,
                                            this.Ded03,
                                            this.Ded04,
                                            this.Ded05,
                                            this.Ded06,
                                            this.Ded07,
                                            this.Ded08,
                                            this.Ded09,
                                            this.Ded10,
                                            this.Ded11,
                                            this.Ded12,
                                            this.Ded13,
                                            this.Ded14,
                                            this.Ded15,
                                            this.Paper1,
                                            this.Paper2,
                                            this.Paper3,
                                            this.Paper4,
                                            this.Paper5,
                                            this.Paper6,
                                            this.Paper7,
                                            this.Paper8,
                                            this.Paper9,
                                            this.Paper10,
                                            this.AddAcc01,
                                            this.AddAcc02,
                                            this.AddAcc03,
                                            this.AddAcc04,
                                            this.AddAcc05,
                                            this.AddAcc06,
                                            this.AddAcc07,
                                            this.AddAcc08,
                                            this.AddAcc09,
                                            this.AddAcc10,
                                            this.AddAcc11,
                                            this.AddAcc12,
                                            this.AddAcc13,
                                            this.AddAcc14,
                                            this.AddAcc15,
                                            this.DedAcc01,
                                            this.DedAcc02,
                                            this.DedAcc03,
                                            this.DedAcc04,
                                            this.DedAcc05,
                                            this.DedAcc06,
                                            this.DedAcc07,
                                            this.DedAcc08,
                                            this.DedAcc09,
                                            this.DedAcc10,
                                            this.DedAcc11,
                                            this.DedAcc12,
                                            this.DedAcc13,
                                            this.DedAcc14,
                                            this.DedAcc15,
                                            this.BasicAcc,
                                            this.Add201,
                                            this.Add202,
                                            this.Add203,
                                            this.Add204,
                                            this.Add205,
                                            this.Add206,
                                            this.Add207,
                                            this.Add208,
                                            this.Add209,
                                            this.Add210,
                                            this.Add211,
                                            this.Add212,
                                            this.Add213,
                                            this.Add214,
                                            this.Add215,
                                            this.Ded201,
                                            this.Ded202,
                                            this.Ded203,
                                            this.Ded204,
                                            this.Ded205,
                                            this.Ded206,
                                            this.Ded207,
                                            this.Ded208,
                                            this.Ded209,
                                            this.Ded210,
                                            this.Ded211,
                                            this.Ded212,
                                            this.Ded213,
                                            this.Ded214,
                                            this.Ded215,
                                            this.PaperE1,
                                            this.PaperE2,
                                            this.PaperE3,
                                            this.PaperE4,
                                            this.PaperE5,
                                            this.PaperE6,
                                            this.PaperE7,
                                            this.PaperE8,
                                            this.PaperE9,
                                            this.PaperE10,
                                            this.BankExpAcc,
                                            this.ClosePeriod,
                                            this.P1db,
                                            this.P1cr,
                                            this.P2db,
                                            this.P2cr,
                                            this.P3db,
                                            this.P3cr,
                                            this.P4db,
                                            this.P4cr,
                                            this.P5db,
                                            this.P5cr,
                                            this.P6db,
                                            this.P6cr,
                                            this.P10db,
                                            this.P10cr,
                                            this.P11db,
                                            this.P11cr,
                                            this.P12db,
                                            this.P12cr,
                                            this.RepairAcc1,
                                            this.RepairAcc2,
                                            this.RepairAcc3,
                                            this.RepairAcc4,
                                            this.RepairAcc5,
                                            this.RepairAcc6,
                                            this.RepairAcc7,
                                            this.RepairAcc8,
                                            this.RepairAcc9,
                                            this.RepairAcc10,
                                            this.RepairAcc11,
                                            this.RepairAcc12,
                                            this.RepairAcc13,
                                            this.RepairAcc14,
                                            this.RepairAcc15,
                                            this.RepairAcc16,
                                            this.RepairAcc17,
                                            this.RepairAcc18,
                                            this.RepairAcc19,
                                            this.RepairAcc20,
                                            this.RepairAcc21,
                                            this.RepairAcc22,
                                            this.RepairAcc23,
                                            this.RepairAcc24,
                                            this.RepairAcc25,
                                            this.RepairAcc26,
                                            this.RepairAcc27,
                                            this.RepairAcc28,
                                            this.RepairAcc29,
                                            this.RepairAcc30);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public MyConfig Get(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ConfigGet(this.Branch);
                    return (from itm in result
                            select new MyConfig
                            {
                                 Branch = itm.Branch,
                                 CompanyName = itm.CompanyName,
                                 CompanyName2 = itm.CompanyName2,
                                 FDate = itm.FDate,
                                 ImageNo = itm.ImageNo,
                                 ImagePath = itm.ImagePath,
                                 ImagePath2 = itm.ImagePath2,
                                 Add01 = itm.Add01,
                                 Add02 = itm.Add02,
                                 Add03 = itm.Add03,
                                 Add04 = itm.Add04,
                                 Add05 = itm.Add05,
                                 Add06 = itm.Add06,
                                 Add07 = itm.Add07,
                                 Add08 = itm.Add08,
                                 Add09 = itm.Add09,
                                 Add10 = itm.Add10,
                                 Add11 = itm.Add11,
                                 Add12 = itm.Add12,
                                 Add13 = itm.Add13,
                                 Add14 = itm.Add14,
                                 Add15 = itm.Add15,
                                 AddAcc01 = itm.AddAcc01,
                                 AddAcc02 = itm.AddAcc02,
                                 AddAcc03 = itm.AddAcc03,
                                 AddAcc04 = itm.AddAcc04,
                                 AddAcc05 = itm.AddAcc05,
                                 AddAcc06 = itm.AddAcc06,
                                 AddAcc07 = itm.AddAcc07,
                                 AddAcc08 = itm.AddAcc08,
                                 AddAcc09 = itm.AddAcc09,
                                 AddAcc10 = itm.AddAcc10,
                                 AddAcc11 = itm.AddAcc11,
                                 AddAcc12 = itm.AddAcc12,
                                 AddAcc13 = itm.AddAcc13,
                                 AddAcc14 = itm.AddAcc14,
                                 AddAcc15 = itm.AddAcc15,
                                 Ded01 = itm.Ded01,
                                 Ded02 = itm.Ded02,
                                 Ded03 = itm.Ded03,
                                 Ded04 = itm.Ded04,
                                 Ded05 = itm.Ded05,
                                 Ded06 = itm.Ded06,
                                 Ded07 = itm.Ded07,
                                 Ded08 = itm.Ded08,
                                 Ded09 = itm.Ded09,
                                 Ded10 = itm.Ded10,
                                 Ded11 = itm.Ded11,
                                 Ded12 = itm.Ded12,
                                 Ded13 = itm.Ded13,
                                 Ded14 = itm.Ded14,
                                 Ded15 = itm.Ded15,
                                 DedAcc01 = itm.DedAcc01,
                                 DedAcc02 = itm.DedAcc02,
                                 DedAcc03 = itm.DedAcc03,
                                 DedAcc04 = itm.DedAcc04,
                                 DedAcc05 = itm.DedAcc05,
                                 DedAcc06 = itm.DedAcc06,
                                 DedAcc07 = itm.DedAcc07,
                                 DedAcc08 = itm.DedAcc08,
                                 DedAcc09 = itm.DedAcc09,
                                 DedAcc10 = itm.DedAcc10,
                                 DedAcc11 = itm.DedAcc11,
                                 DedAcc12 = itm.DedAcc12,
                                 DedAcc13 = itm.DedAcc13,
                                 DedAcc14 = itm.DedAcc14,
                                 DedAcc15 = itm.DedAcc15,
                                 Paper1 = itm.Paper1,
                                 Paper2 = itm.Paper2,
                                 Paper3 = itm.Paper3,
                                 Paper4 = itm.Paper4,
                                 Paper5 = itm.Paper5,
                                 Paper6 = itm.Paper6,
                                 Paper7 = itm.Paper7,
                                 Paper8 = itm.Paper8,
                                 Paper9 = itm.Paper9,
                                 Paper10 = itm.Paper10,
                                 BasicAcc = itm.BasicAcc,
                                 Add201 = itm.Add201,
                                 Add202 = itm.Add202,
                                 Add203 = itm.Add203,
                                 Add204 = itm.Add204,
                                 Add205 = itm.Add205,
                                 Add206 = itm.Add206,
                                 Add207 = itm.Add207,
                                 Add208 = itm.Add208,
                                 Add209 = itm.Add209,
                                 Add210 = itm.Add210,
                                 Add211 = itm.Add211,
                                 Add212 = itm.Add212,
                                 Add213 = itm.Add213,
                                 Add214 = itm.Add214,
                                 Add215 = itm.Add215,
                                 Ded201 = itm.Ded201,
                                 Ded202 = itm.Ded202,
                                 Ded203 = itm.Ded203,
                                 Ded204 = itm.Ded204,
                                 Ded205 = itm.Ded205,
                                 Ded206 = itm.Ded206,
                                 Ded207 = itm.Ded207,
                                 Ded208 = itm.Ded208,
                                 Ded209 = itm.Ded209,
                                 Ded210 = itm.Ded210,
                                 Ded211 = itm.Ded211,
                                 Ded212 = itm.Ded212,
                                 Ded213 = itm.Ded213,
                                 Ded214 = itm.Ded214,
                                 Ded215 = itm.Ded215,
                                 PaperE1 = itm.PaperE1,
                                 PaperE2 = itm.PaperE2,
                                 PaperE3 = itm.PaperE3,
                                 PaperE4 = itm.PaperE4,
                                 PaperE5 = itm.PaperE5,
                                 PaperE6 = itm.PaperE6,
                                 PaperE7 = itm.PaperE7,
                                 PaperE8 = itm.PaperE8,
                                 PaperE9 = itm.PaperE9,
                                 PaperE10 = itm.PaperE10,
                                 BankExpAcc = itm.BankExpAcc,
                                 ClosePeriod = itm.ClosePeriod,
                                 P10cr = itm.P10cr,
                                 P10db = itm.P10db,
                                 P11cr = itm.P11cr,
                                 P11db = itm.P11db,
                                 P12cr = itm.P12cr,
                                 P12db = itm.P12db,
                                 P1cr = itm.P1cr,
                                 P1db = itm.P1db,
                                 P2cr = itm.P2cr,
                                 P2db = itm.P2db,
                                 P3cr = itm.P3cr,
                                 P3db =  itm.P3db,
                                 P4cr = itm.P4cr,
                                 P4db = itm.P4db,
                                 P5cr = itm.P5cr,
                                 P5db = itm.P5db,
                                 P6cr = itm.P6cr,
                                 P6db = itm.P6db,                                  
                                 UpdateTime = itm.UpdateTime,
                                 RepairAcc1 = itm.RepairAcc1,
                                 RepairAcc2 = itm.RepairAcc2,
                                 RepairAcc3 = itm.RepairAcc3,
                                 RepairAcc4 = itm.RepairAcc4,
                                 RepairAcc5 = itm.RepairAcc5,
                                 RepairAcc6 = itm.RepairAcc6,
                                 RepairAcc7 = itm.RepairAcc7,
                                 RepairAcc8 = itm.RepairAcc8,
                                 RepairAcc9 = itm.RepairAcc9,
                                 RepairAcc10 = itm.RepairAcc10,
                                 RepairAcc11 = itm.RepairAcc11,
                                 RepairAcc12 = itm.RepairAcc12,
                                 RepairAcc13 = itm.RepairAcc13,
                                 RepairAcc14 = itm.RepairAcc14,
                                 RepairAcc15 = itm.RepairAcc15,
                                 RepairAcc16 = itm.RepairAcc16,
                                 RepairAcc17 = itm.RepairAcc17,
                                 RepairAcc18 = itm.RepairAcc18,
                                 RepairAcc19 = itm.RepairAcc19,
                                 RepairAcc20 = itm.RepairAcc20,
                                 RepairAcc21 = itm.RepairAcc21,
                                 RepairAcc22 = itm.RepairAcc22,
                                 RepairAcc23 = itm.RepairAcc23,
                                 RepairAcc24 = itm.RepairAcc24,
                                 RepairAcc25 = itm.RepairAcc25,
                                 RepairAcc26 = itm.RepairAcc26,
                                 RepairAcc27 = itm.RepairAcc27,
                                 RepairAcc28 = itm.RepairAcc28,
                                 RepairAcc29 = itm.RepairAcc29,
                                 RepairAcc30 = itm.RepairAcc30
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

