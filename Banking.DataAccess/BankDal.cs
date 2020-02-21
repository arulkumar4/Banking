using Banking.DataAccess.Contracts;

namespace Banking.DataAccess
{
    public class BankDal : IBankDal
    {
        public BankDal() { }

        public int GetBankDetails()
        {
            return 1;
        }
    }
}
