namespace FundApps.ParcelCostCalculator.Models.Parcels
{
	public class MediumParcel : Parcel
	{
		public override decimal BaseShippingCost => 8;
		public override double MaxWeight => 3;
	}
}
