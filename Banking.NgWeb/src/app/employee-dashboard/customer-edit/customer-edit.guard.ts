import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { Observable } from 'rxjs';
import { CustomerEditComponent } from './customer-edit.component';



@Injectable({
  providedIn: 'root'
})
export class CustomerEditGuard implements CanDeactivate<CustomerEditComponent> {
  canDeactivate(component: CustomerEditComponent): Observable<boolean> | Promise<boolean> | boolean {
    console.log('deril');
    console.log(component.customerForm.dirty);
    if (component.customerForm.dirty) {
      console.log('deril');
      const productName = component.customerForm.get('FirstName').value || 'New Product';
      return confirm(`Navigate away and lose all changes to ${productName}?`);
    }
    return true;
  }
}
