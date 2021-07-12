using FundApps.ParcelCostCalculator.Models;
using FundApps.ParcelCostCalculator.Models.Dtos;
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
			const int smallParcelSize = ParcelConstants.SmallParcelMaxDimension - 1;


			// Act
			var parcelRequest = new ParcelRequestDto
			{
				Height = smallParcelSize,
				Length = smallParcelSize,
				Width = smallParcelSize,
				Weight = ParcelConstants.SmallParcelOverweightThreshold
			};

			var parcel = _sut.CreateParcel(parcelRequest);


			// Assert
			Assert.That(parcel, Is.InstanceOf<SmallParcel>());
		}

		[Test]
		public void ShouldReturnMediumParcel_WhenAllDimensionsUnderMaxSmallSizeDimensions()
		{
			// Arrange
			const int mediumParcelSize = ParcelConstants.MediumParcelMaxDimension - 1;
			var parcelRequest = new ParcelRequestDto
			{
				Height = mediumParcelSize,
				Length = mediumParcelSize,
				Width = mediumParcelSize,
				Weight = ParcelConstants.MediumParcelOverweightThreshold
			};


			// Act
			var parcel = _sut.CreateParcel(parcelRequest);


			// Assert
			Assert.That(parcel, Is.InstanceOf<MediumParcel>());
		}

		[Test]
		public void ShouldReturnLargeParcel_WhenAllDimensionsUnderMaxLargeSizeDimensions()
		{
			// Arrange
			const int largeParcelSize = ParcelConstants.LargeParcelMaxDimension - 1;
			var parcelRequest = new ParcelRequestDto
			{
				Height = largeParcelSize,
				Length = largeParcelSize,
				Width = largeParcelSize,
				Weight = ParcelConstants.LargeParcelOverweightThreshold
			};


			// Act
			var parcel = _sut.CreateParcel(parcelRequest);


			// Assert
			Assert.That(parcel, Is.InstanceOf<LargeParcel>());
		}

		[Test]
		public void ShouldReturnXlParcel_WhenAllDimensionsOverMaxLargeSizeDimensions()
		{
			// Arrange
			const int xlParcelSize = ParcelConstants.LargeParcelMaxDimension;
			var parcelRequest = new ParcelRequestDto
			{
				Height = xlParcelSize,
				Length = xlParcelSize,
				Width = xlParcelSize,
				Weight = ParcelConstants.XlParcelOverweightThreshold
			};

			// Act
			var parcel = _sut.CreateParcel(parcelRequest);

			// Assert
			Assert.That(parcel, Is.InstanceOf<XlParcel>());
		}
	}
}
