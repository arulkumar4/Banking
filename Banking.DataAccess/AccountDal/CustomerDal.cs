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
        public bool AddNewCustomer(Customer customer)
        {
            bool result = false;
            SqlParameter[] p = new SqlParameter[10];
            p[0] = new SqlParameter("@FirstName", customer.FirstName);
            p[1] = new SqlParameter("@LastName", customer.LastName);
            p[2] = new SqlParameter("@Address", customer.Address);
            p[3] = new SqlParameter("@ContactNumber", customer.ContactNumber);
            p[4] = new SqlParameter("@Gender", customer.Gender);
            p[5] = new SqlParameter("@Dob", customer.Dob);
            p[6] = new SqlParameter("@Mail", customer.Mail);
            p[7] = new SqlParameter("@Balance", customer.Balance);
            p[8] = new SqlParameter("@Password", customer.Password);
            p[9] = new SqlParameter("@AccType", customer.AccountTypeId);
            int res = GetResult(ProcedureNames.Account.AddNewCustomers, p);
            if (res > 0)
            {
                result = true;
            }
            return result;
        }
        public bool AddCustomerByEmployee(Customer customer)
        {
            bool result = false;
            SqlParameter[] p = new SqlParameter[11];
            p[0] = new SqlParameter("@FirstName", customer.FirstName);
            p[1] = new SqlParameter("@LastName", customer.LastName);
            p[2] = new SqlParameter("@Address", customer.Address);
            p[3] = new SqlParameter("@ContactNumber", customer.ContactNumber);
            p[4] = new SqlParameter("@Gender", customer.Gender);
            p[5] = new SqlParameter("@Dob", customer.Dob);
            p[6] = new SqlParameter("@Mail", customer.Mail);
            p[7] = new SqlParameter("@Balance", customer.Balance);
            p[8] = new SqlParameter("@Password", customer.Password);
            p[9] = new SqlParameter("@AccountType", customer.AccountType);
            p[10] = new SqlParameter("@EmpId", customer.EmployeeId);
            int res = GetResult(ProcedureNames.Account.InsertCustomerByEmployee, p);
            if (res > 0)
            {
                result = true;
            }
            return result;
        }

        public bool UpdateCustomerDetails(Customer customer)
        {
            bool result = false;
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@CustomerId", customer.Password);
            p[1] = new SqlParameter("@Password", customer.Password);
            p[2] = new SqlParameter("@FirstName", customer.FirstName);
            p[3] = new SqlParameter("@LastName", customer.LastName);
            p[4] = new SqlParameter("@Address", customer.Address);
            p[5] = new SqlParameter("@ContactNumber", customer.ContactNumber);
            p[6] = new SqlParameter("@Mail", customer.Mail);
            int res = GetResult(ProcedureNames.Account.UpdateCustomerDetails, p);

            if (res > 0)
            {
                result = true;
            }
            return result;
        }
        
    }
}
