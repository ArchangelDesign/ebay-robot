using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebay_Connector.Pages
{
    public interface Page
    {
        string GetUrl();

        bool IsValid();

        void WaitForIt();
    }
}
