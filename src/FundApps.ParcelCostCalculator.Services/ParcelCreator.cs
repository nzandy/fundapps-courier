using System.Linq;
using FundApps.ParcelCostCalculator.Models;
using FundApps.ParcelCostCalculator.Models.Parcels;

namespace FundApps.ParcelCostCalculator.Services
{
	public class ParcelCreator : IParcelCreator
	{
		public Parcel CreateParcel(double length, double width, double height)
		{
			var maxDimension = new double[] {length, width, height}.Max();

			return maxDimension switch
			{
				< ParcelDimensionConstants.MaxSmallParcelDimension => new SmallParcel(),
				< ParcelDimensionConstants.MaxMediumParcelDimension => new MediumParcel(),
				< ParcelDimensionConstants.MaxLargeParcelDimension => new LargeParcel(),
				_ => new XlParcel()
			};
		}
	}
}
