using Banking.Business.Contracts;
using Banking.Business.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Banking.WebApi.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,POST,PUT,DELETE")]
    public class MangerController : ApiController
    {
        private readonly IManagerBl _managerbl; 
        public MangerController(IManagerBl managerbl)
        {
            _managerbl = managerbl;
        }
        [Route("api/AddManager")]
        [HttpPost]
        public IHttpActionResult AddManager([FromBody]Manager manager)
        {
            return Ok(_managerbl.AddManager(manager));
        }
        [Route("api/GetManagers")]
        [HttpGet]
        public IHttpActionResult GetManagers()
        {
            return Ok(_managerbl.GetManagers());
        }
        [Route("api/GetManagers/{managerid}")]
        [HttpGet]
        public IHttpActionResult GetManagerById(int managerid)
        {
            return Ok(_managerbl.GetManagerById(managerid));
        }
        [Route("api/UpdateManager")]
        [HttpGet]
        public IHttpActionResult UpdateManager(Manager manager)
        {
            return Ok(_managerbl.UpdateManager(manager));
        }
        [Route("api/DeleteManager/{managerid}")]
        [HttpGet]
        public IHttpActionResult DeleteManager(int managerid)
        {
            return Ok(_managerbl.DeleteManager(managerid));
        }

    }
}
