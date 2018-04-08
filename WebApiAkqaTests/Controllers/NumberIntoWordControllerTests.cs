using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiAkqa.Controllers;

namespace WebApiAkqaTests.Controllers
{
    [TestClass()]
    public class NumberIntoWordControllerTests
    {
        public string Username = "Deepak";

        /// <summary>
        /// Web API Test Method Positive Senerio : Price Value
        /// </summary>
        [TestMethod()]
        public void PositiveCalculateTestPrice()
        {
            var price = 34.45;
            var expected = "Thirty Four dollor and Fourty Five Cents Only";
            var a = new NumberIntoWordController();
            var akqamodel = a.Calculate(Username, price);
            Assert.AreEqual<string>(expected,akqamodel.PriceinWord);
        }

        /// <summary>
        /// Web API Test Method Positive Senerio : Price Value Decimal only
        /// </summary>
        [TestMethod()]
        public void PositiveCalculateTestPriceDecimalOnly()
        {
            var price = 00.45;
            var expected = "Fourty Five Cents Only";
            var a = new NumberIntoWordController();
            var akqamodel = a.Calculate(Username, price);
            Assert.AreEqual<string>(expected, akqamodel.PriceinWord);
        }

        /// <summary>
        /// Web API Test Method Positive Senerio : Price Value more than 2 number after decimal
        /// </summary>
        [TestMethod()]
        public void PositiveCalculateTestPriceAfterDecimal()
        {
            var price = 34.4534389323;
            var expected = "Thirty Four dollor and Fourty Five Cents Only";
            var a = new NumberIntoWordController();
            var akqamodel = a.Calculate(Username, price);
            Assert.AreEqual<string>(expected, akqamodel.PriceinWord);
        }

        /// <summary>
        /// Web API Test Method Positive Senerio User Name
        /// </summary>
        [TestMethod()]
        public void PositiveCalculateTestUserName()
        {
            var price = 34.45;
            var expected = "Deepak";
            var a = new NumberIntoWordController();
            var akqamodel = a.Calculate(Username, price);
            Assert.AreEqual<string>(expected, akqamodel.UserName);
        }

        /// <summary>
        /// Web API Test Method Negative Senerio User Name
        /// </summary>
        [TestMethod()]
        public void NegativeCalculateTestUserName()
        {
            var price = 34.45;
            var expected = "Deepak1";
            var a = new NumberIntoWordController();
            var akqamodel = a.Calculate(Username, price);
            Assert.AreEqual<string>(expected, akqamodel.UserName);
        }

        /// <summary>
        /// Web API Test Method Negative Senerio - Number
        /// </summary>
        [TestMethod()]
        public void NegativeCalculateTestPrice()
        {
            var price = 34.45;
            var expected = "34.45";
            var a = new NumberIntoWordController();
            var akqamodel = a.Calculate(Username, price);
            Assert.AreEqual<string>(expected, akqamodel.PriceinWord);
        }

        /// <summary>
        /// Web API Test Method Negative Senerio - ZERO
        /// </summary>
        [TestMethod()]
        public void NegativeCalculateTestWithZero()
        {
            var price = 34.45;
            var expected = "0";
            var a = new NumberIntoWordController();
            var akqamodel = a.Calculate(Username, price);
            Assert.AreEqual<string>(expected, akqamodel.PriceinWord);
        }

        /// <summary>
        /// Web API Test Method Negative Senerio - NEGATIVE VALUE
        /// </summary>
        [TestMethod()]
        public void NegativeCalculateTestWithNegativeValue()
        {
            var price = 34.45;
            var expected = "-23";
            var a = new NumberIntoWordController();
            var akqamodel = a.Calculate(Username, price);
            Assert.AreEqual<string>(expected, akqamodel.PriceinWord);
        }
    }
}