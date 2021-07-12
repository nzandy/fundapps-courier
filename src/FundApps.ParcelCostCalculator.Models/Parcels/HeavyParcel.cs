namespace FundApps.ParcelCostCalculator.Models.Parcels
{
	public class HeavyParcel : Parcel
	{
		public override decimal BaseShippingCost => 50;
		public override double MaxWeight => 50;
		public override int ExtraWeightSurcharge => ParcelConstants.ExtraWeightSurchargeHeavy;

		public HeavyParcel(double weight) : base(weight)
		{
		}
	}
}
