using Banking.Business.Models.Account;
using Banking.DataAccess.Contracts.IAccount;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Banking.DataAccess.Account
{
    public class AccountTypeDal : BaseDal, IAccountTypeDal
    {
        public List<AccountType> GetAllAccountType()
        {
            List<AccountType> acctype = new List<AccountType>();
            using (var dataset = GetDataset(ProcedureNames.Account.GetAccountTypesDetails))
            {
                var accountTable = dataset.Tables[0];
                var accountTableDetail = accountTable.AsEnumerable();

                foreach (var accountRow in accountTableDetail)
                {
                    acctype.Add(PopulateData<AccountType>(accountRow));
                }
            }
            return acctype;
        }
        public List<AccountType> GetOneAccountType(int accounttypeId, string accounttypeName)
        {
            List<AccountType> acctype = new List<AccountType>();
            using (var dataset = GetDataset(ProcedureNames.Account.GetOneAccountType, accounttypeId, accounttypeName))
            {
                var accountTable = dataset.Tables[0];
                var accountTableDetail = accountTable.AsEnumerable();

                foreach (var accountRow in accountTableDetail)
                {
                    acctype.Add(PopulateData<AccountType>(accountRow));
                }
            }
            return acctype;
        }
        public string AddNewAccountType(AccountType acctype)
        {
            var status = GetValue<string>(ProcedureNames.Account.InsertNewAccountType,
            new SqlParameter("@AccountType", acctype.Type),
            new SqlParameter("@MinimumBalance", acctype.MinimumBalance),
            new SqlParameter("@TransactionLimit", acctype.TransactionLimit)
            );
            return status;
        }
        public string UpdateAccountType(AccountType acctype)
        {
            
            var status = GetValue<string>(ProcedureNames.Account.UpdateAccountType,
            new SqlParameter("@AccId", acctype.Id),
            new SqlParameter("@AccountType", acctype.Type),
            new SqlParameter("@MinimumBalance", acctype.MinimumBalance),
            new SqlParameter("@TransactionLimit", acctype.TransactionLimit)
            );
            return status;
        }
        public string DeleteAccountType(AccountType acctype)
        {
            var status = GetValue<string>(ProcedureNames.Account.DeleteAccountType,
            new SqlParameter("@AccId", acctype.Id),
            new SqlParameter("@AccountType", acctype.Type)
            );
            return status;
        }
    }
}
