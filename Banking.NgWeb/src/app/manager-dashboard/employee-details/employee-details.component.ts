import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IEmployee } from '../../model/Bank/employee';
import { EmployeeService } from '../../service/Bank/employee.service';


@Component({
  selector: 'pm-employee-detail',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css']
})
export class EmployeeDetailsComponent implements OnInit {
  pageTitle: string = 'Employee Detail';
  employee: IEmployee;
  errorMessage = '';
  constructor(private route: ActivatedRoute,
    private router: Router,
    private employeeService: EmployeeService) {
  }

  ngOnInit() {
    const param = this.route.snapshot.paramMap.get('id');
    if (param) {
      const id = +param;
      this.getEmployee(id);
    }
  }
  getEmployee(id: number) {
    this.employeeService.getEmployee(id).subscribe({
      next: employee => {
      this.employee = employee;;
      },
      error: err => this.errorMessage = err
    });
  }
  onBack(): void {
    this.router.navigate(['/employeedashboard/employees']);
  }

}
