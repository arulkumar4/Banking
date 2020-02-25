using Banking.Business.Models;
using System.Collections.Generic;

namespace Banking.DataAccess.Contracts
{
    public interface ICityDal
    {
        List<City> GetCityDetail(int cityId);
        List<City> GetCities();
        bool AddCity(City city);
        bool UpdateCity(int id, City city);
        bool DeleteCity(int id);
    }
}
