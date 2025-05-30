using Microsoft.EntityFrameworkCore;
using Migration_Task.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTask.Data.Seeds
{
    public static class SeedData
    {
        public static void CategoriesSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
          new Category
          {
              CategoryId = 1,
              CategoryName = "Electronics",
              Description = "Devices and gadgets"

          },
           new Category
           {
               CategoryId = 2,
               CategoryName = "Devices",
               Description = "Devices and gadgets"

           },
           new Category
           {
               CategoryId = 3,
               CategoryName = "clothes",
               Description = "clothes for men and women"

           });
        }

        public static void ProductsSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
          new Product
          {
              ProductId = 1,
              ProductName = "Electronics",
              ProductDescription = "Devices and gadgets",
              CategoryId = 1,
              Status = true,
              Price = 1000.00M,
              StockQuantity = 50,

          },
              new Product
              {
                  ProductId = 2,
                  ProductName = "Devices Devices ",
                  ProductDescription = "Devices and Devices",
                  CategoryId = 2,
                  Status = true,
                  Price = 1000.00M,
                  StockQuantity = 50,

              },
                  new Product
                  {
                      ProductId = 3,
                      ProductName = "Electronics Electronics ",
                      ProductDescription = "Electronics",
                      CategoryId = 1,
                      Status = false,
                      Price = 1000.00M,
                      StockQuantity = 50,

                  },
                     new Product
                     {
                         ProductId =4,
                         ProductName = "Electronics Electronics ",
                         ProductDescription = "Electronics",
                         CategoryId = 1,
                         Status = false,
                         Price = 1000.00M,
                         StockQuantity = 50,

                     },
                        new Product
                        {
                            ProductId =5,
                            ProductName = "Electronics Electronics ",
                            ProductDescription = "Electronics",
                            CategoryId = 1,
                            Status = false,
                            Price = 1000.00M,
                            StockQuantity = 50,

                        }
         );
        }
    }
}
