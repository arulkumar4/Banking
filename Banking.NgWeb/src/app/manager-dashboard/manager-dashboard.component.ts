import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-manager-dashboard',
  templateUrl: './manager-dashboard.component.html',
  styleUrls: ['./manager-dashboard.component.css']
})
export class ManagerDashboardComponent implements OnInit {
  pageTitle = 'DBG Bank Employee';
  userClaims: any;
  constructor(private router: Router) { }

  ngOnInit() {
  }
  Logout() {
    localStorage.removeItem('userToken');
    this.router.navigate(['/login']);

  }

}
