using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleECommerceApi.Domain.Enums;
using SimpleECommerceApi.Domain.ValueObjects;

namespace SimpleECommerceApi.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public OrderStatus Status { get; private set; }
        public Money TotalAmount { get; private set; }  // decimal yox, Money

        private readonly List<OrderItem> _orderItems = new();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public Order(Guid customerId)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            OrderDate = DateTime.UtcNow;
            Status = OrderStatus.Pending;
            TotalAmount = new Money(0, "USD");  // sıfırla başla
        }

        public void AddOrderItem(Product product, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            if (!product.IsAvailable)
                throw new InvalidOperationException("Product is not available.");

            if (product.StockQuantity < quantity)
                throw new InvalidOperationException("Not enough stock for the product.");

            product.ReduceStock(quantity);

            var orderItem = new OrderItem(this.Id, product.Id, quantity, product.Price);
            _orderItems.Add(orderItem);

            // TotalAmount = TotalAmount + orderItem.TotalPrice; üçün + operator overload edilməlidir
            TotalAmount += orderItem.TotalPrice;
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
        }
    }

    // Sifariş statusları üçün Enum (Enums qovluğunda ayrıca saxlanıla bilər)
}

