using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using PageObjectFactory.PageObject;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObjectFactory
{
    [TestFixture]
    public class TestSite
    {
        [FindsBy(How = How.XPath, Using = "//section[@class='flight-brief-layovers']")]
        private IList<IWebElement> ticketsDirectFlight;
        [FindsBy(How = How.XPath, Using = "//div[@class='bags-info']")]
        private IList<IWebElement> ticketsWithBaggage;
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'ticket-action-airline-container')]")]
        private IList<IWebElement> ticketsAircompanyBelavia;

        [Test]
        public void DirectFlight()
        {
            StartPage startPage = new StartPage();
            startPage.FillInForm("Минск", "Париж");
            FindTicketsPage findTicketsPage = new FindTicketsPage(startPage.getDriver());
            findTicketsPage.FilterFlight();
            SoftAssert ticketsWithDirectFligtAssert = new SoftAssert();
            foreach (IWebElement elem in ticketsDirectFlight)
            {
                ticketsWithDirectFligtAssert.IsTrue(elem.Displayed && !elem.Text.Contains("ПРЯМОЙ ПЕРЕЛЁТ"));
            }
            ticketsWithDirectFligtAssert.VerifyAll();
            Browser.CloseBrowser(findTicketsPage.getDriver());
        }
        
        [Test]
        public void TypeBaggage()
        {
            StartPage startPage = new StartPage();
            startPage.FillInForm("Минск", "Париж");
            FindTicketsPage findTicketsPage = new FindTicketsPage(startPage.getDriver());
            findTicketsPage.FilterBaggage();
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
            Browser.CloseBrowser(findTicketsPage.getDriver());
         }

        [Test]
        public void SelectAircompany()
        {
            StartPage startPage = new StartPage();
            startPage.FillInForm("Минск", "Париж");
            FindTicketsPage findTicketsPage = new FindTicketsPage(startPage.getDriver());
            findTicketsPage.filterAirport();
            SoftAssert ticketsWithLaggageAndBagsAssert = new SoftAssert();
            foreach (IWebElement elem in ticketsAircompanyBelavia)
            {
                if (elem.Displayed)
                {
                    var srcImageAirCompany = elem.FindElement(By.XPath("//img")).GetAttribute("src");
                    ticketsWithLaggageAndBagsAssert.AreEquals(srcImageAirCompany, "/images/airline/120/35/gravity=west/B2@2x.png");
                }
            }
            ticketsWithLaggageAndBagsAssert.VerifyAll();
            Browser.CloseBrowser(findTicketsPage.getDriver());
        }
    }
}
