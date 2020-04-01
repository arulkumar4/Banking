import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators} from '@angular/forms';
import { AccountService } from '../service/account.service';
import { AccountModel } from '../model/account.model';
import { HttpClient } from '@angular/common/http';
import {AccountConfig} from '../constants/account-config';
import {Router,ActivatedRoute} from '@angular/router';
import {AppRoutingModule} from '../app-routing.module';
import { EventEmitter } from 'protractor';
import { moment } from 'ngx-bootstrap/chronos/test/chain';
@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
})

export class CustomerComponent implements OnInit {

  newCustomer=false;
  ageError:string;
  age:any;
  data:any;
  birthday:any;
  value: any;
  errormessage:string;
  account =new AccountModel();
  account_config = AccountConfig;
  registerationForm: FormGroup;
  submitted=false;
  accountregister:any;
  formData: AccountModel;
  datevalue=new Date();
  myroot= "https://localhost:44395/";
  gen: string[] = ['Male', 'Female', 'Other'];

  constructor(private services:AccountService, 
              private fb:FormBuilder,
              private http: HttpClient,
              private myRoute: Router,
              private activatedRoute:ActivatedRoute) 
              { }
              onChange: (value: any) => void;
              
  ngOnInit():void 
  {
    this.registerationForm = this.fb.group({
      firstName: ['',[Validators.required,Validators.minLength(3),
                      Validators.maxLength(50),Validators.pattern("^[a-zA-Z]+$")]],
      lastName:['',[Validators.required, Validators.minLength(3),
                    Validators.maxLength(50),Validators.pattern("^[a-zA-Z]+$")]],
      address:['',[Validators.required, Validators.minLength(3),
                   Validators.maxLength(200),]],
      contactNumber:['',[Validators.required,Validators.minLength(10),
                         Validators.maxLength(10),Validators.pattern("^[0-9]*$")]],
      gender:['',[Validators.required]],
      dob:['',[Validators.required]],
      mail:['',[Validators.required, Validators.minLength(10),
                Validators.maxLength(50),Validators.email]],
      balance:['',[Validators.required,Validators.maxLength(15),Validators.pattern("^[0-9]*$")]],
      accountType:['',[Validators.required, Validators.minLength(3),
                       Validators.maxLength(7)]],
      password:['',[Validators.required, Validators.minLength(4),
                    Validators.maxLength(100)]],
      employeeId:['',[Validators.required, Validators.minLength(4),
                    Validators.maxLength(10),Validators.pattern("^[0-9]*$")]],
    });
  }
  
  get f() {
    return this.registerationForm.controls;
    } 

  onDateChange(newDate: Date) {
  }

  bsValueChange(val){
    setTimeout(()=>{
      this.value = val;
      if (val instanceof Date){
        this.onDateChange(new Date(val.getTime() - val.getTimezoneOffset() * 60 * 1000));  
        console.log(val);
        this.birthday=val;
        this.ageValidation(this.birthday);
        if(this.age>=18)
        {
          console.log(this.age);
          this.account.Dob=val;
        }
        else 
        {
          this.age=0;
          this.ageError="Your age must be atleast 18!!!";
        }
        // let timeDiff = Math.abs(Date.now() - this.account.Dob.getTime());
        // this.age = Math.floor((timeDiff / (1000 * 3600 * 24))/365.25);
        // if(this.age>=18)
        // {
        //   console.log(this.age);
        //   this.ageError="Your age must be atleast 18!!!";
        // }
        // else 
        // {
        //   console.log(this.age)
        // }
      }
      else {
        this.onDateChange(val);
      }
    });
  }
  public ageValidation(birthdate: any):number
  {
    const date = new Date(birthdate);
    this.age = this.datevalue.getFullYear() - birthdate.getFullYear();
    const month = this.datevalue.getMonth() - this.birthday.getMonth();
    if(month < 0 || ( month == 0 && this.datevalue.getDate() < this.birthday.getDate()))
    {
      this.age--;
    }
    return this.age;
  }
  postCustomer(formData: AccountModel) {
    debugger;
    return this.http.post(this.myroot+this.account_config.postNewCustomer,formData).subscribe(res=>{
      this.onReset();
      console.log(res);
      this.data=res;
      
      // alert("Form Submitted Successfully");
    })
  }

    onSubmit()
    {
    this.submitted = true;
    this.account.FirstName="";
    this.account.LastName="";
    this.account.Address="";
    this.account.ContactNumber=null;
    this.account.Gender="";
    this.account.Dob=null
    this.account.Mail="";
    this.account.Balance=null;
    this.account.AccountType="";
    this.account.Password="";
    this.account.EmployeeId=null
          if (this.registerationForm.valid) 
          {
            this.postCustomer(this.registerationForm.value)
                // this.myRoute.navigate(['CustomerDetails']);   
            this.newCustomer=true;
          }
          else
          {
            this.errormessage="Please fill all the details"
          }
    }
        
  onReset()
  {
    this.submitted = false;
    this.registerationForm.reset();
  }
}
