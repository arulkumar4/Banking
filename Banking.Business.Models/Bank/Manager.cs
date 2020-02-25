using System;
using System.Collections.Generic;

namespace Banking.Business.Models
{
    public class Manager
    {
        public Manager() : this(0) { }
        public Manager(int managerId) => ManagerId = managerId;
        public int ManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public DateTimeOffset Dob { get; set; }
        public List<Address> AddressList { get; set; }
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
