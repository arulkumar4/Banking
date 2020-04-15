import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { AccountModel } from '../model/account.model';
import { AccountConfig } from '../constants/account-config';

@Injectable({
  providedIn: 'root'
})

export class AccountService {

  formData: AccountModel;
  list: AccountModel[];
  account: any;
  account_config = AccountConfig;
  readonly rootURL = "https://localhost:44395/api"

  constructor(private http: HttpClient) {
    this.account = [];
  }

  getAllCustomerAccounts() {
    this.account = this.http.get<AccountModel[]>(this.rootURL + '/Account/GetAllCustomerAccounts');
    return this.account;
  }
  getAllAccounts() {
    this.getAllCustomerAccounts().subscribe((response) => {
      this.account = response;
      console.log(this.account);
    });
    return this.account;
  }
  postCustomer(formData: AccountModel, empId: number) {
    debugger;
    return this.http.post(this.rootURL + this.account_config.postNewCustomer + empId, formData)
    // alert("Form Submitted Successfully");
  }
  getCustomerDetails(customerId: number) {
    debugger;
    return this.http.get(this.rootURL + this.account_config.postNewCustomer + customerId)
    // alert("Form Submitted Successfully");
  }
  refreshList() {
    return this.http.get(this.rootURL + '/values').toPromise().then(res => this.list = res as AccountModel[]);
  }
}
