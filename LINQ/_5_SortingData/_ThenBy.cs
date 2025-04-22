using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._5_SortingData;

public class _ThenBy
{
   public static void Ex01()
   {
      var employees = Repository.LoadEmployees();

      var sortedEmp01 = employees.OrderBy(x => x.Name)
                                 .ThenBy(x => x.Salary);

      sortedEmp01.Print("Sorted Employees By NAme First Then By Salary");

   }

   public static void Ex02()
   {
      var employees = new List<Employee2>
      {
          new Employee2 { Name = "Alice", Department = "HR", Salary = 60000 },
          new Employee2 { Name = "Bob", Department = "IT", Salary = 80000 },
          new Employee2 { Name = "Charlie", Department = "HR", Salary = 70000 },
          new Employee2 { Name = "David", Department = "IT", Salary = 65000 }
      };

      // OrderBy with ThenBy
      var sortedEmployees = employees.OrderBy(e => e.Department)
                                     .ThenByDescending(e => e.Salary);

      // Query Syntax
      var sortedEmployeesQuery = from e in employees
                                 orderby e.Department ascending, e.Salary descending
                                 select e;

      Console.WriteLine("Employees Sorted by Department and Salary (Method Syntax):");
      foreach (var emp in sortedEmployees)
      {
         Console.WriteLine($"{emp.Name}: {emp.Department}, {emp.Salary:C}");
      }

      Console.WriteLine("\nEmployees Sorted by Department and Salary (Query Syntax):");
      foreach (var emp in sortedEmployeesQuery)
      {
         Console.WriteLine($"{emp.Name}: {emp.Department}, {emp.Salary:C}");
      }


   }

}

class Employee2
{
   public string Name { get; set; }
   public string Department { get; set; }
   public int Salary { get; set; }
}

