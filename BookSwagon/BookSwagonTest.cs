using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BookSwagon.Email;
using BookSwagon.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookSwagon
{
    [Parallelizable]
    class BookSwagonTest : Base
    {
        Credentials credentails = new Credentials();

        [Test,Order(1)]
        public void ValidLogin()
        {
            log.Info("valid Login Test Started");
            Login login = new Login(driver);
            login.LoginToBookSwagaon(credentails.email, credentails.password);
            string actualResult = driver.Url;
            string expectedResult = "https://www.bookswagon.com/myaccount.aspx";
            Assert.AreEqual(expectedResult, actualResult);
            log.Info("Test Pass");
        }
        [Test, Order(2)]
        public void SearchBookTest()
        {
            log.Info("search book Test Started");
            Search search = new Search(driver);
            search.SearchBook();
            string url = "https://www.bookswagon.com/search-books/mahabharata";
            string actual = driver.Url;
            Assert.AreEqual(url, actual);
            log.Info("Test Pass");
        }
        [Test, Order(3)]
        public void BuyBookTest()
        {
            log.Info("Buy Book Test Started");
            SearchHomePage search = new SearchHomePage(driver);
            search.PlaceOrderBook();
            string url = "https://www.bookswagon.com/checkout-login";
            string actual = driver.Url;
            Assert.AreEqual(url, actual);
            log.Info("Test Pass");
        }
        [Test, Order(4)]
        public void ShippingAddressTest()
        {
            log.Info("Shipping Address Test Started");
            ShippingAddess address = new ShippingAddess(driver);
            address.ShippingAddessData();
            string url = "https://www.bookswagon.com/viewshoppingcart.aspx";
            string actual = driver.Url;
            Assert.AreEqual(url, actual);
            log.Info("Test Pass");
        }
        [Test, Order(5)]
        public void ReviewOderTest()
        {
            log.Info("Review Order Test Started");
            ReviewOrder review = new ReviewOrder(driver);
            review.ReviewOrderCheck();
            string url = "https://www.bookswagon.com/checkout.aspx";
            string actual = driver.Url;
            Assert.AreEqual(url, actual);
            log.Info("Test Pass");
        }

        [Test, Order(6)]
        public void LogoutTest()
        {
            log.Info("Logout Test Started");
            Logout logout = new Logout(driver);
            logout.LogoutToBookSwagaon();
            string url = "https://www.bookswagon.com/login";
            string actual = driver.Url;
            Assert.AreEqual(url, actual);
            log.Info("Test Pass");
        }
    }
}

