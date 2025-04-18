using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._2_FunctionalProgramming;

public static class Repository
{

   public static IEnumerable<Employee> LoadEmployees()
   {
      return new List<Employee>
            {
                new Employee
                {
                        Id = 1001,
                        FirstName = "Cochran",
                        LastName = "Cole",
                        HireDate = new DateTime(2017, 11, 2),
                        Gender = "male",
                        Department = "FIMAMCE",
                        HasHealthInsurance = false,
                        HasPensionPlan = true,
                        Salary = 103200m
                },
              
             
                new Employee
                {
                        Id = 1002,
                        FirstName = "Wallace",
                        LastName = "Buck",
                        HireDate = new DateTime(2014, 5, 12),
                        Gender = "male",
                        Department = "IT",
                        HasHealthInsurance = true,
                        HasPensionPlan = false,
                        Salary = 315800m
                },
               
                new Employee
                {
                        Id = 1003,
                        FirstName = "Debra",
                        LastName = "Hogan",
                        HireDate = new DateTime(2019, 10, 4),
                        Gender = "female",
                        Department = "IT",
                        HasHealthInsurance = false,
                        HasPensionPlan = true,
                        Salary = 249100m
                },
              
                new Employee
                {
                        Id = 1004,
                        FirstName = "Clara",
                        LastName = "Reeves",
                        HireDate = new DateTime(2014, 12, 6),
                        Gender = "female",
                        Department = "IT",
                        HasHealthInsurance = true,
                        HasPensionPlan = true,
                        Salary = 245800m
                },
                new Employee
                {
                        Id = 1005,
                        FirstName = "Karin",
                        LastName = "Blanchard",
                        HireDate = new DateTime(2018, 1, 20),
                        Gender = "female",
                        Department = "IT",
                        HasHealthInsurance = false,
                        HasPensionPlan = true,
                        Salary = 341200m
                },
                new Employee
                {
                        Id = 1006,
                        FirstName = "Burris",
                        LastName = "Morgan",
                        HireDate = new DateTime(2019, 7, 6),
                        Gender = "male",
                        Department = "Accounting",
                        HasHealthInsurance = false,
                        HasPensionPlan = false,
                        Salary = 360300m
                },
                new Employee
                {
                        Id = 1007,
                        FirstName = "Owen",
                        LastName = "Cortez",
                        HireDate = new DateTime(2021, 12, 9),
                        Gender = "male",
                        Department = "IT",
                        HasHealthInsurance = false,
                        HasPensionPlan = true,
                        Salary = 193700m
                },
               
                new Employee
                {
                        Id = 1008,
                        FirstName = "Sharpe",
                        LastName = "Cardenas",
                        HireDate = new DateTime(2017, 11, 28),
                        Gender = "male",
                        Department = "Accounting",
                        HasHealthInsurance = false,
                        HasPensionPlan = true,
                        Salary = 266100m
                },
              
                new Employee
                {
                        Id = 1009,
                        FirstName = "Gonzalez",
                        LastName = "Gilliam",
                        HireDate = new DateTime(2021, 4, 29),
                        Gender = "male",
                        Department = "IT",
                        HasHealthInsurance = false,
                        HasPensionPlan = false,
                        Salary = 394300m
                },
                new Employee
                {
                        Id = 1010,
                        FirstName = "Abigail",
                        LastName = "Bradford",
                        HireDate = new DateTime(2018, 4, 2),
                        Gender = "female",
                        Department = "FIMAMCE",
                        HasHealthInsurance = true,
                        HasPensionPlan = false,
                        Salary = 296100m
                },
                new Employee
                {
                        Id = 1011,
                        FirstName = "Ashlee",
                        LastName = "Farmer",
                        HireDate = new DateTime(2020, 9, 24),
                        Gender = "female",
                        Department = "IT",
                        HasHealthInsurance = false,
                        HasPensionPlan = true,
                        Salary = 125300m
                },
             
                new Employee
                {
                        Id = 1012,
                        FirstName = "Barber",
                        LastName = "Singleton",
                        HireDate = new DateTime(2017, 5, 8),
                        Gender = "male",
                        Department = "Accounting",
                        HasHealthInsurance = false,
                        HasPensionPlan = true,
                        Salary = 192400m
                },
                new Employee
                {
                        Id = 1013,
                        FirstName = "Aileen",
                        LastName = "Sweet",
                        HireDate = new DateTime(2018, 7, 4),
                        Gender = "female",
                        Department = "Accounting",
                        HasHealthInsurance = false,
                        HasPensionPlan = false,
                        Salary = 262400m
                },
                new Employee
                {
                        Id = 1014,
                        FirstName = "Lindsey",
                        LastName = "Hughes",
                        HireDate = new DateTime(2014, 4, 26),
                        Gender = "male",
                        Department = "FIMAMCE",
                        HasHealthInsurance = true,
                        HasPensionPlan = false,
                        Salary = 370000m
                },
                new Employee
                {
                        Id = 1015,
                        FirstName = "Stout",
                        LastName = "Phillips",
                        HireDate = new DateTime(2019, 6, 19),
                        Gender = "male",
                        Department = "FIMAMCE",
                        HasHealthInsurance = true,
                        HasPensionPlan = false,
                        Salary = 151000m
                },
                
                new Employee
                {
                        Id = 1016,
                        FirstName = "Eaton",
                        LastName = "Lyons",
                        HireDate = new DateTime(2021, 7, 3),
                        Gender = "male",
                        Department = "IT",
                        HasHealthInsurance = false,
                        HasPensionPlan = false,
                        Salary = 237600m
                },
                new Employee
                {
                        Id = 1017,
                        FirstName = "Beck",
                        LastName = "Ortiz",
                        HireDate = new DateTime(2015, 5, 13),
                        Gender = "male",
                        Department = "HR",
                        HasHealthInsurance = true,
                        HasPensionPlan = false,
                        Salary = 192900m
                },
                new Employee
                {
                        Id = 1018,
                        FirstName = "Patty",
                        LastName = "Knight",
                        HireDate = new DateTime(2017, 8, 22),
                        Gender = "female",
                        Department = "IT",
                        HasHealthInsurance = false,
                        HasPensionPlan = false,
                        Salary = 173100m
                },
                new Employee
                {
                        Id = 1019,
                        FirstName = "Bowman",
                        LastName = "Hampton",
                        HireDate = new DateTime(2017, 10, 10),
                        Gender = "male",
                        Department = "IT",
                        HasHealthInsurance = true,
                        HasPensionPlan = true,
                        Salary = 145200m
                },
                new Employee
                {
                        Id = 1020,
                        FirstName = "Pace",
                        LastName = "Bryant",
                        HireDate = new DateTime(2019, 3, 1),
                        Gender = "male",
                        Department = "HR",
                        HasHealthInsurance = false,
                        HasPensionPlan = true,
                        Salary = 160100m
                },
                
                new Employee
                {
                        Id = 1021,
                        FirstName = "Nora",
                        LastName = "Dale",
                        HireDate = new DateTime(2021, 7, 26),
                        Gender = "female",
                        Department = "IT",
                        HasHealthInsurance = false,
                        HasPensionPlan = false,
                        Salary = 368900m
                },
                new Employee
                {
                        Id = 1022,
                        FirstName = "Hillary",
                        LastName = "Duran",
                        HireDate = new DateTime(2017, 2, 19),
                        Gender = "female",
                        Department = "Accounting",
                        HasHealthInsurance = false,
                        HasPensionPlan = false,
                        Salary = 282200m
                },
                new Employee
                {
                        Id = 1023,
                        FirstName = "Hamilton",
                        LastName = "Macias",
                        HireDate = new DateTime(2017, 10, 21),
                        Gender = "male",
                        Department = "HR",
                        HasHealthInsurance = false,
                        HasPensionPlan = true,
                        Salary = 237300m
                },
                new Employee
                {
                        Id = 1024,
                        FirstName = "Kent",
                        LastName = "Parsons",
                        HireDate = new DateTime(2018, 3, 30),
                        Gender = "male",
                        Department = "HR",
                        HasHealthInsurance = true,
                        HasPensionPlan = false,
                        Salary = 176400m
                },
                new Employee
                {
                        Id = 1025,
                        FirstName = "Dunn",
                        LastName = "Oliver",
                        HireDate = new DateTime(2018, 9, 3),
                        Gender = "male",
                        Department = "Accounting",
                        HasHealthInsurance = false,
                        HasPensionPlan = false,
                        Salary = 244400m
                },
                new Employee
                {
                        Id = 1026,
                        FirstName = "Betsy",
                        LastName = "Dean",
                        HireDate = new DateTime(2018, 11, 23),
                        Gender = "female",
                        Department = "IT",
                        HasHealthInsurance = false,
                        HasPensionPlan = false,
                        Salary = 196900m
                },
                new Employee
                {
                        Id = 1027,
                        FirstName = "Kay",
                        LastName = "May",
                        HireDate = new DateTime(2020, 9, 8),
                        Gender = "female",
                        Department = "Accounting",
                        HasHealthInsurance = false,
                        HasPensionPlan = true,
                        Salary = 224000m
                },
                
                new Employee
                {
                        Id = 1028,
                        FirstName = "Cervantes",
                        LastName = "Wong",
                        HireDate = new DateTime(2019, 11, 8),
                        Gender = "male",
                        Department = "IT",
                        HasHealthInsurance = false,
                        HasPensionPlan = false,
                        Salary = 235100m
                }
            };
   }

}
