using Framework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Framework.Steps
{
    class Steps
    {
        [FindsBy(How = How.XPath, Using = "//input[@id='depart_date']")]
        private IWebElement departDate;
        [FindsBy(How = How.XPath, Using = "//input[@id='return_date']")]
        private IWebElement returnDate;

        IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.Driver.GetDriver();
        }

        public void CloseBrowser()
        {
            Driver.Driver.CloseBrowser();
        }

        public void FillInForm(string cityOrigin, string cityDestination)
        {
            StartPage startPage = new StartPage(driver);
            startPage.setCitiesOriginAndDestination(cityOrigin, cityDestination);
            DateTime dateCurent = DateTime.Today;
            startPage.SetDate(departDate, dateCurent.AddMonths(1));
            startPage.SetDate(returnDate, dateCurent.AddMonths(1).AddDays(3));
            startPage.ClickButtonSearch();
        }

        public void FilterBaggageInFindTicketsPage()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            findTicketsPage.FilterBaggage();
        }

        public void FilterFlightInFindTicketsPage()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            findTicketsPage.FilterFlight();
        }

        public void FilterAirportInFindTicketsPage()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            findTicketsPage.FilterAirport();
        }
    }
}
