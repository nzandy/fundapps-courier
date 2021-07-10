namespace FundApps.ParcelCostCalculator.Models.Parcels
{
	public class XlParcel : Parcel
	{
		public override decimal BaseShippingCost => 25;
		public override double MaxWeight => 10;
	}
}