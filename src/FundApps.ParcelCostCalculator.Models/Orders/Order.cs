using System.Collections.Generic;
using System.Linq;
using FundApps.ParcelCostCalculator.Models.Parcels;

namespace FundApps.ParcelCostCalculator.Models.Orders
{
	public class Order
	{
		public IEnumerable<Parcel> Parcels { get; set; }

		public virtual decimal TotalOrderCost
		{
			get
			{
				return Parcels.Sum(p => p.Cost);
			}
		}
	}
}
