namespace FundApps.ParcelCostCalculator.Models.Parcels
{
	public class MediumParcel : Parcel
	{
		public override decimal BaseShippingCost => 8;
		public override double MaxWeight => ParcelConstants.MediumParcelOverweightThreshold;
		public override int ExtraWeightSurcharge => ParcelConstants.ExtraWeightSurchargeStandard;

		public MediumParcel(double weight) : base(weight)
		{
		}
	}
}
