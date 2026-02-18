using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EtaxSignUtil.CNDNSALES
{
    public class DocumentHeader : EtaxSignUtil.Layout.DocumentHeader
    {
        public string DOCUMENT_TYPE { get; set; }

        [Required()]
        [StringLength(6)]
        [Description("สาเหตุการออกเอกสาร[CREATE_PURPOSE_CODE]")]
        public override string CREATE_PURPOSE_CODE { get; set; }

        [Required()]
        [StringLength(256)]
        [Description("สาเหตุการออกเอกสาร[CREATE_PURPOSE]")]
        public override string CREATE_PURPOSE { get; set; }

        [Required()]
        [StringLength(35)]
        [Description("เลขที่เอกสารอ้างอิง[ADDITIONAL_REF_ASSIGN_ID]")]
        public override string ADDITIONAL_REF_ASSIGN_ID { get; set; }

        [Required()]
        [StringLength(19)]
        [Description("เอกสารอ้างอิงลงวันที่[ADDITIONAL_REF_ISSUE_DTM]")]
        public override string ADDITIONAL_REF_ISSUE_DTM { get; set; }

        [Required()]
        [StringLength(3)]
        [Description("ประเภทเอกสารอ้างอิง[ADDITIONAL_REF_TYPE_CODE]")]
        public override string ADDITIONAL_REF_TYPE_CODE { get; set; }

        public DocumentHeader(string CrDr_TYPE
            , string DOCUMENT_ID
            , DateTime DOCUMENT_ISSUE_DTM
            , string BUYER_ORDER_ASSIGN_ID
            , string DOCUMENT_REMARK
            , string CREATE_PURPOSE
            , string ADDITIONAL_REF_ASSIGN_ID
            , DateTime ADDITIONAL_REF_ISSUE_DTM)
            : base(CrDr_TYPE == "C" ? "ใบเพิ่มหนี้" : "ใบลดหนี้"
            , CrDr_TYPE == "C" ? "80" : "81"
            , DOCUMENT_ID
            , DOCUMENT_ISSUE_DTM
            , BUYER_ORDER_ASSIGN_ID
            , DOCUMENT_REMARK)
        {
            this.DOCUMENT_TYPE = CrDr_TYPE;
            this.CREATE_PURPOSE_CODE = CrDr_TYPE == "C" ? "DBNG99" : "CDNG99";
            this.CREATE_PURPOSE = CREATE_PURPOSE;
            this.ADDITIONAL_REF_ASSIGN_ID = ADDITIONAL_REF_ASSIGN_ID;
            this.ADDITIONAL_REF_ISSUE_DTM = this.ConvertISODateTime(ADDITIONAL_REF_ISSUE_DTM);
            this.ADDITIONAL_REF_TYPE_CODE = "388";
            this.ADDITIONAL_REF_DOCUMENT_NAME = "ใบกำกับภาษี";
        }
    }
}
