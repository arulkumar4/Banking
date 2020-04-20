import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class AccountTypeService {
  constructor(private httpRequest: HttpClient) { }

  GetAllAccountType() {
    return this.httpRequest.get("https://localhost:44395/api/AccountTypeController/GetAllAccountType")
  }
  GetAccountType(accountTypeId: number) {
    return this.httpRequest.get("https://localhost:44395/api/AccountTypeController/GetOneAccountType?acctypeId=" + accountTypeId)
  }
}
