using System;
using System.Collections.Generic;

#nullable disable

namespace ProductShop.DataBase
{
    public partial class ShoppingCart
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? BuyerId { get; set; }
        public int? Amount { get; set; }

        public virtual Buyer Buyer { get; set; }
        public virtual Product Product { get; set; }
    }
}
