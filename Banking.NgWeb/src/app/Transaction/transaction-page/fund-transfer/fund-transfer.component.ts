import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

import { FormGroup, FormControl, Validators, ValidatorFn, ValidationErrors } from '@angular/forms';
import { Transaction } from '../../../model/transaction/transaction.model';
import { TransactionResult } from '../../../model/transaction/TransactionResult.Model';
import { TransactionType } from '../../../model/transaction/transactionType.model';
import { TransactionService } from '../../../service/transaction/transaction.service';


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
  submitted:boolean=false;
  selectedValue:any = "";
  show:boolean = true;
  showTranDetails:boolean=true;
  dataTransaction:Transaction;
  transaction:TransactionResult;
  trans:TransactionType;
  myForm: FormGroup;
  showBox: boolean = false;
  errorMsg: boolean = true; 

  constructor(private transactionService:TransactionService) { 
    this.transaction = new TransactionResult();
    this.showTranDetails = true;
    this.dataTransaction = new Transaction();
      this.transactionService.getTransactionTypeDataFromAPI().subscribe((data:any)=>
      {
        this.trans = data;
       });
       this.myForm = new FormGroup(
         {
           SenderName: new FormControl(null,Validators.compose([Validators.required])),
           ReciverAccountId:new FormControl(null,Validators.compose([
             Validators.required])),
            ConfirmAccountID: new FormControl(null,Validators.compose([
              Validators.required])), 
           ReceiverName:new FormControl(null,Validators.compose([
             Validators.required,
            Validators.pattern('[A-Za-z.]+')])),
           TransferAmount:new FormControl(null,Validators.compose([
             Validators.required,
             Validators.pattern('[0-9]+'),
            Validators.maxLength(5)]))
         },{ validators:myForm}
        )
  }
  public get SenderName()
  {
    return this.myForm.get("SenderName");
  }
  public get ReciverAccountId()
  {
    return this.myForm.get("ReciverAccountId")
  }

  public get ReceiverName()
  {
    return this.myForm.get("ReceiverName");
  }
  public get ConfirmAccountID()
  {
    return this.myForm.get("ConfirmAccountID");
  }
  public get TransferAmount()
  {
    return this.myForm.get("TransferAmount");
  }
  getChangeType(event)
  {
    this.dataTransaction.TransactionTypeId = event.target.value;
  }
  send()
  {
    this.submitted = true;
    if(this.myForm.valid)
    {
      this.dataTransaction.SenderName = this.myForm.get("SenderName").value;
      this.dataTransaction.ReceiverName = this.myForm.get("ReceiverName").value;
      this.dataTransaction.ReciverAccountId = this.myForm.get("ReciverAccountId").value;
      this.dataTransaction.TransferAmount = this.myForm.get("TransferAmount").value;
      this.dataTransaction.AccountId = "idididid";
      this.transactionService.getDataFromAPI(this.dataTransaction).subscribe((data:TransactionResult)=>{
      this.transaction = data;
      console.log(this.transaction);
      if(this.transaction !=null)
      {
        this.showTranDetails = false;
      }

      }, (error) => {
          this.showBox = true;
          this.errorMsg = error;
      });

    }
    
  }
  getValueFromService(transactionData:TransactionResult)
  {
    this.transactionService.getDataFromAPI(transactionData)
  }
 
  selectFunction(event :any)
  {
    this.selectedValue = event.target.value;
    if(this.selectedValue == "TypeYourOwn")
    {
        this.show = false;
    }
    else
    {
      this.show = true;
    }
  }


  ngOnInit() {
  }

}
