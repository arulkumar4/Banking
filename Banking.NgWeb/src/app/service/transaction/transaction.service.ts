import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Transaction } from '../../model/transaction/transaction.model';
import "rxjs/add/observable/throw";
import 'rxjs/add/operator/catch';
import { Observable } from 'rxjs';
import { TransactionResult } from '../../model/transaction/TransactionResult.Model';
@Injectable()
export class TransactionService
{
    constructor(private myHttp:HttpClient)
    {
    }
  getDataFromAPI(TransactionData: Transaction): Observable<TransactionResult>{
    return this.myHttp.post<TransactionResult>("https://localhost:44395/DebitTransaction", TransactionData)
            .catch(this.errorHandler);
        }
  errorHandler(errorHandler: HttpErrorResponse) {
    return Observable.throw(false);
    }
        getTransactionTypeDataFromAPI()
        {
           return this.myHttp.get("https://localhost:44395/TransactionType/GetAllTypes")
        }

          
}
