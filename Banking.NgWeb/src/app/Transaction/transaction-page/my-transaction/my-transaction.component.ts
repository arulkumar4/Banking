import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';

import * as $ from 'jquery';
import { MyTransaction } from '../../../model/transaction/myTransaction.model';
import { MyTransactionService } from '../../../service/transaction/myTransaction.service';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
@Component({
  selector: 'app-my-transaction',
  templateUrl: './my-transaction.component.html',
  styleUrls: ['./my-transaction.component.css']
})
export class MyTransactionComponent implements OnInit, AfterViewInit {
  transaction: MyTransaction[];
  msg: boolean = true;
  errormsg: string;
  public displayedColumns = ['AccountId', 'TransactionId', 'ReceiverName', 'ReceiverAccountId', 'TransactionDate', 'TransactionType', 'TransferAmount', 'Status'];
  public dataSource = new MatTableDataSource<MyTransaction>();
  AccountID: string;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;



  constructor(private service: MyTransactionService) {
    
  }

  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }


   
    


  ngOnInit() {
    this.AccountID = "ididididid";
    this.service.getDataFromAPI(this.AccountID).subscribe((data: MyTransaction[]) => {
      this.dataSource.data = data;
      if (this.dataSource.data == null) {
        this.msg = false;
      }
    }, error => {
      this.msg = error;

    });

  }
  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;

  }

}
