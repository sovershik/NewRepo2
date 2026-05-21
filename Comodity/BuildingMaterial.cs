using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commodity
{
    public class BuildingMaterial : CommodityClass
    {
        public bool CanBeStoredOutside { get; set; }

        public BuildingMaterial(
            CommodityArticle article,
            string name,
            double weight,
            double length,
            double width,
            double height,
            DateTime arrivalDate,
            double price,
            PackageCharacteristic characteristic,
            int maxstack,
            bool canBeStoredOutside)
            : base(article, name, weight, length, width, height, arrivalDate, price, characteristic, maxstack)
        {
            CanBeStoredOutside = canBeStoredOutside;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[baseInfo.Length + 1];
            Array.Copy(baseInfo, info, baseInfo.Length);

            info[5] = CanBeStoredOutside
                ? "Возможность хранения на открытой площадке: да."
                : "Возможность хранения на открытой площадке: нет.";

            return info;
        }
    }
}