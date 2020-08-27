//-----------------------------------------------------------------------
// <copyright file="BookSwagonNegative.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using BookSwagon.Pages;
using NUnit.Framework;
using System.Configuration;

namespace BookSwagon
{
    /// <summary>
    /// craete BookSwagonNegative class
    /// </summary>
  
    [TestFixture]
    [Parallelizable]
   public class BookSwagonNegative:Base
    {
        /// <summary>
        /// create object of Credentials class
        /// </summary>
        Credentials credentails = new Credentials();

        /// <summary>
        /// craete Invalid user name test
        /// </summary>
        [Test,Order(1)]
        public void GivenInvalidUserName_ShouldReturnInvalidEmailMessage()
        {
            log.Info("valid Login Test Started");
            Login login = new Login(driver);
            login.LoginToBookSwagaon(ConfigurationManager.AppSettings["InvalidUserName"], ConfigurationManager.AppSettings["Password"]);
            string actualResult = login.Validate();
            string expectedResult = "Invalid E-mail";
            Assert.AreEqual(expectedResult, actualResult);
            log.Info("Test Pass");
        }

        /// <summary>
        /// craete Not given password test
        /// </summary>
        [Test,Order(2)]
        public void NotGivenPassword_ShouldReturnRequiredMessage()
        {
            log.Info("valid Login Test Started");
            Login login = new Login(driver);
            login.LoginToBookSwagaon(credentails.email,"");
            string actualResult = login.PassValidate();
            string expectedResult = "Required";
            Assert.AreEqual(expectedResult, actualResult);
            log.Info("Test Pass");
        }

        /// <summary>
        /// create Invalid password test
        /// </summary>
        [Test,Order(3)]
        public void GivenInvalidPassword_ShouldReturnEnterCorrectUserNameAndPaasword()
        {
            log.Info("valid Login Test Started");
            Login login = new Login(driver);
            login.LoginToBookSwagaon(credentails.email, ConfigurationManager.AppSettings["invalidPassword"]);
            string actualResult = login.InvalidPassValidate();
            string expectedResult = "Please enter correct Email or Password.";
            Assert.AreEqual(expectedResult, actualResult);
            log.Info("Test Pass");
        }

        /// <summary>
        /// create Invalid email test
        /// </summary>
        [Test,Order(4)]
        public void GivenInvalidEmail_ShouldReturnEnterCorrectUserNameAndPaasword()
        {
            log.Info("valid Login Test Started");
            Login login = new Login(driver);
            login.LoginToBookSwagaon(ConfigurationManager.AppSettings["invalidUser"], ConfigurationManager.AppSettings["Password"]);
            string actualResult = login.InvalidPassValidate();
            string expectedResult = "Please enter correct Email or Password.";
            Assert.AreEqual(expectedResult, actualResult);
            log.Info("Test Pass");
        }
    }
}
