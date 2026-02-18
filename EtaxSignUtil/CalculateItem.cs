using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtaxSignUtil
{
    public class CalculateItem
    {
        public double Total_ItemIncludeVAT { get; set; }
        public double Total_Discount { get; set; }
        public double Total_AfterVAT { get; set; }
        public double Remain_BeforeVAT { get; set; }
        public double Remain_AfterVAT { get; set; }
        public double Remain_Discount { get; set; }
        public CalculateItem(double Discount, double AfterDiscount, double AfterVAT)
        {
            double Total_BeforeDiscount = Math.Round(AfterDiscount + Discount, 2);
            this.Total_Discount = Discount;
            this.Total_AfterVAT = AfterVAT;
            this.Total_ItemIncludeVAT = Math.Round(AfterVAT + Discount, 2);

            this.Remain_BeforeVAT = Total_BeforeDiscount;
            this.Remain_AfterVAT = AfterVAT;
            this.Remain_Discount = this.Total_Discount;
        }
    }
}
