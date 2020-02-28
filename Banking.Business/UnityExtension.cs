using Banking.DataAccess;
using Banking.DataAccess.Contracts;
using Unity;
using Unity.Extension;

namespace Banking.Business
{
    public class UnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IBankDal, BankDal>();
            Container.RegisterType<ICityDal, CityDal>();
            Container.RegisterType<IBranchDal, BranchDal>();
            Container.RegisterType<IManagerDal, ManagerDal>();
            Container.RegisterType<IEmployeeDal, EmployeeDal>();
        }
    }
}
