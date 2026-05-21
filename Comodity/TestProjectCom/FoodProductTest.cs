using System;
using System.Runtime.CompilerServices;
using Commodity;

namespace Commodity.UnitTest
{
    [TestFixture]
    public class FoodProductTest
    {
        [Test]
        public void FoodProductGetInfoTest()
        {
            var apple = new FoodProduct(
                CommodityArticle.Art1,
                "Яблоко",
                20,
                1,
                1,
                1,
                new DateTime(2020, 1, 1),
                1000,
                PackageCharacteristic.common,
                100,
                10,
                4);

            var info = apple.GetInfo();

            Assert.That(info.Length, Is.EqualTo(7));
            Assert.That(info[5], Is.EqualTo("Срок годности: 10 дней."));
            Assert.That(info[6], Is.EqualTo("Температура хранения: 4 C."));
        }
    }
}