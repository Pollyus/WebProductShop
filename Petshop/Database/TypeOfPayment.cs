﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ProductShop.DataBase
{
    public partial class TypeOfPayment
    {
        public TypeOfPayment()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
