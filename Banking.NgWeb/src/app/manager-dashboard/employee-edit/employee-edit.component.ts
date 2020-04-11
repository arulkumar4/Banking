import { Component, OnInit, ElementRef, ViewChildren, AfterViewInit } from '@angular/core';
import { Subscription, Observable, fromEvent, merge } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';


import { FormBuilder, FormGroup, Validators, FormControlName } from '@angular/forms';
import { debounceTime } from 'rxjs/operators';
import { GenericValidator } from '../../shared/generic-validator';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { IEmployee } from '../../model/Bank/employee';
import { EmployeeService } from '../../service/Bank/employee.service';



@Component({
  selector: 'pm-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.css']
})
export class EmployeeEditComponent implements OnInit {
@ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];
  private sub: Subscription;
  employee: IEmployee;
datepickerConfig:Partial<BsDatepickerConfig>;
errorMessage:string;
value:any
onChange: (value: any) => void; 
employeeForm:FormGroup;
status:boolean=false;
pageTitle:string='Edit product'
displayMessage: { [key: string]: string } = {};
private validationMessages: { [key: string]: { [key: string]: string } };
private genericValidator: GenericValidator;
 isButtonVisible:boolean=true;
 isfeildVisible:boolean=true;

  constructor(private route: ActivatedRoute,
    private employeeService: EmployeeService,
              private fb:FormBuilder,
              private router:Router) { 
                
                this.datepickerConfig=Object.assign({},
                  {
                    containerClass:'theme-dark-blue',
                    showWeekNumbers:false,
                    maxDate: new Date(),
                    dateInputFormat: 'DD/MM/YYYY'
                  });
                this.validationMessages={
                  FirstName:{
                    required:'First Name is required',
                    minlength: 'First Name must be at least three characters.',
                    maxlength: 'First Name cannot exceed 50 characters.'  
                  },
                  LastName:{
                    required:'Last Name is required',
                    minlength: 'Last Name must be at least three characters.',
                    maxlength: 'Last Name cannot exceed 50 characters.'  
                  },
                  Mail:{
                    required:'Mail is required',
                    pattern:'Please enter valid Mail'
                  },
                  ContactNumber:{
                    required:'Contact number is required',
                    pattern:'please enter valid phoneNumber '
                    //maxlength: 'phoneNumber cannot exceed 10 digits.'
                  },
                  DOB:{
                    required:'Date is required'
                  },
                  Password:{
                    required:'Password is required',
                    minlength:'Minimum length 6'
                  },
                  Role:{
                    required:'Role required'
                  }
                  };
                  this.genericValidator= new GenericValidator(this.validationMessages);
              }
              

  ngOnInit():void {
    this.employeeForm=this.fb.group({
      FirstName:['',[Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(50)]],
                    LastName:['',[Validators.required,
                      Validators.minLength(3),
                      Validators.maxLength(50)]],
                      Mail: [null, [Validators.required, Validators.pattern(/^(\d{10}|\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3}))$/)],
                    ],
                      ContactNumber:['',[Validators.required,Validators.pattern(/^(\d{10}|\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3}))$/)]],
                      Password:['',[Validators.required,Validators.minLength(6)]],
                      DOB:['',[Validators.required]],
                      Role:['',Validators.required]
                      


    })
    
    this.sub=this.route.paramMap.subscribe(
      params =>{
        console.log(params);
        
        const id = +params.get('id');
        this.getEmployee(id);
      })
  }
  getEmployee(id: number):void {
    this.employeeService.getEmployee(id).subscribe({
      next:(employee:IEmployee)=>this.displayEmployee(employee),
      error:err =>this.errorMessage=err
    });
  }

  displayEmployee(employee: IEmployee): void {
    if(this.employeeForm){
      this.employeeForm.reset();
    }
    this.employee=employee;
    if(this.employee.Id===0){
      this.isButtonVisible=false;
      this.pageTitle="Add Employee";
    }else{
      
      this.pageTitle=`Edit Employee:${this.employee.FullName}`;
    }
    this.employeeForm.patchValue({
      FirstName:this.employee.FirstName,
      LastName:this.employee.LastName,
      Mail:this.employee.Mail,
      ContactNumber:this.employee.ContactNumber,
      DOB:this.employee.DOB,
      Password:this.employee.Password,
      Role:'Employee'
      
    });

  }
  deleteEmployee(): void {
    if (this.employee.Id === 0) {
      // Don't delete, it was never saved.
      this.onSaveComplete();
    } else {
      if (confirm(`Really delete the Employee: ${this.employee.FullName}?`)) {
        this.employeeService.deleteEmployee(this.employee.Id)
          .subscribe({
            next: () => this.onSaveComplete(),
            error: err => this.errorMessage = err
          });
      }
    }
  }





  saveEmployee():void{
    if (this.employeeForm.valid) {
      if (this.employeeForm.dirty) {
        
        const e = { ...this.employee, ...this.employeeForm.value };
        console.log(this.status)
        if(this.value!='Invalid Date')
        {
          e.DOB=this.value;
        }
        console.log(e);
        if (e.Id=== 0) {
          console.log(e);
           this.employeeService.createEmployee(e)
            .subscribe({
               next: () => this.onSaveComplete(),
               error: err => this.errorMessage = err
             });
        } else {
          this.employeeService.updateEmployee(e)
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
    this.employeeForm.reset();
    this.router.navigate(['/employeedashboard/employees']);
  }

  ngAfterViewInit(): void {
    // Watch for the blur event from any input element on the form.
    // This is required because the valueChanges does not provide notification on blur
    const controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));
    // Merge the blur event observable with the valueChanges observable
    // so we only need to subscribe once.
    merge(this.employeeForm.valueChanges, ...controlBlurs).pipe(
      debounceTime(1000)
    ).subscribe(value => {
      this.displayMessage = this.genericValidator.processMessages(this.employeeForm)
    });
  }
  onValueChange(val){
    setTimeout(()=>{
      this.value = val;
      console.log(this.value)
      this.status=false;
        if (val instanceof Date){
          this.value=new Date(val.getTime() - val.getTimezoneOffset() * 60 * 1000);
          
        } else {
          console.log(this.value);
          
        }
    });
  }
 


}
