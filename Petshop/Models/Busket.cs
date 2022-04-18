using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductShop.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? ByuerId { get; set; }
        public int? Number { get; set; }
        public string ProductName { get; set; }
    }
}
