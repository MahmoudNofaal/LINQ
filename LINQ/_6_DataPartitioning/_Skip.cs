using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._6_DataPartitioning;

public class _Skip
{
   public static void Ex01()
   {
      var employees = Repository.LoadEmployees();

      var q1 = employees.Skip(20);

      q1.Print("Skip First 20 Employees...");

   }

   public static void Ex02()
   {
      var employees = Repository.LoadEmployees();

      var q1 = employees.SkipWhile(x => x.Salary != 214400);

      q1.Print("Still skip employees until found an employee his salary == 21440");


   }

   public static void Ex03()
   {
      var employees = Repository.LoadEmployees();

      var q1 = employees.SkipLast(10);

      q1.Print("Skip last 10 employees");

   }

}


