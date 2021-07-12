namespace FundApps.ParcelCostCalculator.Models.Parcels
{
	public class LargeParcel : Parcel
	{
		public override decimal BaseShippingCost => 15;
		public override double MaxWeight => ParcelConstants.LargeParcelOverweightThreshold;

		public LargeParcel(double weight) : base(weight)
		{
		}
	}
}