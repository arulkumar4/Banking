using System.Collections.Generic;
using Banking.Business.Contracts;
using Banking.Business.Models;
using Banking.DataAccess.Contracts;

namespace Banking.Business
{
    public class ManagerBl : IManagerBl
    {
        private readonly IManagerDal _managerDal;
        public ManagerBl(IManagerDal managerDal)
        {
            _managerDal = managerDal;
        }

        public int AddManager(Manager manager)
        {
            return _managerDal.AddManager(manager);
        }

        public int DeleteManager(int managerid)
        {
            return _managerDal.DeleteManager(managerid);
        }

        public List<Manager> GetManagerById(int managerid)
        {
            return _managerDal.GetManagerById(managerid);
        }

        public int GetManagerId(string mail)
        {
            return _managerDal.GetManagerId(mail);
        }

        public List<Manager> GetManagers()
        {
            return _managerDal.GetManagers();
        }

        public int UpdateManager(Manager manager)
        {
            return _managerDal.UpdateManager(manager);
        }
    }
}
