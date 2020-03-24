import { Component, OnInit ,Input} from '@angular/core';
import { AccountModel } from 'src/app/model/account.model';

@Component({
  selector: 'app-customer-registered-details',
  templateUrl: './customer-registered-details.component.html',
  styleUrls: ['./customer-registered-details.component.css']
})
export class CustomerRegisteredDetailsComponent implements OnInit {

  @Input() newCustomer:AccountModel

  constructor() { }

  ngOnInit() {
  }

}
