﻿using System;

namespace Banking.Business.Models.TransactionModels
{
    public class Payment
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
        public DateTime Date { get; set; }
    }
}
