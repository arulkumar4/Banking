import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerComponent } from './customer/customer.component';
import { CustomerDashboardComponent } from './customer/customer-dashboard/customer-dashboard.component';
import { CustomerAccountComponent } from './customer/customer-account/customer-account.component';

const routes: Routes = [
  { path: '', redirectTo: 'customerDashboard', pathMatch: 'full' },
  { path: 'customer', component: CustomerComponent },
  { path: 'customerDashboard', component: CustomerDashboardComponent },
  { path: 'customerAccount', component: CustomerAccountComponent },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
