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
    public class DocumentHeader : TaxFileLayout
    {
        [Required()]
        [StringLength(1)]
        [Description("ประเภทรายการ[DATA_TYPE]")]
        public virtual string DATA_TYPE { get; set; }

        [Required()]
        [StringLength(3)]
        [Description("ประเภทเอกสาร [DOCUMENT_TYPE_CODE]")]
        public virtual string DOCUMENT_TYPE_CODE { get; set; }

        [StringLength(35)]
        [Description("ชื่อเอกสาร [DOCUMENT_NAME]")]
        public virtual string DOCUMENT_NAME { get; set; }

        [Required()]
        [StringLength(35)]
        [Description("เลขที่เอกสาร[DOCUMENT_ID]")]
        public virtual string DOCUMENT_ID { get; set; }


        [Required()]
        [StringLength(19)]
        [Description("เอกสารลงวันที่[DOCUMENT_ISSUE_DTM]")]
        public virtual string DOCUMENT_ISSUE_DTM { get; set; }


        [StringLength(6)]
        [Description("สาเหตุการออกเอกสาร[CREATE_PURPOSE_CODE]")]
        public virtual string CREATE_PURPOSE_CODE { get; set; }


        [StringLength(256)]
        [Description("สาเหตุการออกเอกสาร[CREATE_PURPOSE]")]
        public virtual string CREATE_PURPOSE { get; set; }


        [StringLength(35)]
        [Description("เลขที่เอกสารอ้างอิง[ADDITIONAL_REF_ASSIGN_ID]")]
        public virtual string ADDITIONAL_REF_ASSIGN_ID { get; set; }


        [StringLength(19)]
        [Description("เอกสารอ้างอิงลงวันที่[ADDITIONAL_REF_ISSUE_DTM]")]
        public virtual string ADDITIONAL_REF_ISSUE_DTM { get; set; }


        [StringLength(3)]
        [Description("ประเภทเอกสารอ้างอิง[ADDITIONAL_REF_TYPE_CODE]")]
        public virtual string ADDITIONAL_REF_TYPE_CODE { get; set; }


        [StringLength(35)]
        [Description("ชื่อเอกสารอ้างอิง [ADDITIONAL_REF_DOCUMENT_NAME]")]
        public virtual string ADDITIONAL_REF_DOCUMENT_NAME { get; set; }


        [StringLength(3)]
        [Description("เงื่อนไขการส่งของ [DELIVERY_TYPE_CODE]")]
        public virtual string DELIVERY_TYPE_CODE { get; set; }


        [StringLength(35)]
        [Description("เลขที่ใบสั่งซื้อ[BUYER_ORDER_ASSIGN_ID]")]
        public virtual string BUYER_ORDER_ASSIGN_ID { get; set; }


        [StringLength(19)]
        [Description("วันเดือนปี ที่ออกใบสั่งซื้อ[BUYER_ORDER_ISSUE_DTM]")]
        public virtual string BUYER_ORDER_ISSUE_DTM { get; set; }


        [StringLength(3)]
        [Description("ประเภทเอกสารอ้างอิงการสั่งซื้อ[BUYER_ORDER_REF_TYPE_CODE]")]
        public virtual string BUYER_ORDER_REF_TYPE_CODE { get; set; }


        [StringLength(500)]
        [Description("หมายเหตุท้ายเอกสาร[DOCUMENT_REMARK]")]
        public virtual string DOCUMENT_REMARK { get; set; }


        [StringLength(50)]
        [Description("เลขใบสำคัญจ่าย[VOUCHER_NO]")]
        public virtual string VOUCHER_NO { get; set; }


        [StringLength(140)]
        [Description("ชื่อผู้ติดต่อ[SELLER_CONTACT_PERSON_NAME]")]
        public virtual string SELLER_CONTACT_PERSON_NAME { get; set; }


        [StringLength(140)]
        [Description("ชื่อแผนก[SELLER_CONTACT_DEPARTMENT_NAME]")]
        public virtual string SELLER_CONTACT_DEPARTMENT_NAME { get; set; }


        [StringLength(256)]
        [Description("อีเมล[SELLER_CONTACT_URIID]")]
        public virtual string SELLER_CONTACT_URIID { get; set; }


        [StringLength(35)]
        [Description("เบอร์โทรศัพท์[SELLER_CONTACT_PHONE_NO]")]
        public virtual string SELLER_CONTACT_PHONE_NO { get; set; }

        [StringLength(35)]
        [Description("เลขที่ใบส่งสินค้า[BUYER_ORDER_ASSIGN_ID2]")]
        public virtual string BUYER_ORDER_ASSIGN_ID2 { get; set; }

        public DocumentHeader(
            string DOCUMENT_NAME
            , string DOCUMENT_TYPE_CODE
            , string DOCUMENT_ID
            , DateTime DOCUMENT_ISSUE_DTM
            , string BUYER_ORDER_ASSIGN_ID
            , string DOCUMENT_REMARK)
        {
            this.DATA_TYPE = "H";
            this.DOCUMENT_NAME = DOCUMENT_NAME;
            this.DOCUMENT_TYPE_CODE = DOCUMENT_TYPE_CODE;
            this.DOCUMENT_ID = DOCUMENT_ID;
            this.DOCUMENT_ISSUE_DTM = this.ConvertISODateTime(DOCUMENT_ISSUE_DTM);
            this.BUYER_ORDER_ASSIGN_ID = BUYER_ORDER_ASSIGN_ID.Trim();
            this.DOCUMENT_REMARK = DOCUMENT_REMARK;
        }
    }
}
