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
				< ParcelConstants.MaxSmallParcelDimension => new SmallParcel(),
				< ParcelConstants.MaxMediumParcelDimension => new MediumParcel(),
				< ParcelConstants.MaxLargeParcelDimension => new LargeParcel(),
				_ => new XlParcel()
			};
		}
	}
}
