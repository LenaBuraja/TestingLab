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
        [FindsBy(How = How.XPath, Using = "//section[@class='flight-brief-layovers']")]
        IList<IWebElement> ticketDirectFlight;
        [FindsBy(How = How.XPath, Using = "//div[@class='bags-info']")]
        IList<IWebElement> ticketWithBaggage;

        private IWebDriver driver;

        public FindTicketsPage(IWebDriver _driver)
        {
            //IWebDriver driver = Browser.OpenBrowser();
            this.driver = _driver;
            PageFactory.InitElements(driver, this);
        }

        public void FilterBaggage()
        {
            driver.FindElement(By.XPath("//label[@for='baggage_filter']")).Click();
            driver.FindElement(By.XPath("//label[@for='baggage_filter_1']")).Click();
        }

        public void FilterFlight()
        {
            driver.FindElement(By.XPath("//label[@for='stops_count_filter']")).Click();
            driver.FindElement(By.XPath("//label[@for='stops_count_filter_0']")).Click();
        }


        public bool isNotDirectFlight()
        {
            foreach (IWebElement elem in ticketDirectFlight)
            {
                if (elem.Displayed && !elem.Text.Contains("ПРЯМОЙ ПЕРЕЛЁТ"))
                {
                    return true;
                }
            }
            return false;
        }

        public bool isWithBaggage()
        {
            foreach (IWebElement elem in ticketWithBaggage)
            {
                var baggage = elem.FindElement(By.XPath("./div[@class='bags-info__icons bags-info__icons--baggage']/i")).GetAttribute("class");
                var handbags = elem.FindElement(By.XPath("./div[@class='bags-info__icons bags-info__icons--handbags']/i")).GetAttribute("class");
                if (baggage.Contains("without-baggage") && handbags.Contains("unknown-handbags"))
                {
                    //Console.WriteLine(handbags + " **** " + baggage);
                    return false;
                }
            }
            return true;
        }

        public IWebDriver getDriver()
        {
            return driver;
        }


    }
}
