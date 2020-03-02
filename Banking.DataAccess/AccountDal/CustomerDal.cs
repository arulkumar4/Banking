using Banking.Business.Models.Account;
using Banking.DataAccess.Contracts.IAccount;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Banking.DataAccess.Account
{
    public class CustomerDal : BaseDal, ICustomerDal
    {
        public List<CustomerAccount> GetCustomerDetails(long customerId, long accountNo)
        {
            List<CustomerAccount> CustomerAcc = new List<CustomerAccount>();
            using (var dataset = GetDataset(ProcedureNames.Account.GetCustomerDetails, customerId,accountNo))
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
        public int AddNewCustomer(Customer customer)
        {
                var status = GetValue<int>(ProcedureNames.Account.AddNewCustomers,
                new SqlParameter("@FirstName", customer.FirstName),
                new SqlParameter("@LastName", customer.LastName),
                new SqlParameter("@Address", customer.Address),
                new SqlParameter("@ContactNumber", customer.ContactNumber),
                new SqlParameter("@Gender", customer.Gender),
                new SqlParameter("@Gender", customer.Gender),
                new SqlParameter("@Dob", customer.Dob),
                new SqlParameter("@Password", customer.Password),
                new SqlParameter("@AccType", customer.AccountTypeId)
                );
                return status;
        }

        public int UpdateCustomerDetails(Customer customer)
        {
            var status = GetValue<int>(ProcedureNames.Account.UpdateCustomerDetails,
            new SqlParameter("@CustomerId", customer.CustomerId),
            new SqlParameter("@Password", customer.Password),
            new SqlParameter("@FirstName", customer.FirstName),
            new SqlParameter("@LastName", customer.LastName),
            new SqlParameter("@Address", customer.Address),
            new SqlParameter("@ContactNumber", customer.ContactNumber),
            new SqlParameter("@Mail", customer.Mail)
            );
            return status;
        }
        
    }
}
