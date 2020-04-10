import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WelcomeManagerComponent } from './welcome-manager.component';

describe('WelcomeManagerComponent', () => {
  let component: WelcomeManagerComponent;
  let fixture: ComponentFixture<WelcomeManagerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WelcomeManagerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WelcomeManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
