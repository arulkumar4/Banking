import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { myFunction } from 'src/assets/scripts/custom.js';
import { UserService } from '../../service/Bank/user.service';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  myForm: FormGroup
  submitted: boolean = false;
  passwordMask: any;
  username: string;
  passwordvalue: string;
  isLoginError: boolean = false;



  constructor(private userService: UserService, private router: Router) { 
    this.myForm = new FormGroup(
      {
        emailAddress: new FormControl(null, Validators.compose([
          Validators.required,
          Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')
        ])),
        password: new FormControl(null, Validators.compose([
          Validators.required]))
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
  if (this.myForm.valid) {
    console.log(this.emailAddress.value);
    this.username = this.emailAddress.value;
    this.passwordvalue = this.password.value;
    this.userService.userAuthentication(this.username, this.passwordvalue).subscribe((data: any) => {
     
      localStorage.setItem('userToken', data.access_token);
      localStorage.setItem('userRoles', data.role)
      if (this.userService.roleMatch(['Manager'])) {
        console.log("deril");
        this.router.navigate(['employeedashboard/welcome']);
      }
      else if (this.userService.roleMatch(['Employee'])) {
        console.log("hi");
        this.router.navigate(['/customerdashboard/welcomecustomer']);
      }
      else if (this.userService.roleMatch(['Customer'])) {
        this.router.navigate(['/customerDashboard']);
      }

      //if(data.role=="Employee")


    },
      (err: HttpErrorResponse) => {
        this.isLoginError = true;
        console.log(this.isLoginError);
      })
  }
}
func()
{
  myFunction();
}


  ngOnInit() {
  }
}
