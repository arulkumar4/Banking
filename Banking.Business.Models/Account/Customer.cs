using System;
using System.Collections.Generic;

namespace Banking.Business.Models.Account
{
    public class Customer
    {
        public Customer() : this(0) { }
        public Customer(int customerId) => CustomerId = customerId;
        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactNumber { get; set; }
        public string Email { get; set; }
        public DateTimeOffset Dob { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int EmployeeId { get; set; }
        public string FullName
        {
            get
            {
                string fullName = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(LastName))
                    {
                        fullName += ", ";
                    }
                    fullName += FirstName;
                }
                return fullName;
            }
        }
    }
}

