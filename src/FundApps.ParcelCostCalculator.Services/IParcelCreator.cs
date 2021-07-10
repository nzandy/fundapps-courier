using FundApps.ParcelCostCalculator.Models.Parcels;

namespace FundApps.ParcelCostCalculator.Services
{
	public interface IParcelCreator
	{
		Parcel CreateParcel(double length, double width, double height);
	}
}