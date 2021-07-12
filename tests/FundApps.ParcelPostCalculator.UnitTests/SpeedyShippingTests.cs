using System.Collections.Generic;
using FundApps.ParcelCostCalculator.Models.Dtos;
using FundApps.ParcelCostCalculator.Models.Orders;
using FundApps.ParcelCostCalculator.Models.Parcels;
using FundApps.ParcelCostCalculator.Services;
using Moq;
using NUnit.Framework;

namespace FundApps.ParcelCostCalculator.UnitTests
{
	[TestFixture]
	public class SpeedyShippingTests
	{
		private Mock<IParcelCreator> _parcelCreator;
		private ParcelCostCalculator _sut;

		[SetUp]
		public void SetUp()
		{
			_parcelCreator = new Mock<IParcelCreator>();
			_sut = new ParcelCostCalculator(_parcelCreator.Object);
		}

		[Test]
		public void ShouldReturnAppropriateOrderType_BasedOnRequestSpeedyShipping([Values] bool isSpeedyShipping)
		{
			// Arrange.
			var parcelRequest = new ParcelRequestDto
			{
				Height = 5,
				Length = 5,
				Width = 5
			};

			var orderRequest = new OrderRequestDto
			{
				Parcels = new List<ParcelRequestDto>
				{
					parcelRequest
				},
				IsSpeedyShipping = isSpeedyShipping
				
			};

			var expectedParcelResponse = new SmallParcel(2);
			_parcelCreator.Setup(pc => pc.CreateParcel(parcelRequest)).Returns(expectedParcelResponse);


			// Act.
			var order = _sut.GetCourierOrderSummary(orderRequest);


			// Assert.
			if (isSpeedyShipping)
			{
				Assert.That(order, Is.InstanceOf<SpeedyShippingOrder>());
			}
			else
			{
				Assert.That(order, Is.InstanceOf<Order>());
				Assert.That(order, Is.Not.InstanceOf<SpeedyShippingOrder>());
			}

		}
	}
}