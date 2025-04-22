using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._9_JoinOperations;

public class _Main
{

   public static void Ex01()
   {
      var employees = Repository.LoadEmployees();
      var departments = Repository.LoadDepartments();

      var result = employees.Join(departments,
                                  e => e.DepartmentId,
                                  d => d.Id,
                                  (e,d) => new
                                  {
                                     e.FullName,
                                     d.Name
                                  });


      foreach (var r in result)
      {
         Console.WriteLine($"Employee NAme: {r.FullName} - Department: {r.Name}");
      }

   }

   public static void Ex02()
   {
      var employees = Repository.LoadEmployees();
      var departments = Repository.LoadDepartments();

      var result = from e in employees
                   join d in departments
                   on e.DepartmentId equals d.Id
                   select new
                   {
                      e.FullName,
                      d.Name
                   };


      foreach (var r in result)
      {
         Console.WriteLine($"Employee NAme: {r.FullName} - Department: {r.Name}");
      }

   }

   public static void Ex03()
   {
      var employees = Repository.LoadEmployees();
      var departments = Repository.LoadDepartments();

      var result = departments.GroupJoin(employees,
                                         d => d.Id,
                                         e => e.DepartmentId,
                                         (d, e) => new
                                         {
                                            d.Name,
                                            List = e.Select(e => e.FullName).ToList()
                                         });


      foreach (var r in result)
      {
         Console.WriteLine($"[[[ Department: {r.Name} ]]]");
         Console.WriteLine("--------------------------");

         foreach (var s in r.List)
         {
            Console.WriteLine(s);
         }
         Console.WriteLine();
      }

   }

   public static void Ex04()
   {
      var employees = Repository.LoadEmployees();
      var departments = Repository.LoadDepartments();

      var result = from d in departments
                   join e in employees
                   on d.Id equals e.DepartmentId
                   into eGroup
                   select eGroup;


      foreach (var r in result)
      {
         Console.WriteLine("--------------------------");

         foreach (var s in r)
         {
            Console.WriteLine(s.FullName);
         }
         Console.WriteLine();
      }

   }

   public static void Ex05()
   {

      var customers = new List<Customer>
      {
          new Customer { Id = 1, Name = "Ahmed" },
          new Customer { Id = 2, Name = "Marwa" },
          new Customer { Id = 3, Name = "Omar" }
      };

      var orders = new List<Order>
      {
          new Order { Id = 1, CustomerId = 1, Amount = 100 },
          new Order { Id = 2, CustomerId = 1, Amount = 150 },
          new Order { Id = 3, CustomerId = 2, Amount = 200 }
      };

      // Method Syntax  [Join]
      var customerOrders = customers.Join(orders,
                                          c => c.Id,
                                          o => o.CustomerId,
                                          (c, o) => new
                                          {
                                             CustomerName = c.Name,
                                             OrderId = o.Id,
                                             OrderAmount = o.Amount
                                          });

      // Query Syntax
      var customerOrdersQuery = from c in customers
                                join o in orders
                                on c.Id equals o.CustomerId
                                select new
                                {
                                   CustomerName = c.Name,
                                   OrderId = o.Id,
                                   OrderAmount = o.Amount
                                };

      Console.WriteLine("Customer Orders (Method Syntax):");
      foreach (var co in customerOrders)
      {
         Console.WriteLine($"{co.CustomerName}: Order {co.OrderId}, {co.OrderAmount:C}");
      }

      Console.WriteLine();

      Console.WriteLine("Customer Orders (Query Syntax):");
      foreach (var co in customerOrdersQuery)
      {
         Console.WriteLine($"{co.CustomerName}: Order {co.OrderId}, {co.OrderAmount:C}");
      }

   }

   public static void Ex06()
   {
      var categories = new List<Category>
      {
         new Category { Id = 1, Name = "Electronics" },
         new Category { Id = 2, Name = "Furniture" }
      };

      var products = new List<Product>
      {
         new Product { Id = 1, CategoryId = 1, Name = "Laptop", Price = 1000 },
         new Product { Id = 2, CategoryId = 1, Name = "Phone", Price = 800 },
         new Product { Id = 3, CategoryId = 2, Name = "Desk", Price = 200 }
      };

      // Query Syntax
      var highPricedProducts = from c in categories
                               join p in products
                               on c.Id equals p.CategoryId
                               where p.Price > 500
                               orderby p.Price descending
                               select new
                               {
                                  CategoryName = c.Name,
                                  ProductName = p.Name,
                                  ProductPrice = p.Price
                               };

      // Group by category to check for multiple products
      var categoryProductCounts = from hp in highPricedProducts
                                  group hp by hp.CategoryName into g
                                  select new
                                  {
                                     Category = g.Key,
                                     ProductCount = g.Count()
                                  };

      bool hasBusyCategories = categoryProductCounts.Any(g => g.ProductCount > 1);

      Console.WriteLine("High Price Products by Category:");
      foreach (var hp in highPricedProducts)
      {
         Console.WriteLine($"{hp.CategoryName}: {hp.ProductName}, {hp.ProductPrice:C}");
      }

      Console.WriteLine("\nCategory Product Counts:");
      foreach (var cpc in categoryProductCounts)
      {
         Console.WriteLine($"{cpc.Category}: {cpc.ProductCount} products");
      }
      Console.WriteLine($"\nCategories with multiple high price products: {hasBusyCategories}");

   }

}


class Customer
{
   public int Id { get; set; }
   public string Name { get; set; }
}

class Order
{
   public int Id { get; set; }
   public int CustomerId { get; set; }
   public decimal Amount { get; set; }
}

class Category
{
   public int Id { get; set; }
   public string Name { get; set; }
}

class Product
{
   public int Id { get; set; }
   public int CategoryId { get; set; }
   public string Name { get; set; }
   public decimal Price { get; set; }
}
