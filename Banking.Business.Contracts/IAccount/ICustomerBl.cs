using Banking.Business.Models.Account;
using System.Collections.Generic;

namespace Banking.Business.Contracts.IAccount
{
    public interface ICustomerBl
    {
        List<CustomerAccount> GetCustomerDetails(long customerId, long accountNo);

        bool AddNewCustomer(Customer customer);
        bool AddNewCustomerByEmployee(Customer customer);

        bool UpdateCustomerDetails(Customer customer);
    }
}
