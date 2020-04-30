import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AccountModel } from 'src/app/model/account.model';
import { AccountConfig } from 'src/app/constants/account-config';
import { ExtraData } from 'src/app/model/account.datamodel';
import { HttpClient } from '@angular/common/http';
import { AccountService } from 'src/app/service/account.service';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from '../../service/Bank/user.service';


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
  userClaims: AccountModel;







  constructor(private http: HttpClient,
    private userService: UserService,
    private fb: FormBuilder,
    private services: AccountService,
    private myRoute: Router,
    private activatedRoute: ActivatedRoute) {
    this.extradata = new ExtraData();
    this.updatesubmitted = false;
    this.deletesubmitted = false;
    this.model = [];
  }

  ngOnInit() {
    this.loginDetails();
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
    this.userService.getUserClaimsCustomer().subscribe((data: AccountModel) => {
      this.userClaims = data;
      return this.http.get(this.myroot + this.account_config.getOneCustomerAccount_cusId
        + this.userClaims.CustomerId + this.account_config.getOneCustomerAccount_accNo
        + this.userClaims.Number).subscribe(res => {
          this.useraccount = 0;
          this.updatedetails = 0;
          this.data = res;
        })
    })

  }

  putPassword(extradata: ExtraData) {
    return this.http.put(this.myroot + this.account_config.putAccountPassword, extradata);
  }


  loginDetails() {
    this.userService.getUserClaimsCustomer().subscribe((data: AccountModel) => {
      this.userClaims = data;
    })
  }

  updateDetails() {
    this.useraccount = 1;
    this.changepassword = 0;
    this.updatedetails = 1;
    this.deleteacc = 0;
    this.services.getCustomerDetails(this.userClaims.CustomerId, this.userClaims.Number).subscribe((res: AccountModel[]) => {
      this.model = res;
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
    if (this.updateForm.valid) {
      this.services.putCustomer(this.updateForm.value, id).subscribe(res => {
        this.updatedata = res;
        alert(this.updatedata)
        this.updateForm.reset();
        this.useraccount = 0;
        this.updatedetails = 0;
        this.updatesubmitted = false;
      })
    }
    else {
      this.updateError = "Please fill all the details !!!"
    }
  }
  ChangePasswordSubmit() {
    this.submitted = true;
    if (this.changepasswordform.valid) {
      if (this.extradata.NewPassword === this.extradata.Password) {
        this.passworderror = "New password cannot be same as OldPassword !!!"
      }
      else {
        if (this.extradata.ConfirmPassword === this.extradata.NewPassword) {
          this.extradata.Number = this.userClaims.Number;
          this.extradata.Mail = this.userClaims.Mail;
          this.putPassword(this.extradata).subscribe(res => {
            this.passdata = res;
            this.submitted = false;
            alert(this.passdata);
            this.changepasswordform.reset();
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
  newaccount() {
    this.myRoute.navigate(['/Customerheader/customer', 1]);
  }
}
