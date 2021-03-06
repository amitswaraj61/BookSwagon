﻿//-----------------------------------------------------------------------
// <copyright file="BrowserFactoryMain.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace BookSwagon.BrowserFactory
{
    /// <summary>
    /// create Browser Factory main class
    /// </summary>
    class BrowserFactoryMain
    {
        /// <summary>
        /// create IWebDriver
        /// </summary>
        IWebDriver driver;
        public IWebDriver InitBrowser(string browser)
        {
            try
            {
                if (browser == null)
                {
                    throw new BrowserFactoryException("Browser not be null", BrowserFactoryException.ExceptionType.NULL_EXCEPTION);
                }
                if (browser.Length == 0)
                {
                    throw new BrowserFactoryException("Browser not be empty", BrowserFactoryException.ExceptionType.EMPTY_EXCEPTION);
                }
                switch (browser)
                {
                    case "chrome":
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddArgument("--disable-notifications");
                        driver = new ChromeDriver(chromeOptions);
                        break;
                    case "firefox":
                        FirefoxOptions firefoxOptions = new FirefoxOptions();
                        firefoxOptions.SetPreference("dom.webnotifications.enabled", false);
                        driver = new FirefoxDriver(firefoxOptions);
                        break;
                }
                return driver;
            }
            catch (BrowserFactoryException exception)
            {
                throw new BrowserFactoryException(exception.Message, BrowserFactoryException.ExceptionType.NULL_EXCEPTION);
            }
        }
    }
}
