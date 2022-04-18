using System;
using System.Collections.Generic;

#nullable disable

namespace ProductShop.DataBase
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int? TypeId { get; set; }

        public virtual CategoryType Type { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
