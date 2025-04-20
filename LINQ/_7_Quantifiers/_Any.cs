using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._7_Quantifiers;

public class _Any
{

   public static void Ex01()
   {
      var products = new List<Product>
      {
         new Product { Name = "Laptop", Price = 1000 },
         new Product { Name = "Phone", Price = 800 },
         new Product { Name = "Tablet", Price = 600 }
      };

      // All: Check if all products are priced above 500
      bool allExpensive = products.All(p => p.Price > 500);
      Console.WriteLine($"All products price > 500: {allExpensive}"); // True

      // Any: Check if any product is priced below 700
      bool hasCheapProduct = products.Any(p => p.Price < 700);
      Console.WriteLine($"Any product price < 700: {hasCheapProduct}"); // True

      // Contains: Check if a specific product exists
      var specificProduct = new Product { Name = "Phone", Price = 800 };

      bool containsPhone = products.Contains(specificProduct); // False (reference comparison)

      bool containsPhoneByName = products.Any(p => p.Name == "Phone"); // True

      Console.WriteLine($"Contains 'Phone' product (reference): {containsPhone}");
      Console.WriteLine($"Contains 'Phone' by name: {containsPhoneByName}");

   }

   public static void Ex02()
   {

      var orders = new List<Order>
      {
         new Order { Id = 1, IsActive = true, IsShipped = true },
         new Order { Id = 2, IsActive = true, IsShipped = true },
         new Order { Id = 3, IsActive = false, IsShipped = false },
         new Order { Id = 4, IsActive = true, IsShipped = false }
      };

      // Any: Check if any active orders exist
      bool hasActiveOrders = orders.Any(o => o.IsActive);
      Console.WriteLine($"Has active orders: {hasActiveOrders}"); // True

      // All: Check if all active orders are shipped
      bool allActiveShipped = orders.Where(o => o.IsActive)
                                    .All(o => o.IsShipped);

      Console.WriteLine($"All active orders shipped: {allActiveShipped}"); // False

      // Using Query Syntax for filtering, then All
      bool allActiveShippedQuery = (from o in orders
                                    where o.IsActive
                                    select o).All(o => o.IsShipped);

      Console.WriteLine($"All active orders shipped (Query Syntax): {allActiveShippedQuery}"); // False

   }

   public static void Ex03()
   {

      var employees = new List<Employee3>
      {
         new Employee3 { Name = "Alice", Salary = 60000, IsActive = true },
         new Employee3 { Name = "Bob", Salary = 45000, IsActive = true },
         new Employee3 { Name = "Charlie", Salary = 70000, IsActive = false }
      };

      // All: Check if all active employees have salary > 40000
      bool allActiveWellPaid = employees.Where(e => e.IsActive)
                                        .All(e => e.Salary > 40000);
      Console.WriteLine($"All active employees salary > 40000: {allActiveWellPaid}"); // True

      // Any: Check if any employee is named "Alice"
      bool hasAlice = employees.Any(e => e.Name == "Alice");
      Console.WriteLine($"Has employee named 'Alice': {hasAlice}"); // True

      // Contains: Check for a specific employee by name (using Any for clarity)
      string nameToCheck = "Bob";
      bool containsBob = employees.Any(e => e.Name == nameToCheck);
      Console.WriteLine($"Contains employee 'Bob': {containsBob}"); // True

   }

   public static void Ex04()
   {
      var employees = Repository.LoadEmployees();

      //check if there is an employee with name start with 'jac'

      // [ StringComparison.OrdinalIgnoreCase ] here it ignores case of the name capital or small
      var result01 = employees.Any(x => x.Name.StartsWith("jac", StringComparison.OrdinalIgnoreCase));

      Console.WriteLine($"check if there is an employee with name start with 'jac': {result01}");

      //check if there is an employee with salary less than $10,000
      var result02 = employees.Any(x => x.Salary < 10_000);

      Console.WriteLine($"check if there is an employee with salary less than $10,000: {result02}");

      //check if there is an employee with one skill
      var result03 = employees.Any(x => x.Skills.Count == 1);

      Console.WriteLine($"check if there is an employee with one skill: {result03}");

   }

   public static void Ex05()
   {
      var employees = Repository.LoadEmployees();

      // check if all employees have value for email
      var r01 = employees.All(x => !string.IsNullOrWhiteSpace(x.Email));
      Console.WriteLine($" check if all employees have value for email: {r01}");

      // check if all employees have C# listed in their skills
      var r02 = employees.All(x => x.Skills.Any(s => s=="C#"));
      Console.WriteLine($" check if all employees have C# listed in their skills: {r02}");

   }

   public static void Ex06()
   {
      var employees = Repository.LoadEmployees();

      var q1 = from e in employees
               where e.Skills.Any(s => s == "C++")
               select e;

      q1.Print("Employees with C++ skill");

      var q2 = from e in employees
               where e.Skills.Any(s => s.Length >=3)
               select e;

      q1.Print("Employees with skills have 3 characters and more..");


   }

   public static void Ex07()
   {
      var employees = Repository.LoadEmployees();


      // if any employee contains 'ee' in his/her name

      var e1 = employees.ToArray()[0];

      var result1 = employees.Contains(e1);

      Console.WriteLine($"find if any employee contains " +
                        $"'{e1.Email}' in his/her name result: {result1}");

      var e2 = new Employee { Email = "Cole.Cochran02@example.com" };

      var result2 = employees.Contains(e2);

      Console.WriteLine($"find if any employee contains " +
                        $"'{e2.Email}' in his/her name result: {result2}");
   }


}

class Employee3
{
   public string Name { get; set; }
   public int Salary { get; set; }
   public bool IsActive { get; set; }
}

class Product
{
   public string Name { get; set; }
   public decimal Price { get; set; }
}

class Order
{
   public int Id { get; set; }
   public bool IsActive { get; set; }
   public bool IsShipped { get; set; }
}

