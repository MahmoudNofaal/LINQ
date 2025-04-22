using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._2_FunctionalProgramming;

public class _Main
{

   public static void Ex01()
   {
      /// HERE WE USED THE NORMAL FUNCTIONS TO MAKE SOME SPECIFIC OPERATIONS
      /// EACH FUNCTION DO SOME SPECIFIC OPERATION!!

      // FUNC01
      var q1 = ExtnensionProcedural.GetEmployeesWithFirstNameStartsWith("ma");
      ExtnensionProcedural.Print(q1, "Employees with first name starts with 'ma'");

      // FUNC02
      var q2 = ExtnensionProcedural.GetEmployeesWithLastNameStartsWith("ju");
      ExtnensionProcedural.Print(q2, "Employees with last name starts with 'ju'");

      // FUNC03
      var q3 = ExtnensionProcedural.GetEmployeesWithDepartmentEqualsTo("hr");
      ExtnensionProcedural.Print(q3, "Employees in 'HR' department");

      // FUNC04
      var q4 = ExtnensionProcedural.GetEmployeesByGender("female");
      ExtnensionProcedural.Print(q4, "Female employees");

      // FUNC05
      var q5 = ExtnensionProcedural.GetEmployeesHiredInYear(2018);
      ExtnensionProcedural.Print(q5, "Employees hired in '2018'");

      // FUNC06
      var q6 = ExtnensionProcedural.GetEmployeesWithPensionPlanValueEqualsTo(true);
      ExtnensionProcedural.Print(q6, "Employees with Pension Plan");

      // FUNC07
      var q7 = ExtnensionProcedural.GetEmployeesWithHealthInsuranceValueEqualsTo(false);
      ExtnensionProcedural.Print(q7, "Employees without Health insurance");

      // FUNC08
      var q8 = ExtnensionProcedural.GetEmployeesWithSalaryEqualsTo(103200);
      ExtnensionProcedural.Print(q8, "Employees with Salary = $103200");

      // FUNC09
      var q9 = ExtnensionProcedural.GetEmployeesWithSalaryGreaterThan(107000);
      ExtnensionProcedural.Print(q9, "Employees with Salary > $107000");

      // FUNC10
      var q10 = ExtnensionProcedural.GetEmployeesWithSalaryLessThan(107000);
      ExtnensionProcedural.Print(q10, "Employees with Salary < $107000");
   }

   public static void Ex02()
   {
      ///HERE IN EXAMPLE 02 WE USE THE DELEGATE TO MAKE THE OPERATIONS
      ///INSTEAD OF MAKING FUNCTION FOR EACH OPERATION!!

      var list = Repository.LoadEmployees();

      //Func<Employee, bool> predicate = e => e.FirstName.ToLowerInvariant() == "ma";
      //var q0 = ExtensionFunctional01.Filter(list, predicate);
      //ExtnensionProcedural.Print(q0, "Employees with first name starts with 'ma'");

      // use just one function as delegate and customize the operation as you want
      var q1 = ExtensionFunctional01.Filter(list, e => e.FirstName.ToLowerInvariant() == "ma");
      ExtnensionProcedural.Print(q1, "Employees with first name starts with 'ma'");

      /// use just one function as delegate and customize the operation as you want
      var q2 = ExtensionFunctional01.Filter(list, e => e.LastName.ToLowerInvariant() == "ju");
      ExtnensionProcedural.Print(q2, "Employees with last name starts with 'ju'");

      /// use just one function as delegate and customize the operation as you want
      var q3 = ExtensionFunctional01.Filter(list, e => e.Department.ToLowerInvariant() == "hr");
      ExtnensionProcedural.Print(q3, "Employees in 'HR' department");

      /// use just one function as delegate and customize the operation as you want
      var q4 = ExtensionFunctional01.Filter(list, e => e.Gender.ToLowerInvariant() == "female");
      ExtnensionProcedural.Print(q4, "Female employees");

      /// use just one function as delegate and customize the operation as you want
      var q5 = ExtensionFunctional01.Filter(list, e => e.HireDate.Year == 2018);
      ExtnensionProcedural.Print(q5, "Employees hired in '2018'");

      /// use just one function as delegate and customize the operation as you want
      var q6 = ExtensionFunctional01.Filter(list, e => e.HasPensionPlan);
      ExtnensionProcedural.Print(q6, "Employees with Pension Plan");

      /// use just one function as delegate and customize the operation as you want
      var q7 = ExtensionFunctional01.Filter(list, e => !e.HasHealthInsurance);
      ExtnensionProcedural.Print(q7, "Employees without Health insurance");

      /// use just one function as delegate and customize the operation as you want
      var q8 = ExtensionFunctional01.Filter(list, e => e.Salary == 107000);
      ExtnensionProcedural.Print(q8, "Employees with Salary = $107000");

      /// use just one function as delegate and customize the operation as you want
      var q9 = ExtensionFunctional01.Filter(list, e => e.Salary > 107000);
      ExtnensionProcedural.Print(q9, "Employees with Salary > $107000");

      /// use just one function as delegate and customize the operation as you want
      var q10 = ExtensionFunctional01.Filter(list, e => e.Salary < 107000);
      ExtnensionProcedural.Print(q10, "Employees with Salary < $107000");

      /// use just one function as delegate and customize the operation as you want
      var q11 = ExtensionFunctional01.Filter(list, e => e.Salary < 107000 && e.Gender == "female");
      ExtnensionProcedural.Print(q11, "Employees with Salary < $107000 and female");
   }

   public static void Ex03()
   {
      var list = Repository.LoadEmployees();

      /// here use extention method to extend Filert() method to customize the operation.
      var q1 = list.Filter(e => e.FirstName.ToLowerInvariant() == "ma");
      q1.Print("Employees with first name starts with 'ma'");

      /// here use extention method to extend Filert() method to customize the operation.
      var q2 = list.Filter(e => e.LastName.ToLowerInvariant() == "ju");
      q2.Print("Employees with last name starts with 'ju'");

      /// here use extention method to extend Filert() method to customize the operation.
      var q3 = list.Filter(e => e.Department.ToLowerInvariant() == "hr");
      q3.Print("Employees in 'HR' department");

      /// here use extention method to extend Filert() method to customize the operation.
      var q4 = list.Filter(e => e.Gender.ToLowerInvariant() == "female");
      q4.Print("Female employees");

      /// here use extention method to extend Filert() method to customize the operation.
      var q5 = list.Filter(e => e.HireDate.Year == 2018);
      q5.Print("Employees hired in '2018'");

      /// here use extention method to extend Filert() method to customize the operation.
      var q6 = list.Filter(e => e.HasPensionPlan);
      q6.Print("Employees with Pension Plan");

      /// here use extention method to extend Filert() method to customize the operation.
      var q7 = list.Filter(e => !e.HasHealthInsurance);
      q7.Print("Employees without Health insurance");

      /// here use extention method to extend Filert() method to customize the operation.
      var q8 = list.Filter(e => e.Salary == 107000);
      q8.Print("Employees with Salary = $107000");

      /// here use extention method to extend Filert() method to customize the operation.
      var q9 = list.Filter(e => e.Salary > 107000);
      q9.Print("Employees with Salary > $107000");

      /// here use extention method to extend Filert() method to customize the operation.
      var q10 = list.Filter(e => e.Salary < 107000);
      q10.Print("Employees with Salary < $107000");

      /// here use extention method to extend Filert() method to customize the operation.
      var q11 = list.Filter(e => e.Salary < 107000 && e.Gender == "female");
      q11.Print("Employees with Salary < $107000 and female");

   }

}

