namespace FundApps.ParcelCostCalculator.Models.Parcels
{
	public class SmallParcel : Parcel
	{
		public override decimal BaseShippingCost => 3;
		public override double MaxWeight => ParcelConstants.SmallParcelOverweightThreshold;

		public SmallParcel(double weight) : base(weight)
		{
		}
	}
}
