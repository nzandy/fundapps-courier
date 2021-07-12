namespace FundApps.ParcelCostCalculator.Models.Parcels
{
	public abstract class Parcel
	{
		protected Parcel(double weight)
		{
			Weight = weight;
		}
		public abstract decimal BaseShippingCost { get; }
		public abstract double MaxWeight { get; }
		public double Weight { get; set; }

		public decimal GetTotalShippingCost()
		{
			if (Weight <= MaxWeight)
			{
				return BaseShippingCost;
			}
			else
			{
				var extraWeight = Weight - MaxWeight;
				var partialKg = extraWeight % 1;

				if (partialKg > 0)
				{
					// Remove anything after decimal point and instead and another whole kg.
					// We charge by KG, so anything over the limit should be charged as whole kg.
					extraWeight -= partialKg;
					extraWeight++;
				}

				return BaseShippingCost + (decimal)extraWeight * ParcelConstants.ExtraWeightSurcharge;
			}
		}

	}
}
