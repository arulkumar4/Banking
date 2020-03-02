using Banking.Business.Contracts;
using Banking.DataAccess.Contracts.IAccount;
using Banking.Business.Contracts.IAccount;
using System.Collections.Generic;
using Banking.Business.Models.Account;

namespace Banking.Business.Account
{
    public class AccountTypeBl : IAccountTypeBl
    {
        private readonly IAccountTypeDal _accountTypeDal;

        public AccountTypeBl() { }


        public AccountTypeBl(IAccountTypeDal accountTypeDal)
        {
            _accountTypeDal = accountTypeDal;
        }

        public List<AccountType>GetAllAccountType()
        {
            return _accountTypeDal.GetAllAccountType();
        }
        public List<AccountType> GetOneAccountType(int acctypeId, string accType )
        {
            return _accountTypeDal.GetOneAccountType(acctypeId,accType);
        }
        public bool AddNewAccountType(AccountType acctype)
        {
            return _accountTypeDal.AddNewAccountType(acctype);
        }
        public bool UpdateAccountType(AccountType acctype)
        {
            return _accountTypeDal.UpdateAccountType(acctype);
        }
        public bool DeleteAccountType(AccountType acctype)
        {
            return _accountTypeDal.DeleteAccountType(acctype);
        }
    }
}
