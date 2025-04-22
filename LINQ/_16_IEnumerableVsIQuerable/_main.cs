using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._16_IEnumerableVsIQuerable;

public class _Main
{

   public static void Ex01()
   {

      // Setup in-memory database
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;

      using (var context = new AppDbContext(options))
      {
         // Seed data
         context.Products.AddRange(new[]
         {
             new Product { Id = 1, Name = "Laptop", Price = 1000 },
             new Product { Id = 2, Name = "Phone", Price = 800 },
             new Product { Id = 3, Name = "Desk", Price = 200 }
         });
         context.SaveChanges();

         // IEnumerable: In-memory filtering
         IEnumerable<Product> products = context.Products.ToList(); // Loads all data

         var expensiveIEnum = products.Where(p => p.Price > 500)
                                      .Select(p => p.Name);

         Console.WriteLine("IEnumerable (in-memory):");
         Console.WriteLine(string.Join(", ", expensiveIEnum));

         // IQueryable: Database filtering
         IQueryable<Product> query = context.Products;

         var expensiveIQuery = query.Where(p => p.Price > 500)
                                    .Select(p => p.Name);

         var results = expensiveIQuery.ToList(); // Executes SQL

         Console.WriteLine();
         Console.WriteLine("IQueryable (database):");
         Console.WriteLine(string.Join(", ", results));
      }

   }

}

class AppDbContext : DbContext
{
   public DbSet<Product> Products { get; set; }
   public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}

class Product
{
   public int Id { get; set; }
   public string Name { get; set; }
   public decimal Price { get; set; }
}

