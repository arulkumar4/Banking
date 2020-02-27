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

        public List<CustomerAccount> GetCustomerAccounts(long customerId, long accountNo)
        {
            return _accountDal.GetCustomerAccount(customerId,accountNo);
        }
    }

}

