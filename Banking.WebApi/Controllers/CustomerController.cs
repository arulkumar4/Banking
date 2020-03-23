using Banking.Business.Contracts.IAccount;
using Banking.Business.Models.Account;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Banking.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerBl _customerbl;
        public CustomerController(ICustomerBl customerbl)
        {
            _customerbl = customerbl;
        }
        // Get: api/Customer/GetCustomerDetails
        [Route("api/Customer/GetCustomerDetails")]
        [HttpGet]
        public IHttpActionResult GetCustomerDetails(long customerId, long accountNo)
        {
            return Ok(_customerbl.GetCustomerDetails(customerId, accountNo));
        }

        // Post: api/Customer/AddCustomer
        [Route("api/Customer/AddNewCustomer")]
        [HttpPost]
        public IHttpActionResult AddNewCustomer([FromBody]Customer customer)
        {
            return Ok(_customerbl.AddNewCustomer(customer));
        }
        
        [Route("api/Customer/UpdateCustomerDetails")]
        [HttpPut]
        public IHttpActionResult UpdateCustomerDetails([FromBody]Customer customer)
        {
            return Ok(_customerbl.UpdateCustomerDetails(customer));
        }        
    }
}
