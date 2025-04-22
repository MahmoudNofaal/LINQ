using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._1_PureVsImpureFunctions;

public class _Main
{

   public static void Ex01()
   {
      /// PURE FUNCTIONS
      /// * It is a function that, given the sampe input, always produces the same output
      ///   and has no side effects
      /// * Deterministic: Same input -> same output.
      /// 
      /// IMPURE FUNCTIONS
      /// * It may produce different outputs for the same input or cause side effects,
      ///   such as modfiying external state, interacting with outside world, depending
      ///   on external variables.
      /// 
      /// WHY ?
      /// PURE: *Predictability: output depends only on input.
      ///       *Reusability: can be used in any context.
      ///       *Thread Safety
      ///       *Funcational Programming
      ///       
      /// IMPURE: *Real-world Interaction: neccessry for practical applications
      ///         *Flexibility: allow interaction with external system
      /// 

      //Pure Function
      int Square(int x) => x * x;

      var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

      var squareNumbers = numbers.Select(Square);

      Console.WriteLine("Numbers       : " + string.Join(", ",numbers));
      Console.WriteLine("Square Numbers: " + string.Join(", ", squareNumbers));

   }


   static int counter = 0;
   public static void Ex02()
   {
      var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7,8,9 };

      //impure function
      bool IsEven(int x)
      {
         counter++;

         Console.WriteLine($"Checking {x}, counter: {counter}");

         return x % 2 == 0;
      }

      var evenNumbers = numbers.Where(IsEven).ToList();

      Console.WriteLine($"Numbers     : {string.Join(", ", numbers)}");
      Console.WriteLine($"Even Numbers: {string.Join(", ", evenNumbers)}");

   }


   static void Print(List<int> source)
   {
      foreach(var i in source)
      {
         Console.Write($" {i}");
      }
      Console.WriteLine();
   }
   static void AddInteger01(int num)
   {
      numbers.Add(num); //impure mutate global variable
   }
   static List<int> numbers = [ 1, 2, 3, 4, 5, 6, 7, 8, 9 ];
   public static void Ex03()
   {

      Print(numbers);

      AddInteger01(3);

      Print(numbers);

   }


   static void AddInteger02(ref int num)
   {
      num++; // impure mutate parameter
      numbers.Add(num);
   }
   public static void Ex04()
   {

      Print(numbers);

      int x = 2;
      AddInteger02(ref x);

      Print(numbers);

   }


   static void AddInteger03()
   {
      //impure iteration with outside world
      numbers.Add(new Random().Next());
   }
   public static void Ex05()
   {
      Print(numbers);

      AddInteger03();

      Print(numbers);

   }


   static List<int> AddInteger04(List<int> numbers, int num)
   {
      var result = new List<int>(numbers);

      result.Add(num);

      return result;
   }
   public static void Ex06()
   {

      var newList = AddInteger04(numbers, 3);

      Console.WriteLine("Old List");
      Print(numbers);

      Console.WriteLine("New List");
      Print(newList);

   }

}

