using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._8_GroupingData;

public class _Main
{
   /// [GROUP BY]
   ///* It organizes your data into groups based on something they share
   ///  you can group orders by customer to see what each person bought
   ///  
   /// [TO LOOKUP]
   ///* It Like GroupBy, but makes a fast-access dictionary of groups
   ///  if you need quickly find all student in a department, ToLookUp is perfect for.
   ///  



   public static void Ex01()
   {
      var products = new List<Product>
      {
          new Product { Name = "Laptop", Category = "Electronics", Price = 1000 },
          new Product { Name = "Phone", Category = "Electronics", Price = 800 },
          new Product { Name = "Desk", Category = "Furniture", Price = 200 },
          new Product { Name = "Chair", Category = "Furniture", Price = 100 }
      };

      // Method Syntax => GroupBy
      var groupedProducts = products.GroupBy(p => p.Category);

      // Query Syntax
      var groupedProductsQuery = from p in products
                                 group p by p.Category into g
                                 select g;

      Console.WriteLine("Products Grouped by Category (Method Syntax):");
      foreach (var group in groupedProducts)
      {
         Console.WriteLine($"Category: {group.Key}");
         foreach (var product in group)
         {
            Console.WriteLine($"  {product.Name}: {product.Price:C}");
         }
      }

      Console.WriteLine("\nProducts Grouped by Category (Query Syntax):");
      foreach (var group in groupedProductsQuery)
      {
         Console.WriteLine($"Category: {group.Key}");
         foreach (var product in group)
         {
            Console.WriteLine($"  {product.Name}: {product.Price:C}");
         }
      }
   }

   public static void Ex02()
   {

      var orders = new List<Order>
      {
         new Order { Id = 1, CustomerName = "Ahmed", Amount = 100 },
         new Order { Id = 2, CustomerName = "Marwa", Amount = 200 },
         new Order { Id = 3, CustomerName = "Ahmed", Amount = 150 },
         new Order { Id = 4, CustomerName = "Marwa", Amount = 300 }
      };

      // Method Syntax: GroupBy
      var customerTotal = orders.GroupBy(o => o.CustomerName)
                                 .Select(g => new
                                 {
                                    Customer = g.Key,
                                    TotalAmount = g.Sum(o => o.Amount),
                                    OrderCount = g.Count()
                                 });

      // Query Syntax
      var customerTotalQuery = from o in orders
                                group o by o.CustomerName into g
                                select new
                                {
                                   Customer = g.Key,
                                   TotalAmount = g.Sum(o => o.Amount),
                                   OrderCount = g.Count()
                                };

      Console.WriteLine("Customer Order Total (Method Syntax):");
      foreach (var total in customerTotal)
      {
         Console.WriteLine($"{total.Customer}: {total.TotalAmount:C}, {total.OrderCount} orders");
      }

      Console.WriteLine("\nCustomer Order Total (Query Syntax):");
      foreach (var total in customerTotalQuery)
      {
         Console.WriteLine($"{total.Customer}: {total.TotalAmount:C}, {total.OrderCount} orders");
      }

   }

   public static void Ex03()
   {
      var employees = new List<Employee3>
      {
         new Employee3 { Name = "Ahmed", Department = "HR", IsActive = true },
         new Employee3 { Name = "Marwa", Department = "IT", IsActive = true },
         new Employee3 { Name = "Omar", Department = "HR", IsActive = true },
         new Employee3 { Name = "Ali", Department = "IT", IsActive = true },
         new Employee3 { Name = "Mai", Department = "Finance", IsActive = false }
      };

      // MEthod Syntax
      var departmentGroups = employees.Where(e => e.IsActive)
                                      .GroupBy(e => e.Department)
                                      .Where(g => g.Count() > 1)
                                      .OrderByDescending(g => g.Count())
                                      .Select(g => new
                                      {
                                         Department = g.Key,
                                         EmployeeCount = g.Count(),
                                         Employees = g.Select(e => e.Name)
                                      });

      // Query
      var departmentGroupsQuery = from e in employees
                                  where e.IsActive
                                  group e by e.Department into g
                                  where g.Count() > 1
                                  orderby g.Count() descending
                                  select new
                                  {
                                     Department = g.Key,
                                     EmployeeCount = g.Count(),
                                     Employees = g.Select(e => e.Name)
                                  };

      Console.WriteLine("Active Employee Groups with Multiple Employees (Method Syntax):");
      foreach (var group in departmentGroups)
      {
         Console.WriteLine($"{group.Department}: {group.EmployeeCount} employees");
         foreach (var name in group.Employees)
         {
            Console.WriteLine($"  {name}");
         }
      }

      Console.WriteLine("\nActive Employee Groups with Multiple Employees (Query Syntax):");
      foreach (var group in departmentGroupsQuery)
      {
         Console.WriteLine($"{group.Department}: {group.EmployeeCount} employees");
         foreach (var name in group.Employees)
         {
            Console.WriteLine($"  {name}");
         }
      }
   }

   public static void Ex04()
   {
      var employees = Repository.LoadEmployees();

      var result = employees.GroupBy(x => x.Department);

      foreach (var item in result)
      {
         item.Print($"Employee in '{item.Key}' Department");
      }
   }

   public static void Ex05()
   {
      var employees = Repository.LoadEmployees();

      var result = employees.ToLookup(x => x.Department);

      foreach (var item in result)
      {
         item.Print($"Employee in '{item.Key}' Department");
      }
   }

   public static void Ex06()
   {
      var employees = Repository.LoadEmployees();

      var result = from emp in employees
                   group emp by emp.Department;

      foreach (var item in result)
      {
         item.Print($"Employee in '{item.Key}' Department");
      }
   }

}

class Product
{
   public string Name { get; set; }
   public string Category { get; set; }
   public decimal Price { get; set; }
}

class Order
{
   public int Id { get; set; }
   public string CustomerName { get; set; }
   public decimal Amount { get; set; }
}

class Employee3
{
   public string Name { get; set; }
   public string Department { get; set; }
   public bool IsActive { get; set; }
}
