//-----------------------------------------------------------------------
// <copyright file="Login.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace BookSwagon.Pages
{
    /// <summary>
    /// create Login class
    /// </summary>
   public class Login
    {
        /// <summary>
        /// create IWebDriver
        /// </summary>
        public IWebDriver driver;

        /// <summary>
        /// create Login constructor
        /// </summary>
        /// <param name="driver"></param>
        public Login(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "ctl00_phBody_SignIn_txtEmail")]
        public IWebElement Email;

        [FindsBy(How = How.Id, Using = "ctl00_phBody_SignIn_txtPassword")]
        public IWebElement Pass;

        [FindsBy(How = How.Id, Using = "ctl00_phBody_SignIn_btnLogin")]
        public IWebElement LoginButton;

        [FindsBy(How = How.XPath, Using = "//body//div//div//div//div//div//div[1]//div[1]//div[2]//div[2]//span[2]")]
        public IWebElement validation;

        [FindsBy(How = How.XPath, Using = "//body//div//div//div//div//div//div[1]//div[1]//div[3]//div[2]//span[1]")]
        public IWebElement passvalidation;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Please enter correct Email or Password.')]")]
        public IWebElement invalidPassValidation;

        /// <summary>
        /// create Login to Bookswagon method
        /// </summary>
        /// <param name="email"></param>
        /// <param name="Password"></param>
        public void LoginToBookSwagaon(String email, String Password)
        {
            Email.SendKeys(email);
            Thread.Sleep(2000);
            Pass.SendKeys(Password);
            Thread.Sleep(2000);
            LoginButton.Click();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// create Validate method
        /// </summary>
        /// <returns>text</returns>
        public string Validate()
        {
            return validation.Text;
        }

        /// <summary>
        /// create Password validate method
        /// </summary>
        /// <returns>text</returns>
        public string PassValidate()
        {
            return passvalidation.Text;
        }
        
        /// <summary>
        /// create Invalid password validate method
        /// </summary>
        /// <returns>text</returns>
      public string InvalidPassValidate()
        {
            return invalidPassValidation.Text;
        }
    }
}
