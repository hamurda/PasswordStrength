using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CAppPasswordStrength.Tests
{

    [TestClass]
    public class StrengthAPIHelperTests
    {

        [TestMethod]
        public void GetStrength_EmptyPassword_ReturnsBlank()
        {
            //Arrange
            StrengthAPIHelper.InitilizeClient();
            string password = "";

            //Act
            string strength = StrengthAPIHelper.GetStrength(password).Result;

            //Assert
            Assert.AreEqual("Blank", strength);
        }

        [TestMethod]
        public void GetStrength_OneCharPassword_ReturnsVeryWeak()
        {
            StrengthAPIHelper.InitilizeClient();
            string password = "a";

            string strength = StrengthAPIHelper.GetStrength(password).Result;

            Assert.AreEqual("VeryWeak", strength);
        }

        [TestMethod]
        public void GetStrength_FiveCharPassword_ReturnsVeryWeak()
        {
            StrengthAPIHelper.InitilizeClient();
            string password = "a1[Ab";

            string strength = StrengthAPIHelper.GetStrength(password).Result;

            Assert.AreEqual("VeryWeak", strength);
        }

        [TestMethod]
        public void GetStrength_SixCharSingleConditionPassword_ReturnsWeak()
        {
            StrengthAPIHelper.InitilizeClient();
            string password = "abcdef";

            string strength = StrengthAPIHelper.GetStrength(password).Result;

            Assert.AreEqual("Weak", strength);
        }

        [TestMethod]
        public void GetStrength_SixCharDoubleConditionPassword_Medium()
        {
            StrengthAPIHelper.InitilizeClient();
            string password = "123[]6";

            string strength = StrengthAPIHelper.GetStrength(password).Result;

            Assert.AreEqual("Medium", strength);
        }

        [TestMethod]
        public void GetStrength_SixCharThreeConditionPassword_Strong()
        {
            StrengthAPIHelper.InitilizeClient();
            string password = "123[]A";

            string strength = StrengthAPIHelper.GetStrength(password).Result;

            Assert.AreEqual("Strong", strength);
        }

        [TestMethod]
        public void GetStrength_SevenCharThreeConditionPassword_Strong()
        {
            StrengthAPIHelper.InitilizeClient();
            string password = "123[]AB";

            string strength = StrengthAPIHelper.GetStrength(password).Result;

            Assert.AreEqual("Strong", strength);
        }

        [TestMethod]
        public void GetStrength_SixCharFourConditionPassword_Strong()
        {
            StrengthAPIHelper.InitilizeClient();
            string password = "12[]Ab";

            string strength = StrengthAPIHelper.GetStrength(password).Result;

            Assert.AreEqual("Strong", strength);
        }

        [TestMethod]
        public void GetStrength_SevenCharFourConditionPassword_Unbreakable()
        {
            StrengthAPIHelper.InitilizeClient();
            string password = "123[]Ab";

            string strength = StrengthAPIHelper.GetStrength(password).Result;

            Assert.AreEqual("Unbreakable", strength);
        }
    }
}
