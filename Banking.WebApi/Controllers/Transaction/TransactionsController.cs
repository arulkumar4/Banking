﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Banking.Business.Contracts.Transaction;
using Banking.Business.Models.TransactionModels;

namespace Banking.WebApi.Controllers.Transaction
{
    [RoutePrefix("Transaction")]
    public class TransactionsController : ApiController
    {
        private readonly ITransactionBl _transactionBl;
        public TransactionsController() { }
        public TransactionsController(ITransactionBl transactionBl) => _transactionBl = transactionBl;

        [Route("GetAllTransactions")]
        [HttpGet]
        public IHttpActionResult GetAllTransactions(string AccountId)
                  => Ok(_transactionBl.GetAllTransactions(AccountId));
        

        [Route("DebitTransaction")]
        [HttpGet]
        public IHttpActionResult DebitTransaction(MTransaction transaction)
                  => Ok(_transactionBl.DebitTransaction(transaction));
        

        [Route("GetAllAccountTransfers")]
        [HttpGet]
        public IHttpActionResult GetAllAccountTransfers(string AccountId)
                  => Ok(_transactionBl.GetAllAccountTransfers(AccountId));
      


    }
}