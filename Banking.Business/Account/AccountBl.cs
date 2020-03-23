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

        public List<Customer> GetAllCustomerAccounts()
        {
            return _accountDal.GetAllCustomersAccount();
        }

        public List<Customer> GetCustomerAccounts(long customerId, long accountNo, string password)
        {
            return _accountDal.GetCustomerAccount(customerId,accountNo, password);
        }
        public List<Customer> GetAccountbyAccountType(string accountType)
        {
            return _accountDal.GetCustomerAccountbyAccountType(accountType);
        }
        public List<Customer> GetAccountByBalance(decimal balance)
        {
            return _accountDal.GetCustomerAccountbyBalance(balance);
        }
        public List<Customer> GetCustomerByAccountStatus(bool status)
        {
            return _accountDal.GetCustomerByAccountStatus(status);
        }
        public string UpdateAccountPassword(long accnumber, string oldpassword, string newpassword)
        {
            return _accountDal.UpdateAccountPassword(accnumber,oldpassword,newpassword);
        }
        public string DeleteCustomerAccount(Customer account)
        {
            return _accountDal.DeleteCustomerAccount(account);
        }
    }

}

