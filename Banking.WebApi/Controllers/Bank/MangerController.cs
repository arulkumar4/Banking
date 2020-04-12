using Banking.Business.Contracts;
using Banking.Business.Models;
using Banking.WebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Banking.WebApi.Controllers
{
    
    public class MangerController : ApiController
    {
        private readonly IManagerBl _managerbl; 
        public MangerController(IManagerBl managerbl)
        {
            _managerbl = managerbl;
        }
        [Route("api/AddManager")]
        [HttpPost]
        public IdentityResult AddManager([FromBody]Manager managerRef)
        {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser() { UserName = managerRef.Mail, Email = managerRef.Mail };
            user.FirstName = managerRef.FirstName;
            user.LastName = managerRef.LastName;
            IdentityResult result = manager.Create(user, managerRef.Password);
            manager.AddToRoles(user.Id, managerRef.Role);
            _managerbl.AddManager(managerRef);
            return result;
            
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

        [HttpGet]
        [Route("api/GetUserClaims/manager")]
        public IHttpActionResult GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            Manager manager = new Manager()
            {
                Mail = identityClaims.FindFirst("UserName").Value,
                Id = GetManagerId(identityClaims.FindFirst("UserName").Value),
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value
            };
            return Ok(manager);
        }

        private int GetManagerId(string value)
        {
            return _managerbl.GetManagerId(value);
        }
    }
}
