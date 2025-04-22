using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._6_DataPartitioning;

public class _Pagination
{
   public static void Ex01()
   {
      var page = 1;
      var size = 10;

      Console.WriteLine("Result per page:");
      if (int.TryParse(Console.ReadLine(), out int resultPerPage))
      {
         size = resultPerPage;
      }

      Console.WriteLine("Page No:");
      if (int.TryParse(Console.ReadLine(), out int pageNo))
      {
         page = pageNo;
      }


      var employees = Repository.LoadEmployees();

      var pagination = employees.Paginate(page, size);

      pagination.Print("Pagination");

   }

}
