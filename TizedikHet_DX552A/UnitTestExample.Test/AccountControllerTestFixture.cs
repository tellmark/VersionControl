using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [
         Test,
         TestCase("abcd1234", false),
         TestCase("irf@uni-corvinus", false),
         TestCase("irf.uni-corvinus.hu", false),
         TestCase("irf@uni-corvinus.hu", true)
        ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            //Arrange
            AccountController accountController = new AccountController();

            //Act
            var actualResult = accountController.ValidateEmail(email);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [
        Test,
        TestCase("AsdAsdAsd", false),
        TestCase("ASDASDASD", false),
        TestCase("asdasdasd", false),
        TestCase("AsdAsd", false),
        TestCase("Abcd1234",true)
        ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            //Arrange
            AccountController accountController = new AccountController();

            //Act
            var actualResult = accountController.ValidatePassword(password);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
