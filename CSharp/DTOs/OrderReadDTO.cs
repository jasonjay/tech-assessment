using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.DTOs
{
    public class OrderReadDTO
    {
        public int Id { get; set; }
        public int customer_id { get; set; }

        public string item { get; set; }

        public int quantity { get; set; }
    }
}
