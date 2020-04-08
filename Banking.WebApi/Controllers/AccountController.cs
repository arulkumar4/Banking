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

        // GET: api/GetAccount/string/accountType
        [Route("api/Account/GetAccountByAcountType")]
        [HttpGet]
        public IHttpActionResult GetAccountByAcountType(string acccountType)
        
        {
            return Ok(_accountbl.GetAccountbyAccountType(acccountType));
        }

        // GET: api/GetAccount/string/balance
        [Route("api/AccountGetAccountByBalance")]
        [HttpGet]
        public IHttpActionResult GetAccountByBalance(decimal balance)
        {
            return Ok(_accountbl.GetAccountByBalance(balance));
        }

        // GET: api/GetAccount/string/accountstatus
        [Route("api/Account/GetCustomerByAccountStatus")]
        [HttpGet]
        public IHttpActionResult GetCustomerByAccountStatus(bool status)
        {
            return Ok(_accountbl.GetCustomerByAccountStatus(status));
        }
        // GET: api/UpdateCustomerByEmployee
        [Route("api/Account/UpdateCustomerByEmployee")]
        [HttpPut]
        public IHttpActionResult UpdateCustomerByEmployee(Customer customer)
        {
            return Ok(_accountbl.UpdateCustomerByEmployee(customer));
        }
        // GET: api/UpdateAccountPassword
        [Route("api/Account/UpdateAccountPassword")]
        [HttpPut]
        public IHttpActionResult UpdateAccountPassword(long accnumber, string oldpassword, string newpassword)
        {
            return Ok(_accountbl.UpdateAccountPassword(accnumber, oldpassword, newpassword));
        }
        // GET: api/DeleteAccount/string
        [Route("api/Account/DeleteAccount")]
        [HttpDelete]
        public IHttpActionResult DeleteAccount([FromBody]Customer account)
        {
            return Ok(_accountbl.DeleteCustomerAccount(account));
        }

    }
}

