using OpenQA.Selenium;
using Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebay_Connector.Pages
{
    public class AllOrders : AbstractPage
    {
        private const string URL = "https://www.ebay.com/sh/ord?filter=status%3AALL_ORDERS";

        private const string ORDER_LIST_WRAPPER = "app-mod-orders-wrapper";

        public AllOrders(AbstractConnector connector) : base(connector)
        {
        }

        public override string GetUrl()
        {
            return URL;
        }

        public override bool IsValid()
        {
            return true;
        }

        public override void WaitForIt()
        {
            
        }

        public List<Order> GetOrders()
        {
            log.Debug("fetching orders...");
            List<Order> orders = new List<Order>();
            IWebElement orderTableWrapper = FindById(ORDER_LIST_WRAPPER);
            if (orderTableWrapper == null)
            {
                return null;
            }

            ReadOnlyCollection<IWebElement> rows = orderTableWrapper.FindElements(By.TagName("tr"));

            if (rows.Count == 0)
            {
                return orders;
            }

            foreach (IWebElement row in rows)
            {
                try
                {
                    IWebElement orderDetails = row.FindElement(By.CssSelector("div.order-details"));
                    IWebElement orderNumberLink = orderDetails.FindElement(By.TagName("a"));
                    string orderNumber = orderNumberLink.Text;
                    string userName = row.FindElement(By.ClassName("user-name")).Text;
                    string userId = row.FindElement(By.CssSelector("span.user-id > a")).Text;
                    string quantity = row.FindElement(By.CssSelector("div.quantity > span > strong")).Text;
                    string listingId = "";
                    try
                    {
                        listingId = row.FindElement(By.ClassName("item-itemID")).Text;
                    } catch (NoSuchElementException)
                    {
                        log.Error("Cannot load listing ID for orde " + orderNumber);
                    }
                    string total = row.FindElement(By.CssSelector("span.price-value > a")).Text;
                    orders.Add(new Order
                    {
                        Id = orderNumber,
                        Username = userName,
                        UserId = userId,
                        Quantity = quantity,
                        ListingId = listingId,
                        Total = total,
                    });
                } catch (NoSuchElementException) {
                    
                }
            }

            return orders;
        }
    }
}
