using Banking.Business.Contracts.IAccount;
using Banking.Business.Models.Account;
using Banking.WebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;

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

        //public IHttpActionResult AddNewCustomer([FromBody]Customer customer, int empId)
        //{
        //    return Ok(_customerbl.AddNewCustomer(customer, empId));
        //}
        public IdentityResult AddNewCustomer([FromBody]Customer customer, int empId)
        {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser() { UserName = customer.Mail, Email = customer.Mail };
            user.FirstName = customer.FirstName;
            user.LastName = customer.LastName;
            IdentityResult result = manager.Create(user, customer.Password);
            manager.AddToRoles(user.Id, customer.Role);
            _customerbl.AddNewCustomer(customer, empId);
            return result;
        }

        [Route("api/Customer/UpdateCustomerDetails")]
        [HttpPut]
        public IHttpActionResult UpdateCustomerDetails([FromBody]Customer customer, long customerId)
        {
            return Ok(_customerbl.UpdateCustomerDetails(customer, customerId));
        }        
        [HttpGet]
        [Route("api/GetUserClaims/customer")]
        
        public IHttpActionResult GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            Customer customer = new Customer()
            {
                Mail = identityClaims.FindFirst("UserName").Value,
                CustomerId = GetCustomerId(identityClaims.FindFirst("UserName").Value),
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value
            };
            return Ok(customer);
        }

        private long GetCustomerId(string mail)
        {
            return _customerbl.GetCustomerId(mail);
        }
    }
}
