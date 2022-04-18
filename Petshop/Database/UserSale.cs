using System;
using System.Collections.Generic;

#nullable disable

namespace ProductShop.DataBase
{
    public partial class UserSale
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? SaleId { get; set; }
        public int? OrderId { get; set; }
        public bool? Used { get; set; }

        public virtual Order Order { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual Buyer User { get; set; }
    }
}
