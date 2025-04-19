namespace LINQ._6_DataPartitioning;

public class _Chunck
{

   public static void Ex01()
   {
      var employees = Repository.LoadEmployees();

      var chunks = employees.Chunk(10).ToList();// divide all employees to groups of 10


      for(int i= 0; i<chunks.Count; i++)
      {
         chunks[i].Print($"Chunck: #{i + 1}");
      }


   }

}

