import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../../service/account.service';
import { AccountModel } from '../../model/account.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-customer-account',
  templateUrl: './customer-account.component.html',
  styleUrls: ['./customer-account.component.css']
})
export class CustomerAccountComponent implements OnInit {
  account: Observable<AccountModel[]>;
accmod:any;
  constructor(private accountservice: AccountService, private myRoutes: Router){}

  ngOnInit() {
    debugger;
    this.accountservice.getAllAccounts().subscribe(value => {
      this.account=value;
    console.log(this.account);

   });
  }

}
