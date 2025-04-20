using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._10_GenerationOperations;

public class _Empty
{

   public static void Ex01()
   {
      // Empty => Create an empty sequence
      IEnumerable<string> emptySequence = Enumerable.Empty<string>();

      Console.WriteLine($"Empty sequence count: {emptySequence.Count()}"); // 0

      // Range => Generate numbers 1 to 5
      IEnumerable<int> numbers = Enumerable.Range(1, 5);
      Console.WriteLine("Range (1 to 5): " + string.Join(", ", numbers)); // 1, 2, 3, 4, 5

      // Repeat => Repeat a value 3 times
      IEnumerable<string> repeated = Enumerable.Repeat("Test", 3);
      Console.WriteLine("Repeat ('Test', 3): " + string.Join(", ", repeated)); // Test, Test, Test

   }

   public static void Ex02()
   {
      var products = new List<Product>(); // Empty list

      // DefaultIfEmpty: Provide a default product if empty
      var productList = products.DefaultIfEmpty(new Product { Name = "No Product", Price = 0 });

      Console.WriteLine("Products (with default):");
      foreach (var product in productList)
      {
         Console.WriteLine($"{product.Name}: {product.Price}");
      }

      // Non-empty list
      products.Add(new Product { Name = "Laptop", Price = 1000 });

      var nonEmptyList = products.DefaultIfEmpty(new Product { Name = "No Product", Price = 0 });

      Console.WriteLine();
      Console.WriteLine("Non-Empty Products:");
      foreach (var product in nonEmptyList)
      {
         Console.WriteLine($"{product.Name}: {product.Price}");
      }

   }

   public static void Ex03()
   {
      // Range: Generate numbers 1 to 10 
      var evenNumbers = Enumerable.Range(1, 10)
                                  .Where(n => n % 2 == 0)
                                  .OrderByDescending(n => n)
                                  .Select(n => new { Number = n });

      Console.WriteLine("Even Numbers (1 to 10) sorted descending]:");
      foreach (var item in evenNumbers)
      {
         Console.WriteLine(item.Number);
      }

   }

   public static void Ex04()
   {
      // int x; // x=0;
      //Console.WriteLine(default(int)); // 0
      //Console.WriteLine(default(DateTime)); // 01-01-0001 12:00:00 AM
      //Console.WriteLine(default(Object) is null ? "NULL" : default(Object)); // NULL

      var questions = Enumerable.Empty<Question>();

      var question2 = questions.DefaultIfEmpty();

      var question3 = questions.DefaultIfEmpty(Question.Default);

      question3.ToQuiz();

   }

   public static void Ex05()
   {
      var range = Enumerable.Range(1, 10);

      //int[] range2 = new int[10];

      //for (int i = 0; i < range2.Length; i++)
      //    range2[i] = i;

      //for (int i = 0; i < range2.Length; i++)
      //    Console.Write($" {i}");

      //foreach (var i in range) 
      //    Console.Write($" {i}");

      var questions = QuestionBank.GetQuestionRange(range);

      questions.ToQuiz();

   }

   public static void Ex06()
   {
      var q = QuestionBank.PickOne();

      var questions2 = new List<Question>();
      for (int i = 0; i < 10; i++)
      {
         questions2.Add(new Question());
      }

      Console.WriteLine(ReferenceEquals(questions2[0], questions2[1]));
      var questions = Enumerable.Repeat(q, 10).ToList();

      Console.WriteLine(ReferenceEquals(questions[0], questions[1]));
      //questions.ToQuiz();

   }

}

class Product
{
   public string Name { get; set; }
   public decimal Price { get; set; }
}

