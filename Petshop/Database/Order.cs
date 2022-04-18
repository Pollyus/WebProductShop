using System;
using System.Collections.Generic;

#nullable disable

namespace ProductShop.DataBase
{
    public partial class Order
    {
        public Order()
        {
            OrderLines = new HashSet<OrderLine>();
            UserSales = new HashSet<UserSale>();
        }

        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public decimal? Sum { get; set; }
        public DateTime? Date { get; set; }
        public int? UserId { get; set; }
        public int? TypeId { get; set; }
        public int? StatusId { get; set; }
        public decimal? Sale { get; set; }

        public virtual OrderStatus Status { get; set; }
        public virtual TypeOfPayment Type { get; set; }
        public virtual Buyer User { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual ICollection<UserSale> UserSales { get; set; }
    }
}
