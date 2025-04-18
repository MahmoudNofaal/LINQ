using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._4_ProjectionOperation;

public class Select
{

   public static void Ex01()
   {
      var words = new List<string> { "talking", "about", "language", "integrated", "query" };

      var result = words.Select(x => x.ToUpper());

      var result02 = from x in words
                     select x.ToUpper();

      foreach (var word in result)
      {
         Console.WriteLine(word);
      }

   }

   public static void Ex02()
   {
      var products = new List<Product>
      {
         new Product { Name = "Laptop", Price = 1000 },
         new Product { Name = "Phone", Price = 800 },
         new Product { Name = "Tablet", Price = 600 }
      };

      // Method Syntax: Select
      var productNames = products.Select(p => p.Name);

      // Query Syntax Equivalent
      var productNamesQuery = from p in products
                              select p.Name;

      Console.WriteLine("Product Names (Method Syntax):");
      foreach (var name in productNames)
      {
         Console.WriteLine(name);
      }

      Console.WriteLine("\nProduct Names (Query Syntax):");
      foreach (var name in productNamesQuery)
      {
         Console.WriteLine(name);
      }
   }

   public static void Ex03()
   {
      var employees = new List<Employee2>
      {
         new Employee2 { Name = "Alice", Salary = 60000, IsActive = true },
         new Employee2 { Name = "Bob", Salary = 45000, IsActive = true },
         new Employee2 { Name = "Charlie", Salary = 70000, IsActive = false }
      };


      var employeesSalariesMethod = employees.Where(e => e.IsActive)
                                             .Select(e => new
                                             {
                                                e.Name,
                                                Bonus = e.Salary * 0.05
                                             });

      var employeesSalariesQuery = from e in employees
                              where e.IsActive
                              select new
                              {
                                 e.Name,
                                 Bonus = e.Salary * 0.05
                              };


      Console.WriteLine("Active Employee Bonus (Query Syntax):");
      foreach (var summary in employeesSalariesQuery)
      {
         Console.WriteLine($"{summary.Name}: Bonus {summary.Bonus:C}");
      }

      Console.WriteLine("\nActive Employee Bonus (Method Syntax):");
      foreach (var summary in employeesSalariesMethod)
      {
         Console.WriteLine($"{summary.Name}: Bonus {summary.Bonus:C}");
      }

   }

}

