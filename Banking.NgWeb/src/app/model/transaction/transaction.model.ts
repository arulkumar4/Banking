export class Transaction
{
    TransferAmount:number;
    SenderName:string;
    ReceiverName:string;
    AccountId:string;
    ReciverAccountId:string;
    TransactionTypeId:string;
    constructor(transfer_amount?,sender_name?,receiver_name?,account_id?,reciver_account_id?,transaction_type_id?)
    {
        this.TransferAmount = transfer_amount;
        this.SenderName = sender_name;
        this.ReceiverName = receiver_name;
        this.AccountId = account_id;
        this.ReciverAccountId = reciver_account_id;
        this.TransactionTypeId = transaction_type_id;
    }
}