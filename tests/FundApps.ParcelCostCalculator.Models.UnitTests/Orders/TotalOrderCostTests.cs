using System.Collections.Generic;
using FundApps.ParcelCostCalculator.Models.Orders;
using FundApps.ParcelCostCalculator.Models.Parcels;
using NUnit.Framework;

namespace FundApps.ParcelCostCalculator.Models.UnitTests.Orders
{
	[TestFixture]
	public class TotalOrderCostTests
	{
		private Order _sut;

		[SetUp]
		public void SetUp()
		{
			_sut = new Order();
		}

		[Test]
		public void ShouldReturnExpectedTotalCost_WhenSingleParcel()
		{
			// Arrange.
			var parcel = new LargeParcel(20);
			_sut.Parcels = new List<Parcel>
			{
				parcel
			};


			// Act.
			var totalCost = _sut.TotalOrderCost;


			// Assert.
			Assert.That(totalCost, Is.EqualTo(parcel.BaseShippingCost));
		}

		[Test]
		public void ShouldReturnExpectedTotalCost_WhenMultipleParcels()
		{
			// Arrange.
			var parcel1 = new LargeParcel(20);
			var parcel2 = new MediumParcel(20);
			var parcel3 = new SmallParcel(20);
			var parcel4 = new XlParcel(20);

			_sut.Parcels = new List<Parcel>
			{
				parcel1,
				parcel2,
				parcel3,
				parcel4
			};


			// Act.
			var totalCost = _sut.TotalOrderCost;


			// Assert.
			var expectedTotalCost = parcel1.BaseShippingCost + parcel2.BaseShippingCost + parcel3.BaseShippingCost + parcel4.BaseShippingCost;
			Assert.That(totalCost, Is.EqualTo(expectedTotalCost));
		}
	}
}
