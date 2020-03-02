using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Banking.Business.Contracts.Transaction;
using Banking.Business.Models.Transaction;


namespace Banking.WebApi.Controllers.Transaction
{
    [RoutePrefix("TransactionType")]
    public class TransactionTypeController : ApiController
    {
        private readonly ITransactionTypeBl _transactionTypeBl;
        public TransactionTypeController() { }
        public TransactionTypeController(ITransactionTypeBl transactionTypeBl) => _transactionTypeBl = transactionTypeBl;


        [Route("GetAllTypes")]
        [HttpGet]
        public IHttpActionResult GetTransactionTypes()
        {
            return Ok(_transactionTypeBl.GetTransactionTypes());
        }
        [Route("InsertType")]
        [HttpPost]
        public IHttpActionResult AddTransaction([FromBody]TransactionType transactionType)
        {
            return Ok(_transactionTypeBl.InsertTransactionType(transactionType));
        }

        [Route("UpdateType")]
        [HttpPut]
        public IHttpActionResult UpdateTransaction([FromBody] TransactionType[] transactionType )
        {
            return Ok(_transactionTypeBl.UpdateTransactionType(transactionType));
        }

    }
}