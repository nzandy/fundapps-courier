using System.Collections.Generic;

namespace FundApps.ParcelCostCalculator.Models.Dtos
{
	public class OrderRequestDto
	{
		public IEnumerable<ParcelRequestDto> Parcels { get; set; }
		public bool IsSpeedyShipping { get; set; }
	}
}
