using System.Collections.Generic;

namespace FundApps.ParcelCostCalculator.Dtos
{
	public class OrderRequestDto
	{
		public IEnumerable<ParcelRequestDto> Parcels { get; set; }
	}
}
