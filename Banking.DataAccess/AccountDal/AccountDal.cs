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
        public List<Customer> GetAllCustomersAccount()
        {
            List<Customer> CustomerAcc = new List<Customer>();
            using (var dataset = GetDataset(ProcedureNames.Account.GetAllCustomers))
            {
                var accountTable = dataset.Tables[0];
                var accountTableDetail = accountTable.AsEnumerable();

                foreach (var accountRow in accountTableDetail)
                {
                    CustomerAcc.Add(PopulateData<Customer>(accountRow));
                }
            }
            return CustomerAcc;
        }
        public List<Customer> GetCustomerAccount(long customerId, long accountNo, string password)
        {
            List<Customer> CustomerAcc = new List<Customer>();
            using (var dataset = GetDataset(ProcedureNames.Account.GetOneCustomerDetails, customerId, accountNo, password))
            {
                var accountTable = dataset.Tables[0];
                var accountTableDetail = accountTable.AsEnumerable();

                foreach (var accountRow in accountTableDetail)
                {
                    CustomerAcc.Add(PopulateData<Customer>(accountRow));
                }
            }
            return CustomerAcc;
        }
        public List<Customer> GetCustomerAccountbyAccountType(string accountType)
        {
            List<Customer> CustomerAcc = new List<Customer>();
            using (var dataset = GetDataset(ProcedureNames.Account.GetAccountByAccountType, accountType))
            {
                var accountTable = dataset.Tables[0];
                var accountTableDetail = accountTable.AsEnumerable();

                foreach (var accountRow in accountTableDetail)
                {
                    CustomerAcc.Add(PopulateData<Customer>(accountRow));
                }
            }
            return CustomerAcc;
        }
        public List<Customer> GetCustomerAccountbyBalance(decimal balance)
        {
            List<Customer> CustomerAcc = new List<Customer>();
            using (var dataset = GetDataset(ProcedureNames.Account.GetAccountByBalance, balance))
            {
                var accountTable = dataset.Tables[0];
                var accountTableDetail = accountTable.AsEnumerable();

                foreach (var accountRow in accountTableDetail)
                {
                    CustomerAcc.Add(PopulateData<Customer>(accountRow));
                }
            }
            return CustomerAcc;
        }
        public List<Customer> GetCustomerByAccountStatus(bool status)
        {
            List<Customer> CustomerAcc = new List<Customer>();
            using (var dataset = GetDataset(ProcedureNames.Account.GetCustomersByAccountStatus, status))
            {
                var accountTable = dataset.Tables[0];
                var accountTableDetail = accountTable.AsEnumerable();

                foreach (var accountRow in accountTableDetail)
                {
                    CustomerAcc.Add(PopulateData<Customer>(accountRow));
                }
            }
            return CustomerAcc;
        }
        public string UpdateAccountPassword(long accnumber, string oldpassword, string newpassword)
        {
            var status = GetValue<string>(ProcedureNames.Account.UpdateAccountPassword,
            new SqlParameter("@Number", accnumber),
            new SqlParameter("@OldPassword", oldpassword),
            new SqlParameter("@NewPassword", newpassword)
            );
            return status;
        }

        public string DeleteCustomerAccount(Customer account)
        {
            var status = GetValue<string>(ProcedureNames.Account.DeleteCustomerAccount,
            new SqlParameter("@Number", account.Number),
            new SqlParameter("@Password", account.Password)
            );
            return status;
        }
    }
}
