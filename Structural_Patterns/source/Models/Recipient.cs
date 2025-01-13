using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.Models
{
    public class Recipient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public Recipient() { }

        public Recipient(string firstName, string lastName, string street, string number, string city, string zipCode, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            Number = number;
            City = city;
            ZipCode = zipCode;
            Country = country;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, {Street} {Number}, {City}, {ZipCode}, {Country}";
        }
    }
}
