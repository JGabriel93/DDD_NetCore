import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentaccountDepositComponent } from './currentaccount-deposit.component';

describe('CurrentaccountDepositComponent', () => {
  let component: CurrentaccountDepositComponent;
  let fixture: ComponentFixture<CurrentaccountDepositComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CurrentaccountDepositComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrentaccountDepositComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
