import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerComponent } from './customer/customer.component';
import { CustomerDashboardComponent } from './customer/customer-dashboard/customer-dashboard.component';
import { CustomerAccountComponent } from './customer/customer-account/customer-account.component';
import { FundTransferComponent } from './Transaction/transaction-page/fund-transfer/fund-transfer.component';
import { PayBillsComponent } from './Transaction/transaction-page/pay-bills/pay-bills.component';
import { MyTransactionComponent } from './Transaction/transaction-page/my-transaction/my-transaction.component';
import { TransactionPageComponent } from './Transaction/transaction-page/transaction-page.component';
import { LoginComponent } from './Transaction/login/login.component';
import { ManagerDashboardComponent } from './manager-dashboard/manager-dashboard.component';
import { EmployeeListComponent } from './manager-dashboard/employee-list/employee-list.component';
import { EmployeeDetailsComponent } from './manager-dashboard/employee-details/employee-details.component';
import { EmployeeEditComponent } from './manager-dashboard/employee-edit/employee-edit.component';
import { WelcomeManagerComponent } from './manager-dashboard/welcome-manager/welcome-manager.component';
import { AuthGuard } from './auth/auth.guard';
import { CustomerDetailComponent } from './employee-dashboard/customer-detail/customer-detail.component';
import { CustomerListComponent } from './employee-dashboard/customer-list/customer-list.component';
import { CustomerEditComponent } from './employee-dashboard/customer-edit/customer-edit.component';
import { WelcomeEmployeeComponent } from './employee-dashboard/welcome-employee/welcome-employee.component';
import { EmployeeDashboardComponent } from './employee-dashboard/employee-dashboard.component';
import { CustomerEditGuard } from './employee-dashboard/customer-edit/customer-edit.guard';
import { CustomerHeaderComponent } from './customer-header/customer-header.component';


const routes: Routes = [
  
  {
    path:'Customerheader',component:CustomerHeaderComponent,
    children: [
      { path: 'customer/:id', component: CustomerComponent },
      { path: 'userDashboard', component: CustomerDashboardComponent },
      { path: 'customerAccount', component: CustomerAccountComponent },
      {
        path: 'transaction-page', component: TransactionPageComponent, children: [
          { path: 'fund-transfer', component: FundTransferComponent },
          { path: 'pay-bills', component: PayBillsComponent },
          { path: 'my-transaction', component: MyTransactionComponent }
        ]
      }
    ]
  },






  { path: 'login', component: LoginComponent },
  {
    path: 'employeedashboard', component: ManagerDashboardComponent, canActivate: [AuthGuard],
    children: [
      { path: 'employees', component: EmployeeListComponent, canActivate:[AuthGuard] },
      { path: 'welcome', component: WelcomeManagerComponent, canActivate: [AuthGuard]},
      { path: 'employees/:id', component: EmployeeDetailsComponent, canActivate: [AuthGuard] },
      { path: 'employees/:id/edit', component: EmployeeEditComponent, canActivate: [AuthGuard]}
    ],
  },
  {
    path: 'customerdashboard', component: EmployeeDashboardComponent, canActivate: [AuthGuard],
    children: [{
      path: 'customers/:id', component: CustomerDetailComponent, canActivate: [AuthGuard]
    },
      { path: 'customers', component: CustomerListComponent, canActivate: [AuthGuard] },
      { path: 'customers/:id/edit', component: CustomerEditComponent, canActivate: [AuthGuard], canDeactivate: [CustomerEditGuard] },
      { path: 'welcomecustomer', component: WelcomeEmployeeComponent, canActivate: [AuthGuard] }
    ]
  },


  { path: '', component: LoginComponent },
  { path: '**', component: LoginComponent }

];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
