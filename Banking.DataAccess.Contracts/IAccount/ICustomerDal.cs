﻿using Banking.Business.Models.Account;
using System.Collections.Generic;

namespace Banking.DataAccess.Contracts.IAccount
{
    public interface ICustomerDal
    {
        List<Customer> GetCustomerDetails(long customerId, long accountNo);
        string AddNewCustomer(Customer customer);
        string UpdateCustomerDetails(Customer customer);
    }
}