using Banking.Business.Models.Account;
using System.Collections.Generic;

namespace Banking.DataAccess.Contracts.IAccount
{
    public interface IAccountDal
    {
        List<Customer> GetAllCustomersAccount();
        List<Customer> GetCustomerAccount(long customerId, long accountNo);
        List<Customer> GetCustomerAccountbyAccountType(string accountType);
        List<Customer> GetCustomerAccountbyBalance(decimal balance);
        List<Customer> GetCustomerByAccountStatus(bool status);
        List<Customer> UpdateCustomerByEmployee(Customer customer);
        string UpdateAccountPassword(Customer customer);
        string DeleteCustomerAccount(long number, string pass);

    }
}
