import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';

import * as $ from 'jquery';
import { MyTransaction } from '../../../model/transaction/myTransaction.model';
import { MyTransactionService } from '../../../service/transaction/myTransaction.service';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { UserService } from '../../../service/Bank/user.service';
import { AccountService } from '../../../service/account.service';
import { AccountModel } from '../../../model/account.model';
@Component({
  selector: 'app-my-transaction',
  templateUrl: './my-transaction.component.html',
  styleUrls: ['./my-transaction.component.css']
})
export class MyTransactionComponent implements OnInit, AfterViewInit {
  transaction: MyTransaction[];
  msg: boolean = true;
  userClaims: AccountModel;
  errormsg: string;
  public displayedColumns = ['AccountId', 'TransactionId', 'ReceiverName', 'ReceiverAccountId', 'TransactionDate', 'TransactionType', 'TransferAmount', 'Status'];
  public dataSource = new MatTableDataSource<MyTransaction>();
  AccountID: string;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;




  constructor(private service: MyTransactionService, private userService: UserService, private accountService: AccountService) {

  }

  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  getCustomerDetails() {
   
    

  }

ngOnInit() {
  this.userService.getUserClaimsCustomer().subscribe((logData: AccountModel) => {
    this.userClaims = logData;
    this.accountService.getCustomerDetails(this.userClaims.CustomerId, this.userClaims.Number).subscribe((loginData: AccountModel) => {
      this.service.getDataFromAPI(loginData[0].Id).subscribe((data: MyTransaction[]) => {
        this.dataSource.data = data;
        if (this.dataSource.data == null) {
          this.msg = false;
        }
      }, error => {
        this.msg = error;

      });
    });
  });
  }
  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;

  }

}
