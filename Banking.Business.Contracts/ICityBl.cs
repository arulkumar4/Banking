using Banking.Business.Models;
using System.Collections.Generic;

namespace Banking.Business.Contracts
{
    public interface ICityBl
    {
        List<City> GetCityDetail(int cityId);
        List<City> GetCities();
        bool AddCity(City city);
        bool UpdateCity(int id,City city);
        bool DeleteCity(int id);

    }
}
