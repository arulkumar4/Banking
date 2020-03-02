using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Business.Models.Transaction;

namespace Banking.DataAccess.Contracts.ITransaction
{
   public interface ITransactionDAL
    {
        List<TransactionClass> DebitTransaction(TransactionClass transaction);
        List<TransactionClass> GetAllTransactions(string AccountId);
    }
}
