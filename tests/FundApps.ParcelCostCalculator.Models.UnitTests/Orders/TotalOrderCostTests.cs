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
			var parcel = new LargeParcel();
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
			var parcel1 = new LargeParcel();
			var parcel2 = new MediumParcel();
			var parcel3 = new SmallParcel();
			var parcel4 = new XlParcel();

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
