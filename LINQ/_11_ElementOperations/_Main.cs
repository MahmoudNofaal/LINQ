using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._11_ElementOperations;



public class _Main
{

   public static void Ex01()
   {
      var questions = QuestionBank.All;

      var questionAt10 = questions.ElementAt(10);

      // var questionAt300 = questions.ElementAt(300); // ArugumentOutOfRangeException
      var questionAt300 = questions.ElementAtOrDefault(300);

      if (questionAt300 is null)
      {

      }

      Console.WriteLine(questionAt300);

   }

   public static void Ex02()
   {

      var questions = QuestionBank.All;
      var firstQuestion = questions.First();
      Console.WriteLine(firstQuestion);

      //var someQuestion = questions.First(x => x.Title.Length == 0); //InvalidOperationException
      var someOtherQuestion = questions.FirstOrDefault(x => x.Title.Length == 0); //null

      if (someOtherQuestion is null)
      {
         Console.WriteLine("Question is null");
      }

   }

   public static void Ex03()
   {
      var questions = QuestionBank.All;
      var lastQuestion = questions.Last();
      Console.WriteLine(lastQuestion);

      //var someQuestion = questions.Last(x => x.Title.Length == 0); //InvalidOperationException

      var someOtherQuestion = questions.LastOrDefault(x => x.Title.Length == 0); //null

      if (someOtherQuestion is null)
      {
         Console.WriteLine("Question is null");
      }

   }

   public static void Ex04()
   {
      var questions = QuestionBank.All;

      //var question = questions.Single(x => x.Title.Contains("#245"));
      //var question2 = questions.SingleOrDefault(x => x.Title.Contains("#245"));
      //var question3 = questions.Single(x => x.Title.Length == 0);

      QuestionBank.All.ToQuiz();

   }

   public static void Ex05()
   {
      var products = new List<Product>
      {
         new Product { Id = 1, Name = "Laptop", Price = 1000 },
         new Product { Id = 2, Name = "Phone", Price = 800 },
         new Product { Id = 3, Name = "Desk", Price = 200 }
      };

      // [ ElementAt ] Get product at index 1
      var secondProduct = products.ElementAt(1);
      Console.WriteLine($"ElementAt(1): {secondProduct.Name}, {secondProduct.Price:C}");

      // [ First ] Get first product
      var firstProduct = products.First();
      Console.WriteLine($"First: {firstProduct.Name}, {firstProduct.Price:C}");

      // [ Last ] Get last product
      var lastProduct = products.Last();
      Console.WriteLine($"Last: {lastProduct.Name}, {lastProduct.Price:C}");

      // [ Single ] Get product with ID 2
      var singleProduct = products.Single(p => p.Id == 2);
      Console.WriteLine($"Single(Id = 2): {singleProduct.Name}, {singleProduct.Price:C}");

      // [ OrDefault ] handles empty or invalid cases
      var emptyList = new List<Product>();
      var firstOrDefault = emptyList.FirstOrDefault();
      Console.WriteLine($"FirstOrDefault (empty): {firstOrDefault?.Name ?? "None"}");

   }

   public static void Ex06()
   {
      var orders = new List<Order>
      {
         new Order { Id = 1, CustomerName = "Ahmed", Amount = 100 },
         new Order { Id = 2, CustomerName = "Marwa", Amount = 200 },
         new Order { Id = 3, CustomerName = "Ahmed", Amount = 150 }
      };

      var firstAhmedOrder = orders.First(o => o.CustomerName == "Ahmed");
      Console.WriteLine($"First order by Ahmed: Id {firstAhmedOrder.Id}, {firstAhmedOrder.Amount}");

      var lastAhmedOrder = orders.Last(o => o.CustomerName == "Ahmed");
      Console.WriteLine($"Last order by Ahmed: Id {lastAhmedOrder.Id}, {lastAhmedOrder.Amount}");

      var uniqueOrder = orders.Single(o => o.Id == 2);
      Console.WriteLine($"Single order (Id = 2): {uniqueOrder.CustomerName}, {uniqueOrder.Amount}");

      var highValueOrder = orders.FirstOrDefault(o => o.Amount > 500);
      Console.WriteLine($"First order > $500: {highValueOrder?.Id.ToString() ?? "None"}");

   }

   public static void Ex07()
   {
      var products = new List<Product2>
      {
         new Product2 { Id = 1, Name = "Laptop", Price = 1000, IsActive = true },
         new Product2 { Id = 2, Name = "Phone", Price = 800, IsActive = true },
         new Product2 { Id = 3, Name = "Desk", Price = 200, IsActive = false },
         new Product2 { Id = 4, Name = "Tablet", Price = 600, IsActive = true }
      };

      // Get first active product and sorted by price descending
      var firstExpensive = products.Where(p => p.IsActive)
                                   .OrderByDescending(p => p.Price)
                                   .First();

      Console.WriteLine($"First expensive active product: {firstExpensive.Name}, {firstExpensive.Price}");

      // Get last active product and sorted by price ascending
      var lastCheap = products.Where(p => p.IsActive)
                              .OrderBy(p => p.Price)
                              .Last();

      Console.WriteLine($"Last cheap active product: {lastCheap.Name}, {lastCheap.Price}");

      // Get second active product, sorted by name
      var secondByName = products.Where(p => p.IsActive)
                                 .OrderBy(p => p.Name)
                                 .ElementAt(1);

      Console.WriteLine($"Second active product by name: {secondByName.Name}, {secondByName.Price}");

   }


}

class Product
{
   public int Id { get; set; }
   public string Name { get; set; }
   public decimal Price { get; set; }
}



class Order
{
   public int Id { get; set; }
   public string CustomerName { get; set; }
   public decimal Amount { get; set; }
}

class Product2
{
   public int Id { get; set; }
   public string Name { get; set; }
   public decimal Price { get; set; }
   public bool IsActive { get; set; }
}

