using Banking.Business.Contracts;
using Banking.Business.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Banking.WebApi.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,POST,PUT,DELETE")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeBl _employeebl;

        
        public EmployeeController(IEmployeeBl employeebl)
        {
            _employeebl = employeebl;
        }
       

        [Route("api/AddEmployee")]
        [HttpPost]
        public IHttpActionResult AddEmployee([FromBody]Employee employee)
        {
            return Ok(_employeebl.AddEmployee(employee));
        }
        [Route("api/GetEmployee")]
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
            return Ok(_employeebl.DeleteEmployee(employeeid));
        }
        [Route("api/GetEmployeebykeyword/{keyword}")]
        [HttpGet]
        public IHttpActionResult GetEmployeeByKeyword(string keyword)
       {
            return Ok(_employeebl.GetEmployeesByKeyword(keyword));
        }

    }
}
