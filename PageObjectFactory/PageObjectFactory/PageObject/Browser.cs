using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace PageObjectFactory.PageObject
{
    public class Browser
    {
        public static IWebDriver OpenBrowser()
        {
            IWebDriver Driver = new FirefoxDriver();
            Driver.Navigate().GoToUrl("http://avia-booking.com/");
            return Driver;
        }

        public static void CloseBrowser(IWebDriver Driver)
        {
            Driver.Close();
        }
    }
}
