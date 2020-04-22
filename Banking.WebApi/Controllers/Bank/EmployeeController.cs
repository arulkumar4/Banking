using Banking.Business.Contracts;
using Banking.Business.Models;
using Banking.WebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;

namespace Banking.WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeBl _employeebl;

        
        public EmployeeController(IEmployeeBl employeebl)
        {
            _employeebl = employeebl;
        }
       

        [Route("api/AddEmployee")]
        [HttpPost]
        public IdentityResult AddEmployee([FromBody]Employee employee)
        {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser() { UserName = employee.Mail, Email = employee.Mail };
            user.FirstName = employee.FirstName;
            user.LastName = employee.LastName;
            IdentityResult result = manager.Create(user, employee.Password);
            manager.AddToRoles(user.Id, employee.Role);
            _employeebl.AddEmployee(employee);
            return result;
        }
        [Route("api/UpdatePassword")]
        [HttpPost]
        public IHttpActionResult updatePassword(string username,string currentpassword,string newpassword)
        {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = manager.FindByName(username);
            bool success = false;
            if (user!=null)
            {
                IdentityResult result =manager.ChangePassword(user.Id, currentpassword, newpassword);
                success = true;
            }
            return Ok(success);
            
        }


        [Route("api/GetEmployee")]
        //[Authorize(Roles =  "Employee" )]
        [HttpGet]
        public IHttpActionResult GetEmployee()
        {
            return Ok(_employeebl.GetEmployees());
        }
        [Route("api/GetEmployee/{employeeid}")]
        [HttpGet]
        public IHttpActionResult GetBranch(int employeeid)
        {
            return Ok(_employeebl.GetEmployeeById(employeeid));
        }
        [Route("api/UpdateEmployee")]
        [HttpPut]
        public IHttpActionResult UpdateEmployee(Employee employee)
        {
            return Ok(_employeebl.UpdateEmployee(employee));
        }
        [Route("api/DeleteEmployee/{employeeid}")]
        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int employeeid)
        {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            return Ok(_employeebl.DeleteEmployee(employeeid));
        }
        [Route("api/GetEmployeebykeyword/{keyword}")]
        [HttpGet]
        public IHttpActionResult GetEmployeeByKeyword(string keyword)
        {
            return Ok(_employeebl.GetEmployeesByKeyword(keyword));
        }
        [HttpGet]
        [Route("api/GetUserClaims")]
        public IHttpActionResult GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            Employee employee = new Employee()
            {
                Mail = identityClaims.FindFirst("UserName").Value,
                Id=GetEmployeeId(identityClaims.FindFirst("UserName").Value),
                LoggedOn=identityClaims.FindFirst("LoggedOn").Value,
                Password=identityClaims.FindFirst("Password").Value
              
            };
            return Ok(employee);
        }

        private int GetEmployeeId(string mail)
        {
            return _employeebl.GetEmployeeId(mail);
        }
    }
}
