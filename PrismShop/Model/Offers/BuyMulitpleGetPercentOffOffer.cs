using System.Linq;

namespace PrismShop.Model.Offers
{
	public class BuyMulitpleGetPercentOffOffer : IOffer
	{
		private readonly Product _productToBuy;

		private readonly short _quantity;

		private readonly Product _discountProduct;

		private readonly decimal _discountPercent;

		public BuyMulitpleGetPercentOffOffer(Product productToBuy, short quantity, Product discountProduct, decimal discountPercent)
		{
			_productToBuy = productToBuy;
			_quantity = quantity;
			_discountProduct = discountProduct;
			_discountPercent = discountPercent;
		}

		public void ApplyDiscount(Basket basket)
		{
			var buyProductLineItem = basket.LineItems.SingleOrDefault(p => p.Product.Name == _productToBuy.Name);
			if (buyProductLineItem == null || buyProductLineItem.Quantity < _quantity) return;

			var discountProductLineItem = basket.LineItems.SingleOrDefault(p => p.Product.Name == _discountProduct.Name);
			if (discountProductLineItem == null) return;

			discountProductLineItem.Discount = discountProductLineItem.UnitPrice * _discountPercent;
		}
	}
}
