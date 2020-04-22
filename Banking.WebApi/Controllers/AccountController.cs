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

        // GET: api/GetAccount
        [Route("api/Account/GetAllCustomerAccounts")]
        [HttpGet]
        public IHttpActionResult GetAllCustomerAccounts()
        {
            return Ok(_accountbl.GetAllCustomerAccounts());
        }

        // GET: api/GetAccount/string/id
        [Route("api/Account/GetCustomerAccounts")]
        [HttpGet]
        public IHttpActionResult GetCustomerAccounts(long customerId, long accountNo)
        {
            return Ok(_accountbl.GetCustomerAccounts(customerId, accountNo));
        }

        // GET: api/UpdateAccountPassword
        [Route("api/Account/UpdateAccountPassword")]
        [HttpPut]
        public IHttpActionResult UpdateAccountPassword(Customer customer)
        {
            return Ok(_accountbl.UpdateAccountPassword(customer));
        }
        // GET: api/DeleteAccount/string
        [Route("api/Account/DeleteAccount")]
        [HttpDelete]
        public IHttpActionResult DeleteAccount(long number, string pass)
        {
            return Ok(_accountbl.DeleteCustomerAccount(number, pass));
        }

    }
}

