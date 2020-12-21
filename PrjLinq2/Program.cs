using System;
using System.Collections.Generic;
using System.Linq;
using PrjLinq2.Entities;

namespace PrjLinq2
{
    class Program
    {

        static void Print<T>(string message, IEnumerable<T> colletion)
        {
            Console.WriteLine(message);
            foreach (T obj in colletion)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2};
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Eletronics", Tier = 1 };
            Category c4 = new Category() { Id = 4, Name = "Utilities", Tier = 2 };

            List<Product> list = new List<Product>()
            {
                new Product() { Id = 1, Name = "Computer", Price = 2000.00, Category = c2 },
                new Product() { Id = 2, Name = "Laptop", Price = 3000.00, Category = c2 },
                new Product() { Id = 3, Name = "Video Game", Price = 1500.00, Category = c3 },
                new Product() { Id = 4, Name = "Hammer", Price = 35.00, Category = c1 },
                new Product() { Id = 5, Name = "Key", Price = 25.00, Category = c4 },
                new Product() { Id = 6, Name = "wire", Price = 40.00, Category = c3 },
                new Product() { Id = 7, Name = "Banch", Price = 150.00, Category = c4 },
                new Product() { Id = 8, Name = "Frame", Price = 50.00, Category = c4 },
                new Product() { Id = 9, Name = "Table", Price = 1000.00, Category = c4 },
                new Product() { Id = 10, Name = "Mouse", Price = 100.00, Category = c3 }

            };


            Console.WriteLine("Tier equal as 1 and Prices equal ");

            var result = list.Where(p => p.Price <= 900.00 && p.Category.Tier == 1);
            Print("Price less than 900.00 and Tier equal 1", result);

            Console.WriteLine("All products of category utilities ");
            var result1 = list.Where(p => p.Category.Name == "Utilities").Select(p => p.Name);
            Print("All products : ", result1);

            Console.WriteLine("Just Name, price, and Category name of products that begging with C ");
            var result2 = list.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            Print("all products Begging with C : ", result2);

            Console.WriteLine("All product tier of c4 and ordered by price");
            var result3 = list.Where(p => p.Category.Tier == 2).OrderBy(p => p.Price).ThenBy(p => p.Name); //primeiro ordena por Prince e depois por Name
            Print("result3 : ", result3);

            
            var result4 = result3.Skip(2).Take(4);
            Print("result4 : ", result4);

        }
    }
}
