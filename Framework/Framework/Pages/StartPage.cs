using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Framework.Pages
{
    class StartPage
    {
        private const string BASE_URL = "http://avia-booking.com/";

        [FindsBy(How = How.XPath, Using = "//input[@id='origin_name']")]
        private IWebElement originName;
        [FindsBy(How = How.XPath, Using = "//input[@id='destination_name']")]
        private IWebElement destinationName;
        [FindsBy(How = How.XPath, Using = "//span[@class='avs_ac_iata'][contains(.,'MSQ')]")]
        private IWebElement airportOrigin;
        [FindsBy(How = How.XPath, Using = "//span[@class='avs_ac_iata'][contains(.,'PAR')]")]
        private IWebElement airportDestination;
        [FindsBy(How = How.XPath, Using = "//div[@class='indexFormBg']")]
        private IWebElement form;
        [FindsBy(How = How.XPath, Using = "//input[@id='submit']")]
        private IWebElement buttonSearch;

        private IWebDriver driver;

        public StartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
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

        public void SetDate(IWebElement fieldDate, DateTime valueDate)
        {
            fieldDate.Clear();
            fieldDate.SendKeys(valueDate.ToString("yyyy-MM-dd"));
        }

        public void ClickButtonSearch()
        {
            form.Click();
            buttonSearch.Click();
        }
    }
}
