using System;
using System.Runtime.CompilerServices;
using Commodity;

namespace Commodity.UnitTest
{
    [TestFixture]
    public class CommodityUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var apple = CreateTestPerson();

            Assert.That(apple.Name, Is.EqualTo("Яблоко"));
            Assert.That(apple.Article, Is.EqualTo(CommodityArticle.Art1));
            Assert.That(apple.Weight, Is.EqualTo(20));
            Assert.That(apple.Length, Is.EqualTo(1));
            Assert.That(apple.Width, Is.EqualTo(1));
            Assert.That(apple.Height, Is.EqualTo(1));
            Assert.That(apple.Price, Is.EqualTo(1000));
            Assert.That(apple.Characteristic, Is.EqualTo(PackageCharacteristic.common));
            Assert.That(apple.MaxStack, Is.EqualTo(100));
        }

        [Test]
        public void GetInfoTest()
        {
            var apple = CreateTestPerson();
            var info = apple.GetInfo();
            apple.ArrivalDate = new DateTime(2020, 1, 1);

            Assert.That(info.Length, Is.EqualTo(5));
            Assert.That(info[0], Is.EqualTo("Название товара: Яблоко. Артикул: Q-16258."));
            Assert.That(info[1], Is.EqualTo("Вес товара: 20. Габариты товара: 1х1х1 см. Характеристика товара: обычный."));
            Assert.That(info[2], Is.EqualTo("Цена товара: 1000 руб."));
            Assert.That(info[3], Is.EqualTo("Максимальное число товара в стопке: 100 шт."));
            Assert.That(info[4], Is.EqualTo("Дата прибытия товара: 01.01.2020 0:00:00."));

        }

        private Commodity CreateTestPerson()
        {
            return new Commodity(CommodityArticle.Art1, "Яблоко", 20, 1, 1, 1, new DateTime(2020, 1, 1), 1000, PackageCharacteristic.common, 100);
        }
    }
}