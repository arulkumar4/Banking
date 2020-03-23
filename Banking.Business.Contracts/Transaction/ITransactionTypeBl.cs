using Banking.Business.Models.TransactionModels;
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
        int InsertTransactionType(TransactionType transactionType);
        int UpdateTransactionType(TransactionType[] transactionType);

    }
}
