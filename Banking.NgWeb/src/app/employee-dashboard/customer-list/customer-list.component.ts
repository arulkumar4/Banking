import { Component, OnInit } from '@angular/core';

import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';
import { ICustomer } from '../../model/Bank/customer';
import { CustomerService } from '../../service/Bank/customer.service';

@Component({
  selector: 'pm-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
  customers: ICustomer[];
  _listFilter: string;
  errorMessage = '';
  pageTitle: string = 'Employee List';
  filterCustomers: ICustomer[];
  get listFilter(): string {
    return this._listFilter;
  }

  set listFilter(value: string) {
    this._listFilter = value;
    this.filterCustomers = this.listFilter ? this.performFilter(this.listFilter) : this.customers
  }


  constructor(private customerService: CustomerService,
    private router: Router, private SpinnerService: NgxSpinnerService) { }

  performFilter(filterBy: string): ICustomer[] {
    filterBy = filterBy.toLowerCase();
    return this.customers.filter((customer: ICustomer) =>
      customer.FullName.toLocaleLowerCase().indexOf(filterBy) !== -1);
  }

  ngOnInit(): void {
    this.SpinnerService.show();
    this.customerService.getCustomers().subscribe({
      next: customers => {
        this.customers = customers;
        this.filterCustomers = this.customers;
        //console.log(this.filterEmployees)
        this.SpinnerService.hide();
        //   setTimeout(() => {
        //     /** spinner ends after 5 seconds */
        //     this.SpinnerService.hide();
        // }, 3000);  
      },
      error: err => this.errorMessage = err
    })
  }
  //   convertText(value:ICustomer)
  // {
  //   console.log(value.CustomerId);
  //    this.router.navigateByUrl('customers/'+value.CustomerId+'/edit');
  // }
}
