using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Commodity;

namespace Commodity.UnitTest
{
    [TestFixture]
    public class CommodityInterfaceTests
    {
        [Test]
        public void CompareTo_SortsByNameAlphabetically()
        {
            var list = new List<CommodityClass>
            {
                new CommodityClass(CommodityArticle.Art1, "Яблоко", 1, 1, 1, 1, DateTime.Now, 10, PackageCharacteristic.common, 1),
                new CommodityClass(CommodityArticle.Art2, "Апельсин", 1, 1, 1, 1, DateTime.Now, 20, PackageCharacteristic.common, 1),
                new CommodityClass(CommodityArticle.Art3, "Банан", 1, 1, 1, 1, DateTime.Now, 30, PackageCharacteristic.common, 1)
            };

            list.Sort();

            Assert.That(list[0].Name, Is.EqualTo("Апельсин"));
            Assert.That(list[1].Name, Is.EqualTo("Банан"));
            Assert.That(list[2].Name, Is.EqualTo("Яблоко"));
        }

        [Test]
        public void Supply_StoresPropertiesCorrectly()
        {
            var goods = new List<CommodityClass>
            {
                new CommodityClass(CommodityArticle.Art1, "Товар1", 1, 1, 1, 1, DateTime.Now, 10, PackageCharacteristic.common, 1)
            };

            var supply = new Supply("ООО Поставщик", 15, new DateTime(2026, 5, 21), goods);

            Assert.That(supply.Supplier, Is.EqualTo("ООО Поставщик"));
            Assert.That(supply.SupplyNumber, Is.EqualTo(15));
            Assert.That(supply.SupplyDate, Is.EqualTo(new DateTime(2026, 5, 21)));
            Assert.That(supply.Goods.Count, Is.EqualTo(1));
        }

        [Test]
        public void Supply_EnumerationWorks()
        {
            var goods = new List<CommodityClass>
            {
                new CommodityClass(CommodityArticle.Art1, "Яблоко", 1, 1, 1, 1, DateTime.Now, 10, PackageCharacteristic.common, 1),
                new CommodityClass(CommodityArticle.Art2, "Банан", 1, 1, 1, 1, DateTime.Now, 20, PackageCharacteristic.common, 1)
            };

            var supply = new Supply("ООО Поставщик", 15, DateTime.Now, goods);

            var names = supply.Select(x => x.Name).ToList();

            Assert.That(names, Is.EqualTo(new[] { "Яблоко", "Банан" }));
        }

        [Test]
        public void Supply_EnumerationCanBeSorted()
        {
            var goods = new List<CommodityClass>
            {
                new CommodityClass(CommodityArticle.Art1, "Яблоко", 1, 1, 1, 1, DateTime.Now, 10, PackageCharacteristic.common, 1),
                new CommodityClass(CommodityArticle.Art2, "Апельсин", 1, 1, 1, 1, DateTime.Now, 20, PackageCharacteristic.common, 1)
            };

            var supply = new Supply("ООО Поставщик", 15, DateTime.Now, goods);

            var sorted = supply.OrderBy(x => x).ToList();

            Assert.That(sorted[0].Name, Is.EqualTo("Апельсин"));
            Assert.That(sorted[1].Name, Is.EqualTo("Яблоко"));
        }
    }
}