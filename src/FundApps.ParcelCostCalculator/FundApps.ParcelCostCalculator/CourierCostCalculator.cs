using System;
using FundApps.ParcelCostCalculator.Models;
using FundApps.ParcelCostCalculator.Models.Dtos;

namespace FundApps.ParcelCostCalculator
{
	public class CourierCostCalculator
	{
		private ParcelCreator _parcelCreator;
		public CourierCostCalculator()
		{
			_parcelCreator = new ParcelCreator();
		}
		public Order GetCourierOrderSummary(OrderRequestDto orderRequest)
		{
			throw new NotImplementedException();
		}
	}
}
