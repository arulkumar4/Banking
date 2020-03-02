using Banking.Business.Models.Account;
using System.Collections.Generic;

namespace Banking.DataAccess.Contracts.IAccount
{
    public interface IAccountTypeDal
    {
        List<AccountType> GetAllAccountType();
        List<AccountType> GetOneAccountType(int accounttypeId, string accounttypeName);
        int AddNewAccountType(AccountType acctype);
        int UpdateAccountType(AccountType acctype);
        int DeleteAccountType(AccountType acctype);
    }
}
