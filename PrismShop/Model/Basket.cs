using System;
using System.Collections.Generic;
using System.Linq;
using PrismShop.Model.Offers;

namespace PrismShop.Model
{
	public class Basket
	{
		public List<LineItem> LineItems { get; private set; }

		private readonly DiscountCalculator _discountCalculator;

		public decimal TotalBeforeDiscount
		{
			get { return LineItems.Sum(li => li.Price); }
		}

		public Basket(IEnumerable<IOffer> offers)
		{
			LineItems = new List<LineItem>();
			_discountCalculator = new DiscountCalculator(offers);
		}

		public void AddProduct(Product product, short quantity)
		{
			if (product == null) throw new ArgumentNullException("product");
			if (quantity <= 0) throw new ArgumentOutOfRangeException("quantity");
			if (LineItems.Exists(li => li.Product.Name == product.Name)) throw new ArgumentException("Cannot add multiple line items of the same product");

			LineItems.Add(new LineItem(product, quantity));
		}

		public decimal CalculateTotal()
		{
			_discountCalculator.ApplyDiscounts(this);

			return TotalBeforeDiscount - LineItems.Sum(li => li.Discount);
		}

	}
}
