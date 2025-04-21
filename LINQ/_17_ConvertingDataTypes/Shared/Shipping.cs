namespace LINQ._17_ConvertingDataTypes;

public abstract class Shipping
{
   protected Shipping(string uniqueId, string sender, DateTime shippingDate)
   {
      this.UniqueId = uniqueId;
      this.Sender = sender;
      this.ShippingDate = shippingDate;
   }
   public string UniqueId { get; private set; }
   public string Sender { get; private set; }
   public DateTime ShippingDate { get; private set; }
   public abstract string Description { get; }
   public virtual void Start()
   {
      Console.WriteLine(
       $"\n\tCode: {UniqueId}" +
       $"\n\tDescription {Description}" +
       $"\n\tSender: {Sender}" +
       $"\n\tDate: {ShippingDate.ToShortDateString()}"
       );
   }
}
