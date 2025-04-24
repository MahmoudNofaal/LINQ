using Questions._Questions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions._Questions;

public class _Main
{
   public  static IEnumerable<Employee> _employees = Repository.LoadEmployees();
   public  static IEnumerable<Department> _departments = Repository.LoadDepartments();

   public static void Ex01()
   {
      /// get employees with their department names
      /// 
      var q01 = from e in _employees
                join d in _departments
                on e.DepartmentId equals d.Id
                select new
                {
                   e.FullName,
                   d.Name
                };

      q01.Print("get employees with their department names");
   }

   public static void Ex02()
   {
      ///get employees with their salary that is bigger than the average salaries
      ///of all employees of the same department
      ///
      var q02 = from e in _employees
                let departmentAvgSalary = _employees.Where(x => x.DepartmentId == e.DepartmentId)
                                                    .Average(x => x.Salary)
                where e.Salary > departmentAvgSalary
                select new
                {
                   e.FullName,
                   DepartmentAverageSalary = departmentAvgSalary
                };

      q02.Print("get employees with their salary that is bigger than the average salaries" +
                " of all employees of the same department");
   }

   public static void Ex03()
   {
      /// get employees with years of service (to @2025) year of now
      /// 
      var q03 = _employees.Select(e => new
      {
         e.FullName,
         YearOfService = DateTime.Now.Year - e.HireDate.Year
      });

      q03.Print($"get employees with years of service (to @{DateTime.Now.Year})");
   }
   public static void Ex04()
   {
      /// get employees with their benefits status (Health, Pension, Both, NONE.)
      var q04 = _employees.Select(x => new
      {
         x.FullName,
         Benfits = x.HasHealthInsurance && x.HasPensionPlan ? "Both" :
                   x.HasHealthInsurance ? "HAs Health Only" :
                   x.HasPensionPlan ? "Has Pension Only" : "NONE"
      });

      q04.Print("get employees with their benefits status (Health, Pension, Both, NONE.)");

   }
   public static void Ex05()
   {
      ///get count of employees in each department
      ///
      var q05 = from d in _departments
                let deptCount = _employees.Count(x => x.DepartmentId == d.Id)
                select new
                {
                   d.Name,
                   DepartmentCount = deptCount
                };

      q05.Print("get count of employees in each department");
   }
   public static void Ex06()
   {
      ///get employees with their names and department and hiredate year
      var q06 = from e in _employees
                join d in _departments
                on e.DepartmentId equals d.Id
                select new
                {
                   e.FullName,
                   Department = d.Name,
                   HireYear = e.HireDate.Year
                };

      q06.Print("get employees with their names and department and hiredate year");
   }
   public static void Ex07()
   {
      /// salary company total is 100%percent, get employees with its percent salary in the company
      /// 

      var totalSalary = _employees.Sum(e => e.Salary);
      var q07 = _employees.Select(x => new
      {
         x.FullName,
         SalaryPercent = x.Salary / totalSalary * 100
      });

      q07.Print("salary company total is 100%percent," +
                " get employees with its percent salary in the company");

   }
   public static void Ex08()
   {
      /// get employees whos salary is the highest salary in their department
      /// 
      var q08 = from e in _employees
                join d in _departments
                on e.DepartmentId equals d.Id
                let highesSalary = _employees.Where(x => x.DepartmentId == e.DepartmentId)
                                             .Max(s => s.Salary)
                select new
                {
                   e.FullName,
                   d.Name,
                   DepartmentHighestSalary = highesSalary,
                };

      q08.Print("get employees who's salary is the highest salary in their department");
   }
   public static void Ex09()
   {
      ///get departments that has no employees
      var q09 = _departments.Where(x => !_employees.Any(e => e.DepartmentId == x.Id));

      q09.Print("get departments that has no employees");
   }
   public static void Ex10()
   {
      /// get unique first names of employees
      /// 
      var q10 = _employees.Select(e => e.FirstName)
                          .Distinct();

      q10.Print("get unique first names of employees");
   }
   public static void Ex11()
   {
      /// get departments with employees hired in 2020
      var q11 = _departments.Where(d => _employees.Any(e => e.DepartmentId == d.Id &&
                                                            e.HireDate.Year == 2020));

      Console.WriteLine("get departments with employees hired in 2020");
      foreach (var d in q11)
      {
         Console.WriteLine(d.Name);
      }

   }
   public static void Ex12()
   {
      /// get employees who are in IT department and have HealthInsurance
      /// 
      var q12 = _employees.Where(x => x.DepartmentId == 2 && x.HasHealthInsurance);

      Console.WriteLine("get employees who are in IT department and have HealthInsurance");
      foreach (var d in q12)
      {
         Console.WriteLine($"Name: {d.FullName}");
      }
   }

