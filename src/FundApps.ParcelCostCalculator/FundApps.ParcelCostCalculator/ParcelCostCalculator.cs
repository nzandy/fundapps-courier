using System.Collections.Generic;
using FundApps.ParcelCostCalculator.Models;
using FundApps.ParcelCostCalculator.Models.Dtos;
using FundApps.ParcelCostCalculator.Models.Parcels;
using FundApps.ParcelCostCalculator.Services;

namespace FundApps.ParcelCostCalculator
{
	public class ParcelCostCalculator
	{
		private readonly IParcelCreator _parcelCreator;
		public ParcelCostCalculator(IParcelCreator parcelCreator)
		{
			_parcelCreator = parcelCreator;
		}

		public Order GetCourierOrderSummary(OrderRequestDto orderRequest)
		{
			var parcels = new List<Parcel>();
			foreach (var parcelRequest in orderRequest.Parcels)
			{
				var parcel =
					_parcelCreator.CreateParcel(parcelRequest.Length, parcelRequest.Width, parcelRequest.Height);
				parcels.Add(parcel);
			}

			return new Order
			{
				Parcels = parcels
			};
		}
	}
}
