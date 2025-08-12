using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleECommerceApi.Domain.ValueObjects;

namespace SimpleECommerceApi.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public Money UnitPrice { get; private set; }  // decimal yox, Money

        public OrderItem(Guid orderId, Guid productId, int quantity, Money unitPrice)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            if (unitPrice == null)
                throw new ArgumentNullException(nameof(unitPrice));

            Id = Guid.NewGuid();
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        // Ümumi məbləğ hesablayan property
        public Money TotalPrice => UnitPrice * Quantity;
    }
}
