import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from '../../service/Bank/user.service';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

declare const myFunction: any
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
  wrongCredentials: boolean = false;



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
  public get emailAddress() {
    return this.myForm.get("emailAddress");
  }
  public get password() {
    return this.myForm.get("password");
  }
login()
{
  this.submitted = true;
  if (this.myForm.valid) {
    this.username = this.emailAddress.value;
    this.passwordvalue = this.password.value
    this.userService.userAuthentication(this.username, this.passwordvalue).subscribe((data: any) => {
      localStorage.setItem('userToken', data.access_token);
      localStorage.setItem('userRoles', data.role)
      if (this.userService.roleMatch(['Manager'])) {
        this.router.navigate(['employeedashboard/welcome']);
      }
      else if (this.userService.roleMatch(['Employee'])) {
        this.router.navigate(['/customerdashboard/welcomecustomer']);
      }
      else if (this.userService.roleMatch(['Customer'])) {
        this.router.navigate(['Customerheader/userDashboard']);
      }

        //if(data.role=="Employee")


    },
      (err: HttpErrorResponse) => {
        this.isLoginError = true;
        if (err.status === 400) {
          this.wrongCredentials = true;

        }
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
