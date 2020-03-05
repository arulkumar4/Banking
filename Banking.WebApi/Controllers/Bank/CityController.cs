using Banking.Business.Contracts;
using Banking.Business.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Banking.WebApi.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,POST,PUT,DELETE")]
    public class CityController : ApiController
    {
        private readonly ICityBl _citybl;
        public CityController(ICityBl citybl)
        {
            _citybl = citybl;
        }

        [Route("api/city/{id}")]
        [HttpGet]
        public IHttpActionResult Getcity(int id)
        {
            return Ok(_citybl.GetCityDetail(id));
        }

        [Route("api/cities")]
        [HttpGet]
        public IHttpActionResult Getcities()
        {
            return Ok(_citybl.GetCities());
        }
        [Route("api/Addcity")]
        [HttpPost]
        public IHttpActionResult Addcity([FromBody]City city)
        {
            return Ok(_citybl.AddCity(city));
        }

        [Route("api/Updatecity/{id}")]
        [HttpPut]
        public IHttpActionResult Updatecity(int id,[FromBody]City city)
        {
            return Ok(_citybl.UpdateCity(id,city));
        }

        [Route("api/Deletecity/{id}")]
        [HttpDelete]
        public IHttpActionResult Deletecity(int id)
        {
            return Ok(_citybl.DeleteCity(id));
        }
    }
}
