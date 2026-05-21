using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Commodity
{
    public class CommodityClass : IComparable<CommodityClass>
    {
        public readonly CommodityArticle Article; //артикул, из списка
        public string Name { get; set; } //наименование товара, строка
        public double Weight { get; set; }//вес товара, дабл
        public double Length { get; set; }//длина товара, дабл
        public double Width { get; set; }//широта товара, дабл
        public double Height { get; set; }//высота товара, дабл

        public DateTime ArrivalDate { get; set; } //дата прибытия товара, дата
        public double Price { get; set; }//цена товара, дабл
        public readonly PackageCharacteristic Characteristic;//характеристики товара, из списка
        public int MaxStack { get; set; }//максимальное число в стопке, целое



        public CommodityClass(
            CommodityArticle article,
            string name,
            double weight,
            double length,
            double widh,
            double height,
            DateTime arrivalDate,
            double price,
            PackageCharacteristic characteristic,
            int maxstack
        )
        {
            Article = article;
            Name = name;
            Weight = weight;
            Length = length;
            Width = widh;
            Height = height;
            ArrivalDate = arrivalDate;
            Price = price;
            Characteristic = characteristic;
            MaxStack = maxstack;
        }


        public int CompareTo(CommodityClass other)
        {
            if (other == null) return 1;
            return string.Compare(Name, other.Name, StringComparison.CurrentCulture);
        }


        public virtual string[] GetInfo()
        {
            string art;
            if (Article == CommodityArticle.Art1) { art = "Q-16258"; }
            else if (Article == CommodityArticle.Art2) { art = "O-90872"; }
            else { art = "H-42424"; }

            string charac;
            if (Characteristic == PackageCharacteristic.afraidOfDampness) { charac = "боится влажности"; }
            else if (Characteristic == PackageCharacteristic.fragile) { charac = "хрупкий"; }
            else { charac = "обычный"; }

            var info = new string[5];
            info[0] = $"Название товара: {Name}. Артикул: {art}.";
            info[1] = $"Вес товара: {Weight}. Габариты товара: {Length}х{Width}х{Height} см. Характеристика товара: {charac}.";
            info[2] = $"Цена товара: {Price} руб.";
            info[3] = $"Максимальное число товара в стопке: {MaxStack} шт.";
            info[4] = $"Дата прибытия товара: {ArrivalDate}.";
            return info;
        }

    }
}


