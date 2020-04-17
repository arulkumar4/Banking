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
        public List<Customer> GetCustomerAccount(long customerId, long accountNo)
        {
            List<Customer> CustomerAcc = new List<Customer>();
            using (var dataset = GetDataset(ProcedureNames.Account.GetCustomerDetails, customerId, accountNo))
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
        public List<Customer> UpdateCustomerByEmployee(Customer customer)
        {
            List<Customer> updateCustomer = new List<Customer>();
            using (var dataset = GetDataset(ProcedureNames.Account.UpdateCustomerDetailsByEmployee,
                    new SqlParameter("@CustomerId", customer.CustomerId),
                    new SqlParameter("@FirstName", customer.FirstName),
                    new SqlParameter("@LastName", customer.LastName),
                    new SqlParameter("@Address", customer.Address),
                    new SqlParameter("@ContactNumber", customer.ContactNumber),
                    new SqlParameter("@Mail", customer.Mail)))

            {
                var accountTable = dataset.Tables[0];
                var accountTableDetail = accountTable.AsEnumerable();

                foreach (var accountRow in accountTableDetail)
                {
                    updateCustomer.Add(PopulateData<Customer>(accountRow));
                }
            }
            return updateCustomer;
        }

        public string UpdateAccountPassword(Customer customer)
        {
            var status = GetValue<string>(ProcedureNames.Account.UpdateAccountPassword,
            new SqlParameter("@Number", customer.Number),
            new SqlParameter("@OldPassword", customer.Password),
            new SqlParameter("@NewPassword", customer.NewPassword)
            );
            return status;
        }

        public string DeleteCustomerAccount(long number, string pass)
        {
            var status = GetValue<string>(ProcedureNames.Account.DeleteCustomerAccount,
            new SqlParameter("@Number", number),
            new SqlParameter("@Password", pass)
            );
            return status;
        }
    }
}
