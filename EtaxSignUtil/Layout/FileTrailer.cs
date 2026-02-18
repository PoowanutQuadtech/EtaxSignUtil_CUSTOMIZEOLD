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
    public class FileTrailer : TaxFileLayout
    {
        [Required()]
        [StringLength(1)]
        [Description("ประเภทรายการ[DATA_TYPE]")]
        public virtual string DATA_TYPE { get; set; }

        [Required()]
        [StringLength(5)]
        [Description("จำนวนเอกสารทั้งหมด[TOTAL_DOCUMENT_COUNT]")]
        public virtual string TOTAL_DOCUMENT_COUNT { get; set; }


        public FileTrailer(int TOTAL_DOCUMENT_COUNT)
        {
            this.DATA_TYPE = "T";
            this.TOTAL_DOCUMENT_COUNT = TOTAL_DOCUMENT_COUNT.ToString();
        }
    }
}
