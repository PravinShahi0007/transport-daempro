using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Emp
    {
        public short Branch { get; set; }
        public string EmpCode { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }

        /// <summary>
        /// Add Emp in Emp Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.EmpInsert(this.Branch, this.EmpCode, this.Name1, this.Name2);                    
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Emp from Emp Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.EmpDelete(this.Branch , this.EmpCode);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Emp in Emp Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.EmpUpdate(this.Branch, this.EmpCode , this.Name1 , this.Name2);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// select all Emps center from Emp Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<Emp> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.EmpGetAll(this.Branch);
                    return (from itm in result
                            select new Emp
                            {
                                Branch = itm.Branch,
                                EmpCode = itm.EmpCode,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select  Emp  from Emp Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public Emp find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.EmpGet(this.Branch, this.EmpCode);
                    return (from itm in result
                            select new Emp
                            {
                                Branch = itm.Branch,
                                EmpCode = itm.EmpCode,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                            }).FirstOrDefault();
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
        public string GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.EmpMaxCode(this.Branch);
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
