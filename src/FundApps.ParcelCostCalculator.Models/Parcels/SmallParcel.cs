namespace FundApps.ParcelCostCalculator.Models.Parcels
{
	public class SmallParcel : Parcel
	{
		public override decimal BaseShippingCost => 3;
		public override double MaxWeight => 1;
	}
}
