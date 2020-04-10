import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http'; 
import { AngularMaterialModule } from '../app/angular-material.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerComponent } from './customer/customer.component';
import {CustomerRegisteredDetailsComponent} from './customer/customer-registered-details/customer-registered-details.component';
import { CustomerAccountComponent } from './customer/customer-account/customer-account.component';
import { AccountTypesComponent } from './account-types/account-types.component';
import { AccountService } from './service/account.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import{DatepickerModule,BsDatepickerModule} from 'ngx-bootstrap/datepicker';
import { CustomerDashboardComponent } from './customer/customer-dashboard/customer-dashboard.component';
import { LoginComponent } from './Transaction/login/login.component';
import { TransactionPageComponent } from './Transaction/transaction-page/transaction-page.component';
import { MyTransactionComponent } from './Transaction/transaction-page/my-transaction/my-transaction.component';
import { FundTransferComponent } from './Transaction/transaction-page/fund-transfer/fund-transfer.component';
import { PayBillsComponent } from './Transaction/transaction-page/pay-bills/pay-bills.component';
import { TransactionService } from './service/transaction/transaction.service';
import { MyTransactionService } from './service/transaction/myTransaction.service';
import { CustomerHeaderComponent } from './customer-header/customer-header.component';
import { ManagerDashboardComponent } from './manager-dashboard/manager-dashboard.component';
import { EmployeeDetailsComponent } from './manager-dashboard/employee-details/employee-details.component';
import { EmployeeListComponent } from './manager-dashboard/employee-list/employee-list.component';
import { EmployeeEditComponent } from './manager-dashboard/employee-edit/employee-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    CustomerAccountComponent,
    CustomerRegisteredDetailsComponent,
    CustomerDashboardComponent,
    AccountTypesComponent,
    LoginComponent,
    TransactionPageComponent,
    MyTransactionComponent,
    FundTransferComponent,
    PayBillsComponent,
    CustomerHeaderComponent,
    ManagerDashboardComponent,
    EmployeeDetailsComponent,
    EmployeeListComponent,
    EmployeeEditComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule,
    HttpClientModule,
    DatepickerModule,
    AngularMaterialModule,
    AppRoutingModule,
    BsDatepickerModule.forRoot(),
    DatepickerModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [AccountService,TransactionService,MyTransactionService],
  bootstrap: [AppComponent]
})
export class AppModule { }
