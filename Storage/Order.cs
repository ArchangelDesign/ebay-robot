using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class Order
    {
        public string Id { get; set; }
        public string Subtotal { get; set; }

        public string Total { get; set; }

        public string DateSold { get; set; }

        public string Username { get; set; }

        public string UserId { get; set; }

        public string ListingId { get; set; }

        public string Quantity { get; set;}
    }
}
