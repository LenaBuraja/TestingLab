using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace Framework.Driver
{
    class Driver
    {
        private static IWebDriver driver;

        private Driver() { }

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = new FirefoxDriver();
            }
            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
    }
}
