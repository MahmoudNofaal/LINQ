using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ._4_ProjectionOperation;

public class _Zip
{
   /// [ZIP]

   public static void Ex01()
   {
      string[] colorName = { "Red", "Green", "Blue" };
      string[] colorHEX = { "#FF0000", "#00FF00", "#0000FF" };

      var colors = colorName.Zip(colorHEX, (name, hex) => $"{name} ({hex})");

      foreach (var color in colors)
      {
         Console.WriteLine(color);
      }

   }

   public static void Ex02()
   {
      var employees = Repository.LoadEmployees().ToArray();

      var firstThreeEmps = employees[..3];

      var lastThreeEmps = employees[^3..];

      var teams = firstThreeEmps.Zip(lastThreeEmps, (first, last) =>
                                     $"{first.FullName} with {last.FullName}");

      var teams01 = from team in firstThreeEmps.Zip(lastThreeEmps)
                    select $"{team.First.FullName} with {team.Second.FullName}";

      foreach (var team in teams01)
      {
         Console.WriteLine(team);
      }

   }

}

