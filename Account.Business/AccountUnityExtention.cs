using Account.DataAccess;
using Account.DataAccess.Contracts;
using Unity;
using Unity.Extension;

namespace Account.Business
{
    public class UnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IAccountDal, AccountDal>();
        }
    }
}