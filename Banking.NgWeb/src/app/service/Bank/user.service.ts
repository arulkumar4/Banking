import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError, of } from 'rxjs'
import { catchError, tap, map } from 'rxjs/operators';
import { isDateValid } from 'ngx-bootstrap/chronos/public_api';
import { Login } from '../../model/login';


@Injectable()
export class UserService {
  login: Login
  private rooturl = 'https://localhost:44395';
  constructor(private http: HttpClient) {
  }
  //var reqHeader=new HttpHeaders({'No-Auth':'True'});

  userAuthentication(username: string, password: string) {

    var data = "username=" + username + "&password=" + password + "&grant_type=password";
    console.log(data);
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded', 'No-Auth': 'True' });
    var added: boolean = false;
    return this.http.post(this.rooturl + '/token', data, { headers: reqHeader })
  }
  getUserClaimsEmployee() {
    return this.http.get(this.rooturl + '/api/GetUserClaims');
  }
  getUserClaimsCustomer() {
    debugger;
    return this.http.get(this.rooturl + '/api/GetUserClaims/customer');
  }
  getUserClaimsManager() {
    return this.http.get(this.rooturl + '/api/GetUserClaims/manager');
  }

  getAllRoles() {
    var reqHeader = new HttpHeaders({ 'No-Auth': 'True' });
    return this.http.get(this.rooturl + '/api/GetAllRoles', { headers: reqHeader });
  }
  roleMatch(allowRoles): boolean {
    var isMatch = false;
    var userRoles: string[] = JSON.parse(localStorage.getItem('userRoles'));
    allowRoles.forEach(element => {
      if (userRoles.indexOf(element) > -1) {
        isMatch = true;
        return false;
      }
    });
    return isMatch;
  }
}
