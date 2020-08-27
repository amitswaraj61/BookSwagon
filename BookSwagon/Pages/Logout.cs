//-----------------------------------------------------------------------
// <copyright file="Logout.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace BookSwagon.Pages
{
    /// <summary>
    /// create Logout class
    /// </summary>
  public class Logout
    {
        /// <summary>
        /// craete IWebDriver
        /// </summary>
        public IWebDriver driver;

        /// <summary>
        /// create Logout method
        /// </summary>
        /// <param name="driver"></param>
        public Logout(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "ctl00_lnkbtnLogout")]
        public IWebElement logoutButton;

       /// <summary>
       /// create Logout to Bookswagon method
       /// </summary>
       public void LogoutToBookSwagaon()
        {
            logoutButton.Click();
            Thread.Sleep(2000);
        }
    }
}
