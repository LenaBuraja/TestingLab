using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace Framework.Tests
{
    class Tests
    {
        private Steps.Steps steps = new Steps.Steps();
        private const string CITY_ORIGIN = "Минск";
        private const string CITY_DISTINATION = "Париж";


        [FindsBy(How = How.XPath, Using = "//section[@class='flight-brief-layovers']")]
        private IList<IWebElement> ticketsDirectFlight;
        [FindsBy(How = How.XPath, Using = "//div[@class='bags-info']")]
        private IList<IWebElement> ticketsWithBaggage;
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'ticket-action-airline-container')]")]
        private IList<IWebElement> ticketsAircompanyBelavia;

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void DisplayFoundFlightsDirectFlight()
        {
            steps.FillInForm(CITY_ORIGIN, CITY_DISTINATION);
            steps.FilterFlightInFindTicketsPage();
            SoftAssert ticketsWithDirectFligtAssert = new SoftAssert();
            foreach (IWebElement elem in ticketsDirectFlight)
            {
                ticketsWithDirectFligtAssert.IsTrue(elem.Displayed && !elem.Text.Contains("ПРЯМОЙ ПЕРЕЛЁТ"));
            }
            ticketsWithDirectFligtAssert.VerifyAll();
        }

        [Test]
        public void SearchForAirticketsWithLuggage()
        {
            steps.FillInForm(CITY_ORIGIN, CITY_DISTINATION);
            steps.FilterBaggageInFindTicketsPage();
            SoftAssert ticketsWithLaggageAndBagsAssert = new SoftAssert();
            foreach (IWebElement elem in ticketsWithBaggage)
            {
                if (elem.Displayed)
                {
                    var luggage = elem.FindElement(By.XPath("./div[@class='bags-info__icons--baggage']/i")).GetAttribute("class");
                    var handbags = elem.FindElement(By.XPath("./div[@class='bags-info__icons--handbags']/i")).GetAttribute("class");
                    ticketsWithLaggageAndBagsAssert.isTrue(luggage.Contains("without-baggage") && handbags.Contains("unknown-handbags"));
                }
            }
            ticketsWithLaggageAndBagsAssert.VerifyAll();
        }

        [Test]
        public void DisplayFoundAirticketsAirlineBelavia()
        {
            steps.FillInForm(CITY_ORIGIN, CITY_DISTINATION);
            steps.FilterAirportInFindTicketsPage();
            SoftAssert ticketsWithLaggageAndBagsAssert = new SoftAssert();
            foreach (IWebElement elem in ticketsAircompanyBelavia)
            {
                if(elem.Displayed)
                {
                    var srcImageAirCompany = elem.FindElement(By.XPath("//img")).GetAttribute("src");
                    ticketsWithLaggageAndBagsAssert.AreEquals(srcImageAirCompany, "/images/airline/120/35/gravity=west/B2@2x.png");
                }
            }
            ticketsWithLaggageAndBagsAssert.VerifyAll();
        }

    }
}
