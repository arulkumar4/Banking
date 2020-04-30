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
       
        public string UpdateAccountPassword(Customer customer)
        {
            var status = GetValue<string>(ProcedureNames.Account.UpdateAccountPassword,
            new SqlParameter("@Number", customer.Number),
            new SqlParameter("@OldPassword", customer.Password),
            new SqlParameter("@NewPassword", customer.NewPassword)
            );
            return status;
        }

        public string DeleteCustomerAccount(long number)
        {
            var status = GetValue<string>(ProcedureNames.Account.DeleteCustomerAccount,
            new SqlParameter("@Number", number)
            );
            return status;
        }
    }
}
