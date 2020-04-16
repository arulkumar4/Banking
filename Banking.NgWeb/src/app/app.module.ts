import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'; 
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
import { EmployeeListComponent } from './manager-dashboard/employee-list/employee-list.component';
import { EmployeeEditComponent } from './manager-dashboard/employee-edit/employee-edit.component';
import { EmployeeService } from './service/Bank/employee.service';
import { NgxSpinnerModule } from "ngx-spinner";
import { NgxPaginationModule } from 'ngx-pagination';
import { EmployeeDashboardComponent } from './employee-dashboard/employee-dashboard.component';
import { CustomerListComponent } from './employee-dashboard/customer-list/customer-list.component';
import { CustomerEditComponent } from './employee-dashboard/customer-edit/customer-edit.component';
import { EmployeeDetailsComponent } from './manager-dashboard/employee-details/employee-details.component';
import { CustomerDetailComponent } from './employee-dashboard/customer-detail/customer-detail.component';
import { WelcomeManagerComponent } from './manager-dashboard/welcome-manager/welcome-manager.component';
import { UserService } from './service/Bank/user.service';
import { AuthGuard } from './auth/auth.guard';
import { AuthInterceptor } from './auth/auth.interceptor';
import { MatTableModule, MatSortModule, MatFormFieldModule, MatInputModule, MatPaginatorModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';





@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    CustomerAccountComponent,
    CustomerRegisteredDetailsComponent,
    CustomerDashboardComponent,
    CustomerHeaderComponent,
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
    EmployeeEditComponent,
    EmployeeDashboardComponent,
    CustomerListComponent,
    CustomerEditComponent,
    CustomerDetailComponent,
    WelcomeManagerComponent,
    EmployeeDetailsComponent

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
    BrowserAnimationsModule,
    NgxSpinnerModule,
    //PaginationModule.forRoot()
    NgxPaginationModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    FlexLayoutModule,
    MatPaginatorModule
  ],
  providers: [AccountService, TransactionService, MyTransactionService, EmployeeService, UserService, AuthGuard, , {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
