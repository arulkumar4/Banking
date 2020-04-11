import { Component, OnInit } from '@angular/core';
import { UserService } from '../../service/Bank/user.service';

@Component({
  selector: 'app-welcome-manager',
  templateUrl: './welcome-manager.component.html',
  styleUrls: ['./welcome-manager.component.css']
})
export class WelcomeManagerComponent implements OnInit {
  public pageTitle = 'Welcome';
  userClaims: any;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getUserClaimsManager().subscribe((data: any) => {
      this.userClaims = data;
    })
      }

}
