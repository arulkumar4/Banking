using Banking.Business.Models;
using System.Collections.Generic;

namespace Banking.Business.Contracts
{
    public interface ICityBl
    {
        List<City> GetCityDetail(int cityId);
        List<City> GetCities();
        int AddCity(City city);
        int UpdateCity(int id,City city);
        int DeleteCity(int id);

    }
}
