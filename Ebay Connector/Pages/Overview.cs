using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebay_Connector.Pages
{
    internal class Overview : AbstractPage
    {
        private const string URL = "https://www.ebay.com/sh/ovw";

        public Overview(AbstractConnector connector) : base(connector)
        {
        }

        public override string GetUrl()
        {
            return URL;
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }

        public override void WaitForIt()
        {
            throw new NotImplementedException();
        }
    }
}
