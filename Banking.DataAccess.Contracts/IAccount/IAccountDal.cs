using Banking.Business.Models.Account;
using System.Collections.Generic;

namespace Banking.DataAccess.Contracts.IAccount
{
    public interface IAccountDal
    {
        List<CustomerAccount> GetCustomerAccount(long customerId, long accountNo );
    }
}
