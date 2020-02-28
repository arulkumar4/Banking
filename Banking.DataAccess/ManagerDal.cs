using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Banking.Business.Models;
using Banking.DataAccess.Contracts;

namespace Banking.DataAccess
{
    public class ManagerDal : BaseDal, IManagerDal
    {
        public int AddManager(Manager manager)
        {
            
            var ManagerId = GetValue<int>(ProcedureNames.Manager.InsertManager,
                new SqlParameter("Firstname",manager.FirstName),
                new SqlParameter("Lastname", manager.LastName),
                new SqlParameter("Fullname", manager.FullName),
                new SqlParameter("contactnumber", manager.ContactNumber),
                new SqlParameter("mail", manager.Mail),
                new SqlParameter("dob", manager.Dob),
                new SqlParameter("Experience",manager.Experience),
                new SqlParameter("BranchId", manager.BranchId)
                );
            //result = (res > 0) ? true : false;
            return ManagerId;
        }

        public int DeleteManager(int managerid)
        {
            var status = GetValue<int>(ProcedureNames.Manager.DeleteManager,
               new SqlParameter("id", managerid)
               );
            return status;
        }

        public List<Manager> GetManagerById(int managerid)
        {
            List<Manager> Managers = new List<Manager>();
            using (var dataset = GetDataset(ProcedureNames.Manager.GetMangersById,
                                    new SqlParameter("id", managerid)))
            {
                var managertable = dataset.Tables[0];
                var managertableDetail = managertable.AsEnumerable();
                foreach (var managerRow in managertableDetail)
                {
                    Managers.Add(PopulateData<Manager>(managerRow));
                }
            }
            return Managers;
        }

        public List<Manager> GetManagers()
        {
            List<Manager> Managers = new List<Manager>();
            using (var dataset = GetDataset(ProcedureNames.Manager.GetMangers))
            {
                var managertable = dataset.Tables[0];
                var managertableDetail = managertable.AsEnumerable();
                foreach (var managerRow in managertableDetail)
                {
                    Managers.Add(PopulateData<Manager>(managerRow));
                }
            }
            return Managers;
        }

        public int UpdateManager(Manager manager)
        {
            var status = GetValue<int>(ProcedureNames.Manager.UpdateMangersById,
               new SqlParameter("id", manager.Id),
               new SqlParameter("Firstname",manager.FirstName),
               new SqlParameter("Lastname", manager.LastName),
               new SqlParameter("Fullname", manager.FullName),
               new SqlParameter("contactnumber", manager.ContactNumber),
               new SqlParameter("mail", manager.Mail),
               new SqlParameter("dob", manager.Dob),
               new SqlParameter("Experience", manager.Experience),
               new SqlParameter("BranchId", manager.BranchId)
               );
            return status;
        }
    }
}
