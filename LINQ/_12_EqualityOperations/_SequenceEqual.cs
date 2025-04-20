using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._12_EqualityOperations;

public class _SequenceEqual
{

   public static void Ex01()
   {
      var q1 = QuestionBank.PickOne();
      var q2 = QuestionBank.PickOne();
      var q3 = QuestionBank.PickOne();

      var quiz1 = new List<Question>(new[] { q1, q2, q3, });
      var quiz2 = new List<Question>(new[] { q1, q2, q3, });

      var equal = quiz1.SequenceEqual(quiz1);

      Console.WriteLine($"Is [quiz1] equals [quiz2]: {equal}");

   }

   public static void Ex02()
   {
      var randomFourQuestions = QuestionBank.GetQuestionRange(Enumerable.Range(1, 4));

      var quiz1 = randomFourQuestions;
      var quiz2 = randomFourQuestions;

      var equal = quiz1.SequenceEqual(quiz2);
      Console.WriteLine($"Is [quiz1] {(equal ? "equals" : "is not equal")} [quiz2]");

   }

   public static void Ex03()
   {
      var quiz1 = QuestionBank.GetQuestionRange(Enumerable.Range(1, 4));
      var quiz2 = QuestionBank.GetQuestionRange(Enumerable.Range(1, 4));

      var equal = quiz1.SequenceEqual(quiz2);
      Console.WriteLine($"Is [quiz1] {(equal ? "equals" : "is not equal")} [quiz2]");

   }

   public static void Ex04()
   {

      var products1 = new List<Product>
      {
         new Product { Id = 1, Name = "Laptop" },
         new Product { Id = 2, Name = "Phone" }
      };

      var products2 = new List<Product>
      {
         new Product { Id = 1, Name = "Laptop" },
         new Product { Id = 2, Name = "Phone" }
      };

      var products3 = new List<Product>
      {
         new Product { Id = 2, Name = "Phone" },
         new Product { Id = 1, Name = "Laptop" }
      };

      // SequenceEqual: Compare products1 and products2
      bool areEqual12 = products1.SequenceEqual(products2);
      Console.WriteLine($"Is products1 equals products2: {areEqual12}");

      // SequenceEqual: Compare products1 and products3 (different order)
      bool areEqual13 = products1.SequenceEqual(products3);
      Console.WriteLine($"Is products1 equals products3: {areEqual13}");
   }

}

class Product
{
   public int Id { get; set; }
   public string Name { get; set; }
}

