using Account.Business.Contracts;
using Account.DataAccess.Contracts;

namespace Account.Business
{
    public class AccountBl : IAccountBl
    {
        private readonly IAccountDal _accountDal;

        public AccountBl() { }


        public AccountBl(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public int GetAccountDetails()
        {
            return _accountDal.GetAccountDetails();
        }
    }
}


