namespace LINQ._15_SetOperations;

public static class Extensions
{

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
