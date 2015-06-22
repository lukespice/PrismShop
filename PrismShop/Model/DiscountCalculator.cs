using System.Collections.Generic;
using PrismShop.Model.Offers;

namespace PrismShop.Model
{
	public class DiscountCalculator
	{
		private IEnumerable<IOffer> Offers { get; set; }

		public DiscountCalculator(IEnumerable<IOffer> offers)
		{
			Offers = offers;
		}

		public void ApplyDiscounts(Basket basket)
		{
			foreach (var offer in Offers)
			{
				offer.ApplyDiscount(basket);
			}
		} 
	}
}
