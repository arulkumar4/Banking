using System.Collections.Generic;
using Account.Business.Contracts;
using System.Web.Http;

namespace Banking.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        IAccountBl _accountBl;

        public AccountController()
        {

        }
        public AccountController(IAccountBl accountBl)
        {
            this._accountBl = accountBl;
        }

        // GET: api/Account
        public int Get()
        {
            return _accountBl.GetAccountDetails();
        }

        // GET: api/Account/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Account
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Account/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Account/5
        public void Delete(int id)
        {
        }
    }
}
