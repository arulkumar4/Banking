import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../service/Bank/user.service';


@Component({
  selector: 'app-customer-dashboard',
  templateUrl: './customer-dashboard.component.html',
  styleUrls: ['./customer-dashboard.component.css']
})
export class CustomerDashboardComponent implements OnInit {
  userClaims: any;
  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getUserClaimsCustomer().subscribe((data: any) => {
      this.userClaims = data;
      console.log(this.userClaims);
    })}

}
