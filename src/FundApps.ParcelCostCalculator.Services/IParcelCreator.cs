using FundApps.ParcelCostCalculator.Models.Dtos;
using FundApps.ParcelCostCalculator.Models.Parcels;

namespace FundApps.ParcelCostCalculator.Services
{
	public interface IParcelCreator
	{
		Parcel CreateParcel(ParcelRequestDto parcelRequest);
	}
}