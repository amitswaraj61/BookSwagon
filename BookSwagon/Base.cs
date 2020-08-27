//-----------------------------------------------------------------------
// <copyright file="Base.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using BookSwagon.BrowserFactory;
using BookSwagon.Email;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Configuration;

namespace BookSwagon
{/// <summary>
/// create Base class
/// </summary>
    public class Base
    {
        /// <summary>
        /// create IWebDriver
        /// </summary>
        public IWebDriver driver;

        /// <summary>
        /// create object of Browser Factory Main class
        /// </summary>
        BrowserFactoryMain browser = new BrowserFactoryMain();

        /// <summary>
        /// create object of Report extent class
        /// </summary>
        public static ExtentReports extent = ReportExtent.GetExtentReport();
        public static ExtentTest test;

        /// <summary>
        /// create object of Log4net
        /// </summary>
        public static readonly log4net.ILog log =
        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// create one time setup to initialize browser
        /// </summary>
        [OneTimeSetUp]
        public void Initilize()
        {
            driver = browser.InitBrowser("chrome");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            driver.Url = ConfigurationManager.AppSettings["URL"];
        }
        
        /// <summary>
        /// create one time tear down to quit the browser
        /// </summary>
       [OneTimeTearDown]
        public void Close()
        { 
           driver.Quit();
        }

        /// <summary>
        /// create tear down to take screenshot,generate extent report and send email
        /// </summary>
        [TearDown]
        public void ExtentFlush()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
            var error = TestContext.CurrentContext.Result.Message;
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                test.Log(Status.Info,error);
                string path = Screenshot.Capture(driver, TestContext.CurrentContext.Test.Name + "   " + "Failed");
                test.AddScreenCaptureFromPath(path);
                test.Fail(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Red));
                test.Log(Status.Fail, "Test Failed");
                log.Error("Test Failed");
                SendEmailMain.SendEmail(error,TestContext.CurrentContext.Result.StackTrace);
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                string path = Screenshot.Capture(driver, TestContext.CurrentContext.Test.Name);
                test.AddScreenCaptureFromPath(path);
                test.Pass(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Green));
                test.Log(Status.Pass, "Test pass");
            }
            driver.Navigate().Refresh(); // every test must refresh the webpage ..use in negative test
            extent.Flush();
        }
    }
}
