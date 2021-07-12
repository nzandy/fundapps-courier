using FundApps.ParcelCostCalculator.Models.Parcels;
using NUnit.Framework;

namespace FundApps.ParcelCostCalculator.Models.UnitTests.Parcels
{
	[TestFixture]
	public class GetTotalShippingCostTests
	{
		[Test]
		public void ShouldCharge_StandardShipping_WhenWeightIsUnderMaxWeight()
		{
			// Arrange
			var parcel = new SmallParcel(ParcelConstants.SmallParcelOverweightThreshold - 0.5);

			// Act / Assert.
			Assert.That(parcel.GetTotalShippingCost(), Is.EqualTo(parcel.BaseShippingCost));
		}

		[Test]
		public void ShouldChargeForExtraKg_WhenWeightIsJustOverMaxWeight()
		{
			// Arrange
			var parcel = new SmallParcel(ParcelConstants.SmallParcelOverweightThreshold + 0.01);

			// Act / Assert.
			Assert.That(parcel.GetTotalShippingCost(), Is.EqualTo(parcel.BaseShippingCost + ParcelConstants.ExtraWeightSurcharge));
		}

		[Test]
		public void ShouldChargeForMultipleTimesOverWeightLimit()
		{
			// Arrange
			var parcel = new SmallParcel(ParcelConstants.SmallParcelOverweightThreshold + 3);

			// Act / Assert.
			Assert.That(parcel.GetTotalShippingCost(), Is.EqualTo(parcel.BaseShippingCost + (ParcelConstants.ExtraWeightSurcharge * 3)));
		}
	}
}