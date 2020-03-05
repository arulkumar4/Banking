using Banking.Business.Models.Account;
using System.Collections.Generic;

namespace Banking.Business.Contracts.IAccount
{
    public interface IAccountTypeBl
    {
        List<AccountType> GetAllAccountType();
        List<AccountType> GetOneAccountType(int accounttypeId, string accounttypeName);
        string AddNewAccountType(AccountType acctype);
        string UpdateAccountType(AccountType acctype);
        string DeleteAccountType(AccountType acctype);

    }
}