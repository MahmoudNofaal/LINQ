using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._13_Concatenation;

public class _Main
{

   public static void Ex01()
   {
      var quiz1 = QuestionBank.Randomize(3);
      var quiz2 = QuestionBank.Randomize(2);

      var quiz3 = quiz1.Concat(quiz2);
      quiz3.ToQuiz();

   }

   public static void Ex02()
   {
      var quiz1 = QuestionBank.Randomize(3);
      var quiz2 = QuestionBank.Randomize(2);

      var questionTitles = quiz1.Select(q => q.Title)
                                .Concat(quiz2.Select(q => q.Title));


      foreach (var title in questionTitles)
      {
         Console.WriteLine(title);
      }

   }

   public static void Ex03()
   {
      var questionTitles = QuestionBank.Randomize(3)
                                       .Select(q => q.Title)
                                       .Concat(QuestionBank.Randomize(2).Select(q => q.Title))
                                       .Concat(QuestionBank.GetQuestionRange(Enumerable.Range(11, 14))
                                       .Select(q => q.Title));

      foreach (var title in questionTitles)
      {
         Console.WriteLine(title);
      }

   }

   public static void Ex04()
   {

      var quiz1 = QuestionBank.Randomize(3);
      var quiz2 = QuestionBank.Randomize(2);

      var quiz3 = new[] { quiz1, quiz2 }.SelectMany(q => q);

      quiz3.ToQuiz();

   }

   public static void Ex05()
   {
      var electronics = new List<Product>
      {
         new Product { Id = 1, Name = "Laptop" },
         new Product { Id = 2, Name = "Phone" }
      };

      var furniture = new List<Product>
      {
         new Product { Id = 3, Name = "Desk" },
         new Product { Id = 4, Name = "Chair" }
      };

      // [Concat] Combine electronics and furniture
      var allProducts = electronics.Concat(furniture);

      Console.WriteLine("All Products:");
      foreach (var product in allProducts)
      {
         Console.WriteLine($"{product.Id}: {product.Name}");
      }

   }

   public static void Ex06()
   {
      var electronics = new List<Product>
      {
         new Product { Id = 1, Name = "Laptop", Price = 1000 },
         new Product { Id = 2, Name = "Phone", Price = 800 }
      };

      var furniture = new List<Product>
      {
         new Product { Id = 3, Name = "Desk", Price = 200 },
         new Product { Id = 4, Name = "Chair", Price = 150 }
      };

      var allowedProducts = electronics.Where(p => p.Price < 900)
                                         .Concat(furniture.Where(p => p.Price < 200))
                                         .OrderBy(p => p.Price);

      Console.WriteLine("Allowed Products (Price < $900 for electronics, < $200 for furniture):");
      foreach (var product in allowedProducts)
      {
         Console.WriteLine($"{product.Name}: {product.Price}");
      }

   }

}

class Product
{
   public int Id { get; set; }
   public string Name { get; set; }
   public decimal Price { get; set; }
}

