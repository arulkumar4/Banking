using Banking.Business.Contracts.IAccount;
using Banking.Business.Models.Account;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Banking.WebApi.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,POST,PUT,DELETE")]

    public class AccountTypeController : ApiController
    {
        private readonly IAccountTypeBl _accountTypeBl;
        public AccountTypeController(IAccountTypeBl accountTypeBl)
        {
            _accountTypeBl = accountTypeBl;
        }

        // GET: api/GetAccountType
        [Route("api/AccountTypeController/GetAllAccountType")]
        [HttpGet]
        public IHttpActionResult GetAllAccountType()
        {
            return Ok(_accountTypeBl.GetAllAccountType());
        }

        // GET: api/GetAccountType
        [Route("api/AccountTypeController/GetOneAccountType")]
        [HttpGet]
        public IHttpActionResult GetOneAccountType(int acctypeId)
        {
            return Ok(_accountTypeBl.GetOneAccountType(acctypeId));
        }

        // POST: api/PostAccountType
        [Route("api/AccountTypeController/AddNewAccountType")]
        [HttpPost]
        public IHttpActionResult AddNewAccountType([FromBody]AccountType acctype)
        {
            return Ok(_accountTypeBl.AddNewAccountType(acctype));
        }

        // PUT: api/PutAccountType
        [Route("api/AccountTypeController/UpdateAccountType")]
        [HttpPut]
        public IHttpActionResult UpdateAccountType([FromBody]AccountType acctype)
        {
            return Ok(_accountTypeBl.UpdateAccountType(acctype));
        }

        // DELETE: api/AccountType
        [Route("api/AccountTypeController/DeleteAccountType")]
        [HttpDelete]
        public IHttpActionResult DeleteAccountType(string acctype)
        {
            return Ok(_accountTypeBl.DeleteAccountType(acctype));
        }

    }
}
