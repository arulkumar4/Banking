namespace Banking.DataAccess
{
    public class ProcedureNames
    {
        public class City
        {
            public const string GetCityDetail = "[Bank].GetCityDetail";
            public const string GetCities = "[Bank].GetCities";
            public const string AddCity = "[Bank].[AddCity]";
            public const string UpdateCity = "[Bank].[UpdateCityDetail]";
            public const string DeleteCity = "[Bank].[DeleteCityDetail]";
        }
        public class Branch
        {
            public const string AddBranch = "[Bank].[AddBranch]";
            public const string GetBranch = "[Bank].[GetBranch]";
            public const string GetBranchbyid = "[Bank].[GetBranchById]";
            public const string UpdateBranch = "[Bank].[UpdateBranchById]";
            public const string DeleteBranch = "[Bank].[DeleteBranch]";

        }
        public class Manager
        {
            public const string InsertManager = "[Bank].[InsertManager]";
            public const string GetMangers = "[Bank].[GetMangers]";
            public const string GetMangersById = "[Bank].[GetMangersById]";
            public const string UpdateMangersById = "[Bank].[UpdateMangersById]";
            public const string DeleteManager = "[Bank].[DeleteManager]";
        }
        public class Employee
        {
            public const string InsertEmployee = "[Bank].[InsertEmployee]";
            public const string GetEmployees = "[Bank].[GetEmployees]";
            public const string GetEmployeeById = "[Bank].[GetEmployeeById]";
            public const string UpdateEmployeeById = "[Bank].[UpdateEmployeeById]";
            public const string DeleteEmployee = "[Bank].DeleteEmployee";

        }        
        public class Transaction
        {
            public const string GetTransactionTypes = "[Transaction].GetTransactionTypes";
            public const string InsertTransactionType = "[Transaction].InsertTransactionType";
            public const string UpdateTransactionType = "[Transaction].UpdateTransactionType";

        }
    }
}
