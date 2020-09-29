//-----------------------------------------------------------------------
// <copyright file="BookSwagonTest.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using BookSwagon.Pages;
using NUnit.Framework;

namespace BookSwagon
{
    /// <summary>
    /// create BookSwagonTest class
    /// </summary>
    [Parallelizable]
    class BookSwagonTest : Base
    {
        /// <summary>
        /// create object of Credentials class
        /// </summary>
        Credentials credentails = new Credentials();

        /// <summary>
        /// create Valid Login test
        /// </summary>
        [Test,Order(1)]
        [System.Obsolete]
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

        /// <summary>
        /// create Search Book test
        /// </summary>
        [Test, Order(2)]
        [System.Obsolete]
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

        /// <summary>
        /// create Buy Book Test
        /// </summary>
        [Test, Order(3)]
        [System.Obsolete]
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

        /// <summary>
        /// create Shipping Address Test
        /// </summary>
        [Test, Order(4)]
        [System.Obsolete]
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

        /// <summary>
        /// create Review Order test
        /// </summary>
        [Test, Order(5)]
        [System.Obsolete]
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

        /// <summary>
        /// create Logout test
        /// </summary>
        [Test, Order(6)]
        [System.Obsolete]
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

