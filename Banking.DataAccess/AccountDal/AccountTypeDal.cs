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
        public bool AddNewAccountType(AccountType acctype)
        {
            bool result = false;
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@AccountType", acctype.Type);
            p[1] = new SqlParameter("@MinimumBalance", acctype.MinimumBalance);
            p[2] = new SqlParameter("@TransactionLimit", acctype.TransactionLimit);
            int res = GetResult(ProcedureNames.Account.InsertNewAccountType, p);
            if (res > 0)
            {
                result = true;
            }
            return result;
        }
        public bool UpdateAccountType(AccountType acctype)
        {
            bool result = false;
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@AccId", acctype.Id);
            p[1] = new SqlParameter("@AccountType", acctype.Type);
            p[2] = new SqlParameter("@MinimumBalance", acctype.MinimumBalance);
            p[3] = new SqlParameter("@TransactionLimit", acctype.TransactionLimit);
            int res = GetResult(ProcedureNames.Account.UpdateAccountType, p);
            if (res > 0)
            {
                result = true;
            }
            return result;
        }
        public bool DeleteAccountType(AccountType acctype)
        {
            bool result = false;
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@AccId", acctype.Id);
            p[1] = new SqlParameter("@AccountType", acctype.Type);
            int res = GetResult(ProcedureNames.Account.DeleteAccountType, p);
            if (res > 0)
            {
                result = true;
            }
            return result;
        }

    }
}
