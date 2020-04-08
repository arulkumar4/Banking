import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AccountModel } from 'src/app/model/account.model';
import { AccountConfig } from 'src/app/constants/account-config';
import { HttpClient } from '@angular/common/http';
import { AccountService } from 'src/app/service/account.service';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-customer-account',
  templateUrl: './customer-account.component.html',
  styleUrls: ['./customer-account.component.css']
})
export class CustomerAccountComponent implements OnInit {

  submitted = false;
  model: AccountModel;
  useraccount: number;
  updatedetails: number;
  customerId: number;
  accountNo: number;
  updateForm: FormGroup;
  formData: AccountModel;
  account_config = AccountConfig;
  myroot = "https://localhost:44395/";
  data: any;
  errormesg: string;
  constructor(private http: HttpClient,
    private fb: FormBuilder,
    private services: AccountService,
    private myRoute: Router,
    private activatedRoute: ActivatedRoute) {
    this.model = new AccountModel();
  }

  ngOnInit() {
    this.getCustomerAccount();

    this.updateForm = this.fb.group({
      firstName: ['', [Validators.required, Validators.minLength(3),
      Validators.maxLength(50), Validators.pattern("^[a-zA-Z]+$")]],
      lastName: ['', [Validators.required, Validators.minLength(3),
      Validators.maxLength(50), Validators.pattern("^[a-zA-Z]+$")]],
      address: ['', [Validators.required, Validators.minLength(3),
      Validators.maxLength(200)]],
      contactNumber: ['', [Validators.required, Validators.minLength(10),
      Validators.maxLength(10), Validators.pattern("^[0-9]*$")]],
      mail: ['', [Validators.required, Validators.minLength(10),
      Validators.maxLength(50), Validators.email]]
    });
  }

  get f() {
    return this.updateForm.controls;
  }

  getCustomerAccount() {
    // debugger;
    this.customerId = 100000090077;
    this.accountNo = 802188699111;
    return this.http.get(this.myroot + this.account_config.getOneCustomerAccount_cusId
      + this.customerId + this.account_config.getOneCustomerAccount_accNo
      + this.accountNo).subscribe(res => {
        console.log(res);
        this.useraccount = 0;
        this.updatedetails = 0;
        this.data = res;
      })
  }
  updateDetails() {
    debugger;
    this.useraccount = 1;
    this.updatedetails = 1;
  }
  putCustomer(formData: AccountModel, id: number) {
    console.log(formData);
    return this.http.put(this.myroot + this.account_config.putCustomerDetails + id, formData);
  }
  onSubmit() {
    this.submitted = true;
    this.model.CustomerId = null;
    this.model.FirstName = "";
    this.model.LastName = "";
    this.model.Address = "";
    this.model.ContactNumber = null;
    this.model.Mail = "";
    if (this.updateForm.valid) {
      // this.formData= new AccountModel();
      this.customerId = 100000090077;
      this.putCustomer(this.updateForm.value, this.customerId).subscribe(res => {
        this.onReset();
        console.log(res);
        this.data = res;
        alert("Your Details Has Been Updated Successfully !!!")
        this.updatedetails === 0;
      })
      // this.myRoute.navigate(['CustomerDetails']);   
    }
    else {
      this.errormesg = "Please fill all the details !!!"
    }
  }
  onReset() {
    this.submitted = false;
    this.updateForm.reset();
  }
}
