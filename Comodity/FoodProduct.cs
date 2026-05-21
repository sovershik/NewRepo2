using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commodity
{
    public class FoodProduct : CommodityClass
    {
        public int ShelfLifeDays { get; set; }
        public double StorageTemperature { get; set; }

        public FoodProduct(
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
            int shelfLifeDays,
            double storageTemperature)
            : base(article, name, weight, length, width, height, arrivalDate, price, characteristic, maxstack)
        {
            ShelfLifeDays = shelfLifeDays;
            StorageTemperature = storageTemperature;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[baseInfo.Length + 2];
            Array.Copy(baseInfo, info, baseInfo.Length);

            info[5] = $"Срок годности: {ShelfLifeDays} дней.";
            info[6] = $"Температура хранения: {StorageTemperature} C.";

            return info;
        }
    }
}