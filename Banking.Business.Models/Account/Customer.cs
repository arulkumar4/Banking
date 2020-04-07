using System;
using System.Collections.Generic;

namespace Banking.Business.Models.Account
{
    public class Customer : CustomerAccount
    {
        public Customer() : this(0) { }
        public Customer(int customerId) => CustomerId = customerId;
        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string Mail { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int EmployeeId { get; set; }
        public string Role { get; set; }
        public string LoggedOn { get; set; }


    }
}

