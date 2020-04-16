import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError, of } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { IEmployee } from '../../model/Bank/employee';


@Injectable()
export class EmployeeService {



  employees: any;
  private EmployeesUrl = 'https://localhost:44395/api/GetEmployee';
  private UpdateEmployeeUrl = 'https://localhost:44395/api/UpdateEmployee'
  private AddEmployeeUrl = 'https://localhost:44395/api/AddEmployee'
  private GetEmployeeById = 'https://localhost:44395/api/GetEmployee'
  private DeleteEmployeeById = 'https://localhost:44395/api/DeleteEmployee'
  private GetEmployeeKeywordUrl = 'https://localhost:44395/api/GetEmployeebykeyword'
  constructor(private http: HttpClient) {
    this.employees = [];

  }
  createEmployee(employee: IEmployee): Observable<IEmployee> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    employee.Id = null;
    employee.ManagerId = 1014;
    console.log(employee);
    return this.http.post<IEmployee>(this.AddEmployeeUrl, employee, { headers })
      .pipe(
        tap(data => console.log('createEmployee: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
    return;
  }

  getEmployees(): Observable<IEmployee[]> {
    return this.http.get<IEmployee[]>(this.EmployeesUrl)
      .pipe(
        tap(data => JSON.stringify(data)),
        catchError(this.handleError)
      );
  }
  getEmployee(id: number): Observable<IEmployee | undefined> {
    if (id === 0) {
      return of(this.initializeEmployee());
    }
    return this.getEmployees()
      .pipe(
        map((employees: IEmployee[]) => employees.find(e => e.Id === id))
      );
  }
  getEmployeeByKeyword(keyword: string): Observable<IEmployee[]> {
    const url = `${this.GetEmployeeKeywordUrl}/${keyword}`;
    return this.http.get<IEmployee[]>(url)
      .pipe(
        tap(data => console.log('getProduct: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }


  getEmployeeAPI(id: number): Observable<IEmployee> {
    if (id === 0) {
      return of(this.initializeEmployee());
    }
    const url = `${this.EmployeesUrl}/${id}`;
    return this.http.get<IEmployee>(url)
      .pipe(
        tap(data => console.log('getEmployee: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  updateEmployee(employee: IEmployee): Observable<IEmployee> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.UpdateEmployeeUrl}`;
    return this.http.put<IEmployee>(url, employee, { headers })
      .pipe(
        tap(() => console.log('updateProduct: ' + employee.Id)),
        // Return the product on an update
        map(() => employee),
        catchError(this.handleError)
      );
  }
  deleteEmployee(id: number): Observable<{}> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.DeleteEmployeeById}/${id}`;
    return this.http.delete<IEmployee>(url, { headers })
      .pipe(
        tap(data => console.log('deleteProduct: ' + id)),
        catchError(this.handleError)
      );
  }

  private initializeEmployee(): IEmployee {
    return {
      Id: 0,
      FirstName: null,
      LastName: null,
      ContactNumber: null,
      Mail: null,
      DOB: null,
      ManagerId: null,
      FullName: null,
      Password: null,
      Role: 'Employee'
    };
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
