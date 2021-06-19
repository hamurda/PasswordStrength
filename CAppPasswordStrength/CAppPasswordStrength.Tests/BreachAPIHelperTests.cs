using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CAppPasswordStrength.Tests
{
    [TestClass]
    public class BreachAPIHelperTests
    {

        [TestMethod]
        public void GetBreachInfo_EmptyPassword_ReturnsInvalid()
        {
            BreachAPIHelper.InitilizeClient();
            string password = "";

            string info = BreachAPIHelper.GetBreachInfo(password).Result;

            Assert.AreEqual("Invalid", info);

        }       

        [TestMethod]
        public void GetBreachInfo_PawnedPassword_ReturnsStringNotEqualToZero()
        {
            BreachAPIHelper.InitilizeClient();
            string password = "qwerty";

            string info = BreachAPIHelper.GetBreachInfo(password).Result;

            long result;
            if (Int64.TryParse(info, out result))
            {
                Assert.AreNotEqual(0, result);
            }
            else
            {
                Assert.Fail();
            }            
        }

        [TestMethod]
        public void GetBreachInfo_NotPawnedPassword_ReturnsStringEqualsToZero()
        {
            BreachAPIHelper.InitilizeClient();
            string password = "notPawned"; //not in the list at the time I'm testing

            string info = BreachAPIHelper.GetBreachInfo(password).Result;

            long result;
            if (Int64.TryParse(info, out result))
            {
                Assert.AreEqual(0, result);
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
