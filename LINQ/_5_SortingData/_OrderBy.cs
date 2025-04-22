using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._5_SortingData;

public class _OrderBy
{
   ///orderby, reverse, thenby
   public static void Ex01()
   {
      string[] fruits = { "grape", "orange", "strawberrry", "mango", "apple", "banana" };

      //ASC
      var orderedFruits = fruits.OrderBy(x => x); // MEANS THAT ORDER WILL BE ALPHABETIC
      orderedFruits.Print("Fruits (ASC) ORDER [Method]");

      var orderedFruitsQuery = from f in fruits
                               orderby f
                               select f;
      orderedFruitsQuery.Print("Fruits (ASC) ORDER [Query]");

      //DESC
      var orderedFruitsDESC = fruits.OrderByDescending(x => x); // MEANS THAT ORDER WILL BE ALPHABETIC
      orderedFruitsDESC.Print("Fruits (DESC) ORDER [Method]");

      var orderedFruitsQueryDESC = from f in fruits
                                   orderby f descending
                                   select f;
      orderedFruitsQueryDESC.Print("Fruits (DESC) ORDER [Query]");

   }

   public static void Ex02()
   {
      string[] fruits = ["grape", "orange", "strawberrry", "mango", "apple", "banana"];

      //DESC
      var orderedFruitsByLengthDESC = fruits.OrderByDescending(x => x.Length); // MEANS THAT ORDER WILL BE ALPHABETIC
      orderedFruitsByLengthDESC.Print("Fruits (DESC) ORDER By Length [Method]");

      var orderedFruitsByLengthQueryDESC = from f in fruits
                                           orderby f.Length descending
                                           select f;
      orderedFruitsByLengthQueryDESC.Print("Fruits (DESC) ORDER By Length [Query]");


   }

   ///

   public static void Ex03()
   {
      var orders = new List<Order>
      {
         new Order { Id = 1, OrderDate = new DateTime(2025, 1, 1), Amount = 100, IsActive = true },
         new Order { Id = 2, OrderDate = new DateTime(2025, 2, 1), Amount = 250, IsActive = true },
         new Order { Id = 3, OrderDate = new DateTime(2025, 1, 15), Amount = 50, IsActive = false }
      };

      // orderby with where and select
      var recentOrderSummaries = from order in orders
                                 where order.IsActive
                                 orderby order.OrderDate descending
                                 select new
                                 {
                                    order.Id,
                                    order.OrderDate,
                                    order.Amount
                                 };

      // Method Syntax
      var recentOrderSummariesMethod = orders.Where(o => o.IsActive)
                                             .OrderByDescending(o => o.OrderDate)
                                             .Select(o => new
                                             {
                                                o.Id,
                                                o.OrderDate,
                                                o.Amount
                                             });

      Console.WriteLine("Recent Active Orders (Query Syntax):");
      foreach (var summary in recentOrderSummaries)
      {
         Console.WriteLine($"Order {summary.Id}: {summary.OrderDate:MM/dd/yyyy}, {summary.Amount:C}");
      }

      Console.WriteLine("\nRecent Active Orders (Method Syntax):");
      foreach (var summary in recentOrderSummariesMethod)
      {
         Console.WriteLine($"Order {summary.Id}: {summary.OrderDate:MM/dd/yyyy}, {summary.Amount:C}");
      }

   }


}






