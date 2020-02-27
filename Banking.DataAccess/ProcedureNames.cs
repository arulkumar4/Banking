using System;

namespace Banking.DataAccess
{
    public class ProcedureNames
    {
        public class Bank
        {
            public const string GetCityDetail = "[Bank].GetCityDetail";
            public const string GetCities = "[Bank].GetCities";
            public const string AddCity = "[Bank].[AddCity]";
            public const string UpdateCity = "[Bank].[UpdateCityDetail]";
            public const string DeleteCity = "[Bank].[DeleteCityDetail]";
        }    
        public class Account
        {
            public const string GetCustomerDetails = "[Account].GetCustomerDetails";
        }
    }
}
