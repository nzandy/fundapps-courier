using System.Collections.Generic;
using FundApps.ParcelCostCalculator.Models.Orders;
using FundApps.ParcelCostCalculator.Models.Parcels;
using NUnit.Framework;

namespace FundApps.ParcelCostCalculator.Models.UnitTests.Orders
{
	[TestFixture]
	public class SpeedyShippingOrderTests
	{
		[Test]
		public void TotalCost_ShouldBeDouble_StandardOrderTotalCost_SingleParcel()
		{
			// Arrange
			var parcels = new List<Parcel>
			{
				new LargeParcel(20)
			};

			var standardOrder = new Order
			{
				Parcels = parcels
			};

			var speedyShippingOrder = new SpeedyShippingOrder
			{
				Parcels = parcels
			};

			// Act/Assert.
			Assert.That(speedyShippingOrder.TotalOrderCost, Is.EqualTo(standardOrder.TotalOrderCost * 2));
		}

		[Test]
		public void TotalCost_ShouldBeDouble_StandardOrderTotalCost_MultipleParcels()
		{
			// Arrange
			var parcels = new List<Parcel>
			{
				new LargeParcel(20),
				new SmallParcel(5)
			};

			var standardOrder = new Order
			{
				Parcels = parcels
			};

			var speedyShippingOrder = new SpeedyShippingOrder
			{
				Parcels = parcels
			};

			// Act/Assert.
			Assert.That(speedyShippingOrder.TotalOrderCost, Is.EqualTo(standardOrder.TotalOrderCost * 2));
		}
	}
}
