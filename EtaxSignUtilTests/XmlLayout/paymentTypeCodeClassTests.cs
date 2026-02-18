using Microsoft.VisualStudio.TestTools.UnitTesting;
using EtaxSignUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtaxSignUtil.Tests
{
    [TestClass()]
    public class paymentTypeCodeClassTests
    {
        [TestMethod()]
        public void GetPaymentTypeCodeTest()
        {
            bool isAssert = true;
            string code = paymentTypeCodeClass.GetPaymentTypeCode("CASH");
            if(code != "56")
            {
                isAssert = false;
            }
            Assert.IsTrue(isAssert);
        }
    }
}