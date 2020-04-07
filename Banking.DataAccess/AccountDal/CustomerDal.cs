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
        public List<Customer> GetCustomerDetails(long customerId, long accountNo)
        {
            List<Customer> CustomerAcc = new List<Customer>();
            using (var dataset = GetDataset(ProcedureNames.Account.GetCustomerDetails, customerId,accountNo))
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
        public List<Customer> AddNewCustomer(Customer customer)
        {
            List<Customer> newCustomer = new List<Customer>();
            using (var dataset = GetDataset(ProcedureNames.Account.AddNewCustomers,
                    new SqlParameter("@FirstName", customer.FirstName),
                    new SqlParameter("@LastName", customer.LastName),
                    new SqlParameter("@Address", customer.Address),
                    new SqlParameter("@ContactNumber", customer.ContactNumber),
                    new SqlParameter("@Gender", customer.Gender),
                    new SqlParameter("@Dob", customer.Dob),
                    new SqlParameter("@Mail", customer.Mail),
                    new SqlParameter("@Balance", customer.Balance),
                    new SqlParameter("@Password", customer.Password),
                    new SqlParameter("@AccType", customer.AccountType),
                    new SqlParameter("@EmpId", customer.EmployeeId)))
            {
                var accountTable = dataset.Tables[0];
                var accountTableDetail = accountTable.AsEnumerable();

                foreach (var accountRow in accountTableDetail)
                {
                newCustomer.Add(PopulateData<Customer>(accountRow));
                }
            }
            return newCustomer;
        }

        public string UpdateCustomerDetails(Customer customer)
        {
            var status = GetValue<string>(ProcedureNames.Account.UpdateCustomerDetails,
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

        public long GetCustomerId(string mail)
        {
            var id = GetValue<long>(ProcedureNames.Account.GetCustomerId,
                  new SqlParameter("email", mail)
                  );
            return id;
        }
    }
}