   public static void Ex13()
   {
      /// get employees in all departments but not in Finance
      /// 
      var q13 = _employees.Except(_employees.Where(e => e.DepartmentId == 1));

      Console.WriteLine("get employees in all departments but not in Finance");
      foreach (var d in q13)
      {
         Console.WriteLine($"Name: {d.FullName}");
      }
   }
   public static void Ex14()
   {
      /// get employees sorted by salary descending
      /// 
      var q14 = _employees.OrderByDescending(x => x.Salary);

      Console.WriteLine("get employees sorted by salary descending");
      foreach (var d in q14)
      {
         Console.WriteLine($"Name: {d.FullName}");
      }
   }
   public static void Ex15()
   {
      /// get employees sorted by department name and then hiredate
      /// 
      var q15 = from e in _employees
                join d in _departments
                on e.DepartmentId equals d.Id
                orderby d.Name, e.HireDate
                select new
                {
                   e.FullName,
                   d.Name,
                   e.HireDate,
                };

      q15.Print("get employees sorted by department name and then hiredate");
   }
   public static void Ex16()
   {
      /// get departments sorted by employees count
      /// 
      var q16 = _departments.OrderByDescending(x => _employees.Count(e => e.DepartmentId == x.Id))
                            .Select(d => new
                            {
                               d.Name,
                               EmployeesCount = _employees.Count(e => e.DepartmentId == d.Id)
                            });

      q16.Print("get departments sorted by employees count");

   }
   public static void Ex17()
   {
      /// get departments sorted by avg salaries of employees
      /// 
      var q17 = _departments.OrderByDescending(x => _employees.Where(e => e.DepartmentId == x.Id)
                                                              .Average(e => e.Salary))
                            .Select(x => new
                            {
                               x.Name,
                               AvgSalary = _employees.Where(e => e.DepartmentId == x.Id)
                                                     .Average(e => e.Salary)
                            });

      q17.Print("get departments sorted by avg salaries of employees");

   }
   public static void Ex18()
   {
      /// get employees sorted by hiredate year descending
      /// 
      var q18 = _employees.OrderByDescending(x=>x.HireDate.Year);

      Console.WriteLine("get employees sorted by hiredate year descending");
      foreach (var d in q18)
      {
         Console.WriteLine($"Name: {d.FullName}");
      }
   }
   public static void Ex19()
   {
      /// get departments sorted by number of female employees
      /// 
      var q19 = _departments.OrderByDescending(x=> _employees.Count(e=>e.Gender == "female"))
                            .Select(x => new
                            {
                               x.Name,
                               NoOfFemaleEmps = _employees.Count(e => e.Gender == "female")
                            });

      q19.Print("get departments sorted by number of female employees");
   }
   public static void Ex20()
   {
      /// get departments sorted by number of hires in 2020
      /// 
      var q20 = _departments.OrderByDescending(x => _employees.Count(e => e.DepartmentId == x.Id &&
                                                                          e.HireDate.Year == 2020))
                            .Select(x=>new
                            {
                               x.Name,
                               NumberOfHires = _employees.Count(e => e.DepartmentId == x.Id &&
                                                                     e.HireDate.Year == 2020)
                            });

      q20.Print("get departments sorted by number of hires in 2020");
   }
   public static void Ex21()
   {
      /// get the employees whos salaries is more or less than the average salary of the company
      /// 
      var q21 = _employees.OrderByDescending(x => Math.Abs(x.Salary - _employees.Average(e => e.Salary)))
                          .Select(x => new
                          {
                             x.FullName,
                             x.Salary,
                             SalaryDifference = Math.Abs(x.Salary - _employees.Average(e=>e.Salary)),
                             MoreOrLessThanAvg = x.Salary > _employees.Average(e => e.Salary) ? "More" : "Less or equal"
                          });

      q21.Print("get the employees whos salaries is more or less than the average salary of the company");
   }
   public static void Ex22()
   {
      /// get the first 10 employees sorted by salary
      /// 
      var q22 = _employees.OrderByDescending(x=>x.Salary).Take(10);

      Console.WriteLine("get the first 10 employees sorted by salary");
      foreach (var d in q22)
      {
         Console.WriteLine($"Name: {d.FullName}");
      }
   }
   public static void Ex23()
   {
      /// get the second page of employees (10 per page) sorted by hiredate year
      /// 
      var q23 = _employees.OrderBy(x => x.HireDate.Year).Skip(10).Take(10);

      Console.WriteLine("get the second page of employees (10 per page) sorted by hiredate year");
      foreach (var d in q23)
      {
         Console.WriteLine($"Name: {d.FullName}");
      }
   }
   public static void Ex24()
   {
      /// get employees in groups of 5 with health insurance
      /// 
      var q24 = _employees.Where(e => e.HasHealthInsurance)
                          .Chunk(5)
                          .SelectMany(c => c);

      Console.WriteLine("get employees in groups of 5 with health insurance");
      foreach(var q in q24)
      {
         Console.WriteLine(q.FullName);
      }
   }
   public static void Ex25()
   {
      /// get the last 5 hired employees
      /// 
      var q25 = _employees.OrderByDescending(x=>x.HireDate).Take(5);

      Console.WriteLine("get the last 5 hired employees");
      foreach (var q in q25)
      {
         Console.WriteLine($"{q.FullName}, {q.HireDate}");
      }
   }
   public static void Ex26()
   {
      /// get the first 3 employees hired in each system
      /// 
      var q26 = from d in _departments
                let First3Hires = _employees.Where(x => x.DepartmentId == d.Id)
                                            .OrderBy(x => x.HireDate)
                                            .Take(3)
                from e in First3Hires
                select new
                {
                   e.FullName, 
                   d.Name,
                   e.HireDate
                };

      q26.Print("get the first 3 employees hired in each system");
   }
   public static void Ex27()
   {
      /// get employees in chunks of 10 sorted by department Id
      var q27 = _employees.OrderBy(e => e.DepartmentId)
                          .Chunk(10)
                          .SelectMany(chunk => chunk);


      Console.WriteLine("get employees in chunks of 10 sorted by department Id");
      foreach (var q in q27)
      {
         Console.WriteLine($"{q.FullName}, {q.DepartmentId}");
      }
   }
   public static void Ex28()
   {
      /// checks if all employees have HealthInsurance
      /// 
      var q28 = _employees.All(x=>x.HasHealthInsurance);

      Console.WriteLine("checks if all employees have HealthInsurance");
      Console.WriteLine(q28 ? "YES" : "NO");
   }
   public static void Ex29()
   {
      /// find employees with salaries above 200k
      var q29 = _employees.Where(e => e.Salary > 200_000);

      Console.WriteLine("find employees with salaries above 200k");
      foreach (var q in q29)
      {
         Console.WriteLine($"{q.FullName}, {q.Salary:C}");
      }
   }
   public static void Ex30()
   {
      /// check if any department has no female employees
      var q30 = _departments.Any(d => _employees.Where(e => e.DepartmentId == d.Id)
                                                .All(e => e.Gender == "male"));

      Console.WriteLine("check if any department has no female employees");
      Console.WriteLine(q30 ? "YES" : "NO");

   }
   public static void Ex31()
   {
      /// check if any employee has a salary below 100k
      var q31 = _employees.Any(e => e.Salary < 100000);

      Console.WriteLine("check if any employee has a salary below 100k");
      Console.WriteLine(q31 ? "YES" : "NO");
   }
   public static void Ex32()
   {
      /// find employees whose first name starts with 'A'
      var q32 = _employees.Where(e => e.FirstName.StartsWith("A", StringComparison.OrdinalIgnoreCase));

      Console.WriteLine("find employees whose first name starts with 'A'");
      foreach (var q in q32)
      {
         Console.WriteLine($"{q.FullName}");
      }
   }
   public static void Ex33()
   {
      /// check if all IT employees have pensions
      var q33 = _employees.Where(e => e.DepartmentId == 2)
                          .All(e => e.HasPensionPlan);

      Console.WriteLine("check if all IT employees have pensions");
      Console.WriteLine(q33 ? "YES" : "NO");
   }
   public static void Ex34()
   {
      /// find departments where all employees earn above 150k
      /// 
      var q34 = _departments.Where(x => _employees.Where(e => e.DepartmentId == x.Id)
                                                  .All(e => e.Salary > 150_000))
                            .Select(x => new
                            {
                               x.Name,
                            });

      q34.Print("find departments where all employees earn above 150k");
   }
   public static void Ex35()
   {
      /// check if any employee was hired in january 1st [01/01] from any year
      /// 
      var q35 = _employees.Any(x=>x.HireDate.Month == 1 && x.HireDate.Day == 1);

      Console.WriteLine("check if any employee was hired in january 1st [01/01] from any year");
      Console.WriteLine(q35 ? "YES" : "NO");
   }
   public static void Ex36()
   {
      /// get the average salary per department
      /// 
      var q36 = from e in _employees
                join d in _departments
                on e.DepartmentId equals d.Id
                group e by d.Name into g
                select new
                {
                   Department = g.Key,
                   AverageSalary = g.Average(x=>x.Salary)
                };

      q36.Print("get the average salary per department");
   }
   public static void Ex37()
   {
      /// get departments with the highest paid employees
      /// 
      var q37 = from d in _departments
                let highestPaid = _employees.Where(e => e.DepartmentId == d.Id)
                                            .OrderByDescending(e => e.Salary)
                                            .FirstOrDefault()
                select new
                {
                   Department = d.Name,
                   HighestPaid = highestPaid?.FullName,
                   highestPaid?.Salary
                };

      q37.Print("get departments with the highest paid employees");
   }
   public static void Ex38()
   {
      /// get employees grouped by hire year
      /// 
      var q38 = _employees.OrderBy(e => e.HireDate.Year)
                          .GroupBy(e => e.HireDate.Year)
                          .Select(x=>new
                          {
                             HireDateYear = x.Key,
                             Count = x.Count()
                          });

      q38.Print("get employees grouped by hire year");
   }
   public static void Ex39()
   {
      /// get departments with employee count by salary range (<150k or 150-300k or >300k)
      /// 
      var q39 = _departments.Select(x => new
      {
         x.Name,
         LowSalary = _employees.Count(e => e.DepartmentId == x.Id && e.Salary < 150_000),
         MidSalary = _employees.Count(e => e.DepartmentId == x.Id && e.Salary >= 150_000 && e.Salary <= 300_000),
         HighSalary = _employees.Count(e => e.DepartmentId == x.Id && e.Salary > 300_000),
      });

      q39.Print("get departments with employee count by salary range (<150k or 150-300k or >300k)");
   }
   public static void Ex40()
   {
      /// get employees grouped by first letter of first name
      /// 
      var q40 = _employees.GroupBy(e => e.FirstName[0])
                          .Select(x => new
                          {
                             FirstLetter = x.Key,
                             Count = x.Count()
                          });

      q40.Print("get employees grouped by first letter of first name");
   }
   public static void Ex41()
   {
      /// generate a list of years (2014-2021) with employee hire date
      /// 
      var q41 = Enumerable.Range(2014, 8)
                          .Select(x => new
                          {
                             Year = x,
                             HireCount = _employees.Count(e => e.HireDate.Year==x)
                          });

      q41.Print("generate a list of years (2014-2021) with employee hire date");
   }
   public static void Ex42()
   {
      /// generate an empty list of employees if no one earn above 350k
      /// 
      var q42 = _employees.Any(x=>x.Salary>350_000) ? _employees.Where(x=>x.Salary > 350_000)
                                                    : Enumerable.Empty<Employee>();

      Console.WriteLine("generate an empty list of employees if no one earn above 350k");
      foreach (var q in q42)
      {
         Console.WriteLine($"{q.FullName}");
      }
   }
   public static void Ex43()
   {
      /// generate a list of salary [100k, 200k, 300k] with employees count
      /// 
      var q43 = new[] { 100_000, 200_000, 300_000 }
                .Select(x => new
                {
                   Threshold = x,
                   Count = _employees.Count(e => e.Salary > x)
                });

      q43.Print("generate a list of salary [100k, 200k, 300k] with employees count");
   }
   public static void Ex44()
   {
      /// generate a list of gender with employee counts
      var q44 = _employees.GroupBy(e => e.Gender)
                          .Select(g => new
                          {
                             g.Key,
                             Count = g.Count()
                          });

      q44.Print("generate a list of gender with employee counts");
   }
   public static void Ex45()
   {
      /// generate a list of departments with no female employees
      var q45 = _departments.Where(d => !_employees.Any(e => e.DepartmentId == d.Id &&
                                                             e.Gender == "female"));

      q45.Print("generate a list of departments with no female employees");
   }
   public static void Ex46()
   {
      /// get the highest-paid employee
      var q46 = _employees.OrderByDescending(e => e.Salary).First();

      Console.WriteLine("get the highest-paid employee");
      Console.WriteLine($"Name: {q46.FullName}, Salary: {q46.Salary}");
   }
   public static void Ex47()
   {
      /// get the first employee hired
      var q47 = _employees.OrderBy(e => e.HireDate).First();

      Console.WriteLine("get the first employee hired");
      Console.WriteLine($"Name: {q47.FullName}, Salary: {q47.Salary}");
   }
   public static void Ex48()
   {
      /// get the last employee hired in IT
      var q48 = _employees.Where(e => e.DepartmentId == 2)
                          .OrderByDescending(e => e.HireDate)
                          .FirstOrDefault();

      Console.WriteLine("get the last employee hired in IT");
      Console.WriteLine($"Name: {q48?.FullName}, Salary: {q48?.Salary}");
   }
   public static void Ex49()
   {
      /// get the employee with the lowest salary
      var q49 = _employees.OrderBy(e => e.Salary).First();

      Console.WriteLine("get the employee with the lowest salary");
      Console.WriteLine($"Name: {q49?.FullName}, Salary: {q49?.Salary}");
   }
   public static void Ex50()
   {
      /// get the highest-paid female employee
      var q50 = _employees.Where(e => e.Gender == "female")
                          .OrderByDescending(e => e.Salary)
                          .FirstOrDefault();

      Console.WriteLine("get the highest-paid female employee");
      Console.WriteLine($"Name: {q50?.FullName}, Salary: {q50?.Salary}");
   }
   public static void Ex51()
   {
      /// get the employee with the longest first name
      var q51 = _employees.OrderByDescending(e => e.FirstName.Length).First();

      Console.WriteLine("get the employee with the longest first name");
      Console.WriteLine($"Name: {q51.FullName}, Salary: {q51.Salary}");
   }
   public static void Ex52()
   {
      /// get the first employee hired in each department
      var q52 = from d in _departments
                let firstHire = _employees.Where(e => e.DepartmentId == d.Id)
                                          .OrderBy(e => e.HireDate)
                                          .FirstOrDefault()
                where firstHire != null
                select new
                {
                   firstHire.FullName,
                   Department = d.Name,
                   firstHire.HireDate
                };

      q52.Print("get the first employee hired in each department");
   }
   public static void Ex53()
   {
      /// combine employees hired in 2019 and 2020
      var q53 = _employees.Where(e => e.HireDate.Year == 2019)
                          .Union(_employees.Where(e => e.HireDate.Year == 2020));

      Console.WriteLine("combine employees hired in 2019 and 2020");
      foreach (var q in q53)
      {
         Console.WriteLine($"{q.FullName}");
      }
   }
   public static void Ex54()
   {
      /// combine employees with salaries above 200k and those in IT
      var q54 = _employees.Where(e => e.Salary > 200000)
                          .Concat(_employees.Where(e => e.DepartmentId == 2));

      Console.WriteLine("combine employees with salaries above 200k and those in IT");
      foreach (var q in q54)
      {
         Console.WriteLine($"{q.FullName}");
      }
   }
   public static void Ex55()
   {
      /// get total salary of all employees
      var q55 = _employees.Sum(e => e.Salary);

      Console.WriteLine("get total salary of all employees");
      Console.WriteLine($"Total Salary: {q55}");
   }
   public static void Ex56()
   {
      /// get maximum salary in each department
      var q98 = _departments.Select(d => new
      {
         d.Name,
         MaxSalary = _employees.Where(e => e.DepartmentId == d.Id).Max(e => e.Salary)
      });

      q98.Print("get maximum salary in each department");
   }
 

}
