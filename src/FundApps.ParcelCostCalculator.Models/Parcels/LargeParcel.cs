namespace FundApps.ParcelCostCalculator.Models.Parcels
{
	public class LargeParcel : Parcel
	{
		public override decimal BaseShippingCost => 15;
		public override double MaxWeight => ParcelConstants.LargeParcelOverweightThreshold;
		public override int ExtraWeightSurcharge => ParcelConstants.ExtraWeightSurchargeStandard;

		public LargeParcel(double weight) : base(weight)
		{
		}
	}
}