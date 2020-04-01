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

@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    CustomerAccountComponent,
    CustomerRegisteredDetailsComponent,
    CustomerDashboardComponent,
    AccountTypesComponent,
    LoginComponent
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
  providers: [AccountService],
  bootstrap: [AppComponent]
})
export class AppModule { }
