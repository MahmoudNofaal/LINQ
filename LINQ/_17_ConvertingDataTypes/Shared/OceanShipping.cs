namespace LINQ._17_ConvertingDataTypes.Shared;

public class OceanShipping : Shipping
{
   public OceanShipping(string uniqueId, string sender, DateTime shippingDate) : base(uniqueId, sender, shippingDate)
   {
   }
   public override string Description => "Ocean Shipping";

}
