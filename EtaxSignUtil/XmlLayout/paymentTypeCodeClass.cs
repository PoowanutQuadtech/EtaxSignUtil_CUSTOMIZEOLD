using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtaxSignUtil
{
    public class paymentTypeCodeClass
    {
        // สร้าง dictionary เพื่อทำการ mapping ระหว่าง Name กับ Value และเปรียบเทียบแบบ case-insensitive
        private static Dictionary<string, string> paymentTypeCodeMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Basic", "1" },
            { "End of month", "2" },
            { "Fixed date", "3" },
            { "Deferred", "4" },
            { "Discount not applicable", "5" },
            { "Mixed", "6" },
            { "Extended", "7" },
            { "Basic discount offered", "8" },
            { "Proximo", "9" },
            { "Instant", "10" },
            { "Elective", "11" },
            { "10 days after end of month", "12" },
            { "Seller to advise buyer", "13" },
            { "Paid against statement", "14" },
            { "No charge", "15" },
            { "Not yet defined", "16" },
            { "Ultimo", "17" },
            { "Previously agreed upon", "18" },
            { "United States funds", "19" },
            { "Penalty terms", "20" },
            { "Payment by instalment", "21" },
            { "Discount", "22" },
            { "Available by sight payment", "23" },
            { "Available by deferred payment", "24" },
            { "Available by acceptance", "25" },
            { "Available by negotiation with any bank", "26" },
            { "Available by negotiation with any bank in ...", "27" },
            { "Available by negotiation by named bank", "28" },
            { "Available by negotiation", "29" },
            { "Adjustment payment", "30" },
            { "Late payment", "31" },
            { "Advanced payment", "32" },
            { "Payment by instalments according to progress (as agreed)", "33" },
            { "Payment by instalments according to progress (to be agreed)", "34" },
            { "Nonstandard", "35" },
            { "Tenor payment terms", "36" },
            { "Complete payment", "37" },
            { "Payment terms defined in consolidated invoice", "38" },
            { "Payment upon completion", "39" },
            { "Partial advance", "40" },
            { "Consignment", "41" },
            { "Inter-company account", "42" },
            { "Sell by note", "43" },
            { "Supplier floor plan", "44" },
            { "Contract basis", "45" },
            { "Credit controlled", "46" },
            { "Dating given", "47" },
            { "Trade acceptance", "48" },
            { "Cost plus", "49" },
            { "Letter of credit", "50" },
            { "Lease agreement", "51" },
            { "Cash On Delivery (COD)", "52" },
            { "Cash by state law", "53" },
            { "Bank transfer", "54" },
            { "Cash on arrival", "55" },
            { "Cash", "56" },
            { "Cash discount terms apply", "57" },
            { "Cash with order", "58" },
            { "Cash per vendor request", "59" },
            { "Irrevocable letter of credit", "60" },
            { "Documents against acceptance", "61" },
            { "Charge card", "62" },
            { "Documents against payment", "63" },
            { "Usance bill", "64" },
            { "Letter of credit at sight", "65" },
            { "Secured account", "66" },
            { "Basic commission terms", "67" },
            { "Deposit required", "68" },
            { "Discount with prompt pay", "69" },
            { "Discount with advance payment", "70" },
            { "Certified cheque", "71" },
            { "Cash against documents", "72" },
            { "Bill of exchange", "73" },
            { "Progressive discount", "74" },
            { "Lump sum", "75" },
            { "Fixed fee", "76" },
            { "Promissory note", "77" },
            { "Factoring", "78" }
        };

        public static string GetPaymentTypeCode(string PAYMENT_TYPE_CODE)
        {
            string code = "ZZZ"; 
            if (paymentTypeCodeMap.TryGetValue(PAYMENT_TYPE_CODE, out string mappedCode))
            {
                code = mappedCode; 
            }
            return code; 
        }

    }
}
