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
        [Test]
        public void DirectFlight()
        {
            StartPage startPage = new StartPage();
            startPage.FillInForm("Минск", "Париж");
            FindTicketsPage findTicketsPage = new FindTicketsPage(startPage.getDriver());
            findTicketsPage.FilterFlight();
            Assert.IsTrue(!findTicketsPage.isNotDirectFlight());
            Browser.CloseBrowser(findTicketsPage.getDriver());
        }
        
        [Test]
        public void TypeBaggage()
        {
            StartPage startPage = new StartPage();
            startPage.FillInForm("Минск", "Париж");
            FindTicketsPage findTicketsPage = new FindTicketsPage(startPage.getDriver());
            findTicketsPage.FilterBaggage();
            Assert.IsTrue(findTicketsPage.isWithBaggage());
            Browser.CloseBrowser(findTicketsPage.getDriver());
         }

        [Test]
        public void SelectAircompany()
        {
            StartPage startPage = new StartPage();
            startPage.FillInForm("Минск", "Париж");
            FindTicketsPage findTicketsPage = new FindTicketsPage(startPage.getDriver());
            findTicketsPage.filterAirport();
            Assert.IsTrue(findTicketsPage.isRightAircompany());
            Browser.CloseBrowser(findTicketsPage.getDriver());
        }
    }
}
