using Banking.Business.Contracts.IAccount;
using Banking.Business.Models.Account;
using Banking.WebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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

        [Route("api/RegisterCustomer")]
        [HttpPost]
        public IdentityResult Register(Customer customer)
        {
            _customerbl.AddNewCustomer(customer);
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser() { UserName = customer.LastName,Email=customer.Mail};
            IdentityResult result = manager.Create(user, customer.Password);
            return result;
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
