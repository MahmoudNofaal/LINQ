using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._2_FunctionalProgramming;

public class Employee
{
   public Employee()
   {
      
   }

   public int Id { get; set; }
   public string FirstName { get; set; }
   public string LastName { get; set; }
   public DateTime HireDate { get; set; }
   public string Gender { get; set; }
   public string Department { get; set; }
   public bool HasHealthInsurance { get; set; }
   public bool HasPensionPlan { get; set; }
   public decimal Salary { get; set; }

   public override string ToString()
   {
      return $"Id: {Id}\n" +
             $"First Name: {FirstName}\n" + 
             $"Last Name: {LastName} \n" +
             $"Hire Date: {HireDate} \n" +
             $"Gender: {Gender} \n" +
             $"Department: {Department} \n" +
             $"Has Health Insurance: {HasHealthInsurance} \n" +
             $"Has Pension Plan: {HasPensionPlan}  \n" +
             $"Salary: {Salary}  \n" +
             $"--------------------\n";
   }

}
