using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace PageObjectFactory.PageObject
{
    class StartPage
    {
        [FindsBy(How = How.XPath, Using = "//input[@id='origin_name']")]
        private IWebElement originName;
        [FindsBy(How = How.XPath, Using = "//input[@id='destination_name']")]
        private IWebElement destinationName;
        [FindsBy(How = How.XPath, Using = "//input[@id='depart_date']")]
        private IWebElement departDate;
        [FindsBy(How = How.XPath, Using = "//input[@id='return_date']")]
        private IWebElement returnDate;
        [FindsBy(How = How.XPath, Using = "//div[@class='ticket-action-airline-container']/a")]
        private IWebElement elements;
        [FindsBy(How = How.XPath, Using = "//span[@class='avs_ac_iata'][contains(.,'MSQ')]")]
        private IWebElement airportOrigin;
        [FindsBy(How = How.XPath, Using = "//span[@class='avs_ac_iata'][contains(.,'PAR')]")]
        private IWebElement airportDestination;
        [FindsBy(How = How.XPath, Using = "//div[@class='indexFormBg']")]
        private IWebElement form;
        [FindsBy(How = How.XPath, Using = "//input[@id='submit']")]
        private IWebElement buttonSearch;

        private IWebDriver driver;

        public StartPage()
        {
            IWebDriver _driver = Browser.OpenBrowser();
            this.driver = _driver;
            PageFactory.InitElements(driver, this);
        }

        public IWebDriver getDriver()
        {
            return driver;
        }

        public void setCitiesOriginAndDestination(string cityOrigin, string cityDestination)
        {
            originName.SendKeys(cityOrigin);
            originName.Click();
            airportOrigin.Click();
            destinationName.SendKeys(cityDestination);
            destinationName.Click();
            airportDestination.Click();
        }

        public void setDate(IWebElement fieldDate, DateTime valueDate)
        {
            fieldDate.Clear();
            fieldDate.SendKeys(valueDate.ToString("yyyy-MM-dd"));            
        }

        public void clickButtonSearch()
        {
            form.Click();
            buttonSearch.Click();
        }

        public void FillInForm(string cityOrigin, string cityDestination)
        {
            this.setCitiesOriginAndDestination(cityOrigin, cityDestination);
            DateTime dateCurent = DateTime.Today;
            this.setDate(departDate, dateCurent.AddMonths(1));
            this.setDate(returnDate, dateCurent.AddMonths(1).AddDays(3));
            this.clickButtonSearch();
        }
    }
}
