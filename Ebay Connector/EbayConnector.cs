using Ebay_Connector.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Ebay_Connector
{
    public class EbayConnector: AbstractConnector
    {
        private Provider provider;

        public int UpdateOrders()
        {
            AllOrders allOrdersPage = new AllOrders(this);
            this.GoToPage(allOrdersPage);
            var allOrders = allOrdersPage.GetOrders();
            var ordersToUpdate = new List<Order>();
            foreach (var order in allOrders) {
                if (provider.fetchOrder(order.Id) == null)
                {
                    ordersToUpdate.Add(order);
                }
            }
            provider.StoreOrders(ordersToUpdate);

            return ordersToUpdate.Count;
        }
        
    }
}
