using Banking.Business.Contracts;
using Banking.DataAccess.Contracts.IAccount;
using Banking.Business.Contracts.IAccount;
using System.Collections.Generic;
using Banking.Business.Models.Account;

namespace Banking.Business.Account
{
    public class AccountBl : IAccountBl
    {
        private readonly IAccountDal _accountDal;

        public AccountBl() { }


        public AccountBl(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public List<CustomerAccount> GetAllCustomerAccounts()
        {
            return _accountDal.GetAllCustomersAccount();
        }

        public List<CustomerAccount> GetCustomerAccounts(long customerId, long accountNo, string password)
        {
            return _accountDal.GetCustomerAccount(customerId,accountNo, password);
        }
        public List<CustomerAccount> GetAccountbyAccountType(string accountType)
        {
            return _accountDal.GetCustomerAccountbyAccountType(accountType);
        }
        public List<CustomerAccount> GetAccountByBalance(decimal balance)
        {
            return _accountDal.GetCustomerAccountbyBalance(balance);
        }
        public List<CustomerAccount> GetCustomerByAccountStatus(bool status)
        {
            return _accountDal.GetCustomerByAccountStatus(status);
        }
        public bool DeleteCustomerAccount(CustomerAccount account)
        {
            return _accountDal.DeleteCustomerAccount(account);
        }
    }

}

