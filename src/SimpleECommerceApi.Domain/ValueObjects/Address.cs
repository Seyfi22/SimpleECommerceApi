using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleECommerceApi.Domain.ValueObjects
{
    public class Address : IEquatable<Address>
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }

        public Address(string street, string city, string state, string postalCode, string country)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street cannot be empty.", nameof(street));

            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City cannot be empty.", nameof(city));

            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country cannot be empty.", nameof(country));

            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;
        }

        public bool Equals(Address other)
        {
            if (other is null) return false;

            return Street == other.Street &&
                   City == other.City &&
                   State == other.State &&
                   PostalCode == other.PostalCode &&
                   Country == other.Country;
        }

        public override bool Equals(object obj) => Equals(obj as Address);
        public override int GetHashCode() => HashCode.Combine(Street, City, State, PostalCode, Country);

        public override string ToString()
        {
            return $"{Street}, {City}, {State} {PostalCode}, {Country}";
        }
    }
}
