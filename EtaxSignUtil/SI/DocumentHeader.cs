using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtaxSignUtil.SI
{
    public class DocumentHeader : EtaxSignUtil.Layout.DocumentHeader
    {
        public DocumentHeader(string DOCUMENT_ID
            , DateTime DOCUMENT_ISSUE_DTM
            , string BUYER_ORDER_ASSIGN_ID
            , string DOCUMENT_REMARK)
            : base("ใบกำกับภาษี"
            , "388"
            , DOCUMENT_ID
            , DOCUMENT_ISSUE_DTM
            , BUYER_ORDER_ASSIGN_ID
            , DOCUMENT_REMARK)
        {

        }

        public DocumentHeader(string DOCUMENT_ID
          , DateTime DOCUMENT_ISSUE_DTM
          , string BUYER_ORDER_ASSIGN_ID
          , string BUYER_ORDER_ASSIGN_ID2
          , string DOCUMENT_REMARK)
            : base("ใบกำกับภาษี"
            , "388"
            , DOCUMENT_ID
            , DOCUMENT_ISSUE_DTM
            , BUYER_ORDER_ASSIGN_ID
            , DOCUMENT_REMARK)
        {
            this.BUYER_ORDER_ASSIGN_ID2 = BUYER_ORDER_ASSIGN_ID2;
        }
    }
}
