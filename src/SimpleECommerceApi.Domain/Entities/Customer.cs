using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleECommerceApi.Domain.ValueObjects;

namespace SimpleECommerceApi.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public Email Email { get; private set; }    // Email Value Object
        public Address Address { get; private set; }  // Address Value Object
        private string PasswordHash { get; set; }

        public Customer(string fullName, Email email, Address address, string passwordHash)
        {
            Id = Guid.NewGuid();

            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("FullName cannot be empty.");

            if (email == null)
                throw new ArgumentNullException(nameof(email));

            if (address == null)
                throw new ArgumentNullException(nameof(address));

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("PasswordHash cannot be empty.");

            FullName = fullName;
            Email = email;
            Address = address;
            PasswordHash = passwordHash;
        }

        public void UpdateFullName(string newFullName)
        {
            if (string.IsNullOrWhiteSpace(newFullName))
                throw new ArgumentException("FullName cannot be empty.");

            FullName = newFullName;
        }

        public void UpdateEmail(Email newEmail)
        {
            if (newEmail == null)
                throw new ArgumentNullException(nameof(newEmail));

            Email = newEmail;
        }

        public void UpdateAddress(Address newAddress)
        {
            if (newAddress == null)
                throw new ArgumentNullException(nameof(newAddress));

            Address = newAddress;
        }

        public void UpdatePasswordHash(string newPasswordHash)
        {
            if (string.IsNullOrWhiteSpace(newPasswordHash))
                throw new ArgumentException("PasswordHash cannot be empty.");

            PasswordHash = newPasswordHash;
        }
    }

}
