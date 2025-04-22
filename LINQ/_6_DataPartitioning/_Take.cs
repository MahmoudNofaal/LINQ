namespace LINQ._6_DataPartitioning;

public class _Take
{
   //chunk, pagination, skip, take
   public static void Ex01()
   {

      var employees = Repository.LoadEmployees();

      var q1 = employees.Take(20);

      q1.Print("Take First 20 Employees...");

   }

   public static void Ex02()
   {
      var employees = Repository.LoadEmployees();

      var q1 = employees.TakeWhile(x => x.Salary != 214400);

      q1.Print("Still Take employees until found an employee his salary == 21440");

   }

   public static void Ex03()
   {
      var employees = Repository.LoadEmployees();

      var q1 = employees.TakeLast(10);

      q1.Print("Take last 10 employees");

   }

   ///
   

   ///


   ///



}

