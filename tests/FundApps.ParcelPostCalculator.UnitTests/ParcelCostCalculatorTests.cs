using System.Collections.Generic;
using System.Linq;
using FundApps.ParcelCostCalculator.Models;
using FundApps.ParcelCostCalculator.Models.Dtos;
using FundApps.ParcelCostCalculator.Models.Parcels;
using FundApps.ParcelCostCalculator.Services;
using Moq;
using NUnit.Framework;

namespace FundApps.ParcelCostCalculator.UnitTests
{
    [TestFixture]
    public class ParcelCostCalculatorTests
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
	    public void ShouldCallParcelCreator_WithExpectedParams()
	    {
			// Arrange.
		    var parcelRequest = new ParcelRequestDto
		    {
				Height = 5,
				Length = 5,
				Width = 5
		    };

		    var order = new OrderRequestDto
		    {
			    Parcels = new List<ParcelRequestDto>
			    {
				    parcelRequest
			    }
		    };


			// Act.
		    _sut.GetCourierOrderSummary(order);


			// Assert.
			_parcelCreator.Verify(pc => pc.CreateParcel(parcelRequest), Times.Once);
	    }

		[Test]
	    public void ShouldReturnExpectedOrder()
	    {
			// Arrange.
		    var parcelRequest = new ParcelRequestDto
		    {
			    Height = 5,
			    Length = 5,
			    Width = 5,
				Weight = 2
		    };

		    var orderRequest = new OrderRequestDto
		    {
			    Parcels = new List<ParcelRequestDto>
			    {
				    parcelRequest
			    }
		    };

		    var expectedParcelResponse = new SmallParcel(2);
		    _parcelCreator.Setup(pc => pc.CreateParcel(parcelRequest)).Returns(expectedParcelResponse);


			// Act.
		    var order = _sut.GetCourierOrderSummary(orderRequest);


		    // Assert.
			Assert.That(order, Is.Not.Null);
			var parcels = order.Parcels.ToList();
			Assert.That(parcels.Count, Is.EqualTo(1));
			var parcelResult = parcels.First();
			Assert.That(parcelResult, Is.InstanceOf<SmallParcel>());
			Assert.That(parcelResult.GetTotalShippingCost(), Is.EqualTo(parcelResult.BaseShippingCost + ParcelConstants.ExtraWeightSurchargeStandard));
		}
    }
}
