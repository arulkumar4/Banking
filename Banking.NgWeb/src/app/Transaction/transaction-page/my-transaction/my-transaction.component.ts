import { Component, OnInit } from '@angular/core';

import * as $ from 'jquery';
import { MyTransaction } from '../../../model/transaction/myTransaction.model';
import { MyTransactionService } from '../../../service/transaction/myTransaction.service';
@Component({
  selector: 'app-my-transaction',
  templateUrl: './my-transaction.component.html',
  styleUrls: ['./my-transaction.component.css']
})
export class MyTransactionComponent implements OnInit {
  AccountID: string;
  transaction: MyTransaction[];
  showHeadings: boolean = true;
  msg: boolean = true;
  errormsg: string;

  constructor(private service: MyTransactionService) {
    this.AccountID = "ididididid";
    this.service.getDataFromAPI(this.AccountID).subscribe((data: MyTransaction[]) => {
      this.showHeadings = false;
      this.transaction = data;
      if (this.transaction == null) {
        this.showHeadings = true;
        this.msg = false;
      }
    }, error => {
        this.msg = error;

    });
    
  }

   
    


  ngOnInit() {

  }

}
