using Banking.Business.Models;
using Banking.DataAccess.Contracts;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace Banking.DataAccess.Account
{
    public class AccountDal : AccountBaseDal, IAccountDal
    {
            public List<CustomerAccount> GetCities()
            {
                List<City> Cities = new List<City>();
                using (var dataset = GetDataset(ProcedureNames.Bank.GetCities))
                {
                    var citytable = dataset.Tables[0];
                    var citytableDetail = citytable.AsEnumerable();

                    foreach (var cityRow in citytableDetail)
                    {
                        Cities.Add(PopulateData<City>(cityRow));
                    }
                }
                return Cities;
            }


            public List<City> GetCityDetail(int cityId)
            {
                List<City> Cities = new List<City>();
                using (var dataset = GetDataset(ProcedureNames.Bank.GetCityDetail, cityId))
                {
                    var citytable = dataset.Tables[0];
                    var citytableDetail = citytable.AsEnumerable();

                    foreach (var cityRow in citytableDetail)
                    {
                        Cities.Add(PopulateData<City>(cityRow));
                    }
                }
                return Cities;
            }

            public bool AddCity(City city)
            {
                bool result = false;
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Name", city.Name);
                int res = GetResult(ProcedureNames.Bank.AddCity, p);
                if (res > 0)
                {
                    result = true;
                }
                return result;
            }

            public bool UpdateCity(int id, City city)
            {
                bool result = false;
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Id", id);
                p[1] = new SqlParameter("@Name", city.Name);
                int res = GetResult(ProcedureNames.Bank.UpdateCity, p);
                if (res > 0)
                {
                    result = true;
                }
                return result;
            }

            public bool DeleteCity(int id)
            {
                bool result = false;
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Id", id);
                int res = GetResult(ProcedureNames.Bank.DeleteCity, p);
                if (res > 0)
                {
                    result = true;
                }
                return result;
            }
        }
    }

}
}
