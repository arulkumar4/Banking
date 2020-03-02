using Banking.Business.Models.Account;
using Banking.DataAccess.Contracts.IAccount;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Banking.DataAccess.Account
{
    public class AccountDal : BaseDal, IAccountDal
    {
        public List<CustomerAccount> GetAllCustomersAccount()
        {
            List<CustomerAccount> CustomerAcc = new List<CustomerAccount>();
            using (var dataset = GetDataset(ProcedureNames.Account.GetAllCustomers))
            {
                var accountTable = dataset.Tables[0];
                var accountTableDetail = accountTable.AsEnumerable();

                foreach (var accountRow in accountTableDetail)
                {
                    CustomerAcc.Add(PopulateData<CustomerAccount>(accountRow));
                }
            }
            return CustomerAcc;
        }
        public List<CustomerAccount> GetCustomerAccount(long customerId, long accountNo, string password)
        {
            List<CustomerAccount> CustomerAcc = new List<CustomerAccount>();
            using (var dataset = GetDataset(ProcedureNames.Account.GetOneCustomerDetails, customerId, accountNo, password))
            {
                var accountTable = dataset.Tables[0];
                var accountTableDetail = accountTable.AsEnumerable();

                foreach (var accountRow in accountTableDetail)
                {
                    CustomerAcc.Add(PopulateData<CustomerAccount>(accountRow));
                }
            }
            return CustomerAcc;
        }
        public List<CustomerAccount> GetCustomerAccountbyAccountType(string accountType)
        {
            List<CustomerAccount> CustomerAcc = new List<CustomerAccount>();
            using (var dataset = GetDataset(ProcedureNames.Account.GetAccountByAccountType, accountType))
            {
                var accountTable = dataset.Tables[0];
                var accountTableDetail = accountTable.AsEnumerable();

                foreach (var accountRow in accountTableDetail)
                {
                    CustomerAcc.Add(PopulateData<CustomerAccount>(accountRow));
                }
            }
            return CustomerAcc;
        }
        public List<CustomerAccount> GetCustomerAccountbyBalance(decimal balance)
        {
            List<CustomerAccount> CustomerAcc = new List<CustomerAccount>();
            using (var dataset = GetDataset(ProcedureNames.Account.GetAccountByBalance, balance))
            {
                var accountTable = dataset.Tables[0];
                var accountTableDetail = accountTable.AsEnumerable();

                foreach (var accountRow in accountTableDetail)
                {
                    CustomerAcc.Add(PopulateData<CustomerAccount>(accountRow));
                }
            }
            return CustomerAcc;
        }
        public List<CustomerAccount> GetCustomerByAccountStatus(bool status)
        {
            List<CustomerAccount> CustomerAcc = new List<CustomerAccount>();
            using (var dataset = GetDataset(ProcedureNames.Account.GetCustomersByAccountStatus))
            {
                var accountTable = dataset.Tables[0];
                var accountTableDetail = accountTable.AsEnumerable();

                foreach (var accountRow in accountTableDetail)
                {
                    CustomerAcc.Add(PopulateData<CustomerAccount>(accountRow));
                }
            }
            return CustomerAcc;
        }
        public int DeleteCustomerAccount(CustomerAccount account)
        {
            var status = GetValue<int>(ProcedureNames.Account.DeleteCustomerAccount,
            new SqlParameter("@Number", account.Number),
            new SqlParameter("@Password", account.Password)
            );
            return status;
        }
    }
}
