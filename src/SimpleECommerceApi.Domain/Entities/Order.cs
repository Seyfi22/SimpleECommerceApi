using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleECommerceApi.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public OrderStatus Status { get; private set; }
        public decimal TotalAmount { get; private set; }

        // Bir sifariş bir neçə OrderItem-dən ibarət olur
        private readonly List<OrderItem> _orderItems = new();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        // Konstruktor
        public Order(Guid customerId)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            OrderDate = DateTime.UtcNow;
            Status = OrderStatus.Pending;
            TotalAmount = 0;
        }

        // OrderItem əlavə etmək metodu
        public void AddOrderItem(Product product, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            if (!product.IsAvailable)
                throw new InvalidOperationException("Product is not available.");

            if (product.StockQuantity < quantity)
                throw new InvalidOperationException("Not enough stock for the product.");

            // Stock-u azaldırıq
            product.ReduceStock(quantity);

            // Yeni OrderItem yaradıb siyahıya əlavə edirik
            var orderItem = new OrderItem(this.Id, product.Id, quantity, product.Price);
            _orderItems.Add(orderItem);

            // Total məbləği yeniləyirik
            TotalAmount += orderItem.UnitPrice * orderItem.Quantity;
        }

        // Sifariş statusunu yeniləmə metodu
        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
        }
    }

    // Sifariş statusları üçün Enum (Enums qovluğunda ayrıca saxlanıla bilər)
    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Shipped,
        Delivered,
        Cancelled
    }
}

