namespace LINQ._6_DataPartitioning;

public static class Extentions
{

   public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, int page=1,
                                            int size=1) where T : class
   {

      if (page <= 1)
      {
         page = 1;
      }

      if (size <= 0)
      {
         size = 1;
      }

      var total = source.Count();

      // 51/10 => 5.1#### (after ceiling) => 6 pages
      var pages = (int) Math.Ceiling((decimal) total / size);

      var result = source.Skip((page - 1) * size).Take(size);

      return result;
   }
}

