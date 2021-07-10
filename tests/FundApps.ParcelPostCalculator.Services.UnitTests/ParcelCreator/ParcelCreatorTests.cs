using FundApps.ParcelCostCalculator.Models;
using FundApps.ParcelCostCalculator.Models.Parcels;
using NUnit.Framework;

namespace FundApps.ParcelCostCalculator.Services.UnitTests.ParcelCreator
{
	[TestFixture]
	public class ParcelCreatorTests
	{
		private Services.ParcelCreator _sut;

		[SetUp]
		public void SetUp()
		{
			_sut = new Services.ParcelCreator();
		}

		[Test]
		public void ShouldReturnSmallParcel_WhenAllDimensionsUnderMaxSmallSizeDimensions()
		{
			// Arrange
			var smallParcelSize = ParcelDimensionConstants.MaxSmallParcelDimension - 1;

			// Act
			var parcel = _sut.CreateParcel(smallParcelSize, smallParcelSize, smallParcelSize);

			// Assert
			Assert.That(parcel, Is.InstanceOf<SmallParcel>());
		}

		[Test]
		public void ShouldReturnMediumParcel_WhenAllDimensionsUnderMaxSmallSizeDimensions()
		{
			// Arrange
			var mediumParcelSize = ParcelDimensionConstants.MaxMediumParcelDimension - 1;

			// Act
			var parcel = _sut.CreateParcel(mediumParcelSize, mediumParcelSize, mediumParcelSize);

			// Assert
			Assert.That(parcel, Is.InstanceOf<MediumParcel>());
		}

		[Test]
		public void ShouldReturnLargeParcel_WhenAllDimensionsUnderMaxLargeSizeDimensions()
		{
			// Arrange
			var largeParcelSize = ParcelDimensionConstants.MaxLargeParcelDimension - 1;

			// Act
			var parcel = _sut.CreateParcel(largeParcelSize, largeParcelSize, largeParcelSize);

			// Assert
			Assert.That(parcel, Is.InstanceOf<LargeParcel>());
		}

		[Test]
		public void ShouldReturnXlParcel_WhenAllDimensionsOverMaxLargeSizeDimensions()
		{
			// Arrange
			var xlParcelSize = ParcelDimensionConstants.MaxLargeParcelDimension;

			// Act
			var parcel = _sut.CreateParcel(xlParcelSize, xlParcelSize, xlParcelSize);

			// Assert
			Assert.That(parcel, Is.InstanceOf<XlParcel>());
		}
	}
}
