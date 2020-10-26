using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public partial class OrderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(OrderId)}: {OrderId}, {nameof(ProductId)}: {ProductId}, {nameof(UnitPrice)}: {UnitPrice}, {nameof(Quantity)}: {Quantity}, {nameof(Discount)}: {Discount}";
        }
    }
}
