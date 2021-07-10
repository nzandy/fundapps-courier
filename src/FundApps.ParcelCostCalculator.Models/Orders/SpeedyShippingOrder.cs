namespace FundApps.ParcelCostCalculator.Models.Orders
{
	public class SpeedyShippingOrder : Order
	{
		public override decimal TotalOrderCost => base.TotalOrderCost * 2;
	}
}
