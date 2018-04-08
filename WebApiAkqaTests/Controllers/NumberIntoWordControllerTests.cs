using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiAkqa.Controllers;

namespace WebApiAkqaTests.Controllers
{
    [TestClass()]
    public class NumberIntoWordControllerTests
    {
        public string Username = "Deepak";

        /// <summary>
        /// Web API Test Method Senerio : Price Value
        /// </summary>
        [TestMethod()]
        public void CalculateTestPrice()
        {
            var price = 34.45;
            var expected = "Thirty Four dollor and Fourty Five Cents Only";
            var a = new NumberIntoWordController();
            var akqamodel = a.Calculate(Username, price);
            Assert.AreEqual<string>(expected,akqamodel.PriceinWord);
        }

        /// <summary>
        /// Web API Test Method Senerio : Price Value Decimal only
        /// </summary>
        [TestMethod()]
        public void CalculateTestPriceDecimalOnly()
        {
            var price = 00.45;
            var expected = "Fourty Five Cents Only";
            var a = new NumberIntoWordController();
            var akqamodel = a.Calculate(Username, price);
            Assert.AreEqual<string>(expected, akqamodel.PriceinWord);
        }

        /// <summary>
        /// Web API Test Method Senerio : Price Value more than 2 number after decimal
        /// </summary>
        [TestMethod()]
        public void CalculateTestPriceAfterDecimal()
        {
            var price = 34.4534389323;
            var expected = "Thirty Four dollor and Fourty Five Cents Only";
            var a = new NumberIntoWordController();
            var akqamodel = a.Calculate(Username, price);
            Assert.AreEqual<string>(expected, akqamodel.PriceinWord);
        }

        /// <summary>
        /// Web API Test Method Senerio User Name
        /// </summary>
        [TestMethod()]
        public void CalculateTestUserName()
        {
            var price = 34.45;
            var expected = "Deepak";
            var a = new NumberIntoWordController();
            var akqamodel = a.Calculate(Username, price);
            Assert.AreEqual<string>(expected, akqamodel.UserName);
        }

        /// <summary>
        /// Web API Test Method Senerio Zero
        /// </summary>
        [TestMethod()]
        public void CalculateTestZero()
        {
            var price = 0.00;
            var expected = "Please Enter Number above than 0.00";
            var a = new NumberIntoWordController();
            var akqamodel = a.Calculate(Username, price);
            Assert.AreEqual<string>(expected, akqamodel.PriceinWord);
        }
    }
}