﻿namespace FundApps.ParcelCostCalculator.Models.Parcels
{
	public class LargeParcel : Parcel
	{
		public override decimal BaseShippingCost => 15;
		public override double MaxWeight => 6;
	}
}