using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace PageObjectFactory.PageObject
{
    class StartPage
    {
        [FindsBy(How = How.XPath, Using = "//input[@id='origin_name']")]
        IWebElement originName;
        [FindsBy(How = How.XPath, Using = "//input[@id='destination_name']")]
        IWebElement destinationName;
        [FindsBy(How = How.XPath, Using = "//input[@id='depart_date']")]
        IWebElement departDate;
        [FindsBy(How = How.XPath, Using = "//input[@id='return_date']")]
        IWebElement returnDate;
        [FindsBy(How = How.XPath, Using = "//div[@class='ticket-action-airline-container']/a")]
        IWebElement elements;

        private IWebDriver driver;

        public StartPage(/*IWebDriver _driver*/)
        {
            IWebDriver _driver = Browser.OpenBrowser();
            this.driver = _driver;
            PageFactory.InitElements(driver, this);
        }

        public IWebDriver getDriver()
        {
            return driver;
        }

        public void FillInForm(string cityOrigin, string cityDestination)
        {
            originName.SendKeys(cityOrigin);
            originName.Click();
            originName.SendKeys(Keys.Down);
            originName.Click();
            destinationName.SendKeys(cityDestination);
            destinationName.Click();
            destinationName.SendKeys(Keys.Down);
            destinationName.Click();
            DateTime dateCurent = DateTime.Today;
            DateTime dateDepart = dateCurent.AddMonths(1);
            DateTime dateReturn = dateDepart.AddDays(3);
            departDate.Clear();
            departDate.SendKeys(dateDepart.ToString("yyyy-MM-dd"));
            returnDate.Clear();
            returnDate.SendKeys(dateReturn.ToString("yyyy-MM-dd"));
            returnDate.Click();
            driver.FindElement(By.XPath("//div[@class='indexFormBg']")).Click();
            driver.FindElement(By.XPath("//input[@id='submit']")).Click();
        }
    }
}
