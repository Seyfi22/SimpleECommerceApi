using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleECommerceApi.Domain.ValueObjects;

namespace SimpleECommerceApi.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Money Price { get; private set; }       // Burda decimal yox, Money tipi olacaq
        public int StockQuantity { get; private set; }
        public bool IsAvailable => StockQuantity > 0;

        public Product(string name, string description, Money price, int stockQuantity)
        {
            if (price == null) throw new ArgumentNullException(nameof(price));
            if (stockQuantity < 0) throw new ArgumentException("Stock quantity cannot be negative.", nameof(stockQuantity));

            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public void UpdatePrice(Money newPrice)
        {
            if (newPrice == null) throw new ArgumentNullException(nameof(newPrice));

            Price = newPrice;
        }

        public void AddStock(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            StockQuantity += amount;
        }

        public void ReduceStock(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            if (amount > StockQuantity)
                throw new InvalidOperationException("Not enough stock available.");

            StockQuantity -= amount;
        }

        public void MarkAsUnavailable()
        {
            StockQuantity = 0;
        }
    }
}
