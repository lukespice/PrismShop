using NUnit.Framework;
using PrismShop.Model;
using PrismShop.Model.Offers;

namespace PrismShop.Tests
{
	[TestFixture]
	public class BasketTests
	{

		private Basket _basket;

		readonly Product _butter = new Product { Name = "Butter", Price = 0.8m };
		readonly Product _milk = new Product { Name = "Milk", Price = 1.15m };
		readonly Product _bread = new Product { Name = "Bread", Price = 1 };

		[SetUp]
		public void SetUp()
		{
			_basket = new Basket(new IOffer[] { 
				// Buy 2 Butter and get B Bread at 50% off
				new BuyMulitpleGetPercentOffOffer(_butter, 2, _bread, .5m),
				//  3 Milk and get the 4th milk for free
				new BuyMultipleGetOneFreeOffer(_milk, 3)
			});
		}
		
		[Test]
		public void NoDiscount()
		{
			// Given the basket has 1 bread, 1 butter and 1 milk
			_basket.AddProduct(_butter, 1);
			_basket.AddProduct(_milk, 1);
			_basket.AddProduct(_bread, 1);

			// when I total the basket
			var total = _basket.CalculateTotal();
			
			// then the total should be £2.95
			Assert.AreEqual(2.95m, total);
		}

		[Test]
		public void TwoButterGetBread50PercentOff()
		{
			// Given the basket has 2 butter and 2 bread 
			_basket.AddProduct(_butter, 2);
			_basket.AddProduct(_bread, 2);

			// when I total the basket
			var total = _basket.CalculateTotal();

			// then the total should be £3.10
			Assert.AreEqual(3.10m, total);
		}

		[Test]
		public void Buy3MilkGetOneFree()
		{
			// Given the basket has 4 milk
			_basket.AddProduct(_milk, 4);

			// when I total the basket
			var total = _basket.CalculateTotal();

			// then the total should be £3.45
			Assert.AreEqual(3.45m, total);
		}

		[Test]
		public void TwoButter1Bread8Milk()
		{
			// Given the basket has 2 butter, 1 bread and 8 milk 
			_basket.AddProduct(_butter, 2);
			_basket.AddProduct(_bread, 1);
			_basket.AddProduct(_milk, 8);

			// when I total the basket
			var total = _basket.CalculateTotal();

			// then the total should be £9.00
			Assert.AreEqual(9, total);
		}
	}
}
