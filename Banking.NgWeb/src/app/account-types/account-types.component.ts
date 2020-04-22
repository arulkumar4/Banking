import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AccountTypeService } from '../service/account-type.service';
import { AccountType } from '../model/account-type.model';
import { HttpClient } from '@angular/common/http';
import { AccountConfig } from '../constants/account-config';

@Component({
  selector: 'app-account-types',
  templateUrl: './account-types.component.html',
  styleUrls: ['./account-types.component.css']
})
export class AccountTypesComponent implements OnInit {

  CreateAccountResult: string;
  account: AccountType[];
  account_config = AccountConfig;
  deleteAccountResult: AccountType;
  updatesubmitted = false;
  newsubmitted = false;
  newbutton = true;
  val;
  Updateval;
  Deleteval;
  id: any;
  myroot = "https://localhost:44395/";
  updatetype: number;
  newacctype: number;
  alltype: number;
  updateForm: FormGroup;
  newForm: FormGroup;
  updateAccountResult: string;
  newTypeResult: string;
  updateError: string;
  newError: string;
  getdata: AccountType;
  gettype: AccountType;
  newerrormsg = false;
  errormesg = false;
  constructor(private accountTypeService: AccountTypeService,
    private fb: FormBuilder,
    private httpRequest: HttpClient) {
    this.newbutton = true;
    this.account = [];
    this.alltype = 1;
    this.updatetype = 0;
    this.newacctype = 0;
  }

  ngOnInit() {
    this.GetAllAccountTypes();
    this.updateForm = this.fb.group({
      Id: [''],
      Type: [''],
      MinimumBalance: ['', [Validators.required, Validators.minLength(4),
      Validators.maxLength(6), Validators.pattern("^[0-9]*$")]],
      TransactionLimit: ['', [Validators.required, Validators.minLength(5),
      Validators.maxLength(10), Validators.pattern("^[0-9]*$")]],
    });

    this.newForm = this.fb.group({
      Type: ['', [Validators.required, Validators.minLength(3),
      Validators.maxLength(50), Validators.pattern("^[a-zA-Z]+$")]],
      MinimumBalance: ['', [Validators.required, Validators.minLength(4),
      Validators.maxLength(6), Validators.pattern("^[0-9]*$")]],
      TransactionLimit: ['', [Validators.required, Validators.minLength(5),
      Validators.maxLength(10), Validators.pattern("^[0-9]*$")]],
    });
  }

  get f() {
    return this.updateForm.controls;
  }
  get n() {
    return this.newForm.controls;
  }

  GetAllAccountTypes() {
    this.accountTypeService.GetAllAccountType().subscribe((data: AccountType) => {
      this.getdata = data;
      console.log(this.getdata)
    })
  }
  postAccountType(accountTypeDetail: AccountType) {
    return this.httpRequest.post(this.myroot + this.account_config.postAccountType, accountTypeDetail)
  }
  onNewAccTypeSubmit() {
    this.newsubmitted = true;
    if (this.newForm.valid) {
      // this.formData= new AccountModel();
      this.postAccountType(this.newForm.value).subscribe((data: any) => {
        console.log(data);
        this.newTypeResult = data;
        alert(this.newTypeResult);
        this.GetAllAccountTypes();
        this.alltype = 1;
        this.updatetype = 0;
        this.newacctype = 0;
        this.newsubmitted = false;
      })

    }
    {
      this.newerrormsg = true;
      this.newError = "Invalid Form !!!"
    }
  }
  updatetypeform(id: number) {
    debugger;
    this.newbutton = true;
    this.alltype = 0;
    this.updatetype = 1;
    this.newacctype = 0;
    this.accountTypeService.GetAccountType(id).subscribe((data: AccountType[]) => {
      this.account = data;
    })
  }
  UpdateAccountType(accountTypeDetail: AccountType[]) {
    console.log(accountTypeDetail)
    return this.httpRequest.put(this.myroot + this.account_config.putAccountType, accountTypeDetail);
  }
  onAccTypeSubmit() {
    debugger;
    this.updatesubmitted = true;
    if (this.updateForm.valid) {
      // this.formData= new AccountModel();
      this.UpdateAccountType(this.updateForm.value).subscribe((data: any) => {
        console.log(data);
        this.updateAccountResult = data;
        this.GetAllAccountTypes();
        alert(this.updateAccountResult)
        this.alltype = 1;
        this.updatetype = 0;
        this.newacctype = 0;
        this.updatesubmitted = false;
      })
    }
    else {
      this.errormesg = true;
      this.updateError = "Invalid Form !!!"
    }
  }
  DeleteAccountType(accountType: string) {
    return this.httpRequest.delete(this.myroot + this.account_config.deleteAccountType + accountType);
  }

  onDelete(type: string) {
    alert("Are You Sure? You want to delete this Account Type?");
    this.DeleteAccountType(type).subscribe((data: any) => {
      this.deleteAccountResult = data;
      this.GetAllAccountTypes();
      alert(this.deleteAccountResult);
    })
  }
  new() {
    this.newbutton = false;
    this.alltype = 0;
    this.updatetype = 0;
    this.newacctype = 1;
  }
  back() {
    this.GetAllAccountTypes();
    this.updatesubmitted = false;
    this.newsubmitted = false;
    this.newbutton = true;
    this.errormesg = false;
    this.alltype = 1;
    this.updatetype = 0;
    this.newacctype = 0;
  }
}
