using Microsoft.EntityFrameworkCore.Internal;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class Provider
    {
        private MainContext db;
        protected Logger log = LogManager.GetCurrentClassLogger();
        public Provider()
        {
            db = new MainContext();
        }

        public Provider(string dbName)
        {
            db = new MainContext(dbName);
        }

        public void StoreOrder(Order order)
        {
            db.Add(order);
            db.SaveChanges();
        }

        public Order fetchOrder(string orderId)
        {
            return db.Orders.Where(o => o.Id == orderId).FirstOr(null);
        }

        public List<Order> fetchOrders()
        {
            return db.Orders.ToList();
        }

        public void StoreOrders(List<Order> orders)
        {
            foreach (Order order in orders)
            {
                db.Add(order);
            }
            int written = db.SaveChanges();
            log.Debug("written " + written + " records to DB");
        }
    }
}
