import { Component, OnInit, ElementRef, ViewChildren, AfterViewInit } from '@angular/core';
import { Subscription, Observable, fromEvent, merge } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControlName, ValidatorFn, AbstractControl } from '@angular/forms';
import { debounceTime } from 'rxjs/operators';
import { GenericValidator } from '../../shared/generic-validator';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { ICustomer } from '../../model/Bank/customer';
import { CustomerService } from '../../service/Bank/customer.service';


@Component({
  selector: 'pm-customer-edit',
  templateUrl: './customer-edit.component.html',
  styleUrls: ['./customer-edit.component.css']
})
export class CustomerEditComponent implements OnInit {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];
  private sub: Subscription;
  customer: ICustomer;
  datepickerConfig: Partial<BsDatepickerConfig>;
  errorMessage: string;
  value: any
  onChange: (value: any) => void;
  customerForm: FormGroup;
  status: boolean = false;
  pageTitle: string = 'Edit Customer'
  displayMessage: { [key: string]: string } = {};
  private validationMessages: { [key: string]: { [key: string]: string } };
  private genericValidator: GenericValidator;
  isButtonVisible: boolean = true;
  isfeildVisible: boolean = true;
  constructor(private route: ActivatedRoute,
    private customerService: CustomerService,
    private fb: FormBuilder,
    private router: Router) {
    this.datepickerConfig = Object.assign({},
      {
        containerClass: 'theme-dark-blue',
        showWeekNumbers: false,
        maxDate: new Date(),
        dateInputFormat: 'DD/MM/YYYY'
      });


    this.validationMessages = {
      FirstName: {
        required: 'First Name is required',
        minlength: 'First Name must be at least three characters.',
        maxlength: 'First Name cannot exceed 50 characters.'
      },
      LastName: {
        required: 'Last Name is required',
        minlength: 'Last Name must be at least three characters.',
        maxlength: 'Last Name cannot exceed 50 characters.'
      },
      Mail: {
        required: 'Mail is required',
        pattern: 'Please enter valid Mail'
      },
      ContactNumber: {
        required: 'Contact number is required',
        pattern: 'please enter valid phoneNumber '
        //maxlength: 'phoneNumber cannot exceed 10 digits.'
      },
      Dob: {
        required: 'Date is required'
      },
      Address: {
        required: 'Address is required'
      },
      Password: {
        required: 'Password is required'
      },
      Balance: {
        required: 'This feild is required',
        min: 'Minimum balanace 1000',
        max: 'Maximum Amount 10,000'

      },
      Role: {
        required: 'This feild is required'
      }
    };
    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  ngOnInit() {
    this.customerForm = this.fb.group({

      FirstName: ['', [Validators.required,
      Validators.minLength(3),
      Validators.maxLength(50)]],
      LastName: ['', [Validators.required,
      Validators.minLength(3),
      Validators.maxLength(50)]],
      Mail: [null, [Validators.required, Validators.pattern(/^(\d{10}|\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3}))$/)],
      ],
      ContactNumber: ['', [Validators.required, Validators.pattern(/^(\d{10}|\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3}))$/)]],
      Dob: ['', Validators.required],
      Address: ['', Validators.required],
      Gender: 'male',
      Password: ['', Validators.required],
      AccountType: 'Savings',
      Balance: ['', [Validators.required, Validators.min(5000), Validators.max(20000)]],
      Role: ['Customer', Validators.required]


    })

    this.sub = this.route.paramMap.subscribe(
      params => {
        console.log(params);

        const id = +params.get('id');
        this.getCustomer(id);
      })

  }
  getCustomer(id: number): void {
    this.customerService.getCustomer(id).subscribe({
      next: (customer: ICustomer) => this.displayCustomer(customer),
      error: err => this.errorMessage = err
    });
  }


  displayCustomer(customer: ICustomer): void {
    if (this.customerForm) {
      this.customerForm.reset();
    }
    customer.Role = 'Customer';
    this.customer = customer;
    if (this.customer.CustomerId === 0) {
      this.isButtonVisible = false;
      this.pageTitle = "Add customer";
    } else {
      //this.isfeildVisible=false;
      this.pageTitle = `Edit customer : ${this.customer.FullName}`;
    }
    this.customerForm.patchValue({
      FirstName: this.customer.FirstName,
      LastName: this.customer.LastName,
      Mail: this.customer.Mail,
      ContactNumber: this.customer.ContactNumber,
      Dob: this.customer.Dob,
      Address: this.customer.Address,
      Gender: this.customer.Gender,
      Password: this.customer.Password,
      AccountType: this.customer.AccountType,
      Balance: this.customer.Balance,
      Role: 'Customer'
    });

  }


  saveCustomer(): void {
    if (this.customerForm.valid) {
      if (this.customerForm.dirty) {

        const c = { ...this.customer, ...this.customerForm.value };
        console.log(c);
        if (this.value != 'Invalid Date') {
          c.Dob = this.value;
        }
        if (c.CustomerId == 0) {
          console.log(c);
          this.customerService.createCustomer(c)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.errorMessage = err
            });
        } else {
          console.log(c);
          this.customerService.updateCustomer(c)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.errorMessage = err
            });
        }
      } else {
        this.onSaveComplete();
      }
    } else {
      this.errorMessage = 'Please correct the validation errors.';
    }

  }
  onSaveComplete() {
    this.customerForm.reset();
    localStorage.removeItem("employeeid");
    this.router.navigate(['/customerdashboard/customers']);
  }


  ngAfterViewInit(): void {

    // Watch for the blur event from any input element on the form.
    // This is required because the valueChanges does not provide notification on blur
    const controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));
    // Merge the blur event observable with the valueChanges observable
    // so we only need to subscribe once.
    merge(this.customerForm.valueChanges, ...controlBlurs).pipe(

      debounceTime(1000)
    ).subscribe(value => {
      console.log(this.customerForm);
      this.displayMessage = this.genericValidator.processMessages(this.customerForm)
    });

  }
  onValueChange(val) {
    setTimeout(() => {
      this.value = val;
      console.log(this.value)
      this.status = false;
      if (val instanceof Date) {
        this.value = new Date(val.getTime() - val.getTimezoneOffset() * 60 * 1000);
      } else {
        console.log(this.value);
      }
    });
  }
}
