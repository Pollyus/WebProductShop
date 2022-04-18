using System;
using System.Collections.Generic;

#nullable disable

namespace ProductShop.DataBase
{
    public partial class Buyer
    {
        public Buyer()
        {
            Orders = new HashSet<Order>();
            ShoppingCarts = new HashSet<ShoppingCart>();
            UserSales = new HashSet<UserSale>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Address { get; set; }
        public decimal? Sum { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public virtual ICollection<UserSale> UserSales { get; set; }
    }
}
