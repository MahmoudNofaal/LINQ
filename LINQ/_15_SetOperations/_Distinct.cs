using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._15_SetOperations;

public class _Distinct
{

   public static void Ex01()
   {
      var participantsM1M2 = Repository.Meeting1.Participants.Concat(Repository.Meeting2.Participants);
      participantsM1M2.Print("Meeting 1 and Meeting 2 Participants");

      //YOU HAVE TO OVERRIDE [Equals()] and [GetHashCode()]
      var ditinctParticipantsM1M2 = participantsM1M2.Distinct();
      ditinctParticipantsM1M2.Print("Meeting 1 and Meeting 2 Participants [Distinct]");

      //YOU HAVE TO OVERRIDE [Equals()] and [GetHashCode()]
      var ditinctParticipantsM1M2DistinctBy = participantsM1M2.DistinctBy(x => x.EmployeeNo);
      ditinctParticipantsM1M2DistinctBy.Print("Meeting 1 and Meeting 2 Participants" +
                                              " [Distinct By] Employee No.");

   }

   public static void Ex02()
   {
      var set1 = Repository.Meeting1.Participants;
      var set2 = Repository.Meeting2.Participants;

      set1.Print($"======= MEeting 1 Participants ({set1.Count()})");
      set2.Print($"======= MEeting 2 Participants ({set2.Count()})");

      var set3 = set1.Except(set2);
      set3.Print($"======= set1 Except set2 Participants ({set3.Count()})");

      var set4 = set1.ExceptBy(set2.Select(x => x.EmployeeNo), x => x.EmployeeNo);
      set4.Print($"======= set1 ExceptBy [EmployeeNo] set2 Participants ({set4.Count()})");

   }

   public static void Ex03()
   {
      var set1 = Repository.Meeting1.Participants;
      var set2 = Repository.Meeting2.Participants;

      set1.Print($"======= Meeting 1 Participants ({set1.Count})");
      set2.Print($"======= Meeting 1 Participants ({set2.Count})");

      var set3 = set1.Intersect(set2);
      set3.Print($"======= set1 Intersect set2 Participants ({set3.Count()})");

      var set4 = set1.IntersectBy(set2.Select(x => x.EmployeeNo), x => x.EmployeeNo);
      set4.Print($"======= set1 IntersectBy [EmployeeNo] set2 ) Participants ({set4.Count()})");

   }

   public static void Ex04()
   {
      var set1 = Repository.Meeting1.Participants;
      var set2 = Repository.Meeting2.Participants;

      set1.Print($"======= Meeting 1 Participants ({set1.Count})");
      set2.Print($"======= Meeting 1 Participants ({set2.Count})");

      var set3 = set1.Union(set2);
      set3.Print($"=======  set1 Union set2 Participants ({set3.Count()})");

      var set4 = set1.UnionBy(set2, x => x.EmployeeNo);
      set4.Print($"=======  set1 UnionBy [EmployeeNo] set2 Participants ({set4.Count()})");

   }

   public static void Ex05()
   {
      var ordersA = new List<Order>
      {
          new Order { Id = 1, CustomerName = "Ahmed", Amount = 100 },
          new Order { Id = 2, CustomerName = "Marwa", Amount = 200 }
      };

      var ordersB = new List<Order>
      {
          new Order { Id = 2, CustomerName = "Marwa", Amount = 200 },
          new Order { Id = 3, CustomerName = "Omar", Amount = 300 }
      };

      // Union of customer names
      var highValueCustomers = ordersA.Where(o => o.Amount > 150)
                                      .Select(o => o.CustomerName)
                                      .Union(ordersB.Where(o => o.Amount > 150)
                                                    .Select(o => o.CustomerName));

      Console.WriteLine("Customers (Amount > $150):");
      Console.WriteLine(string.Join(", ", highValueCustomers));

      // Intersect of customer names
      var commonCustomers = ordersA.Select(o => o.CustomerName)
                                   .Intersect(ordersB.Select(o => o.CustomerName));

      Console.WriteLine();

      Console.WriteLine("Common customers:");
      Console.WriteLine(string.Join(", ", commonCustomers));

   }

}

class Order
{
   public int Id { get; set; }
   public string CustomerName { get; set; }
   public decimal Amount { get; set; }
}
