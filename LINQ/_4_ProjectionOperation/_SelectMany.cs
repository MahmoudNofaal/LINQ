using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._4_ProjectionOperation;

public class _SelectMany
{
   /// [SELECT MANY]
   ///* It takes lists inside a list and flattens them into on big list
   ///
   ///* It is great for combining nested data,
   ///  like getting all items from multiple shopping carts.

   public static void Ex01()
   {
      var customers = new List<Customer>
      {
         new Customer
         {
            Name = "Ahmed",
            Orders = new List<Order>
            {
               new Order { Id =1, Amount = 100},
               new Order { Id = 2, Amount = 200},
            }
         },
         new Customer
         {
            Name = "Marwa",
            Orders = new List<Order>
            {
                new Order { Id = 3, Amount = 150 }
            }
         }
      };


      var allOrders = customers.SelectMany(x => x.Orders);

      var allOrdersQuery = from c in customers
                           from o in c.Orders
                           select o;

      Console.WriteLine("All Orders (Method Syntax):");
      foreach (var order in allOrders)
      {
         Console.WriteLine($"Order {order.Id}: {order.Amount:C}");
      }

      Console.WriteLine("\nAll Orders (Query Syntax):");
      foreach (var order in allOrdersQuery)
      {
         Console.WriteLine($"Order {order.Id}: {order.Amount:C}");
      }

   }

   public static void Ex02()
   {
      var employees = Repository.LoadEmployees();

      var skills = employees.SelectMany(x => x.Skills).Distinct();

      var skillsQuery = (from e in employees
                         from s in e.Skills
                         select s).Distinct();

      Console.WriteLine("Skills (Method Syntax):");
      foreach (var s in skills)
      {
         Console.WriteLine(s);
      }

      Console.WriteLine("\nSkills (Query Syntax):");
      foreach (var s in skillsQuery)
      {
         Console.WriteLine(s);
      }

   }

}


class Customer
{
   public string Name { get; set; }
   public List<Order> Orders { get; set; }
}

class Order
{
   public int Id { get; set; }
   public decimal Amount { get; set; }
}


