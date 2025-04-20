using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._14_AggregateOperations;

public class _Aggregate
{

   public static void Ex01()
   {
      var names = new[] { "Ahmed", "Marwa", "Abeer", "Reem", "Omar" };
      // Ahmed, Marwa, ....

      //// we can operate that....
      //var output = "";
      //foreach (var item in names)
      //    output += $"{item},";
      //Console.WriteLine(output.TrimEnd(','));

      //var output = string.Join(',', names);
      //Console.WriteLine(output);

      var commaSeparatedNames = names.Aggregate((a, b) =>
      {
         Console.WriteLine($"a = {a}, b = {b}");
         return $"{a},{b}";
      });

   }

   public static void Ex02()
   {
      var numbers = new[] { 1, 2, 3, 4, 5 };

      //var total = 0;
      //foreach (var n in numbers)
      //    total += n;

      var total = numbers.Aggregate(2, (a, b) => a + b);

      Console.WriteLine($"Total: {total}");

   }

   public static void Ex03()
   {
      var quiz = QuestionBank.All;

      var longestQuestionTitle = quiz[0];

      Console.WriteLine($"{longestQuestionTitle}");
      Console.WriteLine("-----");

      longestQuestionTitle = quiz
         .Aggregate(longestQuestionTitle,
                    (longest, next) => longest.Title.Length < next.Title.Length ? next : longest,
                    x => x);

      Console.WriteLine($"{longestQuestionTitle}");

   }

   public static void Ex04()
   {
      var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));

      //Count
      Console.WriteLine($"Total Questions: {quiz.Count()}");

      Console.WriteLine($"Total Questions With One Mark : {quiz.Count(x => x.Marks == 1)}");

      Console.WriteLine($"Total Questions With One Mark : {quiz.Where(x => x.Marks == 1).Count()}");

      Console.WriteLine($"Total Questions With One Mark Using LongCount :" +
                        $" {quiz.Where(x => x.Marks == 1).LongCount()}");

   }

   public static void Ex05()
   {
      var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));

      //Max
      var maximumMark = quiz.Max(x => x.Marks);

      //var maximumMark = quiz.Where(x => x.Choices.Count < 3).Max(x => x.Marks);

      Console.WriteLine($"Maximum Mark: {maximumMark}");

   }

   public static void Ex06()
   {
      var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));

      //MaxBy
      var maximumQuestionMark = quiz.MaxBy(x => x.Marks);

      //var maximumMark = quiz.Where(x => x.Choices.Count < 3).Max(x => x.Marks);

      Console.WriteLine($"{maximumQuestionMark}");

   }

   public static void Ex07()
   {
      var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));

      //Min
      var maximumMark = quiz.Min(x => x.Marks);

      //var minimumMark = quiz.Where(x => x.Choices.Count < 3).Min(x => x.Marks);

      Console.WriteLine($"Minimum Mark: {maximumMark}");

   }

   public static void Ex08()
   {
      var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));

      //MinBy
      var minimumQuestionMark = quiz.MinBy(x => x.Marks);

      //var minimumMark = quiz.Where(x => x.Choices.Count < 3).MinBy(x => x.Marks);

      Console.WriteLine($"{minimumQuestionMark}");

   }

   public static void Ex09()
   {
      var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));

      //Sum
      var total = quiz.Sum(x => x.Marks);

      Console.WriteLine($"total: {total}");

   }

   public static void Ex10()
   {
      var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));

      //Avg
      var average = quiz.Average(x => x.Marks);

      Console.WriteLine($"average: {average.ToString("#.##")}");

   }

}


