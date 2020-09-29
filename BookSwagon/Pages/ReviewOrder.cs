//-----------------------------------------------------------------------
// <copyright file="ReviewOrder.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace BookSwagon.Pages
{
    /// <summary>
    /// create Review order class
    /// </summary>
   public class ReviewOrder
    {
        /// <summary>
        /// create IWebDriver
        /// </summary>
        public IWebDriver driver;

        /// <summary>
        /// create Review order constructor
        /// </summary>
        /// <param name="driver"></param>
        [System.Obsolete]
        public ReviewOrder(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_ShoppingCart_lvCart_savecontinue")]
        public IWebElement saveAndContinue;

        /// <summary>
        /// create Review order check method
        /// </summary>
       public void ReviewOrderCheck()
        {
            saveAndContinue.Click();
            Thread.Sleep(2000);
        }
    }
}
