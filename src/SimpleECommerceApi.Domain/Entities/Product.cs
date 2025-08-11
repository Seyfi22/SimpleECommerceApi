using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleECommerceApi.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }           // Unikal identifikator
        public string Name { get; private set; }       // Məhsul adı
        public string Description { get; private set; } // Məhsul təsviri
        public decimal Price { get; private set; }     // Qiymət
        public int StockQuantity { get; private set; } // Anbardakı say
        public bool IsAvailable => StockQuantity > 0; // Məhsul mövcuddurmu?

        // Konstruktor - məhsul yaradarkən əsas məlumatlar daxil edilir
        public Product(string name, string description, decimal price, int stockQuantity)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            StockQuantity = stockQuantity;
        }

        // Qiyməti dəyişmək üçün metod
        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("Price must be greater than zero.");

            Price = newPrice;
        }

        // Stok miqdarını artırmaq üçün metod
        public void AddStock(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            StockQuantity += amount;
        }

        // Stok miqdarını azaltmaq üçün metod (sifarişdə istifadə olunur)
        public void ReduceStock(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            if (amount > StockQuantity)
                throw new InvalidOperationException("Not enough stock available.");

            StockQuantity -= amount;
        }

        // Məhsulu əl ilə əlçatmaz etmək üçün metod
        public void MarkAsUnavailable()
        {
            StockQuantity = 0;
        }
    }
}
