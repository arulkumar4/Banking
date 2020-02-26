using Banking.Business.Contracts;
using Banking.DataAccess.Contracts;

namespace Banking.Business.AccountBl
{
    class AccountBl
    {
        public class AccountBl : IBankBl
        {
            private readonly IBankDal _bankDal;

            public AccountBl() { }


            public AccountBl(IBankDal bankDal)
            {
                _bankDal = bankDal;
            }

            public int GetAccountDetails()
            {
                return _bankDal.GetAccountDetails();
            }
        }
    }
}
}
