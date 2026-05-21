using System;
using System.Runtime.CompilerServices;
using Commodity;

namespace Commodity.UnitTest
{
    [TestFixture]
    public class BuildingMaterialTest
    {
        [Test]
        public void BuildingMaterialGetInfoTest()
        {
            var brick = new BuildingMaterial(
                CommodityArticle.Art2,
                "Кирпич",
                30,
                20,
                10,
                5,
                new DateTime(2020, 1, 1),
                500,
                PackageCharacteristic.common,
                50,
                true);

            var info = brick.GetInfo();

            Assert.That(info.Length, Is.EqualTo(6));
            Assert.That(info[5], Is.EqualTo("Возможность хранения на открытой площадке: да."));
        }
    }
}