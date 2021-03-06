﻿using Banking.Business.Models.Account;
using System.Collections.Generic;

namespace Banking.DataAccess.Contracts.IAccount
{
    public interface ICustomerDal
    {
        List<Customer> GetCustomerDetails(long customerId, long accountNo);
        List<Customer> AddNewCustomer(Customer customer,int empId);
        string UpdateCustomerDetails(Customer customer, long customerId);
        long GetCustomerId(string mail);
        long GetAccnumber(string mail);
    }
}
