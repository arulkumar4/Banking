using Banking.DataAccess;
using Banking.DataAccess.Contracts;
using Banking.DataAccess.Transaction;
using Banking.DataAccess.Contracts.ITransaction;
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
            Container.RegisterType<ITransactionTypeDal, TransactionTypeDal>();
        }
    }
}
