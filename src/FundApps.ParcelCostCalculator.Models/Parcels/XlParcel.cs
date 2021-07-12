namespace FundApps.ParcelCostCalculator.Models.Parcels
{
	public class XlParcel : Parcel
	{
		public override decimal BaseShippingCost => 25;
		public override double MaxWeight => ParcelConstants.XlParcelOverweightThreshold;

		public XlParcel(double weight) : base(weight)
		{
		}
	}
}