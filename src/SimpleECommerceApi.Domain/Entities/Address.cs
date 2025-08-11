using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleECommerceApi.Domain.Entities
{
    public class Address
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }

        public Address(Guid customerId, string street, string city, string state, string postalCode, string country)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;

            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street cannot be empty.");
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City cannot be empty.");
            if (string.IsNullOrWhiteSpace(state))
                throw new ArgumentException("State cannot be empty.");
            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentException("PostalCode cannot be empty.");
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country cannot be empty.");

            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;
        }

        public void UpdateStreet(string newStreet)
        {
            if (string.IsNullOrWhiteSpace(newStreet))
                throw new ArgumentException("Street cannot be empty.");
            Street = newStreet;
        }

        public void UpdateCity(string newCity)
        {
            if (string.IsNullOrWhiteSpace(newCity))
                throw new ArgumentException("City cannot be empty.");
            City = newCity;
        }

        public void UpdateState(string newState)
        {
            if (string.IsNullOrWhiteSpace(newState))
                throw new ArgumentException("State cannot be empty.");
            State = newState;
        }

        public void UpdatePostalCode(string newPostalCode)
        {
            if (string.IsNullOrWhiteSpace(newPostalCode))
                throw new ArgumentException("PostalCode cannot be empty.");
            PostalCode = newPostalCode;
        }

        public void UpdateCountry(string newCountry)
        {
            if (string.IsNullOrWhiteSpace(newCountry))
                throw new ArgumentException("Country cannot be empty.");
            Country = newCountry;
        }
    }
}
