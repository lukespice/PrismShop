
namespace PrismShop.Model
{
	public class LineItem
	{
		public Product Product { get; private set; }

		public decimal UnitPrice { get; private set; }

		public short Quantity { get; private set; }

		public decimal Price
		{
			get { return UnitPrice * Quantity; }
		}

		public decimal Discount { get; set; }

		public LineItem(Product product, short quantity)
		{
			Product = product;
			UnitPrice = product.Price;
			Quantity = quantity;
		}
	}
}
