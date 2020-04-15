import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError, of } from 'rxjs'
import { catchError, tap, map } from 'rxjs/operators';
import { UserService } from './user.service';
import { ICustomer } from '../../model/Bank/customer';


@Injectable()
export class CustomerService {

  private CustomerUrl = 'https://localhost:44395/api/Account/GetAllCustomerAccounts';
  private Addcustomerurl = 'https://localhost:44395/api/Customer/AddNewCustomer';
  private UpdatecustomerUrl = 'https://localhost:44395/api/Account/UpdateCustomerByEmployee';
  employeeid: string;

  constructor(private http: HttpClient, private userService: UserService) {


  }
  createCustomer(customer: ICustomer): Observable<ICustomer> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    this.userService.getUserClaimsEmployee().subscribe((data: any) => {
      console.log(data);
      localStorage.setItem('employeeid', data.Id);
    })
    customer.CustomerId = null;
    this.employeeid = localStorage.getItem('employeeid');
    console.log(this.employeeid)
    console.log(customer);
    return this.http.post<ICustomer>(this.Addcustomerurl + "?empid="+ this.employeeid, customer, { headers })
      .pipe(
        tap(data => JSON.stringify(data)),
        catchError(this.handleError)
      );
  }

  updateCustomer(customer: ICustomer): Observable<ICustomer> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.UpdatecustomerUrl}`;
    return this.http.put<ICustomer>(url, customer, { headers })
      .pipe(
        tap(() => console.log('updateProduct: ' + customer.CustomerId)),
        // Return the product on an update
        map(() => customer),
        catchError(this.handleError)
      );
  }

  getCustomers(): Observable<ICustomer[]> {
    return this.http.get<ICustomer[]>(this.CustomerUrl)
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        catchError(this.handleError)
      );
  }
  getCustomer(id: number): Observable<ICustomer | undefined> {
    if (id === 0) {
      return of(this.initializeCustomer());
    }
    return this.getCustomers()
      .pipe(
        map((customers: ICustomer[]) => customers.find(c => c.CustomerId === id))
      );
  }

  private initializeCustomer(): ICustomer {
    return {
      CustomerId: 0,
      FirstName: null,
      LastName: null,
      FullName: null,
      ContactNumber: null,
      Mail: null,
      Gender: 'Female',
      Address: null,
      Number: null,
      Dob: null,
      AccountType: 'Savings',
      Balance: null,
      EmployeeId: null,
      Password: null,
      AccountTypeId: null,
      Status: null,
      OpenDate: null,
      Role: 'Customer'

    };
  }
  private getid(): any {
    return this.userService.getUserClaimsEmployee().subscribe((data) => {

    });

  }

  private handleError(err) {
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
    }
    console.error(err);
    return throwError(errorMessage);
  }
}
