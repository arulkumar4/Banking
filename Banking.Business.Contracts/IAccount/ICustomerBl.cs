﻿using Banking.Business.Models.Account;
using System.Collections.Generic;

namespace Banking.Business.Contracts.IAccount
{
    public interface ICustomerBl
    {
        List<Customer> GetCustomerDetails(long customerId, long accountNo);
        List<Customer> AddNewCustomer(Customer customer, int empId);
        long GetCustomerId(string mail);
        string UpdateCustomerDetails(Customer customer, long customerId);
        long GetAccnumber(string mail);
    }
}
