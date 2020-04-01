import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { myFunction } from 'src/assets/scripts/custom.js';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  myForm:FormGroup
  submitted:boolean = false;
  passwordMask:any;

  
  constructor() { 
    this.myForm = new FormGroup(
      {emailAddress:new FormControl(null, Validators.compose([
        Validators.required,
        Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')
      ])),
        password:new FormControl(null,Validators.compose([
          Validators.required,
          Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}'
)]))
      })
  }
  public get emailAddress()
  {
    return this.myForm.get("emailAddress");
  }
  public get password()
  {
    return this.myForm.get("password");
  }
login()
{
  this.submitted = true;
  if(this.myForm.valid)
  {
    console.log("sucess");
  }
}
func()
{
  myFunction();
}


  ngOnInit() {
  }
}
