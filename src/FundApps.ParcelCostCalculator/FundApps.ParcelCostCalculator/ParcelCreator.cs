using System.Linq;
using FundApps.ParcelCostCalculator.Models.Parcels;

namespace FundApps.ParcelCostCalculator
{
	public class ParcelCreator
	{
		private const int MaxSmallParcelDimension = 10;
		private const int MaxMediumParcelDimension = 50;
		private const int MaxLargeParcelDimension = 100;

		public Parcel CreateParcel(double length, double width, double height)
		{
			var maxDimension = new double[] {length, width, height}.Max();

			return maxDimension switch
			{
				< MaxSmallParcelDimension => new SmallParcel(),
				< MaxMediumParcelDimension => new MediumParcel(),
				< MaxLargeParcelDimension => new LargeParcel(),
				_ => new XlParcel()
			};
		}
	}
}
