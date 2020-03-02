using Banking.DataAccess;
using Banking.DataAccess.Account;
using Banking.DataAccess.Contracts;
using Banking.DataAccess.Transaction;
using Banking.DataAccess.Contracts.ITransaction;
using Banking.DataAccess.Contracts.IAccount;
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
            Container.RegisterType<ITransactionTypeDal, TransactionTypeDal>();

            Container.RegisterType<IAccountDal, AccountDal>();
            Container.RegisterType<IAccountTypeDal, AccountTypeDal>();
            Container.RegisterType<ICustomerDal, CustomerDal>();
        }
    }
}
