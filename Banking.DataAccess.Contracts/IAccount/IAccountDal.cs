using Banking.Business.Models.Account;
using System.Collections.Generic;

namespace Banking.DataAccess.Contracts.IAccount
{
    public interface IAccountDal
    {
        List<CustomerAccount> GetAllCustomersAccount();
        List<CustomerAccount> GetCustomerAccount(long customerId, long accountNo , string password);
        List<CustomerAccount> GetCustomerAccountbyAccountType(string accountType);
        List<CustomerAccount> GetCustomerAccountbyBalance(decimal balance);
        List<CustomerAccount> GetCustomerByAccountStatus(bool status);
        string UpdateAccountPassword(long accnumber, string oldpassword, string newpassword);
        string DeleteCustomerAccount(CustomerAccount account);
    }
}
