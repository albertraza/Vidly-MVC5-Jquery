using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSuscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

        public List<Customer> GetCustomer()
        {
            var list = new List<Customer>
            {
            new Customer{Name = "Albert", Id = 1},
            new Customer {Name = "Jose", Id = 2},
            new Customer {Name = "Juan", Id = 3}
            };
            return list;
        }
    }
}