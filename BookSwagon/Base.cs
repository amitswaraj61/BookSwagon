using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using BookSwagon.BrowserFactory;
using BookSwagon.Email;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookSwagon
{
    public class Base
    {
        public IWebDriver driver;

        //create Instance of Browser Factory
        BrowserFactoryMain browser = new BrowserFactoryMain();

        //create Instance of Extent Report
        public static ExtentReports extent = ReportExtent.GetExtentReport();
        public static ExtentTest test;

        //craete instance of Log4net
        public static readonly log4net.ILog log =
        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        [OneTimeSetUp]
        public void Initilize()
        {

            driver = browser.InitBrowser("chrome"); //Initialize chrome driver

            //Using implicitly wait 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //Maximizing the window
            driver.Manage().Window.Maximize();

            //Enter the url
            driver.Url = "https://www.bookswagon.com/login";
        }
       [OneTimeTearDown]
        public void Close()
        {
            Thread.Sleep(2000);

            driver.Quit();
        }
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
               // SendEmailMain.SendEmail(exception.Message.Trim(), exception.StackTrace);
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                string path = Screenshot.Capture(driver, TestContext.CurrentContext.Test.Name);
                test.AddScreenCaptureFromPath(path);
                test.Pass(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Green));
                test.Log(Status.Pass, "Test pass");
            }
            extent.Flush();
        }
    }
}
