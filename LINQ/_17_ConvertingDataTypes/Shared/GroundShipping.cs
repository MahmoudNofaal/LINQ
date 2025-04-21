namespace LINQ._17_ConvertingDataTypes.Shared;

public class GroundShipping : Shipping
{
   public GroundShipping(string uniqueId, string sender, DateTime shippingDate) : base(uniqueId, sender, shippingDate)
   {
   }
   public override string Description => "Ground Shipping";

}
