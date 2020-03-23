using Banking.Business.Contracts;
using Banking.DataAccess.Contracts;

namespace Banking.Business
{
    public class BankBl : IBankBl
    {
        private readonly IBankDal _bankDal;
        public BankBl() { }  
        public BankBl(IBankDal bankDal)
        {
            _bankDal = bankDal;
        }

        public int GetBankDetails()
        {
            return _bankDal.GetBankDetails();
        }
    }
}
