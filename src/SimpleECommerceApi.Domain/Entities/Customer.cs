using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleECommerceApi.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        private string PasswordHash { get; set; }
        // Ünvanlar ValueObject və ya ayrıca Entity kimi ayrı idarə oluna bilər, sadəlik üçün burda yox.

        public Customer(string fullName, string email, string passwordHash)
        {
            Id = Guid.NewGuid();

            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("FullName cannot be empty.");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty.");

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("PasswordHash cannot be empty.");

            FullName = fullName;
            Email = email;
            PasswordHash = passwordHash;
        }

        public void UpdateFullName(string newFullName)
        {
            if (string.IsNullOrWhiteSpace(newFullName))
                throw new ArgumentException("FullName cannot be empty.");

            FullName = newFullName;
        }

        public void UpdateEmail(string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail))
                throw new ArgumentException("Email cannot be empty.");

            Email = newEmail;
        }

        public void UpdatePasswordHash(string newPasswordHash)
        {
            if (string.IsNullOrWhiteSpace(newPasswordHash))
                throw new ArgumentException("PasswordHash cannot be empty.");

            PasswordHash = newPasswordHash;
        }
    }
}
