export class TransactionType
{
    Id:string;
    Type:string;
    constructor(userResponse:any)
    {
        this.Id = userResponse.Id;
        this.Type = userResponse.Type;
    }
}