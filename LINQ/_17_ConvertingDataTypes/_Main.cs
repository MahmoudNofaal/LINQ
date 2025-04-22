using LINQ._17_ConvertingDataTypes.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._17_ConvertingDataTypes;

public class _Main
{

   public static void Ex01()
   {
      var products = new List<Product>
      {
         new Product { Id = 1, Name = "Laptop", Category = "Electronics" },
         new Product { Id = 2, Name = "Phone", Category = "Electronics" },
         new Product { Id = 3, Name = "Desk", Category = "Furniture" }
      };

      // [ToArray] Convert to array
      string[] productNamesArray = products.Select(p => p.Name).ToArray();

      Console.WriteLine("Product names (array):");
      Console.WriteLine(string.Join(", ", productNamesArray));

      Console.WriteLine();

      // [ToList] Convert to list
      List<string> productNamesList = products.Select(p => p.Name).ToList();

      Console.WriteLine("Product names (list):");
      Console.WriteLine(string.Join(", ", productNamesList));

      Console.WriteLine();

      // [ToDictionary] Convert to dictionary by Id
      Dictionary<int, Product> productDict = products.ToDictionary(p => p.Id);

      Console.WriteLine("Product dictionary (by ID):");
      Console.WriteLine($"Product ID 1: {productDict[1].Name}");

      Console.WriteLine();

      // [ToLookup] Group by category
      ILookup<string, string> categoryLookup = products.ToLookup(p => p.Category, p => p.Name);

      Console.WriteLine("Products by category (lookup):");
      foreach (var group in categoryLookup)
      {
         Console.WriteLine($"{group.Key}: {string.Join(", ", group)}");
      }

   }

   public static void Ex02()
   {
      ArrayList mixedData = new ArrayList
      {
          "Laptop",
          1000,
          "Phone",
          "Desk",
          null
      };


      // [OfType] get strings
      var strings = mixedData.OfType<string>();

      Console.WriteLine("Strings (OfType):");
      Console.WriteLine(string.Join(", ", strings));

      Console.WriteLine();

      // Cast: Convert to strings (will fail on non-strings)
      try
      {
         var allStrings = mixedData.Cast<string>();
         Console.WriteLine("All strings (Cast):");
         Console.WriteLine(string.Join(", ", allStrings));
      }
      catch (InvalidCastException)
      {
         Console.WriteLine("Cast failed due to non-string elements.");
      }

   }

   public static void Ex03()
   {
      var orders = new List<Order>
      {
         new Order { Id = 1, CustomerName = "Ahmed", Amount = 100 },
         new Order { Id = 2, CustomerName = "Marwa", Amount = 200 },
         new Order { Id = 3, CustomerName = "Ahmed", Amount = 150 }
      };

      // Query Syntax
      var query = from o in orders
                  group o by o.CustomerName into g
                  select new
                  {
                     Customer = g.Key,
                     TotalAmount = g.Sum(o => o.Amount)
                  };

      Dictionary<string,decimal> customerTotals = query.ToDictionary(c => c.Customer, c => c.TotalAmount);

      Console.WriteLine("Customer Order Totals:");
      foreach (var kvp in customerTotals)
      {
         Console.WriteLine($"{kvp.Key}: {kvp.Value:C}");
      }

   }

   public static void Ex04()
   {
      ///AS ENUMERABLE

      ShippingList<Shipping> shippings = ShippingRepository.AllAsShippingList;

      var todayShipping = shippings.Where(x => x.ShippingDate == DateTime.Today);

      todayShipping.Process("Today's shipping using ShippingList<T> Where");


      var todayShipping2 = shippings.AsEnumerable().Where(x => x.ShippingDate == DateTime.Today);

      todayShipping2.Process("Today's shipping using IEnumerable<T> Where");

   }

   public static void Ex05()
   {
      ///AS QUERYABLE
      ShippingList<Shipping> shippings = ShippingRepository.AllAsShippingList;

      var todayShipping = shippings.Where(x => x.ShippingDate == DateTime.Today);
      //Console.WriteLine(todayShipping.Expression); // not available for IEnumerable
      todayShipping.Process("Today's shipping using ShippingList<T> Where");


      IQueryable<Shipping> todayShipping2 = shippings.AsQueryable().Where(x => x.ShippingDate == DateTime.Today);

      todayShipping2.Process("Today's shipping using IQueryable<T> Where");


      Console.WriteLine(todayShipping2.Expression);

   }

   public static void Ex06()
   {
      ///CAST

      IEnumerable<Shipping> shippings = ShippingRepository.AllAsList;

      var groundShippings = shippings.Where(x => x.GetType() == typeof(GroundShipping))
                                     .Cast<GroundShipping>();

      groundShippings.Process("Ground shippings");

   }

   public static void Ex07()
   {
      /// OF TYPE
      IEnumerable<Shipping> shippings = ShippingRepository.AllAsList;

      var groundShippings = shippings.OfType<GroundShipping>();

      groundShippings.Process("Ground shippings");

   }

   public static void Ex08()
   {
      ///TO ARRAY

      IEnumerable<Shipping> shippings = ShippingRepository.AllAsList;

      var shippingArray = shippings.ToArray();

      Console.WriteLine($"total shippings: {shippingArray.Length}");

      Console.WriteLine($"first shipping");
      shippingArray[0].Start();

   }

   public static void Ex09()
   {
      ///TO DICTIONARY

      IEnumerable<Shipping> shippings = ShippingRepository.AllAsList;

      Dictionary<string, Shipping> dictionary1 = shippings.ToDictionary(x => x.UniqueId);

      dictionary1["ABC005"].Start();

      Dictionary<DateTime, List<Shipping>> dictionary2 = shippings.GroupBy(x => x.ShippingDate)
                                                            .ToDictionary(s => s.Key, s => s.ToList());

      //var date = DateTime.Now;
      //dictionary2[date].Process($"Shippings on {date}");

   }

   public static void Ex10()
   {
      ///TO LIST
      IEnumerable<Shipping> shippings = ShippingRepository.AllAsList;

      List<Shipping> shippingList = shippings.ToList();

      Console.WriteLine($"total shippings: {shippingList.Count}");

      Console.WriteLine($"first shipping");
      shippingList[0].Start();

      shippingList.First().Start();

   }

   public static void Ex11()
   {
      ///TO LOOKUP

      IEnumerable<Shipping> shippings = ShippingRepository.AllAsList;

      ILookup<string, Shipping> lookup1 = shippings.ToLookup(x => x.UniqueId);
      lookup1["ABC005"].First().Start();

      ILookup<DateTime, Shipping> lookup2 = shippings.ToLookup(x => x.ShippingDate);

      var date = new DateTime(2022, 3, 9, 0, 0, 0);
      lookup2[date].Process($"Shippings on {date.ToString("dddd, MMMM dd yyyy")}");

   }


}

class Product
{
   public int Id { get; set; }
   public string Name { get; set; }
   public string Category { get; set; }
}

class Order
{
   public int Id { get; set; }
   public string CustomerName { get; set; }
   public decimal Amount { get; set; }
}

