using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;

namespace EssentialTools.Tests
{
	[TestClass]
	public class UnitTest1
	{
		private IDiscountHelper getTestObject() {
			return new MinimumDiscountHelper();
		}

		[TestMethod]
		public void Dicsount_Above_100() {
			// Arrange (시나리오를 설정한다.)
			IDiscountHelper target = getTestObject();
			decimal total = 200;

			// Act (작업을 시도한다.)
			var discountedTotal = target.ApplyDiscount(total);

			// Assert(결과를 검증한다.)
			Assert.AreEqual(total * 0.9M, discountedTotal);
		}

		[TestMethod]
		public void Dicsount_Between_10_And_100()
		{
			// Arrange (시나리오를 설정한다.)
			IDiscountHelper target = getTestObject();

			// Act (작업을 시도한다.)
			decimal TenDollarDiscount = target.ApplyDiscount(10);
			decimal HundredDollarDiscount = target.ApplyDiscount(100);
			decimal FiftyDollarDiscount = target.ApplyDiscount(50);
			
			// Assert(결과를 검증한다.)
			Assert.AreEqual(5, TenDollarDiscount, "$10 discount is wrong");
			Assert.AreEqual(95, HundredDollarDiscount, "$100 discountedTotal");
			Assert.AreEqual(45, FiftyDollarDiscount, "%50 discount is wrong");
		}


		[TestMethod]
		public void Dicsount_Less_Than_10()
		{
			// Arrange (시나리오를 설정한다.)
			IDiscountHelper target = getTestObject();

			// Act (작업을 시도한다.)
			decimal TenDollarDiscount = target.ApplyDiscount(5);
			decimal HundredDollarDiscount = target.ApplyDiscount(0);
			
			// Assert(결과를 검증한다.)
			Assert.AreEqual(5, TenDollarDiscount);
			Assert.AreEqual(0, HundredDollarDiscount);
		}


		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Dicsount_Negative_Total()
		{
			// Arrange (시나리오를 설정한다.)
			IDiscountHelper target = getTestObject();

			// Act (작업을 시도한다.)
			target.ApplyDiscount(-1);
		}
	}
}
