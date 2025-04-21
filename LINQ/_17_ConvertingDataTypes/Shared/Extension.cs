namespace LINQ._17_ConvertingDataTypes.Shared;

public static class Extension
{
   public static void Process<T>(this IEnumerable<T> source, string title) where T : Shipping
   {
      Console.WriteLine("┌───────────────────────────────────────────────────────┐");
      Console.WriteLine($"│   {title.PadRight(52, ' ')}│");
      Console.WriteLine("└───────────────────────────────────────────────────────┘");
      foreach (var item in source)
      {
          item.Start();
      }
   }
}

