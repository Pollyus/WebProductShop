using System;
using System.Collections.Generic;

#nullable disable

namespace ProductShop.DataBase
{
    public partial class CategoryType
    {
        public CategoryType()
        {
            Categories = new HashSet<Category>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
