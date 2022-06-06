using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;
using System.Configuration;
using BLL;
using System.Web.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Reflection;

namespace ACC
{
    public partial class WebExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            if (FileUpload1.PostedFile != null)
            {
                String FileName = Config.GetImageName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                string excelPath = Server.MapPath("~/Excel/") + FileName + Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(excelPath);

                string connString = "";
                string strFileType = Path.GetExtension(this.FileUpload1.FileName).ToLower();
                string path = this.FileUpload1.PostedFile.FileName;
                //Connection String to Excel Workbook
                if (strFileType.Trim() == ".xls")
                {
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelPath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }
                else if (strFileType.Trim() == ".xlsx")
                {
                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelPath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                }
                string query = "SELECT * FROM " + ddlSheet.SelectedValue; //[Sheet1$]";

                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    grvExcelData.DataSource = ds.Tables[0];
                    grvExcelData.DataBind();

                    FExcel ex = new FExcel();
                    ex.DeleteAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    int i = 1;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {                        
                        ex = new FExcel();
                        ex.Num = i++;
                        int r = 1;
                        foreach (var item in row.ItemArray)
                        {
                            PropertyInfo propertyInfo = typeof(FExcel).GetProperty("F" +moh.MakeMask(r.ToString(),2));
                            if (propertyInfo != null) propertyInfo.SetValue(ex,item.ToString(), null);
                            r++;
                        }
                        ex.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    da.Dispose();
                    conn.Close();
                    conn.Dispose();

                    List<CarPrices> VouData = new List<CarPrices>();
                    ex = new FExcel();
                    bool vFirst = true;
                    foreach (FExcel itm in ex.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        if (!string.IsNullOrEmpty(itm.F14))
                        {
                            if (vFirst)
                            {
                                vFirst = false;
                                VouData.Add(new CarPrices
                                {
                                    Branch = 1,
                                    AccountNo = "-1",
                                    MonthNo = 0,
                                    PLevel = moh.MakeMask((ddlSheet.SelectedIndex + 21).ToString(), 5),
                                    FromCode = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                                  where sitm.Name1.Contains(itm.F02.Trim())
                                                    select sitm.Code).FirstOrDefault(),  //99999
                                    CollectBran = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                                    where citm.Name1.Contains(itm.F03)
                                                        select citm.Code).FirstOrDefault(),
                                    toCode = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                              where sitm.Name1.Contains(itm.F06.Trim())
                                              select sitm.Code).FirstOrDefault(),  //99999
                                    DisBran = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                                    where citm.Name1.Contains(itm.F07)
                                                        select citm.Code).FirstOrDefault(),
                                    BranRange = moh.StrToDouble(itm.F04),
                                    BranRange2 = moh.StrToDouble(itm.F08),
                                    KMeter = moh.StrToDouble(itm.F09),
                                    Price = moh.StrToDouble(itm.F10),
                                    PriceDiff = moh.StrToDouble(itm.F11),
                                    CollectPrice = moh.StrToDouble(itm.F12),
                                    DisPrice = moh.StrToDouble(itm.F13),
                                    XPrice1 = moh.StrToDouble(itm.F14),
                                    HTwoWay = moh.StrToDouble(itm.F15),
                                    TruckPrice = moh.StrToDouble(itm.F16),
                                    Truck2Price = moh.StrToDouble(itm.F17),
                                    FTime = itm.F18,
                                    CostAmount = moh.StrToDouble(itm.F19),
                                    HOneWay = moh.StrToDouble(itm.F20),
                                    LTwoWay = moh.StrToDouble(itm.F21),
                                    ExPrice1 = moh.StrToDouble(itm.F22),
                                    ExPrice12 = moh.StrToDouble(itm.F23),
                                    ExPrice4 = moh.StrToDouble(itm.F24),
                                    ExPrice42 = moh.StrToDouble(itm.F25),
                                    ExPrice2 = moh.StrToDouble(itm.F26),
                                    ExPrice22 = moh.StrToDouble(itm.F27),
                                    ExPrice3 = moh.StrToDouble(itm.F28),
                                    ExPrice32 = moh.StrToDouble(itm.F29),
                                    FTime2 = itm.F30,
                                    XPrice3 = moh.StrToDouble(itm.F31),
                                    XPrice4 = moh.StrToDouble(itm.F32),
                                    XPrice5 = moh.StrToDouble(itm.F33),
                                });
                            }
                            else
                            {
                                vFirst = true;
                                VouData[VouData.Count() - 1].CollectPrice2 = moh.StrToDouble(itm.F12);
                                VouData[VouData.Count() - 1].DisPrice2 = moh.StrToDouble(itm.F13);
                                VouData[VouData.Count() - 1].XPrice2 = moh.StrToDouble(itm.F14);
                                VouData[VouData.Count() - 1].LTwoWay = moh.StrToDouble(itm.F15);
                                VouData[VouData.Count() - 1].TruckPrice2 = moh.StrToDouble(itm.F16);
                                VouData[VouData.Count() - 1].Truck2Price2 = moh.StrToDouble(itm.F17);
                                VouData[VouData.Count() - 1].ExPrice01 = moh.StrToDouble(itm.F22);
                                VouData[VouData.Count() - 1].ExPrice012 = moh.StrToDouble(itm.F23);
                                VouData[VouData.Count() - 1].ExPrice04 = moh.StrToDouble(itm.F24);
                                VouData[VouData.Count() - 1].ExPrice042 = moh.StrToDouble(itm.F25);
                                VouData[VouData.Count() - 1].ExPrice02 = moh.StrToDouble(itm.F26);
                                VouData[VouData.Count() - 1].ExPrice022 = moh.StrToDouble(itm.F27);
                                VouData[VouData.Count() - 1].ExPrice03 = moh.StrToDouble(itm.F28);
                                VouData[VouData.Count() - 1].ExPrice032 = moh.StrToDouble(itm.F29);
                                VouData[VouData.Count() - 1].Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }
                        }
                    }

                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult.Text = "لقد تمت أستيراد البيانات بنجاح";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);
                }
            }
        }
    }
}