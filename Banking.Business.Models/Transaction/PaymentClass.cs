using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Business.Models.Transaction
{
    public class PaymentClass
    {
        public string  Id { get; set; }
        public string Type { get; set; }
        public Decimal IntialBalance { get; set; }
        public Decimal   TransferAmount { get; set; }

        public Decimal AvailableBalance { get; set; }

        public string SenderName { get; set; }

        public string ReciverName { get; set; }
        public string status { get; set; }

        public string AccountId { get; set; }
    }
}
