export class MyTransaction {
  AccountId: string;
  AvailableBalance: number;
  Id: string;
  IntialBalance: number;
  ReceiverName: string;
  ReciverAccountId: string;
  SenderName: string;
  status: string;
  TransactionDate: string;
  TransactionTypeId: string;
  TransferAmount: number;
  CustomerId: any;
  Number: any;
  constructor(accId?, accBal?, id?, inBal?, recName?, recAmtID?, sendName?, status?, TransactionDate?, TranTypeId?, TransAmount?) {
    this.AccountId = accId;
    this.AvailableBalance = accBal;
    this.Id = id;
    this.IntialBalance = inBal;
    this.ReceiverName = recName;
    this.ReciverAccountId = recAmtID;
    this.SenderName = sendName;
    this.status = status;
    this.TransactionDate = TransactionDate;
    this.TransactionTypeId = TranTypeId;
    this.TransferAmount = TransAmount;
  }
}
