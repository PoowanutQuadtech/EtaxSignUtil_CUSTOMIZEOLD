using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using DBUtil;
using System.Data;
using ModuleUtil;
using System.Reflection;
using System.ComponentModel;

namespace EtaxSignUtil.Layout
{
    public class FileControl : TaxFileLayout 
    {
        [Required()]
        [StringLength(1)]
        [Description("ประเภทรายการ[DATA_TYPE]")]
        public virtual string DATA_TYPE { get; set; }

        [Required()]
        [StringLength(13)]
        [Description("เลขประจำตัวผู้เสียภาษีอากรของผู้ขาย[SELLER_TAX_ID]")]
        public virtual string SELLER_TAX_ID { get; set; }

        [Required()]
        [StringLength(5)]
        [Description("เลขสาขาสถานประกอบการ[SELLER_BRANCH_ID]")]
        public virtual string SELLER_BRANCH_ID { get; set; }

        [Required()]
        [StringLength(50)]
        [Description("ชื่อไฟล์[FILE_NAME]")]
        public virtual string FILE_NAME { get; set; }

        public FileControl(string SELLER_TAX_ID
            , string SELLER_BRANCH_ID)
        {
            this.DATA_TYPE = "C";
            this.SELLER_TAX_ID = SELLER_TAX_ID;
            this.SELLER_BRANCH_ID = SELLER_BRANCH_ID;
            this.FILE_NAME = String.Format("{0}.txt", SELLER_TAX_ID);
        }
    }
}
