using System;
using System.Collections.Generic;

#nullable disable

namespace ProductShop.DataBase
{
    public partial class Sale
    {
        public Sale()
        {
            UserSales = new HashSet<UserSale>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Offer { get; set; }
        public decimal? GiveAwayCondition { get; set; }
        public decimal? Condition { get; set; }
        public string Background { get; set; }

        public virtual ICollection<UserSale> UserSales { get; set; }
    }
}
