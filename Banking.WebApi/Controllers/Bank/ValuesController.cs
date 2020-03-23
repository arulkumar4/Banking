using Banking.Business.Contracts;
using System.Web.Http;

namespace Banking.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
         IBankBl _bankBl;

        public ValuesController()
        {

        }

        public ValuesController(IBankBl bankBl)
        {
            this._bankBl = bankBl;
        }

        // GET api/values
        public int Get()
        {
            return _bankBl.GetBankDetails();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
