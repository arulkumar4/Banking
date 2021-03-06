﻿using Banking.Business.Contracts;
using Banking.Business.Models;
using Banking.DataAccess.Contracts;
using System.Collections.Generic;

namespace Banking.Business
{
    public class CityBl : ICityBl
    {
        private readonly ICityDal _cityDal;
        public CityBl(ICityDal cityDal) => _cityDal = cityDal;

        public List<City> GetCityDetail(int cityId)
        {
            return _cityDal.GetCityDetail(cityId);
        }

        public List<City> GetCities()
        {
            return _cityDal.GetCities();
        }

        public int AddCity(City city)
        {
            return _cityDal.AddCity(city);
        }

        public int UpdateCity(int id, City city)
        {
            return _cityDal.UpdateCity(id, city);
        }

        public int DeleteCity(int id)
        {
            return _cityDal.DeleteCity(id);
        }
    }
}
