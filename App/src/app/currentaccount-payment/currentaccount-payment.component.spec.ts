import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentaccountPaymentComponent } from './currentaccount-payment.component';

describe('CurrentaccountPaymentComponent', () => {
  let component: CurrentaccountPaymentComponent;
  let fixture: ComponentFixture<CurrentaccountPaymentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CurrentaccountPaymentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrentaccountPaymentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
