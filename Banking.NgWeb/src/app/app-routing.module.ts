import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerComponent } from './customer/customer.component';
import { CustomerDashboardComponent } from './customer/customer-dashboard/customer-dashboard.component';
import { CustomerRegisteredDetailsComponent } from './customer/customer-registered-details/customer-registered-details.component';
import { LoginComponent } from './login/login.component';


const routes: Routes = [
  {path:'adminhomepage',component:CustomerComponent,children:
  [
  {path:'',redirectTo:'home',pathMatch:'full'},  
  // {path:'home',component:HomeComponet},
  {path:'customer_Register',component:CustomerRegisteredDetailsComponent},
  {path:'customer_Dashboard',component:CustomerDashboardComponent}
  ]
  },
  {path:'login', component:LoginComponent}
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
