import { Component, OnInit } from '@angular/core';
import { UserService } from '../../service/Bank/user.service';

@Component({
  selector: 'app-welcome-employee',
  templateUrl: './welcome-employee.component.html',
  styleUrls: ['./welcome-employee.component.css']
})
export class WelcomeEmployeeComponent implements OnInit {
  public pageTitle = 'Welcome';
  userClaims: any;
  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getUserClaimsEmployee().subscribe((data: any) => {
      this.userClaims = data;
    })
  }

}
