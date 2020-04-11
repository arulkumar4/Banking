using Banking.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.DataAccess.Contracts
{
    public interface IManagerDal
    {
        int AddManager(Manager manager);
        List<Manager> GetManagers();
        List<Manager> GetManagerById(int managerid);
        int UpdateManager(Manager manager);
        int DeleteManager(int managerid);
        int GetManagerId(string mail);
    }
}
