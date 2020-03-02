using Banking.Business.Contracts.IAccount;
using Banking.Business.Models.Account;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Banking.WebApi.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,POST,PUT,DELETE")]
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
        // Post: api/Customer/AddCustomerByEmployee
        //[Route("api/Customer/AddNewCustomerByEmployee")]
        //[HttpPost]
        //public IHttpActionResult AddNewCustomerByEmployee([FromBody]Customer customer)
        //{
        //    return Ok(_customerbl.AddNewCustomerByEmployee(customer));
        //}
        // PUT: api/Customer/UpdateCustomerDetails
        [Route("api/Customer/UpdateCustomerDetails")]
        [HttpPut]
        public IHttpActionResult UpdateCustomerDetails([FromBody]Customer customer)
        {
            return Ok(_customerbl.UpdateCustomerDetails(customer));
        }        
    }
}
