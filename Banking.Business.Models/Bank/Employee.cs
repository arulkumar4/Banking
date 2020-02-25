using System;
using System.Collections.Generic;

namespace Banking.Business.Models
{
    public class Employee
    {
        public Employee() : this(0) { }
        public Employee(int employeeId) => EmployeeId = employeeId;
        public int EmployeeId { get; set; }
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
