using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebay_Connector.Pages
{
    public abstract class AbstractPage : Page
    {
        protected Logger log = LogManager.GetCurrentClassLogger();

        private IWebDriver driver;

        public AbstractPage(AbstractConnector connector)
        {
            this.driver = connector.driver;
        }
        public abstract string GetUrl();
        public abstract bool IsValid();
        public abstract void WaitForIt();
        
        protected IWebElement FindById(string id)
        {
            try
            {
                return driver.FindElement(By.Id(id));
            } catch (NoSuchElementException e)
            {
                log.Debug("element not found: " + e.Message);
                return null;
            }
        }

        protected IWebElement FindBySelector(string selector)
        {
            try {
                return driver.FindElement(By.CssSelector(selector));
            }
            catch (NoSuchElementException e)
            {
                log.Debug("element not found: " + e.Message);
                return null;
            }
        }

        protected void WaitFor(By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(drv => drv.FindElement(by));
        }

        protected void WaitForId(string id)
        {
            WaitFor(By.Id(id));
        }

        protected void WaitForSelector(string selector)
        {
            WaitFor(By.CssSelector(selector));
        }
    }
}
