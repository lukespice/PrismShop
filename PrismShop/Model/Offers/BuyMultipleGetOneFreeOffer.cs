using System;
using System.Linq;

namespace PrismShop.Model.Offers
{
	public class BuyMultipleGetOneFreeOffer : IOffer
	{
		private readonly Product _product;

		private readonly short _quantity;

		public BuyMultipleGetOneFreeOffer(Product product, short quantity)
		{
			_product = product;
			_quantity = quantity;
		}

		public void ApplyDiscount(Basket basket)
		{
			var productLineItem = basket.LineItems.SingleOrDefault(p => p.Product.Name == _product.Name);

			if (productLineItem == null || productLineItem.Quantity < _quantity + 1) return;

			productLineItem.Discount = Math.Floor(productLineItem.Quantity / (decimal)(_quantity + 1)) * productLineItem.UnitPrice;
		}
	}
}
