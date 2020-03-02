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
            public const string GetOneCustomerDetails = "[Account].[GetOneCustomerDetails]";
            public const string AddNewCustomers = "[Account].[InsertCustomer]";
            public const string UpdateCustomerDetails = "[Account].[UpdateCustomerDetails]";
            public const string DeleteCustomerAccount = "[Account].[DeleteCustomerAccount]";
            public const string GetAllCustomers = "[Account].[GetAllCustomers]";
            public const string GetCustomerDetails = "[Account].[GetCustomerDetails]";
            public const string GetAccountByAccountType = "[Account].[GetAllAccountByAccountType]";
            public const string GetAccountByBalance = "[Account].[GetAllAccountByBalance]";
            public const string GetCustomersByAccountStatus = "[Account].[GetAllCustomersByStatus]";            
            public const string InsertCustomerByEmployee = "[Account].[InsertCustomerByEmployee]";
            //public const string UpdateAccountDetails = "[Account].[UpdateAccountDetails]";
            public const string DeleteAccountByBalance = "[Account].[DeleteAccountByBalance]";
            public const string GetAccountTypesDetails = "[Account].[GetAccountTypesDetails]";
            public const string GetOneAccountType = "[Account].[GetOneAccountType]";
            public const string InsertNewAccountType = "[Account].[InsertNewAccountType]";
            public const string UpdateAccountType = "[Account].[UpdateAccountType]";
            public const string DeleteAccountType = "[Account].[DeleteAccountType]";
        }
    }
}
