using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    [Serializable]
    public class AccType
    {
        public string FType { get; set; }
        public string Name { get; set; }

        public List<AccType> GetallType(short CurLevel)
        {
            bool AccountType = false; // Should Change and Switch According to Clients
            List<AccType> actype = new List<AccType>();
            if (CurLevel == 1)
            {
                actype.Add(new AccType { FType = "1", Name = "حساب ميزانية - أصول" });
                actype.Add(new AccType { FType = "2", Name = "حساب ميزانية - مطلوبات وحقوق ملكية" });
                if (AccountType)
                {
                    actype.Add(new AccType { FType = "3", Name = "الارباح والخسائر - الايرادات" });
                    actype.Add(new AccType { FType = "4", Name = "الارباح والخسائر - المصروفات" });
                    actype.Add(new AccType { FType = "5", Name = "التشغيل والمتاجرة - الايرادات" });
                    actype.Add(new AccType { FType = "6", Name = "التشغيل و المتاجرة - المصروفات" });
                }
                else
                {
                    actype.Add(new AccType { FType = "3", Name = "قائمة الدخل - الايرادات" });
                    actype.Add(new AccType { FType = "4", Name = "قائمة الدخل - المصروفات" });
                }
            }
            else 
            {
                actype.Add(new AccType { FType = "1", Name = "حساب ميزانية - أصول ثابتة" });
                actype.Add(new AccType { FType = "2", Name = "حساب ميزانية - أصول متداولة" });
                actype.Add(new AccType { FType = "3", Name = "حساب ميزانية - مطلوبات متداولة" });
                actype.Add(new AccType { FType = "4", Name = "حساب ميزانية - حقوق الملكية" });
                if (AccountType)
                {
                    actype.Add(new AccType { FType = "5", Name = "الارباح والخسائر - الايرادات" });
                    actype.Add(new AccType { FType = "6", Name = "الارباح والخسائر - المصروفات" });
                    actype.Add(new AccType { FType = "7", Name = "التشغيل والمتاجرة - الايرادات" });
                    actype.Add(new AccType { FType = "8", Name = "التشغيل و المتاجرة - المصروفات" });
                }
                else
                {
                    actype.Add(new AccType { FType = "5", Name = "قائمة الدخل - الايرادات" });
                    actype.Add(new AccType { FType = "6", Name = "قائمة الدخل - المصروفات" });
                }
            }
            return actype;
        }
    }

}
