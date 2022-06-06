using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    [Serializable]
    public class Vou
    {
        public short sno { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public string CostCenter { get; set; }
        public string CostCenter2 { get; set; }
        public string CostCenterCode { get; set; }
        public string Area { get; set; }
        public string Area2 { get; set; }
        public string AreaCode { get; set; }
        public string CostAcc { get; set; }
        public string CostAcc2 { get; set; }
        public string CostAccCode { get; set; }
        public string Emp { get; set; }
        public string Emp2 { get; set; }
        public string EmpCode { get; set; }
        public string CarNo { get; set; }
        public string CarNo2 { get; set; }
        public string Project { get; set; }
        public string Project2 { get; set; }
        public string ProjectCode { get; set; }
        public string InvNo { get; set; }
        public string Remark { get; set; }
        public int? Claim { get; set; }
        public short? InvType { get; set; }

        public Vou()
        {
            this.sno = 0;
            this.Code = "";
            this.Name = "";
            this.Debit = 0.00;
            this.Credit = 0.00;
            this.CostCenter = "";
            this.CostCenterCode = "-1";
            this.Project = "";
            this.ProjectCode = "-1";
            this.Remark = "";
            this.CostCenter2 = "";
            this.Project2 = "";
            this.Name2 = "";
            this.InvNo = "";
            this.Area = "";
            this.Area2 = "";
            this.AreaCode = "-1";
            this.CostAcc = "";
            this.CostAcc2 = "";
            this.CostAccCode = "-1";
            this.Emp = "";
            this.Emp2 = "";
            this.EmpCode = "-1";
            this.CarNo2 = "";
            this.CarNo = "-1";
            this.Claim = 0;
            this.InvType = 0;
        }
    }
}
