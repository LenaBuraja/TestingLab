using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using PageObjectFactory.PageObject;

namespace PageObjectFactory
{
    [TestFixture]
    public class TestSite
    {
        /*[Test]
        public void DirectFlight()
        {
            StartPage page = new StartPage();
            page.FillInForm("Минск", "Париж");
            FindTicketsPage result = new FindTicketsPage(page.getDriver());
            result.FilterFlight();
            Assert.AreEqual(result.isNotDirectFlight(), false);
            Browser.CloseBrowser(result.getDriver());
        }
        
        [Test]
        public void TypeBaggage()
        {
            StartPage page = new StartPage();
            page.FillInForm("Минск", "Париж");
            FindTicketsPage result = new FindTicketsPage(page.getDriver());
            result.FilterBaggage();
            Assert.AreEqual(result.isWithBaggage(), true);
            Browser.CloseBrowser(result.getDriver());
         }*/

        [Test]
        public void SelectAircompany()
        {
            StartPage page = new StartPage();
            page.FillInForm("Минск", "Париж");
            FindTicketsPage result = new FindTicketsPage(page.getDriver());
            result.filterAirport();
            Assert.AreEqual(result.isRightAircompany(), true);
            Browser.CloseBrowser(result.getDriver());
        }
    }
}
