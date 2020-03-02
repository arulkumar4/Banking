using Banking.Business.Models;
using System.Collections.Generic;

namespace Banking.Business.Contracts
{
    public interface IManagerBl
    {
        int AddManager(Manager manager);
        List<Manager> GetManagers();
        List<Manager> GetManagerById(int managerid);
        int UpdateManager(Manager manager);
        int DeleteManager(int managerid);

    }
}
