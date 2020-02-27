using Banking.Business.Contracts.IAccount;
using Banking.Business.Models.Account;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Banking.WebApi.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,POST,PUT,DELETE")]
    public class AccountController : ApiController
    {
        private readonly IAccountBl _accountbl;
        public AccountController(IAccountBl accountbl)
        {
            _accountbl = accountbl;
        }

        // GET: api/Account/string/id
        [Route("api/Account")]
        [HttpGet]
        public IHttpActionResult GetAccount(long customerId, long accountNo)
        {
            return Ok(_accountbl.GetCustomerAccounts(customerId, accountNo));
        }

        //[Route("api/cities")]
        //[HttpGet]
        //public IHttpActionResult Getcities()
        //{
        //    return Ok(_citybl.GetCities());
        //}
        //[Route("api/Addcity")]
        //[HttpPost]
        //public IHttpActionResult Addcity([FromBody]City city)
        //{
        //    return Ok(_citybl.AddCity(city));
        //}

        //[Route("api/Updatecity/{id}")]
        //[HttpPut]
        //public IHttpActionResult Updatecity(int id, [FromBody]City city)
        //{
        //    return Ok(_citybl.UpdateCity(id, city));
        //}

        //[Route("api/Deletecity/{id}")]
        //[HttpDelete]
        //public IHttpActionResult Deletecity(int id)
        //{
        //    return Ok(_citybl.DeleteCity(id));
        //}
    }
}

