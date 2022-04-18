using System;
using System.Collections.Generic;
using System.Linq;
using ProductShop.DataBase;
using ProductShop.Models;

namespace ProductShop.Data
{
    public class DbInitializer
    {
        public static void Initialize(ProductShopContext context)
        {
            context.Database.EnsureCreated();
            if (context.Categories.Any())
            {
                return;
            }
        //    var CategoryTypes = new Category[]
        //    {
        //        new Category {
        //           Name = "Бакалея"
        //        },
        //        new Category {
        //           Name = "Сладкое"
        //        },
        //    };
        //    foreach (Category c in CategoryTypes)
        //    {
        //        context.Category.Add(c);
        //    }
        //    context.SaveChanges();
        //    var goods = new Product[]
        //    {
        //        new Product {
        //            Name = "Рожки",
        //            CategoryId = 1,
        //            Price = 100,
        //            Amount = 50,
                 

        //},
        //        new Product {
        //           Name = "Конфеты",
        //           CategoryId = 2,
        //           Price = 270,
        //           Amount = 30, 
                  

        //        }
        //    };
        //    foreach (Product p in goods)
        //    {
        //        context.Products.Add(p);
        //    }
        //    context.SaveChanges();
        }
    }
}
