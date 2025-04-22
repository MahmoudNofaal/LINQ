using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._6_DataPartitioning;

public class _Chunk
{
   /// [CHUNCK]
   ///* It breaks a big list into smaller groups
   ///  If you have 100 items, Chunk can spilt them into groups of 10

   public static void Ex01()
   {
      var employees = Repository.LoadEmployees();

      var chunks = employees.Chunk(10).ToList();// divide all employees to groups of 10


      for (int i = 0; i < chunks.Count; i++)
      {
         chunks[i].Print($"Chunck: #{i + 1}");
      }

   }

}

