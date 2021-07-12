using System.Collections.Generic;
using System.Linq;
using FundApps.ParcelCostCalculator.Models;
using FundApps.ParcelCostCalculator.Models.Dtos;
using FundApps.ParcelCostCalculator.Models.Parcels;

namespace FundApps.ParcelCostCalculator.Services
{
	public class ParcelCreator : IParcelCreator
	{
		public Parcel CreateParcel(ParcelRequestDto parcelRequest)
		{
			var maxDimension = new double[] {parcelRequest.Height, parcelRequest.Length, parcelRequest.Width}.Max();
			var validParcels = GetValidParcelSizes(maxDimension, parcelRequest.Weight);

			var parcelsOrderedByCost = validParcels.OrderBy(parcel => parcel.TotalShippingCost);
			return parcelsOrderedByCost.First();
		}


		// Not happy with this conditional logic below, to me this is a bad code smell, but I do not have time to 
		// try and refactor this now.
		private IEnumerable<Parcel> GetValidParcelSizes(double maxDimension, double weight)
		{
			var validParcelSizesForRequest = new List<Parcel>
			{
				new XlParcel(weight)
			};

			if (ParcelConstants.SmallParcelMaxDimension > maxDimension)
			{
				validParcelSizesForRequest.Add(new SmallParcel(weight));
			}
			if (ParcelConstants.MediumParcelMaxDimension > maxDimension)
			{
				validParcelSizesForRequest.Add(new MediumParcel(weight));
			}
			if (ParcelConstants.LargeParcelMaxDimension > maxDimension)
			{
				validParcelSizesForRequest.Add(new LargeParcel(weight));
			}

			return validParcelSizesForRequest;
		}
	}
}
