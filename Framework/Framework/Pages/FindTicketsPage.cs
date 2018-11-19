using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework.Pages
{
    class FindTicketsPage
    {
        [FindsBy(How = How.XPath, Using = "//label[@for='baggage_filter']")]
        private IWebElement labelBaggageFilter;
        [FindsBy(How = How.XPath, Using = "//label[@for='baggage_filter_1']")]
        private IWebElement filterBaggageAndBags;
        [FindsBy(How = How.XPath, Using = "//label[@for='stops_count_filter']")]
        private IWebElement filterStopsCount;
        [FindsBy(How = How.XPath, Using = "//label[@for='stops_count_filter_0']")]
        private IWebElement filterDirectFlight;
        [FindsBy(How = How.XPath, Using = "//div[@class='title title-dropdown semibold closed'][contains(.,'Авиакомпании')]")]
        private IWebElement listAircompany;
        [FindsBy(How = How.XPath, Using = "//label[@for='airlines_filter']")]
        private IWebElement filterAircompany;
        [FindsBy(How = How.XPath, Using = "//label[@class='label-block name airlines-label g-text-overflow'][contains(.,'БелавиаТолько')]")]
        private IWebElement filterAircompanyBelavia;

        private IWebDriver driver;

        public FindTicketsPage(IWebDriver _driver)
        {
            this.driver = _driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void FilterBaggage()
        {
            labelBaggageFilter.Click();
            filterBaggageAndBags.Click();
        }

        public void FilterFlight()
        {
            filterStopsCount.Click();
            filterDirectFlight.Click();
        }

        public void FilterAirport()
        {
            listAircompany.Click();
            filterAircompany.Click();
            filterAircompanyBelavia.Click();
        }
    }
}
