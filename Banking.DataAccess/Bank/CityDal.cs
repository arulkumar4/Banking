using Banking.Business.Models;
using Banking.DataAccess.Contracts;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Banking.DataAccess
{
    public class CityDal : BaseDal, ICityDal
    {

        public List<City> GetCities()
        {
            List<City> Cities = new List<City>();
            using (var dataset = GetDataset(ProcedureNames.City.GetCities))
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
            using (var dataset = GetDataset(ProcedureNames.City.GetCityDetail, cityId))
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

        public int AddCity(City city)
        {
            int cityId = GetValue<int>(ProcedureNames.City.AddCity,
                new SqlParameter("Name", city.Name));
            return cityId;
        }
        public int UpdateCity(int id, City city)
        {
            //SqlParameter[] p = new SqlParameter[2];
            //p[0] = new SqlParameter("@Id", id);
            //p[1] = new SqlParameter("@Name", city.Name);
            int status = GetValue<int>(ProcedureNames.City.UpdateCity,
                        new SqlParameter("Id", id),
                        new SqlParameter("Name", city.Name));

            return status;
        }

        public int DeleteCity(int id)
        {
            //SqlParameter[] p = new SqlParameter[1];
            //p[0] = new SqlParameter("@Id", id);
            int status = GetValue<int>(ProcedureNames.City.DeleteCity,
               new SqlParameter("Id", id));
            return status;
        }
    }
}
