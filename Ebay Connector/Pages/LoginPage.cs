using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebay_Connector.Pages
{
    public class LoginPage : AbstractPage
    {
        private const string URL = "https://signin.ebay.com/ws/eBayISAPI.dll?SignIn&ru=https%3A%2F%2Fwww.ebay.com%2F";

        private const string ELEMENT_USERNAME = "userId";

        private const string ELEMENT_PASSWORD = "pass";

        public LoginPage(AbstractConnector connector) : base(connector)
        {
        }

        public override string GetUrl()
        {
            return URL;
        }

        public override bool IsValid()
        {
            return FindById(ELEMENT_USERNAME) != null || FindById(ELEMENT_PASSWORD) != null;
        }

        public override void WaitForIt()
        {
            
        }
    }
}
