using Banking.Business.Models.Account;
using System.Collections.Generic;

namespace Banking.DataAccess.Contracts.IAccount
{
    public interface ICustomerDal
    {
        List<CustomerAccount> GetCustomerDetails(long customerId, long accountNo);
        bool AddNewCustomer(Customer customer);
        bool AddCustomerByEmployee(Customer customer);

        bool UpdateCustomerDetails(Customer customer);
    }
}
