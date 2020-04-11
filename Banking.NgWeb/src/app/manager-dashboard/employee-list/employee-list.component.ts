import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from "ngx-spinner";
import { IEmployee } from '../../model/Bank/employee';
import { EmployeeService } from '../../service/Bank/employee.service';


@Component({
  selector: 'pm-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  filterEmployees: IEmployee[];
  employees: IEmployee[] = [];
  _listFilter: string;
  pageTitle: string = 'Employee List';
  errorMessage = '';
  encrypted: string;
  dycrpted: string;
  tokenFromUI: string = "0123456789123456";
  // private employeeUrl = 'api/products'

  get listFilter(): string {
    return this._listFilter;
  }

  set listFilter(value: string) {
    this._listFilter = value;
    this.filterEmployees = this.listFilter ? this.performFilter(this.listFilter) : this.employees
  }


  constructor(private employeeService: EmployeeService,
    private router: Router, private SpinnerService: NgxSpinnerService) {

  }



  performFilter(filterBy: string): IEmployee[] {
    filterBy = filterBy.toLowerCase();
    // return this.employees.filter((employee: IEmployee)=>
    // employee.FullName.toLocaleLowerCase().indexOf(filterBy) !== -1);
    this.employeeService.getEmployeeByKeyword(filterBy).subscribe({
      next: employees => {
        console.log(this.employees)
        this.filterEmployees = employees;

      }

    })
    return this.employees;
  }


  ngOnInit(): void {
    this.SpinnerService.show();
    this.employeeService.getEmployees().subscribe({
      next: employees => {
        this.employees = employees;
        this.filterEmployees = this.employees;
        console.log(this.filterEmployees)
        this.SpinnerService.hide();
        //   setTimeout(() => {
        //     /** spinner ends after 5 seconds */
        //     this.SpinnerService.hide();
        // }, 3000);  
      },
      error: err => this.errorMessage = err
    })
  }

  convertText(value: IEmployee) {
    // let route = this.router.config.find(r => r.path === 'employees/:id/edit');
    //  route.data=value;

    // console.log(value);
    // let _key = CryptoJS.enc.Utf8.parse(this.tokenFromUI);
    // let _iv = CryptoJS.enc.Utf8.parse(this.tokenFromUI);
    // let encrypted = CryptoJS.AES.encrypt(
    //   JSON.stringify(value.Id), _key, {
    //     keySize: 10,
    //     iv: _iv,
    //     mode: CryptoJS.mode.CTRGladman,
    //     padding: CryptoJS.pad.Iso10126
    //   });
    //   this.encrypted=encrypted.toString();
    //   console.log(encodeURIComponent(this.encrypted));



    //   let dycrypted = CryptoJS.AES.decrypt(
    //     JSON.stringify(encrypted) , _key, {
    //       keySize: 10,
    //       iv: _iv,
    //       mode: CryptoJS.mode.CTRGladman,
    //       padding: CryptoJS.pad.Iso10126
    //     });
    //     console.log(dycrypted.toString());


    //value.Id=this.encrypted;
    //[routerLink]="['/employees',employee.Id,'edit']"
    //this.router.navigateByUrl(`${'/employees'}/${this.encrypted}/${'/edit'}`)
    this.router.navigateByUrl('employeedashboard/employees/' + value.Id + '/edit');
  }


}
