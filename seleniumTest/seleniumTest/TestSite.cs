using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seleniumTest {
    [TestFixture]
    class TestSite {
        [Test]
        public void DirectFlight( ) {
            IWebDriver driver = new FirefoxDriver( );

            driver.Navigate( ).GoToUrl("http://avia-booking.com/");
            var originName = driver.FindElement(By.XPath("//input[@id='origin_name']"));
            originName.SendKeys("Минск");
            originName.Click( );
            originName.SendKeys(Keys.Down);
            originName.Click( );
            var destinationName = driver.FindElement(By.XPath("//input[@id='destination_name']"));
            destinationName.SendKeys("Париж");
            destinationName.Click( );
            destinationName.SendKeys(Keys.Down);
            destinationName.Click( );
            DateTime dateCurent = DateTime.Today;
            DateTime dateDepart = dateCurent.AddMonths(1);
            DateTime dateReturn = dateDepart.AddDays(3);
            var departDate = driver.FindElement(By.XPath("//input[@id='depart_date']"));
            departDate.Clear( );
            departDate.SendKeys(dateDepart.ToString("yyyy-MM-dd"));
            var returnDate = driver.FindElement(By.XPath("//input[@id='return_date']"));
            returnDate.Clear( );
            returnDate.SendKeys(dateReturn.ToString("yyyy-MM-dd"));
            driver.FindElement(By.XPath("//div[@class='indexFormBg']")).Click( );
            driver.FindElement(By.XPath("//input[@id='submit']")).Click( );

            driver.FindElement(By.XPath("//label[@for='stops_count_filter']")).Click( );
            driver.FindElement(By.XPath("//label[@for='stops_count_filter_0']")).Click( );

            bool isNotDirectFlight = false;
            var elements = driver.FindElements(By.XPath("//section[@class='flight-brief-layovers']"));
            foreach (IWebElement elem in elements) {
                if (elem.Displayed && !elem.Text.Contains("ПРЯМОЙ ПЕРЕЛЁТ")) {
                    isNotDirectFlight = true;
                    break;
                }
            }
            driver.Close( );
            Assert.AreEqual(isNotDirectFlight, false);
        }

    }
}
