using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtil;
using System.Data;
using ModuleUtil;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EtaxSignUtil.Layout
{
    public class BaseLayout : IDisposable
    {
        public DBSimple dbSimple;
        public QEB.Center QEBCenterInfo;
        public SellerInformation SellerInformation { get; private set; }
        public BaseLayout(DBSimple dbSimple, QEB.Center QEBCenterInfo)
        {
            this.dbSimple = dbSimple;
            this.QEBCenterInfo = QEBCenterInfo;
        }
        public bool GetSellerInfomation(ref string ErrMsg)
        {
            bool result = false;
            int ErrCode = 0;
            DataTable TBCompany = new DataTable();
            string Query =
$@"SELECT C.HeadQuaterOrBranch
, C.BranchNumber
, C.T AS 'CompanyName'
, C.TaxID
, CASE WHEN C.UseEtaxAddress = 1 THEN C.EtaxPostalCode ELSE C.PostalCode END PostalCode
, CASE WHEN C.UseEtaxAddress = 1 THEN C.EtaxCountry ELSE C.Country END Country
, CASE WHEN C.UseEtaxAddress = 1 THEN C.EtaxAddressThai ELSE C.AddressThai END AddressThai
, CASE WHEN C.UseEtaxAddress = 1 THEN C.EtaxKwaengTambon ELSE C.KwaengTambon END KwaengTambon
, T.T AS KwaengTambonName
, CASE WHEN C.UseEtaxAddress = 1 THEN C.EtaxKhetAmporCity ELSE C.KhetAmporCity END KhetAmporCity
, A.T AS KhetAmporCityName
, CASE WHEN C.UseEtaxAddress = 1 THEN C.EtaxProvinceState ELSE C.ProvinceState END ProvinceState
, P.T AS ProvinceStateName
, P.KwaengKhetTrueFalse
FROM Company C
LEFT JOIN QERP.dbo.ProvinceState P
ON P.CountryCode = CASE WHEN C.UseEtaxAddress = 1 THEN C.EtaxCountry ELSE C.Country END
AND P.Code = CASE WHEN C.UseEtaxAddress = 1 THEN C.EtaxProvinceState ELSE C.ProvinceState END
LEFT JOIN QERP.dbo.KhetAmporCity A
ON A.CountryCode = CASE WHEN C.UseEtaxAddress = 1 THEN C.EtaxCountry ELSE C.Country END
AND A.ProvinceStateCode = CASE WHEN C.UseEtaxAddress = 1 THEN C.EtaxProvinceState ELSE C.ProvinceState END
AND A.Code = CASE WHEN C.UseEtaxAddress = 1 THEN C.EtaxKhetAmporCity ELSE C.KhetAmporCity END
LEFT JOIN QERP.dbo.KwaengTambon T
ON T.CountryCode = CASE WHEN C.UseEtaxAddress = 1 THEN C.EtaxCountry ELSE C.Country END
AND T.ProvinceStateCode = CASE WHEN C.UseEtaxAddress = 1 THEN C.EtaxProvinceState ELSE C.ProvinceState END
AND T.KhetAmporCity = CASE WHEN C.UseEtaxAddress = 1 THEN C.EtaxKhetAmporCity ELSE C.KhetAmporCity END
AND T.Code = CASE WHEN C.UseEtaxAddress = 1 THEN C.EtaxKwaengTambon ELSE C.KwaengTambon END
WHERE C.Code = '{QEBCenterInfo.Company}'";

            int TransErr = dbSimple.FillData(TBCompany, Query, "QERP", ref ErrCode, ref ErrMsg);
            if (TransErr != 0 || TBCompany.Rows.Count == 0)
            {
                ErrMsg = String.Format("ไม่พบ : Seller Infomation [{0}]", ErrMsg);
                return result;
            }
            DataRow rowCompany = TBCompany.Rows[0];
            string CompanyName  = ReceiveValue.StringReceive("CompanyName",rowCompany).Trim();
            string HeadQuaterOrBranch = ReceiveValue.StringReceive("HeadQuaterOrBranch", rowCompany);
            string BranchNumber = ReceiveValue.StringReceive("BranchNumber", rowCompany);
            string TaxID = ReceiveValue.StringReceive("TaxID", rowCompany).Trim().Replace("-", "");
            string ADDRESS = ReceiveValue.StringReceive("AddressThai", rowCompany).Trim();
            int KWAENGTAMBON_CODE = ReceiveValue.IntReceive("KwaengTambon", rowCompany, 0);
            string KWAENGTAMBON_NAME = ReceiveValue.StringReceive("KwaengTambonName", rowCompany);
            int AMPORCITY_CODE = ReceiveValue.IntReceive("KhetAmporCity", rowCompany, 0);
            string AMPORCITY_NAME = ReceiveValue.StringReceive("KhetAmporCityName", rowCompany);
            int PROVINCE_CODE = ReceiveValue.IntReceive("ProvinceState", rowCompany, 0);
            string PROVINCE_NAME = ReceiveValue.StringReceive("ProvinceStateName", rowCompany);
            bool KWAENGKHET_TRUEFALSE = ReceiveValue.BoolReceive("KwaengKhetTrueFalse", rowCompany, false);
            string COUNTRY_ID = ReceiveValue.StringReceive("Country", rowCompany).ToUpper();
            string POST_CODE = ReceiveValue.StringReceive("PostalCode", rowCompany);

            this.SellerInformation = new SellerInformation(
                CompanyName
                , TaxID
                , HeadQuaterOrBranch
                , ADDRESS
                , KWAENGTAMBON_CODE
                , KWAENGTAMBON_NAME
                , AMPORCITY_CODE
                , AMPORCITY_NAME
                , PROVINCE_CODE
                , PROVINCE_NAME
                , KWAENGKHET_TRUEFALSE
                , COUNTRY_ID
                , POST_CODE);
            return true;
        }

        #region IDisposable Members
        public void Dispose()
        {

        }
        #endregion
    }
}
