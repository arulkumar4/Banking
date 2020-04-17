using Banking.Business.Models.Account;
using System.Collections.Generic;

namespace Banking.DataAccess.Contracts.IAccount
{
    public interface IAccountTypeDal
    {
        List<AccountType> GetAllAccountType();
        List<AccountType> GetOneAccountType(int accounttypeId);
        string AddNewAccountType(AccountType acctype);
        string UpdateAccountType(AccountType acctype);
        string DeleteAccountType(string accType);
    }
}
