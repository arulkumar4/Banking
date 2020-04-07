import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerComponent } from './customer/customer.component';
import { CustomerDashboardComponent } from './customer/customer-dashboard/customer-dashboard.component';
import { CustomerRegisteredDetailsComponent } from './customer/customer-registered-details/customer-registered-details.component';
import { TransactionPageComponent } from './Transaction/transaction-page/transaction-page.component';
import { FundTransferComponent } from './Transaction/transaction-page/fund-transfer/fund-transfer.component';
import { PayBillsComponent } from './Transaction/transaction-page/pay-bills/pay-bills.component';
import { MyTransactionComponent } from './Transaction/transaction-page/my-transaction/my-transaction.component';


const routes: Routes = [
  {path:'adminhomepage',component:CustomerComponent,children:
  [
      { path: '', redirectTo: 'home', pathMatch: 'full' },
  // {path:'home',component:HomeComponet},
  {path:'customer_Register',component:CustomerRegisteredDetailsComponent},
  {path:'customer_Dashboard',component:CustomerDashboardComponent}
  ]
  },
  {
    path: 'transaction-page', component: TransactionPageComponent, children: [
      { path: 'fund-transfer', component: FundTransferComponent },
      { path: 'pay-bills', component: PayBillsComponent },
      { path: 'my-transaction', component: MyTransactionComponent }
    ]
  }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
