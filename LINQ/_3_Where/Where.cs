using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Transactions;

namespace LINQ._3_Where;

public class Where
{

   public static void Ex01()
   {
      /// LINQ (Language Integrated Query)
      /// * It is a set of technologies in C# that enables querying data from
      ///   various sources (in memory collection, database, XML).
      ///   
      /// 1. [ Query Expressions (Query Syntax and Method Syntax) ]:
      ///    The syntaxes for writing LINQ queries, either SQL-like (Query Syntax)
      ///    or method-based (Method Syntax).
      ///    
      /// 2. [ Standard Query Operators ]:
      ///    A set of extension methods (Select, Where, GroupBy) that perform operations
      ///    like filtering, projection, and aggregation.
      ///    
      /// 3. [ Lambda Expressions and Delegates ]:
      ///    The functional building blocks for defining query logic inline.
      ///    
      /// 4. [ IEnumerable <T> and IQueryable<T> ]:
      ///    The interfaces that enable LINQ to work with in-memory collections (LINQ to Objects)
      ///    and external data sources(e.g., databases).
      ///    
      /// 5. [ Deferred Execution ]:
      ///    The mechanism that delays query execution until results are needed,
      ///    optimizing performance.
      ///    
      /// 6. [ Expression Trees ]:
      ///    A data structure for representing query logic, enabling translation
      ///    to other domains(SQL queries in LINQ to SQL).
      ///    
      /// 7. [ Functional Programming Principles ]:
      ///    LINQ’s reliance on pure functions, immutability, and declarative style,
      ///    rooted in functional programming.
      ///    

      var employees = Repository.LoadEmployees();

      var femaleEmployeesWithFirstNameStartsWithS = employees
         .Filter(e => e.Gender == "female" &&
                      e.FirstName.ToLowerInvariant().StartsWith("s"));

      femaleEmployeesWithFirstNameStartsWithS
         .Print("female Employees With First Name Starts With S / filter");

      var femaleEmployeesWithFirstNameStartsWithS02 = employees
         .Where(e => e.Gender == "female" && e.FirstName.ToLowerInvariant().StartsWith("s"));

      femaleEmployeesWithFirstNameStartsWithS
         .Print("female Employees With First Name Starts With S / where");

   }

   public static void Ex02()
   {
      var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

      var evenNumbers01 = numbers.Where(x => x % 2 == 0);

      var evenNumbers02 = numbers.Where(x => x % 2 == 0);

      var evenNumbers03 = from x in numbers
                          where x % 2 == 0
                          select x;

      evenNumbers01.Print($"Even Numbers using [where]");
      evenNumbers02.Print($"Even Numbers using [EnumerableWhereMethod]");
      evenNumbers03.Print($"Even Numbers using [select query]");

   }

   public static void Ex03()
   {
      var orders = new List<Order>
      {
         new Order { Id = 1, Amount = 100 },
         new Order { Id = 2, Amount = 250 },
         new Order { Id = 3, Amount = 50 },
         new Order { Id = 4, Amount = 300 }
      };

      // .Where with index
      var everySecondOrder = orders.Where((order, index) => index % 2 == 1);

      Console.WriteLine("Every Second Order:");
      foreach (var order in everySecondOrder)
      {
         Console.WriteLine($"Order {order.Id}: {order.Amount:C}");
      }
   }

}

