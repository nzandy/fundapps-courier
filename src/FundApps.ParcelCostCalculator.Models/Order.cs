using System.Collections.Generic;
using System.Linq;
using FundApps.ParcelCostCalculator.Models.Parcels;

namespace FundApps.ParcelCostCalculator.Models
{
	public class Order
	{
		public IEnumerable<Parcel> Parcels { get; set; }

		public decimal TotalOrderCost
		{
			get
			{
				return Parcels.Sum(p => p.Cost);
			}
		}
	}
}
