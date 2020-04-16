import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ICustomer } from '../../model/Bank/customer';
import { CustomerService } from '../../service/Bank/customer.service';

@Component({
  selector: 'pm-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.css']
})
export class CustomerDetailComponent implements OnInit {
  pageTitle: string = 'Customer Detail';
  customer: ICustomer;
  errorMessage = '';

  constructor(private route: ActivatedRoute,
    private router: Router,
    private customerService: CustomerService) { }

  ngOnInit() {
    const param = this.route.snapshot.paramMap.get('id');
    if (param) {
      const id = +param;
      this.getCustomer(id);
    }
  }
  getCustomer(id: number) {
    this.customerService.getCustomer(id).subscribe({
      next: customer => {
        this.customer = customer;;
        console.log(this.customer);
      },
      error: err => this.errorMessage = err
    });
  }

  onBack(): void {
    this.router.navigate(['customerdashboard/customers']);
  }

}
