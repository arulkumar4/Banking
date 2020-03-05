using Banking.Business.Models.Account;
using System.Collections.Generic;

namespace Banking.Business.Contracts.IAccount
{
    public interface ICustomerBl
    {
        List<CustomerAccount> GetCustomerDetails(long customerId, long accountNo);
        string AddNewCustomer(Customer customer);
        string UpdateCustomerDetails(Customer customer);
    }
}
