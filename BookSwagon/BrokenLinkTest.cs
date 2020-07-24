using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BookSwagon
{
    [Parallelizable]
    class BrokenLinkTest
    {
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void BrokenLinksTest()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // implicit weight for 20 secs

            driver.Navigate().GoToUrl("http://www.google.com"); //naviagte to this url and open web page

            IList<IWebElement> links = driver.FindElements(By.TagName("a"));
            foreach (IWebElement link in links)
            {
                var url = link.GetAttribute("href");
                IsLinkWorking(url);
            }


            bool IsLinkWorking(string url)
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

                //You can set some parameters in the "request" object...
                request.AllowAutoRedirect = true;

                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Console.WriteLine(url + "   " + "Response Status Code is OK and StatusDescription is: {0}", response.StatusDescription);
                        // Releases the resources of the response.
                        response.Close();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine(url + "  " + "Response Status Code is Not OK and StatusDescription is: {0}", response.StatusDescription);
                        response.Close();
                        return false;
                    }
                }
                catch (Exception e)
                { //TODO: Check for the right exception here
                    Console.WriteLine(e.Message);
                    return false;
                }

            }
            driver.Quit();
        }
    }
}
  
        
   

