import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

import { FormGroup, FormControl, Validators, ValidatorFn, ValidationErrors } from '@angular/forms';
import { Transaction } from '../../../model/transaction/transaction.model';
import { TransactionResult } from '../../../model/transaction/TransactionResult.Model';
import { TransactionType } from '../../../model/transaction/transactionType.model';
import { TransactionService } from '../../../service/transaction/transaction.service';
import { UserService } from '../../../service/Bank/user.service';
import { AccountService } from '../../../service/account.service';
import { AccountModel } from '../../../model/account.model';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Rx';



const myForm: ValidatorFn = (control: FormGroup): ValidationErrors | null => {
  const email = control.get('ReciverAccountId');
  const reenteremail = control.get('ConfirmAccountID');
  return email && reenteremail && email.value !== reenteremail.value ?
    { 'emailNotSame': true } : null;
};

@Component({
  selector: 'app-fund-transfer',
  templateUrl: './fund-transfer.component.html',
  styleUrls: ['./fund-transfer.component.css']
})
export class FundTransferComponent implements OnInit {
  submitted: boolean = false;
  selectedValue: any = "";
  show: boolean = true;
  showTranDetails: boolean = true;
  dataTransaction: Transaction;
  transaction: TransactionResult;
  trans: TransactionType;
  myForm: FormGroup;
  userClaims: AccountModel;
  Details: AccountModel;
  id: any;
  showBox: boolean = false;
  errorMsg: boolean = true;

  constructor(private transactionService: TransactionService, private userService: UserService, private accountService: AccountService) {
    this.transaction = new TransactionResult();
    this.showTranDetails = true;
    this.dataTransaction = new Transaction();
    this.transactionService.getTransactionTypeDataFromAPI().subscribe((data: any) => {
      this.trans = data;
      console.log(this.trans);
    });
    this.myForm = new FormGroup(
      {
        ReciverAccountId: new FormControl(null, Validators.compose([
          Validators.required])),
        ConfirmAccountID: new FormControl(null, Validators.compose([
          Validators.required])),
        ReceiverName: new FormControl(null, Validators.compose([
          Validators.required,
          ])),
        TransferAmount: new FormControl(null, Validators.compose([
          Validators.required,
          Validators.pattern('[0-9]+'),
          Validators.maxLength(5)]))
      }, { validators: myForm }
    )
  }
  public get ReciverAccountId() {
    return this.myForm.get("ReciverAccountId")
  }

  public get ReceiverName() {
    return this.myForm.get("ReceiverName");
  }
  public get ConfirmAccountID() {
    return this.myForm.get("ConfirmAccountID");
  }
  public get TransferAmount() {
    return this.myForm.get("TransferAmount");
  }
  getChangeType(event) {
    this.dataTransaction.TransactionTypeId = event.target.value;
  }
  send() {
    this.submitted = true;
    if (this.myForm.valid) {

      this.dataTransaction.ReceiverName = this.myForm.get("ReceiverName").value;
      this.dataTransaction.ReciverAccountId = this.myForm.get("ReciverAccountId").value;
      this.dataTransaction.TransferAmount = this.myForm.get("TransferAmount").value;
      this.loginDetails().then((data: AccountModel) => {
        this.dataTransaction.SenderName = data[0].FullName;
        this.dataTransaction.AccountId = data[0].Id;
        this.transactionService.getDataFromAPI(this.dataTransaction).subscribe((data: TransactionResult) => {
          this.transaction = data;
          if (this.transaction != null) {
            this.showTranDetails = false;
          }

        }, (error) => {
          this.showBox = true;
          this.errorMsg = error;
        });
      });

    }

  }
  getValueFromService(transactionData: TransactionResult) {
    this.transactionService.getDataFromAPI(transactionData)
  }

  selectFunction(event: any) {
    this.selectedValue = event.target.value;
    if (this.selectedValue == "TypeYourOwn") {
      this.show = false;
    }
    else {
      this.show = true;
    }
  }

  loginDetails(): Promise<AccountModel> {

    return new Promise(resolve => {
      this.userService.getUserClaimsCustomer().subscribe((logData: AccountModel) => {
        this.userClaims = logData;
        return this.accountService.getCustomerDetails(this.userClaims.CustomerId, this.userClaims.Number).map(value => value)
          .subscribe((data: AccountModel) => {
            console.log(data);
            this.Details = data;
            resolve(this.Details);
          });
      });
    });
  }



  ngOnInit() {
    this.loginDetails().then((data: AccountModel) => {
      this.id = data[0].FullName + "/" + data[0].Id;
      console.log(this.id);
    })
  }

}
