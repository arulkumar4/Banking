using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Business.Models.Transaction
{
    public class TransactionClass
     {
    
        public string Id { get; set; }
        public Decimal IntialBalance { get; set; }
        public Decimal TransferAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public Decimal AvailableBalance { get; set; }
        public string SenderName { get; set; }
        public String ReceiverName { get; set; }
        public string status { get; set; }
        public string AccountId { get; set; }
        public string TransactionTypeId { get; set; }
    }
}
