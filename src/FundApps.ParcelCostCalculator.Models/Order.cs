using System.Collections.Generic;
using FundApps.ParcelCostCalculator.Models.Parcels;

namespace FundApps.ParcelCostCalculator.Models
{
	public class Order
	{
		public IEnumerable<Parcel> Parcels { get; set; }
		public decimal TotalOrderCost { get; }
	}
}
