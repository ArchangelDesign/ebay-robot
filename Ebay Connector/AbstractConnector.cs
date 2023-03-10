using Ebay_Connector.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using NLog;

namespace Ebay_Connector
{
    public abstract class AbstractConnector
    {
        public IWebDriver driver;

        protected Logger log = LogManager.GetCurrentClassLogger();

        public AbstractConnector()
        {
            string path = new DriverManager().SetUpDriver(new ChromeConfig());
            try
            {
                driver = new ChromeDriver(path);
            } catch (Exception ex)
            {
                log.Error(ex.Message);
                throw ex;
            }
        }

        public bool GoToPage(Page page)
        {
            log.Debug("navigating to " + page.GetUrl());
            driver.Navigate().GoToUrl(page.GetUrl());
            page.WaitForIt();
            return page.IsValid();
        }

        ~AbstractConnector()
        {
            driver.Quit();
        }
    }
}
