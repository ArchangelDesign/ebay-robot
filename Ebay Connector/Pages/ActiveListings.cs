using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebay_Connector.Pages
{
    public class ActiveListings : AbstractPage
    {
        private const string URL = "https://www.ebay.com/sh/lst/active";

        private const string TITLE = "#listings-content-target > div.title-bar.clearfix > h1";
        public ActiveListings(AbstractConnector connector) : base(connector)
        {
        }

        public override string GetUrl()
        {
            return URL;
        }

        public override bool IsValid()
        {
            return FindBySelector(TITLE) != null;
        }

        public override void WaitForIt()
        {
            WaitForSelector(TITLE);
        }
    }
}
