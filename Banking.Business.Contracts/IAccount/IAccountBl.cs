using Banking.Business.Models.Account;
using System.Collections.Generic;

namespace Banking.Business.Contracts.IAccount
{
    public interface IAccountBl
    {
        List<CustomerAccount>GetCustomerAccounts(long customerId, long accountNo);
        //List<City> GetCities();
        //bool AddCity(City city);
        //bool UpdateCity(int id, City city);
        //bool DeleteCity(int id);

    }
}