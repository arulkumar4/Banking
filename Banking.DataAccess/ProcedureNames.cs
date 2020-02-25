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
    }
}
