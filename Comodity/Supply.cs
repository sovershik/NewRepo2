using System;
using System.Collections;
using System.Collections.Generic;

namespace Commodity
{
    public class Supply : IEnumerable<CommodityClass>
    {
        public string Supplier { get; private set; }
        public int SupplyNumber { get; private set; }
        public DateTime SupplyDate { get; private set; }
        public List<CommodityClass> Goods { get; private set; }

        public Supply(string supplier, int supplyNumber, DateTime supplyDate, List<CommodityClass> goods)
        {
            Supplier = supplier;
            SupplyNumber = supplyNumber;
            SupplyDate = supplyDate;
            Goods = goods ?? new List<CommodityClass>();
        }

        public IEnumerator<CommodityClass> GetEnumerator()
        {
            return Goods.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
