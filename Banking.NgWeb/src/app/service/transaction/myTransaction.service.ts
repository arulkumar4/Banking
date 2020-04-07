import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { MyTransaction } from '../../model/transaction/myTransaction.model';
import "rxjs/add/observable/throw";
import 'rxjs/add/operator/catch';
import { Observable } from 'rxjs';

@Injectable()
export class MyTransactionService
{
  urlString: string = "https://localhost:44395";
    constructor(private http:HttpClient){}
    getDataFromAPI(AccountId:string):Observable<MyTransaction[]>
     {
      return this.http.get<MyTransaction[]>(this.urlString+"/GetAllTransactions?AccountId=" + AccountId)
        .catch(this.errorHandler);
    }

    errorHandler(errorHandler: HttpErrorResponse) {
      return Observable.throw(false);
    }

}
