export class TransactionResult
{
    AccountId:string;
    AvailableBalance:number;
    Id:string;
    IntialBalance:number;
    ReceiverName:string;
    ReciverAccountId:string;
    SenderName:string;
    status:string;
    TransactionDate: string;
    Type: string;
    TransactionTypeId:string;
    TransferAmount:number;
    constructor(a?,b?,c?,D?,E?,F?,G?,H?,I?,j?,k?,typ?)
    {
        this.AccountId=a;
        this.AvailableBalance=b;
        this.Id=c;
        this.IntialBalance=D;
        this.ReceiverName=E;
        this.ReciverAccountId=F;
        this.SenderName=G;
        this.status=H;
        this.TransactionDate=I;
        this.TransactionTypeId=j;
        this.TransferAmount = k;
        this.Type = typ;
    }
}
