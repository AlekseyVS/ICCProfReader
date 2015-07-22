using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ICCProfReader;

namespace ICCProfReaderUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodGray()
        {
            Work wrk = new Work();
            wrk.GetProfile("BlackWhite.icc");
            wrk.GetData();

            Assert.IsTrue(wrk.iccProfile.NumComponents == "1");
            Assert.AreEqual(wrk.iccProfile.ClrType, ColorTypeEnum.Gray);
            Assert.AreEqual(wrk.iccProfile.Description, "Black & White");
        }

        [TestMethod]
        public void TestMethodRGB()
        {
            Work wrk = new Work();
            wrk.GetProfile("AppleRGB.icc");
            wrk.GetData();

            Assert.IsTrue(wrk.iccProfile.NumComponents == "3");
            Assert.AreEqual(wrk.iccProfile.ClrType, ColorTypeEnum.RGB);
            Assert.AreEqual(wrk.iccProfile.Description, "Apple RGB");
        }
    }
}
