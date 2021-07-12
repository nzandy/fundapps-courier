using System.Collections.Generic;
using FundApps.ParcelCostCalculator.Models.Dtos;
using FundApps.ParcelCostCalculator.Models.Orders;
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
					_parcelCreator.CreateParcel(parcelRequest);
				parcels.Add(parcel);
			}

			return CreateOrderFromParcels(parcels, orderRequest.IsSpeedyShipping);
		}

		private Order CreateOrderFromParcels(IEnumerable<Parcel> parcels, bool isSpeedyShipping)
		{
			if (isSpeedyShipping)
			{
				return new SpeedyShippingOrder
				{
					Parcels = parcels
				};
			}

			return new Order
			{
				Parcels = parcels
			};
		}
	}
}
