import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AccountModel } from 'src/app/model/account.model';
import { AccountConfig } from 'src/app/constants/account-config';
import { ExtraData } from 'src/app/model/account.datamodel';
import { HttpClient } from '@angular/common/http';
import { AccountService } from 'src/app/service/account.service';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-customer-account',
  templateUrl: './customer-account.component.html',
  styleUrls: ['./customer-account.component.css']
})
export class CustomerAccountComponent implements OnInit {

  updatesubmitted = false;
  deletesubmitted = false;
  submitted = false;
  model: AccountModel[];
  useraccount: number;
  updatedetails: number;
  changepassword: number;
  deleteacc: number;
  customerId: number;
  accountNo: number;
  updateForm: FormGroup;
  changepasswordform: FormGroup;
  deleteaccform: FormGroup;
  formData: AccountModel;
  extradata: ExtraData;
  account_config = AccountConfig;
  myroot = "https://localhost:44395/";
  data: any;
  updatedata: any;
  passdata: any;
  deldata: any;
  updateError: string = "";
  passworderror: string;
  passerror: string;
  constructor(private http: HttpClient,
    private fb: FormBuilder,
    private services: AccountService,
    private myRoute: Router,
    private activatedRoute: ActivatedRoute) {
    this.customerId = 100000090077;
    this.accountNo = 802188699111;
    // this.model=new AccountModel();
    this.extradata = new ExtraData();
    this.updatesubmitted = false;
    this.deletesubmitted = false;
    this.model = [];
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
      Validators.maxLength(50), Validators.email]],
    });

    this.changepasswordform = this.fb.group({
      oldpassword: ['', [Validators.required, Validators.minLength(4),
      Validators.maxLength(100)]],
      newpassword: ['', [Validators.required, Validators.minLength(4),
      Validators.maxLength(100)]],
      confirmpassword: ['', [Validators.required, Validators.minLength(4),
      Validators.maxLength(100)]],
    });

    this.deleteaccform = this.fb.group({
      password: ['', [Validators.required, Validators.minLength(4),
      Validators.maxLength(100)]],
      newpassword: ['', [Validators.required, Validators.minLength(4),
      Validators.maxLength(100)]],
    })
  }

  get f() {
    return this.updateForm.controls;
  }
  get c() {
    return this.changepasswordform.controls;
  }
  get d() {
    return this.deleteaccform.controls;
  }

  getCustomerAccount() {
    // debugger;
    return this.http.get(this.myroot + this.account_config.getOneCustomerAccount_cusId
      + this.customerId + this.account_config.getOneCustomerAccount_accNo
      + this.accountNo).subscribe(res => {
        console.log(res);
        this.useraccount = 0;
        this.updatedetails = 0;
        this.data = res;
      })
  }

  putPassword(extradata: ExtraData) {
    console.log(extradata);
    return this.http.put(this.myroot + this.account_config.putAccountPassword, extradata);
  }
  deleteAccount(no: number, pass: any) {
    console.log(pass, no);
    return this.http.delete(this.myroot + this.account_config.deleteAccount_no + no
      + this.account_config.deleteAccount_pass + pass)
  }

  updateDetails() {
    this.useraccount = 1;
    this.changepassword = 0;
    this.updatedetails = 1;
    this.deleteacc = 0;
    this.services.getCustomerDetails(this.customerId, this.accountNo).subscribe((res: AccountModel[]) => {
    this.model = res;
      console.log(this.model);
    })
  }
  changePassword() {
    this.useraccount = 1;
    this.updatedetails = 0;
    this.changepassword = 1;
    this.deleteacc = 0;
  }
  delaccount() {
    this.useraccount = 1;
    this.updatedetails = 0;
    this.changepassword = 0;
    this.deleteacc = 1;
  }

  UpdateDetailsSubmit(form: AccountModel, id: number) {
    debugger;
    if (this.updateForm.valid) {
      // this.formData= new AccountModel();
      this.services.putCustomer(this.updateForm.value, id).subscribe(res => {
        console.log(res);
        this.updatedata = res;
        alert(this.updatedata)
        this.updateForm.reset();
        this.updatesubmitted = false;
      })
      // this.myRoute.navigate(['CustomerDetails']);   
    }
    else {
      this.updateError = "Please fill all the details !!!"
    }
  }
  ChangePasswordSubmit(extradata: ExtraData) {
    debugger;
    this.submitted = true;
    if (this.changepasswordform.valid) {
      if (this.extradata.NewPassword === this.extradata.Password) {
        this.passworderror = "New password cannot be same as OldPassword !!!"
      }
      else {
        if (this.extradata.ConfirmPassword === this.extradata.NewPassword) {
          this.putPassword(this.extradata).subscribe(res => {
            // console.log(res);
            this.passdata = res;
            alert(this.passdata);
            this.changepasswordform.reset();
            this.submitted = false;
          });
        }
        else {
          this.passworderror = "New and Confirm password doesn't match !!!"
        }
      }
    }
    else {
      this.passworderror = "Invalid Form !!!"
    }
  }
  DeleteAccount(extradata: ExtraData) {
    this.deletesubmitted = true;
    alert("Are you sure? you want to Delete your Account?")
    if (this.deleteaccform.valid) {
      if (this.extradata.Password === this.extradata.NewPassword) {
        this.deleteAccount(this.extradata.Number, this.extradata.Password)
          .subscribe(res => {
            // console.log(res);
            this.deldata = res;
            alert(this.deldata);
            this.deleteaccform.reset();
            this.deletesubmitted = false;
          });
      }
      else {
        this.passerror = "Passwords doesn't match !!!"
      }
    }
    else {
      this.passerror = "Invalid Form !!!"
    }
  }
  newaccount() {
    this.myRoute.navigate(['/customer'])
  }
}
