using Microsoft.VisualStudio.TestTools.UnitTesting;
using Storage;
using System;

namespace StorageTest
{
    [TestClass]
    public class StorageTest
    {
        [TestMethod]
        public void TestOrderIsStoredAndFetched()
        {
            Provider storage = new Provider("unit-tests.sqlite");
            Order testOrder = new Order
            {
                Id = "1",
                Username = "Test",
            };
            storage.StoreOrder(testOrder);
            Order fetchedOrder = storage.fetchOrder("1");
            Assert.AreEqual(testOrder.Id, fetchedOrder.Id);
        }
    }
}
