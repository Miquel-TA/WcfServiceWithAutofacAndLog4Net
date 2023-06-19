using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceWithAutofacAndLog4Net_Client.WCFServer;
using Moq;
using System;

namespace WcfServiceWithAutofacAndLog4Net_Client
{
    [TestClass]
    public class UnitTest1
    {
        Mock<WCFServer.IService> mockedWcfService;

        [TestInitialize]
        public void Initialize()
        {
            mockedWcfService = new Mock<WCFServer.IService>(MockBehavior.Strict);
        }

        [DataTestMethod()]
        [DataRow("240", "160", "400")]
        [DataRow("200", "-200", "0")]
        [DataRow("1.25", "0.25", "1.5")]
        public void TestMethod1(string num1String, string num2String, string expectedSumString)
        {
            // Parses
            decimal num1 = decimal.Parse(num1String);
            decimal num2 = decimal.Parse(num2String);
            decimal expectedSum = decimal.Parse(expectedSumString);

            // Arrange
            var dto = new Dto { Num1 = num1, Num2 = num2 };
            mockedWcfService.Setup(s => s.Suma(dto)).Returns(expectedSum);

            // Act
            var result = mockedWcfService.Object.Suma(dto);

            // Assert
            Assert.AreEqual(expectedSum, result, "Expected sum does not match actual sum");
        }
    }
}
