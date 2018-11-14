using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectFactory.PageObject
{
    class FindTicketsPage
    {
        [FindsBy(How = How.XPath, Using = "//section[@class='flight-brief-layovers'][contains(.,'ПРЯМОЙ ПЕРЕЛЁТ')]")]
        private IList<IWebElement> ticketDirectFlight;
        [FindsBy(How = How.XPath, Using = "//div[@class='bags-info']")]
        private IList<IWebElement> ticketWithBaggage;
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
        [FindsBy(How = How.XPath, Using = "//img[@src='/images/airline/120/35/gravity=west/B2@2x.png']")]
        private IList<IWebElement> listTicketFilterByAircompany;
        [FindsBy(How = How.XPath, Using = "//div[@class='ticket-scroll-container']")]
        private IList<IWebElement> listTicketAll;

        private IWebDriver driver;

        public FindTicketsPage(IWebDriver _driver)
        {
            this.driver = _driver;
            PageFactory.InitElements(driver, this);
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


        public bool isNotDirectFlight()
        {
            return ticketDirectFlight.Count == listTicketAll.Count;
        }

        public bool isWithBaggage()
        {
            foreach (IWebElement elem in ticketWithBaggage)
            {
                var baggage = elem.FindElement(By.XPath("./div[@class='bags-info__icons bags-info__icons--baggage']/i")).GetAttribute("class");
                var handbags = elem.FindElement(By.XPath("./div[@class='bags-info__icons bags-info__icons--handbags']/i")).GetAttribute("class");
                if (baggage.Contains("without-baggage") && handbags.Contains("unknown-handbags"))
                {
                    return false;
                }
            }

            return true;
        }

        public void filterAirport()
        {
            listAircompany.Click();
            filterAircompany.Click();
            filterAircompanyBelavia.Click();
        }

        public bool isRightAircompany()
        {
            return listTicketFilterByAircompany.Count == listTicketAll.Count;
        }

        public IWebDriver getDriver()
        {
            return driver;
        }


    }
}
