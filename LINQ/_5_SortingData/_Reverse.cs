using LINQ._4_ProjectionOperation;

namespace LINQ._5_SortingData;

public class _Reverse
{

   public static void Ex01()
   {

      var orders = new List<Order>
      {
         new Order { Id = 1, OrderDate = new DateTime(2025, 1, 1) },
         new Order { Id = 2, OrderDate = new DateTime(2025, 2, 1) },
         new Order { Id = 3, OrderDate = new DateTime(2025, 1, 15) }
      };

      // OrderBy then Reverse
      var reversedSortedOrders = orders.OrderBy(o => o.OrderDate)
                                       .Reverse();

      // OrderByDescending
      var descendingOrders = orders.OrderByDescending(o => o.OrderDate);

      Console.WriteLine("Orders Sorted by Date then Reversed:");
      foreach (var order in reversedSortedOrders)
      {
         Console.WriteLine($"Order {order.Id}: {order.OrderDate:MM/dd/yyyy}");
      }

      Console.WriteLine("\nOrders Sorted by Date Descending (for comparison):");
      foreach (var order in descendingOrders)
      {
         Console.WriteLine($"Order {order.Id}: {order.OrderDate:MM/dd/yyyy}");
      }

   }

   public static void Ex02()
   {

     var customers = new List<Customer>
     {
         new Customer { Name = "Alice", PurchaseAmount = 500, IsActive = true },
         new Customer { Name = "Bob", PurchaseAmount = 200, IsActive = true },
         new Customer { Name = "Charlie", PurchaseAmount = 600, IsActive = false }
     };

      // Where, Select, Reverse
      var reversedCustomerSummaries = customers.Where(c => c.IsActive)
                                               .Select(c => new { c.Name, c.PurchaseAmount })
                                               .Reverse();

      // Query Syntax for Where and Select and Reverse
      var reversedCustomerSummariesQuery = (from c in customers
                                            where c.IsActive
                                            select new { c.Name, c.PurchaseAmount }).Reverse();

      Console.WriteLine("Active Customer Summaries (Reversed) [Method Syntax]:");
      foreach (var summary in reversedCustomerSummaries)
      {
         Console.WriteLine($"{summary.Name}: {summary.PurchaseAmount:C}");
      }

      Console.WriteLine("\nActive Customer Summaries (Reversed) [Query Syntax]:");
      foreach (var summary in reversedCustomerSummariesQuery)
      {
         Console.WriteLine($"{summary.Name}: {summary.PurchaseAmount:C}");
      }

   }

}

class Customer
{
   public string Name { get; set; }
   public decimal PurchaseAmount { get; set; }
   public bool IsActive { get; set; }
}

