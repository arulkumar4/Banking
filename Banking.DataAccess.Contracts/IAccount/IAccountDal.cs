using Banking.Business.Models.Account;
using System.Collections.Generic;

namespace Banking.DataAccess.Contracts.IAccount
{
    public interface IAccountDal
    {
        List<Customer> GetAllCustomersAccount();
        List<Customer> GetCustomerAccount(long customerId, long accountNo);
        string UpdateAccountPassword(Customer customer);
        string DeleteCustomerAccount(long number, string pass);
    }
}
