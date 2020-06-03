using System;
using NUnit.Framework;
using ETAL.Util;

namespace ETAL.UtilTest
{
    public class ComputerHelperTest
    {
        [Test]
        public void TestGetComputerInfo()
        {
            ComputerInfo computerInfo = ComputerHelper.GetComputerInfo();

            Assert.IsNotEmpty(computerInfo.CPURate);
            Assert.IsNotEmpty(computerInfo.RAMRate);
            Assert.IsNotEmpty(computerInfo.TotalRAM);
            Assert.IsNotEmpty(computerInfo.RunTime);
        }
    }
}
