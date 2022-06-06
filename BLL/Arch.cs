using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Arch
    {
        public short Branch { get; set; }
        public short LocNumber { get; set; }
        public int DocType { get; set; }
        public int Number { get; set; }
        public short FNo { get; set; }
        public string FileName { get; set; }
        public string FileName2 { get; set; }

        public Arch()
        {
            this.Branch = 1;
            this.LocNumber = 0;
            this.DocType = 0;
            this.Number = 0;
            this.FNo = 1;
            this.FileName = "";
            this.FileName2 = "";
        }

        /// <summary>
        /// Add Item in Arch Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.ArchInsert(this.Branch, this.LocNumber, this.DocType, this.Number, this.FNo, this.FileName, this.FileName2);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Item from Arch Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.ArchDelete(this.Branch, this.LocNumber, this.DocType, this.Number);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Item from Arch Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool DeleteFNo(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.ArchDeleteFNo(this.Branch, this.LocNumber, this.DocType, this.Number,this.FNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// select all Cars from MyPO Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<Arch> Find(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.ArchGet(this.Branch, this.LocNumber, this.DocType, this.Number);
                    return (from itm in result
                            select new Arch
                            {
                                Branch = itm.Branch,
                                LocNumber = itm.LocNumber,
                                DocType = itm.DocType,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                FileName = itm.FileName2.ToUpper().Contains(".MP4") ? @"<video width='320' height='240' controls='controls'><source src='" + itm.FileName2 + @"' type='video/mp4'/>Movie</video>" : itm.FileName,
                                FileName2 = itm.FileName2
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cars from MyPO Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public Arch FindFNo(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.ArchGetFNo(this.Branch, this.LocNumber, this.DocType, this.Number,this.FNo);
                    return (from itm in result
                            select new Arch
                            {
                                Branch = itm.Branch,
                                LocNumber = itm.LocNumber,
                                DocType = itm.DocType,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                FileName = itm.FileName2.ToUpper().Contains(".MP4") ? @"<video width='320' height='240' controls='controls'><source src='" + itm.FileName2 + @"' type='video/mp4'/>Movie</video>" : itm.FileName,
                                FileName2 = itm.FileName2
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get New FNo for Arch Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public short? GetNewFNo(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.ArchMaxFNo(this.Branch, this.LocNumber, this.DocType, this.Number);
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
}