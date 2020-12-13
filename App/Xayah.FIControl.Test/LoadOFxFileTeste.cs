using NUnit.Framework;
using System.IO;
using Xayah.FIControl.Domain;
using System.Collections.Generic;
using System.Linq;
using Xayah.FIControl.Business;

namespace Xayah.FIControl.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoaOFCFile()
        {
            OFXDataBusiness business = new OFXDataBusiness();


            var data = new OFXData();
            var fileName = @"OFXFIles\extrato1.ofx";   

            OFXReader r = new OFXReader(fileName);
        //    data.statement =  business.LoadStatements(r);


           var _OFXData = business.LoadData(r);

            Assert.IsTrue(((List<OFXBankStatement>)data.statements).Count() == 31);
        }
        
    }
}