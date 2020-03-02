using Banking.Business.Models.Account;
using System.Collections.Generic;

namespace Banking.DataAccess.Contracts.IAccount
{
    public interface IAccountTypeDal
    {
        List<AccountType> GetAllAccountType();
        List<AccountType> GetOneAccountType(int accounttypeId, string accounttypeName);
        bool AddNewAccountType(AccountType acctype);
        bool UpdateAccountType(AccountType acctype);
        bool DeleteAccountType(AccountType acctype);
    }
}
