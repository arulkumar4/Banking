import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AccountService } from '../service/account.service';
import { AccountModel } from '../model/account.model';
import { HttpClient } from '@angular/common/http';
import { AccountConfig } from '../constants/account-config';
import { Router, ActivatedRoute } from '@angular/router';
import { AppRoutingModule } from '../app-routing.module';
import { ExtraData } from '../model/account.datamodel';
import { AccountTypeService } from '../service/account-type.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
})

export class CustomerComponent implements OnInit {

  newCustomer = false;
  ageError: string;
  age: any;
  data: any;
  birthday: any;
  value: any;
  errormessage: string;
  empId: number;
  account: AccountModel;
  accounts: AccountModel[];
  extradata: ExtraData;
  account_config = AccountConfig;
  registerationForm: FormGroup;
  submitted = false;
  accountregister: any;
  formData: AccountModel;
  datevalue = new Date();
  myroot = "https://localhost:44395/";
  gen: string[] = ['Male', 'Female', 'Other'];
  generror: any;
  passerror: string;
  genmesg = false;
  string: string;
  AccountType: any;
  accountType: string;
  buttonSelection:any;

  constructor(private services: AccountService,
    private fb: FormBuilder,
    private http: HttpClient,
    private myRoute: Router,
    private accType: AccountTypeService,
    private activatedRoute: ActivatedRoute, private route: ActivatedRoute)
  {
    this.account = new AccountModel();
    this.extradata = new ExtraData();
    this.empId = 10000;
    this.accounts = [];
    this.string = "Process Failed. Check Your Data And Please Try Again !!!"
  }
  onChange: (value: any) => void;

  ngOnInit(): void {
    this.registerationForm = this.fb.group({
      firstName: ['', [Validators.required, Validators.minLength(3),
      Validators.maxLength(50), Validators.pattern("^[a-zA-Z]+$")]],
      lastName: ['', [Validators.required, Validators.minLength(3),
      Validators.maxLength(50), Validators.pattern("^[a-zA-Z]+$")]],
      address: ['', [Validators.required, Validators.minLength(3),
      Validators.maxLength(200),]],
      contactNumber: ['', [Validators.required, Validators.minLength(10),
      Validators.maxLength(10), Validators.pattern("^[0-9]*$")]],
      gender: ['', [Validators.required]],
      dob: ['', [Validators.required]],
      mail: ['', [Validators.required, Validators.minLength(10),
      Validators.maxLength(50), Validators.email]],
      balance: ['', [Validators.required, Validators.maxLength(15), Validators.pattern("^[0-9]*$")]],
      accountType: ['', [Validators.required, Validators.minLength(3),
      Validators.maxLength(7)]],
      password: ['', [Validators.required, Validators.minLength(4),
      Validators.maxLength(100)]],
      confirmpassword: ['', [Validators.required, Validators.minLength(4),
      Validators.maxLength(100)]],
    });
    this.accType.GetAllAccountType().subscribe((AccountTypedata: any) => {
      this.AccountType = AccountTypedata;

    });
    this.buttonSelection = this.route.snapshot.paramMap.get('id');

  
  }


  get f() {
    return this.registerationForm.controls;
  }

  getAccounType() {  }

  onDateChange(newDate: Date) {
  }
  cancel() {
    this.myRoute.navigateByUrl('/login');
  }

  bsValueChange(val) {
    setTimeout(() => {
      this.value = val;
      if (val instanceof Date) {
        this.onDateChange(new Date(val.getTime() - val.getTimezoneOffset() * 60 * 1000));
        this.birthday = val;
        this.ageValidation(this.birthday);
        if (this.age < 18) {
          this.ageError = "Your age must be atleast 18!!!";
          this.account.Dob = null;
          this.age = 0;
        }
        else {
          this.account.Dob = val;
        }
      }
      else {
        this.onDateChange(val);
      }
    });
  }
  public ageValidation(birthdate: any): number {
    let timeDiff = Math.abs(Date.now() - this.account.Dob.getTime());
    this.age = Math.floor((timeDiff / (1000 * 3600 * 24)) / 365.25);
    return this.age;
  }

  onSubmit() {
    debugger;
    this.submitted = true;
    if (this.account.Gender == null || this.account.Gender == undefined) {
      this.genmesg = true;
      this.generror = "Please select your gender !!!"
    }
    if (this.registerationForm.valid) {
      if (this.account.Password === this.extradata.ConfirmPassword) {
        this.account.Role = "Customer";
        this.services.postCustomer(this.account, this.empId).subscribe((res: AccountModel[]) => {
          if (res.length != 0 ) {
            this.data = res;
            alert("Your New Account Created Succesfully !!!");
            this.newCustomer = true;
          }
          else {
            alert(res);
            this.registerationForm.reset();
          }
        })
      }
      else {
        this.passerror = "Passwords doesn't match !!!"
      }
    }
    else {
      this.errormessage = "Invalid Form !!!"
    }
  }
  login() {
    this.myRoute.navigate(['/login']);
  } 
  onReset() {
    this.submitted = false;
    this.registerationForm.reset();
  }
}
