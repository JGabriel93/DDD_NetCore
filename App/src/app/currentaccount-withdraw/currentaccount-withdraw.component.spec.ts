import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentaccountWithdrawComponent } from './currentaccount-withdraw.component';

describe('CurrentaccountWithdrawComponent', () => {
  let component: CurrentaccountWithdrawComponent;
  let fixture: ComponentFixture<CurrentaccountWithdrawComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CurrentaccountWithdrawComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrentaccountWithdrawComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
