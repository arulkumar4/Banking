using Banking.DataAccess.Contracts.IAccount;
using Banking.Business.Contracts.IAccount;
using System.Collections.Generic;
using Banking.Business.Models.Account;

namespace Banking.Business.Account
{
    public class CustomerBl : ICustomerBl
    {
        private readonly ICustomerDal _customerDal;

        public CustomerBl() { }


        public CustomerBl(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public List<CustomerAccount> GetCustomerDetails(long customerId, long accountNo)
        {
            return _customerDal.GetCustomerDetails(customerId, accountNo);
        }
        public string AddNewCustomer(Customer customer)
        {
            return _customerDal.AddNewCustomer(customer);
        }

        public string UpdateCustomerDetails(Customer customer)
        {
            return _customerDal.UpdateCustomerDetails(customer);
        }

    }

}

