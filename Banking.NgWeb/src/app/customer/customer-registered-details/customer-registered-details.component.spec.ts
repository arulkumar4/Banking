import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerRegisteredDetailsComponent } from './customer-registered-details.component';

describe('CustomerRegisteredDetailsComponent', () => {
  let component: CustomerRegisteredDetailsComponent;
  let fixture: ComponentFixture<CustomerRegisteredDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CustomerRegisteredDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomerRegisteredDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
