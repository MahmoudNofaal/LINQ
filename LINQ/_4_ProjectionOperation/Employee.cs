namespace LINQ._4_ProjectionOperation;

public class Employee
{
   public int Id { get; set; }

   public string FirstName { get; set; }

   public string LastName { get; set; }

   public string Email { get; set; }

   public List<string> Skills { get; set; } = new List<string>();


   public string FullName => $"{FirstName} {LastName}";

   public override string ToString()
   {

      return
              $"" +
              $"{Id}\t" +
              $"{String.Concat(FirstName, " ", LastName).PadRight(30, ' ')}\t" +
              $"{Email.PadRight(30, ' ')}\t" +
              $"[ {string.Join(", ", Skills)} ]";

   }
}

