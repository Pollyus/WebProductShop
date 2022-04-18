using System;
using System.Collections.Generic;

#nullable disable

namespace ProductShop.DataBase
{
    public partial class Product
    {
        public Product()
        {
            OrderLines = new HashSet<OrderLine>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Cost { get; set; }
        public int? CategoryId { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public bool? Avalibility { get; set; }
        public int? BrandId { get; set; }
        public DateTime? DateProduction { get; set; }
        public DateTime? DateExpiration { get; set; }
        public int? Amount { get; set; }
        public decimal? Sale { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
