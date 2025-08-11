using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleECommerceApi.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; private set; }       // Unikal identifikator
        public string Name { get; private set; }   // Kateqoriya adı
        public string? Description { get; private set; } // İstəyə bağlı təsvir

        // Konstruktor
        public Category(string name, string? description = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }

        // Adı dəyişmək üçün metod
        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Category name cannot be empty.");

            Name = newName;
        }

        // Təsviri dəyişmək üçün metod
        public void UpdateDescription(string? newDescription)
        {
            Description = newDescription;
        }
    }
}
