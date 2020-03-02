using Banking.Business.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Business.Contracts.Transaction
{
   public interface ITransactionTypeBl
    {
        List<TransactionType> GetTransactionTypes();
        bool InsertTransactionType(TransactionType transactionType);
        bool UpdateTransactionType(TransactionType transactionType, TransactionType transactiontype);

    }
}
