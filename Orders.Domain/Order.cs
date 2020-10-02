using System;

namespace Orders.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int customer_id { get; set; }

        public string item { get; set; }

        public int quantity { get; set; }

    }
}
