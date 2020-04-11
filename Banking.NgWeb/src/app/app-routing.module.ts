import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerComponent } from './customer/customer.component';
import { CustomerDashboardComponent } from './customer/customer-dashboard/customer-dashboard.component';
import { CustomerAccountComponent } from './customer/customer-account/customer-account.component';
import { CustomerRegisteredDetailsComponent } from './customer/customer-registered-details/customer-registered-details.component';
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

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: '**', redirectTo: 'login', pathMatch: 'full' },
  { path: 'customer', component: CustomerComponent },
  { path: 'customerDashboard', component: CustomerDashboardComponent },
  { path: 'customerAccount', component: CustomerAccountComponent },
  {
    path: 'transaction-page', component: TransactionPageComponent, children: [
      { path: 'fund-transfer', component: FundTransferComponent },
      { path: 'pay-bills', component: PayBillsComponent },
      { path: 'my-transaction', component: MyTransactionComponent }
    ]
  },
  { path: 'login', component: LoginComponent },
  {
    path: 'employeedashboard', component: ManagerDashboardComponent,
    children: [
      { path: 'employees', component: EmployeeListComponent },
      { path: 'welcome', component: WelcomeManagerComponent },
      { path: 'employees/:id', component: EmployeeDetailsComponent },
      { path: 'employees/:id/edit', component: EmployeeEditComponent}
    ],
  },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
