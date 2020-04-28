import { Component, OnInit } from '@angular/core';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';
declare var $: any;

@Component({
  selector: 'app-transaction-page',
  templateUrl: './transaction-page.component.html',
  styleUrls: ['./transaction-page.component.css']
})
export class TransactionPageComponent implements OnInit {
  show: number;
  href: any;
  check: any = "/Customerheader/transaction-page";

  constructor(private route: Router)
  {}
  fundTransfer() {
this.check = null;
    this.route.navigateByUrl("/Customerheader/transaction-page/fund-transfer");
  }
  payBills() {
this.check = null;
    this.route.navigateByUrl("/Customerheader/transaction-page/pay-bills");
  }
  myTransaction() {
this.check = null;
    this.route.navigateByUrl("/Customerheader/transaction-page/my-transaction");
  }

  ngOnInit() {
    this.href = this.route.url;
  }

}
