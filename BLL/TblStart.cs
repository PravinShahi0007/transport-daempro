using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
	[Serializable]
	public class TblStart
	{
		public short FType { get; set; }
		public short FNo { get; set; }
		public string Fd1 { get; set; }
		public string Fd2 { get; set; }
		public string Fd3 { get; set; }
		public string Fd4 { get; set; }
		public string Fd5 { get; set; }

		public TblStart()
		{
			this.FType = 0;
			this.FNo = 0;
			this.Fd1 = "";
			this.Fd2 = "";
			this.Fd3 = "";
			this.Fd4 = "";
			this.Fd5 = "";
		}

		/// <summary>
		/// Update Account in Acc Table
		/// </summary>
		/// <returns>True if Update Success or False if Fail</returns>
		public bool Update(string ConnectionStr)
		{
			try
			{
				using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
				{
					myContext.TblStartUpdate(this.FType,this.FNo,this.Fd1,(this.FType == 6 ? this.Fd2.Replace("*",@"<br />").Replace("&",@"</p>").Replace("#",@"<p style='color:Red;'>") : this.Fd2),this.Fd3,this.Fd4,this.Fd5);
					return true;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}


		/// <summary>
		/// select all Account from Acc Table
		/// </summary>
		/// <returns>List of Account or null if Fail</returns>
		public List<TblStart> Get(string ConnectionStr)
		{
			try
			{
				using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
				{
					var result = myContext.TblStartGetAll(this.FType);
					return (from itm in result
							select new TblStart
							{
								FType = itm.FType,
								FNo = itm.FNo,
								Fd1 = itm.Fd1,
                                Fd2 = (itm.FType == 6 ? itm.Fd2.Replace(@"<br />", "*").Replace(@"<br/>", "*").Replace(@"</p>", "&").Replace(@"<p style='color:Red;'>", "#") : itm.Fd2),
								Fd3 = itm.Fd3,
								Fd4 = itm.Fd4,
								Fd5 = itm.Fd5
							}).ToList();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

        /// <summary>
        /// select all Account from Acc Table
        /// </summary>
        /// <returns>List of Account or null if Fail</returns>
        public List<TblStart> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.TblStartGetAll2();
                    return (from itm in result
                            select new TblStart
                            {
                                FType = itm.FType,
                                FNo = itm.FNo,
                                Fd1 = itm.Fd1,
                                Fd2 = itm.Fd2,
                                Fd3 = itm.Fd3,
                                Fd4 = itm.Fd4,
                                Fd5 = itm.Fd5
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


		/// <summary>
		/// select all Account from Acc Table
		/// </summary>
		/// <returns>List of Account or null if Fail</returns>
		public TblStart Find(string ConnectionStr)
		{
			try
			{
				using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
				{
					var result = myContext.TblStartGetAll(this.FType);
					return (from itm in result
							select new TblStart
							{
								FType = itm.FType,
								FNo = itm.FNo,
								Fd1 = itm.Fd1,
								Fd2 = (this.FType == 6 ? itm.Fd2.Replace(@"<br />","*").Replace(@"<br/>","*").Replace(@"</p>","&").Replace(@"<p style='color:Red;'>","#") : itm.Fd2),
								Fd3 = itm.Fd3,
								Fd4 = itm.Fd4,
								Fd5 = itm.Fd5
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
