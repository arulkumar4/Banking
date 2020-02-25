using Account.DataAccess.Contracts;

namespace Account.DataAccess
{
    public class AccountDal : IAccountDal
    {
        public AccountDal() { }

        public int GetAccountDetails()
        {
            return 1;
        }
    }
}
