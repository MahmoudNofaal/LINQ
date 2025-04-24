namespace Questions._Questions.Shared;

public static class ExtensionFunctional
{

   public static IEnumerable<Employee> Filter
       (this IEnumerable<Employee> source, Func<Employee, bool> predicate)
   {

      foreach (var employee in source)
      {
         if (predicate(employee))
         {
            yield return employee;
         }
      }
   }

   public static void Print<T>(this IEnumerable<T> source, string title)
   {
      var defaultColor = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      Console.WriteLine($"\n{title}\n");
      Console.ForegroundColor = defaultColor;

      foreach (var item in source)
         Console.WriteLine($"{item}");
   }

}

