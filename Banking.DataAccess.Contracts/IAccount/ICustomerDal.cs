using Banking.Business.Models.Account;
using System.Collections.Generic;

namespace Banking.DataAccess.Contracts.IAccount
{
    public interface ICustomerDal
    {
        List<CustomerAccount> GetCustomerDetails(long customerId, long accountNo);
        int AddNewCustomer(Customer customer);
        int UpdateCustomerDetails(Customer customer);
    }
}
