using Banking.Business.Models.Account;
using System.Collections.Generic;

namespace Banking.Business.Contracts.IAccount
{
    public interface ICustomerBl
    {
        List<CustomerAccount> GetCustomerDetails(long customerId, long accountNo);
        int AddNewCustomer(Customer customer);
        int UpdateCustomerDetails(Customer customer);
    }
}
