using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public class Transaction
        {
            public const string GetTransactionTypes = "[Transaction].GetTransactionTypes";
            public const string InsertTransactionType = "[Transaction].InsertTransactionType";

            public const string UpdateTransactionType = "[Transaction].UpdateTransactionType";
        }
    }
}
